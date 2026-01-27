namespace Locadora.Application.DTOs;

public sealed record DevolverLocacaoRequest(
    DateOnly? Devolucao // se vier null, usamos "hoje"
);
