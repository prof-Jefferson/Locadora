using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Locadora.Infrastructure.Persistence.Entities;

namespace Locadora.Infrastructure.Persistence.Configurations;

public sealed class LocacaoExtraMap : IEntityTypeConfiguration<LocacaoExtraEntity>
{
    public void Configure(EntityTypeBuilder<LocacaoExtraEntity> b)
    {
        b.ToTable("locacao_extras");
        b.HasKey(x => x.Id);

        b.Property(x => x.Id).HasColumnName("id").HasMaxLength(36);
        b.Property(x => x.LocacaoId).HasColumnName("locacao_id").IsRequired();

        b.Property(x => x.TipoExtra).HasColumnName("tipo_extra").HasMaxLength(20).IsRequired();
        b.Property(x => x.PrecoPorDia).HasColumnName("preco_por_dia").HasPrecision(10, 2).IsRequired();
        b.Property(x => x.Quantidade).HasColumnName("quantidade").IsRequired();

        b.HasIndex(x => x.LocacaoId).HasDatabaseName("ix_locacao_extras_locacao");
    }
}
