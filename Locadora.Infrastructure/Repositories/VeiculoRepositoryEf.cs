using Locadora.Application.DTOs;
using Locadora.Application.Ports;
using Locadora.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infrastructure.Repositories;

public sealed class VeiculoRepositoryEf : IVeiculoRepository
{
	private readonly LocadoraDbContext _db;

	public VeiculoRepositoryEf(LocadoraDbContext db)
		=> _db = db;

	public async Task<IReadOnlyList<VeiculoDto>> ListarDisponiveisAsync(CancellationToken ct = default)
	{
		return await _db.Veiculos
			.AsNoTracking()
			.Where(v => v.Ativo && v.Disponivel)
			.OrderBy(v => v.Modelo)
			.Select(v => new VeiculoDto(
				v.Id,
				v.Placa,
				v.Modelo,
				v.Ano,
				v.Categoria,
				v.ValorDiaria,
				v.Ativo,
				v.Disponivel
			))
			.ToListAsync(ct);
	}
	
	public async Task<bool> TryMarcarComoIndisponivelAsync(Guid veiculoId, CancellationToken ct = default)
	{
		var afetadas = await _db.Veiculos
			.Where(v => v.Id == veiculoId && v.Ativo && v.Disponivel)
			.ExecuteUpdateAsync(s => s.SetProperty(v => v.Disponivel, false), ct);

		return afetadas == 1;
	}
	
	public async Task MarcarComoDisponivelAsync(Guid veiculoId, CancellationToken ct = default)
	{
		await _db.Veiculos
			.Where(v => v.Id == veiculoId && v.Ativo)
			.ExecuteUpdateAsync(s => s.SetProperty(v => v.Disponivel, true), ct);
	}
}
