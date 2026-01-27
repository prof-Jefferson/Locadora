using Locadora.Application.Events;
using Locadora.Infrastructure.Events.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.Api;

public static class EventSubscriptions
{
    public static WebApplication UseLocadoraEventSubscriptions(this WebApplication app)
    {
        var bus = app.Services.GetRequiredService<IEventBus>();

        bus.Subscribe<VeiculoLocado>(app.Services.GetRequiredService<PatioHandler>().OnVeiculoLocado);
        bus.Subscribe<VeiculoDevolvido>(app.Services.GetRequiredService<LavaRapidoHandler>().OnVeiculoDevolvido);
        bus.Subscribe<VeiculoLavado>(app.Services.GetRequiredService<ManutencaoHandler>().OnVeiculoLavado);

        return app;
    }
}
