namespace Locadora.Infrastructure.Persistence.Entities;

public sealed class VeiculoEntity
{
    public Guid Id { get; set; }
    public string Placa { get; set; } = default!;
    public string Modelo { get; set; } = default!;
    public int Ano { get; set; }
    public string Categoria { get; set; } = default!;
    public decimal ValorDiaria { get; set; }
    public bool Ativo { get; set; }
    public bool Disponivel { get; set; }
    public DateTime CriadoEm { get; set; }
}
