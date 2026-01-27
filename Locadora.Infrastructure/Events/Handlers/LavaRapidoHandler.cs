using Locadora.Application.DTOs;
using Locadora.Application.Events;
using Locadora.Application.Ports;
using Microsoft.Extensions.Logging;

namespace Locadora.Infrastructure.Events.Handlers;

public sealed class LavaRapidoHandler
{
    private readonly IOrdemServicoStore _os;
    private readonly ILogger<LavaRapidoHandler> _log;

    public LavaRapidoHandler(IOrdemServicoStore os, ILogger<LavaRapidoHandler> log)
    {
        _os = os;
        _log = log;
    }

    public async Task OnVeiculoDevolvido(VeiculoDevolvido ev, CancellationToken ct)
    {
        var ordem = await _os.CriarAsync(ev.VeiculoId, TipoOrdemServico.Lavagem, ct);
        _log.LogInformation("LAVA-RÁPIDO: criada OS {OrdemId} para veiculo {VeiculoId}", ordem.Id, ev.VeiculoId);
    }
}
