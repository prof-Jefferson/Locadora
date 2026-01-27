using Locadora.Application.DTOs;

namespace Locadora.Application.Ports;

public interface IVeiculoRepository
{
    Task<IReadOnlyList<VeiculoDto>> ListarDisponiveisAsync(CancellationToken ct = default);
}
