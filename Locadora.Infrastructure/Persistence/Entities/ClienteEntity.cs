namespace Locadora.Infrastructure.Persistence.Entities;

public sealed class ClienteEntity
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Tipo { get; set; } = default!;         // "PF" | "PJ"
    public string Documento { get; set; } = default!;

    public string? Cnh { get; set; }                      // PF
    public string? RazaoSocial { get; set; }              // PJ
    public string? Responsavel { get; set; }              // PJ

    public DateTime CriadoEm { get; set; }
}
