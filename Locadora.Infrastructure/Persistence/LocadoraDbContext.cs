using Locadora.Domain.Locacoes;
using Locadora.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using Locadora.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Locadora.Infrastructure.Persistence;

public sealed class LocadoraDbContext : DbContext
{
	public LocadoraDbContext(DbContextOptions<LocadoraDbContext> options) : base(options) {}

	public DbSet<ClienteEntity> Clientes => Set<ClienteEntity>();
	public DbSet<VeiculoEntity> Veiculos => Set<VeiculoEntity>();
	public DbSet<LocacaoEntity> Locacoes => Set<LocacaoEntity>();
	public DbSet<OrdemServicoEntity> OrdensServico => Set<OrdemServicoEntity>();
	public DbSet<LocacaoExtraEntity> LocacaoExtras => Set<LocacaoExtraEntity>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Locacao: StatusLocacao enum -> string
		var statusLocacaoConverter = new EnumToStringConverter<Locadora.Domain.Locacoes.StatusLocacao>();
		modelBuilder.Entity<LocacaoEntity>(entity =>
		{
			entity.Property(x => x.Status)
				.HasConversion(statusLocacaoConverter)
				.HasMaxLength(16)
				.IsRequired();
		});

		// OS: enums -> string (legível no banco)
		var tipoOsConverter = new EnumToStringConverter<TipoOrdemServico>();
		var statusOsConverter = new EnumToStringConverter<StatusOrdemServico>();

		modelBuilder.Entity<OrdemServicoEntity>(entity =>
		{
			entity.ToTable("ordens_servico");

			entity.HasKey(x => x.Id);

			entity.Property(x => x.Tipo)
				.HasConversion(tipoOsConverter)
				.HasMaxLength(16)
				.IsRequired();

			entity.Property(x => x.Status)
				.HasConversion(statusOsConverter)
				.HasMaxLength(16)
				.IsRequired();

			entity.Property(x => x.CriadoEmUtc).IsRequired();

			entity.HasIndex(x => new { x.VeiculoId, x.Status });
		});
	}
}
