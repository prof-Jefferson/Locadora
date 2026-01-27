using Microsoft.EntityFrameworkCore;
using Locadora.Infrastructure.Persistence.Entities;

namespace Locadora.Infrastructure.Persistence;

public sealed class LocadoraDbContext : DbContext
{
    public LocadoraDbContext(DbContextOptions<LocadoraDbContext> options) : base(options) {}

    public DbSet<ClienteEntity> Clientes => Set<ClienteEntity>();
    public DbSet<VeiculoEntity> Veiculos => Set<VeiculoEntity>();
    public DbSet<LocacaoEntity> Locacoes => Set<LocacaoEntity>();
    public DbSet<LocacaoExtraEntity> LocacaoExtras => Set<LocacaoExtraEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocadoraDbContext).Assembly);
    }
}
