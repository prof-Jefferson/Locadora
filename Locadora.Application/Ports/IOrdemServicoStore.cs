using Locadora.Application.DTOs;

namespace Locadora.Application.Ports;

public interface IOrdemServicoStore
{
    Task<OrdemServicoDto> CriarAsync(Guid veiculoId, TipoOrdemServico tipo, CancellationToken ct = default);
    Task<IReadOnlyList<OrdemServicoDto>> ListarAsync(CancellationToken ct = default);
    Task<OrdemServicoDto?> ConcluirAsync(Guid ordemId, CancellationToken ct = default);
}
