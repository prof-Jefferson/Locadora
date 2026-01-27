using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Locadora.Infrastructure.Persistence.Entities;

namespace Locadora.Infrastructure.Persistence.Configurations;

public sealed class LocacaoMap : IEntityTypeConfiguration<LocacaoEntity>
{
    public void Configure(EntityTypeBuilder<LocacaoEntity> b)
    {
        b.ToTable("locacoes");
        b.HasKey(x => x.Id);

        b.Property(x => x.Id).HasColumnName("id").HasMaxLength(36);

        b.Property(x => x.ClienteId).HasColumnName("cliente_id").IsRequired();
        b.Property(x => x.VeiculoId).HasColumnName("veiculo_id").IsRequired();

        b.Property(x => x.Retirada).HasColumnName("retirada").IsRequired();
        b.Property(x => x.Prevista).HasColumnName("prevista").IsRequired();
        b.Property(x => x.Devolucao).HasColumnName("devolucao");

        b.Property(x => x.Status).HasColumnName("status").HasMaxLength(20).IsRequired();

        b.Property(x => x.ValorPrevisto).HasColumnName("valor_previsto").HasPrecision(10, 2).IsRequired();
        b.Property(x => x.ValorFinal).HasColumnName("valor_final").HasPrecision(10, 2);

        b.Property(x => x.CriadoEm).HasColumnName("criado_em").IsRequired();

        b.HasOne(x => x.Cliente)
            .WithMany()
            .HasForeignKey(x => x.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.Veiculo)
            .WithMany()
            .HasForeignKey(x => x.VeiculoId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasMany(x => x.Extras)
            .WithOne(x => x.Locacao)
            .HasForeignKey(x => x.LocacaoId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(x => new { x.VeiculoId, x.Status }).HasDatabaseName("ix_locacoes_veiculo_status");
        b.HasIndex(x => new { x.ClienteId, x.Status }).HasDatabaseName("ix_locacoes_cliente_status");
    }
}
