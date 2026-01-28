using Locadora.Domain.Locacoes;

public sealed record LocacaoDto(
    Guid Id,
    Guid ClienteId,
    Guid VeiculoId,
    StatusLocacao Status,
    DateOnly Retirada,
    DateOnly Prevista,
    DateOnly? Devolucao,
    DateTime CriadoEmUtc
);

