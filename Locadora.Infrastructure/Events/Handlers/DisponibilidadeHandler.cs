using Locadora.Application.Events;
using Locadora.Application.Ports;
using Microsoft.Extensions.Logging;

namespace Locadora.Infrastructure.Events.Handlers;

public sealed class DisponibilidadeHandler
{
    private readonly IVeiculoRepository _veiculos;
    private readonly ILogger<DisponibilidadeHandler> _log;

    public DisponibilidadeHandler(IVeiculoRepository veiculos, ILogger<DisponibilidadeHandler> log)
    {
        _veiculos = veiculos;
        _log = log;
    }

    public async Task OnVeiculoLavado(VeiculoLavado ev, CancellationToken ct)
    {
        await _veiculos.MarcarComoDisponivelAsync(ev.VeiculoId, ct);
        _log.LogInformation("PÁTIO: veículo {VeiculoId} liberado após lavagem.", ev.VeiculoId);
    }
}
