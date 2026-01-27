using Locadora.Application.DTOs;
using Locadora.Application.Ports;
using System.Collections.Concurrent;

namespace Locadora.Infrastructure.Stores;

public sealed class InMemoryOrdemServicoStore : IOrdemServicoStore
{
    private readonly ConcurrentDictionary<Guid, OrdemServicoDto> _db = new();

    public Task<OrdemServicoDto> CriarAsync(Guid veiculoId, TipoOrdemServico tipo, CancellationToken ct = default)
    {
        var os = new OrdemServicoDto(
            Id: Guid.NewGuid(),
            VeiculoId: veiculoId,
            Tipo: tipo,
            Status: StatusOrdemServico.Aberta,
            CriadoEmUtc: DateTime.UtcNow,
            ConcluidoEmUtc: null
        );

        _db[os.Id] = os;
        return Task.FromResult(os);
    }

    public Task<IReadOnlyList<OrdemServicoDto>> ListarAsync(CancellationToken ct = default)
        => Task.FromResult((IReadOnlyList<OrdemServicoDto>)_db.Values
            .OrderByDescending(x => x.CriadoEmUtc)
            .ToList());

    public Task<OrdemServicoDto?> ConcluirAsync(Guid ordemId, CancellationToken ct = default)
    {
        if (!_db.TryGetValue(ordemId, out var atual)) return Task.FromResult<OrdemServicoDto?>(null);
        if (atual.Status == StatusOrdemServico.Concluida) return Task.FromResult<OrdemServicoDto?>(atual);

        var atualizado = atual with { Status = StatusOrdemServico.Concluida, ConcluidoEmUtc = DateTime.UtcNow };
        _db[ordemId] = atualizado;

        return Task.FromResult<OrdemServicoDto?>(atualizado);
    }
}
