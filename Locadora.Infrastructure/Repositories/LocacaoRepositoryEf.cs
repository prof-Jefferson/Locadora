using Locadora.Application.Ports;
using Locadora.Infrastructure.Persistence;
using Locadora.Infrastructure.Persistence.Entities;
using Locadora.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using Locadora.Domain.Locacoes;

namespace Locadora.Infrastructure.Repositories;

public sealed class LocacaoRepositoryEf : ILocacaoRepository
{
	private readonly LocadoraDbContext _db;

	public LocacaoRepositoryEf(LocadoraDbContext db) => _db = db;

	public async Task AddAsync(Guid id, Guid clienteId, Guid veiculoId, DateOnly retirada, DateOnly prevista, CancellationToken ct = default)
	{
		_db.Locacoes.Add(new LocacaoEntity
		{
			Id = id,
			ClienteId = clienteId,
			VeiculoId = veiculoId,
			Retirada = retirada,
			Prevista = prevista,
			Devolucao = null,
			Status = StatusLocacao.Ativa,
			ValorPrevisto = 0m,
			ValorFinal = null,
			CriadoEm = DateTime.UtcNow
		});

		await Task.CompletedTask;
	}
	
	public async Task<LocacaoInfoDto?> GetInfoAsync(Guid locacaoId, CancellationToken ct = default)
	{
		return await _db.Locacoes
			.AsNoTracking()
			.Where(l => l.Id == locacaoId)
			.Select(l => new LocacaoInfoDto(l.Id, l.ClienteId, l.VeiculoId, l.Status))
			.FirstOrDefaultAsync(ct);
	}

	public async Task<bool> EncerrarAsync(Guid locacaoId, DateOnly devolucao, CancellationToken ct = default)
	{
		var afetadas = await _db.Locacoes
			.Where(l => l.Id == locacaoId && l.Status == StatusLocacao.Ativa).ExecuteUpdateAsync(setters => setters
				.SetProperty(x => x.Devolucao, devolucao)
				.SetProperty(x => x.Status, StatusLocacao.Encerrada)
				.SetProperty(x => x.ValorFinal, x => x.ValorPrevisto), ct);

		return afetadas == 1;
	}
}
