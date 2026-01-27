namespace Locadora.Infrastructure.Persistence.Entities;

public sealed class LocacaoEntity
{
    public Guid Id { get; set; }

    public Guid ClienteId { get; set; }
    public ClienteEntity Cliente { get; set; } = default!;

    public Guid VeiculoId { get; set; }
    public VeiculoEntity Veiculo { get; set; } = default!;

    public DateOnly Retirada { get; set; }
    public DateOnly Prevista { get; set; }
    public DateOnly? Devolucao { get; set; }

    public string Status { get; set; } = "ATIVA";

    public decimal ValorPrevisto { get; set; }
    public decimal? ValorFinal { get; set; }

    public DateTime CriadoEm { get; set; }

    public List<LocacaoExtraEntity> Extras { get; set; } = new();
}
