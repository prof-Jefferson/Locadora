namespace Locadora.Infrastructure.Persistence.Entities;

public sealed class LocacaoExtraEntity
{
    public Guid Id { get; set; }

    public Guid LocacaoId { get; set; }
    public LocacaoEntity Locacao { get; set; } = default!;

    public string TipoExtra { get; set; } = default!; // "SEGURO" | "GPS" | "CADEIRINHA"
    public decimal PrecoPorDia { get; set; }
    public int Quantidade { get; set; }
}
