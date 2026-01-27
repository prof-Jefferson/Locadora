namespace Locadora.Application.Events;

public interface IEventBus
{
    Task PublishAsync<TEvent>(TEvent ev, CancellationToken ct = default);
    void Subscribe<TEvent>(Func<TEvent, CancellationToken, Task> handler);
}
