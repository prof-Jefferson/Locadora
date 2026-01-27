namespace Locadora.Application.DTOs;

public sealed record AbrirLocacaoResponse(
    Guid LocacaoId,
    Guid ClienteId,
    Guid VeiculoId,
    string Status
);