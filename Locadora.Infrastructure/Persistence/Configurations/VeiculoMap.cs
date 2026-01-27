using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Locadora.Infrastructure.Persistence.Entities;

namespace Locadora.Infrastructure.Persistence.Configurations;

public sealed class VeiculoMap : IEntityTypeConfiguration<VeiculoEntity>
{
    public void Configure(EntityTypeBuilder<VeiculoEntity> b)
    {
        b.ToTable("veiculos");
        b.HasKey(x => x.Id);

        b.Property(x => x.Id).HasColumnName("id").HasMaxLength(36);
        b.Property(x => x.Placa).HasColumnName("placa").HasMaxLength(10).IsRequired();
        b.Property(x => x.Modelo).HasColumnName("modelo").HasMaxLength(80).IsRequired();
        b.Property(x => x.Ano).HasColumnName("ano").IsRequired();
        b.Property(x => x.Categoria).HasColumnName("categoria").HasMaxLength(30).IsRequired();

        b.Property(x => x.ValorDiaria).HasColumnName("valor_diaria").HasPrecision(10, 2).IsRequired();
        b.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();
        b.Property(x => x.Disponivel).HasColumnName("disponivel").IsRequired();
        b.Property(x => x.CriadoEm).HasColumnName("criado_em").IsRequired();

        b.HasIndex(x => x.Placa).IsUnique();
    }
}
