namespace Locadora.Application.Ports;

public interface IClienteRepository
{
    Task<bool> ExistsAsync(Guid clienteId, CancellationToken ct = default);
}
