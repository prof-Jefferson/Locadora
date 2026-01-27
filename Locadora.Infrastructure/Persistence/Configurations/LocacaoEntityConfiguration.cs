using Locadora.Domain.Locacoes;
using Locadora.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Locadora.Infrastructure.Persistence.Configurations;

public sealed class LocacaoEntityConfiguration : IEntityTypeConfiguration<LocacaoEntity>
{
    public void Configure(EntityTypeBuilder<LocacaoEntity> builder)
    {
        var statusConverter = new EnumToStringConverter<StatusLocacao>();

        builder.Property(x => x.Status)
            .HasConversion(statusConverter)
            .HasMaxLength(16)
            .IsRequired();
    }
}
