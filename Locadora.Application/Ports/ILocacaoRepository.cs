using Locadora.Application.DTOs;

namespace Locadora.Application.Ports;

public interface ILocacaoRepository
{
    Task AddAsync(Guid id, Guid clienteId, Guid veiculoId, DateOnly retirada, DateOnly prevista, CancellationToken ct = default);

    Task<LocacaoInfoDto?> GetInfoAsync(Guid locacaoId, CancellationToken ct = default);

    // retorna false se não encontrou ou não estava ATIVA
    Task<bool> EncerrarAsync(Guid locacaoId, DateOnly devolucao, CancellationToken ct = default);
}
