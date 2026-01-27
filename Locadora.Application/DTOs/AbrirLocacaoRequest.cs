namespace Locadora.Application.DTOs;

public sealed record AbrirLocacaoRequest(
    Guid ClienteId,
    Guid VeiculoId,
    DateOnly Retirada,
    DateOnly Prevista
);
