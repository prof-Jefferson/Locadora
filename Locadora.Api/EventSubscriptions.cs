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

        bus.Subscribe<VeiculoLocado>(async (ev, ct) =>
        {
            using var scope = app.Services.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<PatioHandler>();
            await handler.OnVeiculoLocado(ev, ct);
        });

        bus.Subscribe<VeiculoDevolvido>(async (ev, ct) =>
        {
            using var scope = app.Services.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<LavaRapidoHandler>();
            await handler.OnVeiculoDevolvido(ev, ct);
        });

        bus.Subscribe<VeiculoLavado>(async (ev, ct) =>
        {
            using var scope = app.Services.CreateScope();
            var manut = scope.ServiceProvider.GetRequiredService<ManutencaoHandler>();
            await manut.OnVeiculoLavado(ev, ct);

            var disp = scope.ServiceProvider.GetRequiredService<DisponibilidadeHandler>();
            await disp.OnVeiculoLavado(ev, ct);
        });

        return app;
    }
}
