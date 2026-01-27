using Locadora.Infrastructure.Persistence;
using Locadora.Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.Api;

public static class DevSeed
{
    public static async Task<WebApplication> SeedDevDataAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<LocadoraDbContext>();

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

        return app;
    }
}
