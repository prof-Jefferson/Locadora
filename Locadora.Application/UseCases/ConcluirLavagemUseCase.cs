using Locadora.Application.Events;
using Locadora.Application.Ports;

namespace Locadora.Application.UseCases;

public sealed class ConcluirLavagemUseCase
{
    private readonly IOrdemServicoStore _store;
    private readonly IEventBus _bus;

    public ConcluirLavagemUseCase(IOrdemServicoStore store, IEventBus bus)
    {
        _store = store;
        _bus = bus;
    }

    public async Task<bool> ExecuteAsync(Guid ordemId, CancellationToken ct = default)
    {
        var os = await _store.ConcluirAsync(ordemId, ct);
        if (os is null) return false;

        if (os.Tipo == Application.DTOs.TipoOrdemServico.Lavagem)
            await _bus.PublishAsync(new VeiculoLavado(os.VeiculoId, DateTime.UtcNow), ct);

        return true;
    }
}
