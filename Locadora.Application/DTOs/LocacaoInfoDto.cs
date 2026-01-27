namespace Locadora.Application.DTOs;

public sealed record LocacaoInfoDto(
    Guid LocacaoId,
    Guid ClienteId,
    Guid VeiculoId,
    string Status
);
