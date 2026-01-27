using Locadora.Application.Ports;
using Locadora.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infrastructure.Repositories;

public sealed class ClienteRepositoryEf : IClienteRepository
{
    private readonly LocadoraDbContext _db;

    public ClienteRepositoryEf(LocadoraDbContext db) => _db = db;

    public Task<bool> ExistsAsync(Guid clienteId, CancellationToken ct = default)
        => _db.Clientes.AsNoTracking().AnyAsync(c => c.Id == clienteId, ct);
}
