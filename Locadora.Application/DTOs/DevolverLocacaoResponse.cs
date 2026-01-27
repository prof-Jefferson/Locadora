namespace Locadora.Application.DTOs;

public sealed record DevolverLocacaoResponse(
    Guid LocacaoId,
    Guid VeiculoId,
    string Status
);
