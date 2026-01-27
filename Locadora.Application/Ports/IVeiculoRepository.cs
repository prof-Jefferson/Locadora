using Locadora.Application.DTOs;

namespace Locadora.Application.Ports;

public interface IVeiculoRepository
{
    Task<IReadOnlyList<VeiculoDto>> ListarDisponiveisAsync(CancellationToken ct = default);
    Task<bool> TryMarcarComoIndisponivelAsync(Guid veiculoId, CancellationToken ct = default);
    Task MarcarComoDisponivelAsync(Guid veiculoId, CancellationToken ct = default);
}
