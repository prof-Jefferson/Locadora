using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Locadora.Infrastructure.Persistence.Entities;

namespace Locadora.Infrastructure.Persistence.Configurations;

public sealed class ClienteMap : IEntityTypeConfiguration<ClienteEntity>
{
    public void Configure(EntityTypeBuilder<ClienteEntity> b)
    {
        b.ToTable("clientes");
        b.HasKey(x => x.Id);

        b.Property(x => x.Id).HasColumnName("id").HasMaxLength(36);
        b.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(120).IsRequired();
        b.Property(x => x.Tipo).HasColumnName("tipo").HasMaxLength(2).IsRequired();
        b.Property(x => x.Documento).HasColumnName("documento").HasMaxLength(20).IsRequired();

        b.Property(x => x.Cnh).HasColumnName("cnh").HasMaxLength(20);
        b.Property(x => x.RazaoSocial).HasColumnName("razao_social").HasMaxLength(160);
        b.Property(x => x.Responsavel).HasColumnName("responsavel").HasMaxLength(120);

        b.Property(x => x.CriadoEm).HasColumnName("criado_em").IsRequired();

        b.HasIndex(x => x.Documento).IsUnique();
    }
}
