namespace Locadora.Application.DTOs;

public enum TipoOrdemServico
{
    Lavagem = 1,
    Manutencao = 2
}

public enum StatusOrdemServico
{
    Aberta = 1,
    Concluida = 2
}

public sealed record OrdemServicoDto(
    Guid Id,
    Guid VeiculoId,
    TipoOrdemServico Tipo,
    StatusOrdemServico Status,
    DateTime CriadoEmUtc,
    DateTime? ConcluidoEmUtc
);
