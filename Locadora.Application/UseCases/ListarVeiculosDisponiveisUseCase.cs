using Locadora.Application.DTOs;
using Locadora.Application.Ports;

namespace Locadora.Application.UseCases;

public sealed class ListarVeiculosDisponiveisUseCase
{
    private readonly IVeiculoRepository _repo;

    public ListarVeiculosDisponiveisUseCase(IVeiculoRepository repo)
        => _repo = repo;

    public Task<IReadOnlyList<VeiculoDto>> ExecuteAsync(CancellationToken ct = default)
        => _repo.ListarDisponiveisAsync(ct);
}
