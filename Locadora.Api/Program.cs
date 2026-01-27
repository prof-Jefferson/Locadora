using Locadora.Infrastructure.Persistence;
using Locadora.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Locadora.Application.Ports;
using Locadora.Application.UseCases;
using Locadora.Infrastructure.Repositories;


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

var app = builder.Build();

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


app.Run();
