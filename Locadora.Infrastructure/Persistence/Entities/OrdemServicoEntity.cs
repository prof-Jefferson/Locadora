using Locadora.Application.DTOs;

namespace Locadora.Infrastructure.Persistence.Entities;

public sealed class OrdemServicoEntity
{
    public Guid Id { get; set; }
    public Guid VeiculoId { get; set; }

    public TipoOrdemServico Tipo { get; set; }
    public StatusOrdemServico Status { get; set; }

    public DateTime CriadoEmUtc { get; set; }
    public DateTime? ConcluidoEmUtc { get; set; }
}
