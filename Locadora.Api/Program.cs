using Locadora.Infrastructure.Persistence;
using Locadora.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cs = builder.Configuration.GetConnectionString("MariaDb");

builder.Services.AddDbContext<LocadoraDbContext>(opt =>
{
    opt.UseMySql(cs, ServerVersion.AutoDetect(cs));
});

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
app.MapGet("/veiculos", async (LocadoraDbContext db) =>
    await db.Veiculos
        .Where(v => v.Ativo && v.Disponivel)
        .OrderBy(v => v.Modelo)
        .ToListAsync()
);

app.Run();
