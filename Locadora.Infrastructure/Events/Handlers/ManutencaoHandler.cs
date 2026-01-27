using Locadora.Application.Events;
using Microsoft.Extensions.Logging;

namespace Locadora.Infrastructure.Events.Handlers;

public sealed class ManutencaoHandler
{
    private readonly ILogger<ManutencaoHandler> _log;

    public ManutencaoHandler(ILogger<ManutencaoHandler> log) => _log = log;

    public Task OnVeiculoLavado(VeiculoLavado ev, CancellationToken ct)
    {
        _log.LogInformation("MANUTENÇÃO: veículo {VeiculoId} lavado. Avaliar necessidade de revisão.", ev.VeiculoId);
        return Task.CompletedTask;
    }
}
