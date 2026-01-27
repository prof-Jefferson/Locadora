using Locadora.Domain.Locacoes;

namespace Locadora.Application.DTOs;

public sealed record LocacaoInfoDto(
    Guid LocacaoId,
    Guid ClienteId,
    Guid VeiculoId,
    StatusLocacao Status
);
