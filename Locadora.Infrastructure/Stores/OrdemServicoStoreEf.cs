using Locadora.Application.DTOs;
using Locadora.Application.Ports;
using Locadora.Infrastructure.Persistence;
using Locadora.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infrastructure.Stores;

public sealed class OrdemServicoStoreEf : IOrdemServicoStore
{
    private readonly LocadoraDbContext _db;

    public OrdemServicoStoreEf(LocadoraDbContext db) => _db = db;

    public async Task<OrdemServicoDto> CriarAsync(Guid veiculoId, TipoOrdemServico tipo, CancellationToken ct = default)
    {
        var entity = new OrdemServicoEntity
        {
            Id = Guid.NewGuid(),
            VeiculoId = veiculoId,
            Tipo = tipo,
            Status = StatusOrdemServico.Aberta,
            CriadoEmUtc = DateTime.UtcNow,
            ConcluidoEmUtc = null
        };

        _db.OrdensServico.Add(entity);
        await _db.SaveChangesAsync(ct);

        return ToDto(entity);
    }

    public async Task<IReadOnlyList<OrdemServicoDto>> ListarAsync(CancellationToken ct = default)
    {
        var list = await _db.OrdensServico
            .AsNoTracking()
            .OrderByDescending(x => x.CriadoEmUtc)
            .ToListAsync(ct);

        return list.Select(ToDto).ToList();
    }

    public async Task<OrdemServicoDto?> ConcluirAsync(Guid ordemId, CancellationToken ct = default)
    {
        var entity = await _db.OrdensServico.FirstOrDefaultAsync(x => x.Id == ordemId, ct);
        if (entity is null) return null;

        if (entity.Status == StatusOrdemServico.Concluida)
            return ToDto(entity);

        entity.Status = StatusOrdemServico.Concluida;
        entity.ConcluidoEmUtc = DateTime.UtcNow;

        await _db.SaveChangesAsync(ct);

        return ToDto(entity);
    }

    private static OrdemServicoDto ToDto(OrdemServicoEntity x) =>
        new(x.Id, x.VeiculoId, x.Tipo, x.Status, x.CriadoEmUtc, x.ConcluidoEmUtc);
}
