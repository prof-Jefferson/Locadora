using Locadora.Application.Events;
using System.Collections.Concurrent;

namespace Locadora.Infrastructure.Events;

public sealed class InMemoryEventBus : IEventBus
{
    private readonly ConcurrentDictionary<Type, List<Func<object, CancellationToken, Task>>> _handlers = new();

    public void Subscribe<TEvent>(Func<TEvent, CancellationToken, Task> handler)
    {
        var list = _handlers.GetOrAdd(typeof(TEvent), _ => new List<Func<object, CancellationToken, Task>>());
        list.Add((ev, ct) => handler((TEvent)ev, ct));
    }

    public async Task PublishAsync<TEvent>(TEvent ev, CancellationToken ct = default)
    {
        if (!_handlers.TryGetValue(typeof(TEvent), out var list)) return;

        foreach (var h in list)
            await h(ev!, ct);
    }
}
