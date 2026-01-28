LocacaoDtopublic sealed record LocacaoDto(
    Guid Id,
    Guid ClienteId,
    Guid VeiculoId,
    string Status,
    DateOnly Retirada,
    DateOnly Prevista,
    DateOnly? Devolucao,
    DateTime CriadoEmUtc
);
