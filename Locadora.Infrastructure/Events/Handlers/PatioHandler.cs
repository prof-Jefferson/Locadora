using Locadora.Application.Events;
using Microsoft.Extensions.Logging;

namespace Locadora.Infrastructure.Events.Handlers;

public sealed class PatioHandler
{
    private readonly ILogger<PatioHandler> _log;

    public PatioHandler(ILogger<PatioHandler> log) => _log = log;

    public Task OnVeiculoLocado(VeiculoLocado ev, CancellationToken ct)
    {
        _log.LogInformation("PÁTIO: veículo {PlacaId} locado. LocacaoId={LocacaoId}", ev.VeiculoId, ev.LocacaoId);
        return Task.CompletedTask;
    }
}
