using Locadora.Infrastructure.Persistence;
using Locadora.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Locadora.Application.Ports;
using Locadora.Application.UseCases;
using Locadora.Infrastructure.Repositories;
using Locadora.Application.Events;
using Locadora.Infrastructure.Events;
using Locadora.Infrastructure.Events.Handlers;
using Locadora.Application.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cs = builder.Configuration.GetConnectionString("MariaDb");

builder.Services.AddDbContext<LocadoraDbContext>(opt =>
{
	opt.UseMySql(cs, ServerVersion.AutoDetect(cs));
});

builder.Services.AddScoped<IVeiculoRepository, VeiculoRepositoryEf>();
builder.Services.AddScoped<ListarVeiculosDisponiveisUseCase>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkEf>();

builder.Services.AddScoped<IClienteRepository, ClienteRepositoryEf>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepositoryEf>();
builder.Services.AddScoped<ILocacaoRepository, LocacaoRepositoryEf>();

builder.Services.AddSingleton<IEventBus, InMemoryEventBus>();
builder.Services.AddSingleton<PatioHandler>();

builder.Services.AddScoped<AbrirLocacaoUseCase>();

builder.Services.AddScoped<DevolverVeiculoUseCase>();

var app = builder.Build();

var bus = app.Services.GetRequiredService<IEventBus>();
var patio = app.Services.GetRequiredService<PatioHandler>();
bus.Subscribe<VeiculoLocado>(patio.OnVeiculoLocado);

app.UseSwagger();
app.UseSwaggerUI();

// 🔧 Seed mínimo (para provar que EF + MariaDB está gravando)
using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<LocadoraDbContext>();

	// Garante que o banco existe e está atualizado (em dev é ok)
	// Se preferir, remova e use só migrations no terminal.
	await db.Database.MigrateAsync();

	if (!await db.Veiculos.AnyAsync(v => v.Placa == "ABC1D23"))
	{
		db.Veiculos.Add(new VeiculoEntity
		{
			Id = Guid.NewGuid(),
			Placa = "ABC1D23",
			Modelo = "Uno",
			Ano = 2012,
			Categoria = "Carro",
			ValorDiaria = 99.90m,
			Ativo = true,
			Disponivel = true,
			CriadoEm = DateTime.UtcNow
		});

		await db.SaveChangesAsync();
	}
}

app.MapGet("/", () => "Locadora API online");

// Endpoint de teste: lista veículos disponíveis
app.MapGet("/veiculos", async (ListarVeiculosDisponiveisUseCase useCase, CancellationToken ct) =>
{
	var veiculos = await useCase.ExecuteAsync(ct);
	return Results.Ok(veiculos);
});

// Endpoint de locacoes: lista veículos locados
app.MapPost("/locacoes", async (AbrirLocacaoRequest req, AbrirLocacaoUseCase useCase, CancellationToken ct) =>
{
	var res = await useCase.ExecuteAsync(req, ct);
	return Results.Created($"/locacoes/{res.LocacaoId}", res);
});

// Endpoint de locacoes: devolver veículo
app.MapPost("/locacoes/{id:guid}/devolver", async (Guid id, DevolverLocacaoRequest req, DevolverVeiculoUseCase useCase, CancellationToken ct) =>
{
	var res = await useCase.ExecuteAsync(id, req, ct);
	return Results.Ok(res);
});

app.Run();