using Locadora.Application.Ports;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infrastructure.Persistence;

public sealed class UnitOfWorkEf : IUnitOfWork
{
    private readonly LocadoraDbContext _db;

    public UnitOfWorkEf(LocadoraDbContext db) => _db = db;

    public async Task ExecuteInTransactionAsync(Func<CancellationToken, Task> action, CancellationToken ct = default)
    {
        await using var tx = await _db.Database.BeginTransactionAsync(ct);

        await action(ct);
        await _db.SaveChangesAsync(ct);

        await tx.CommitAsync(ct);
    }
}
