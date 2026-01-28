using Locadora.Application.DTOs;
using Locadora.Application.Ports;
using Locadora.Application.UseCases;
using Locadora.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Locadora.Domain.Locacoes;

namespace Locadora.Api;

public static class Endpoints
{
	public static WebApplication MapLocadoraEndpoints(this WebApplication app)
	{
		app.MapGet("/", () => "Locadora API online");

		app.MapGet("/veiculos", async (ListarVeiculosDisponiveisUseCase useCase, CancellationToken ct) =>
			Results.Ok(await useCase.ExecuteAsync(ct)));

		app.MapPost("/locacoes", async (AbrirLocacaoRequest req, AbrirLocacaoUseCase useCase, CancellationToken ct) =>
			Results.Created("", await useCase.ExecuteAsync(req, ct)));

		app.MapPost("/locacoes/{id:guid}/devolver", async (Guid id, DevolverLocacaoRequest req, DevolverVeiculoUseCase useCase, CancellationToken ct) =>
			Results.Ok(await useCase.ExecuteAsync(id, req, ct)));

		app.MapGet("/os", async (IOrdemServicoStore store, CancellationToken ct) =>
			Results.Ok(await store.ListarAsync(ct)));

		app.MapPost("/os/{id:guid}/concluir", async (Guid id, ConcluirLavagemUseCase useCase, CancellationToken ct) =>
		{
			var ok = await useCase.ExecuteAsync(id, ct);
			return ok ? Results.Ok() : Results.NotFound();
		});
		
			app.MapGet("/locacoes", async (
				int page,
				int pageSize,
				StatusLocacao? status,
				LocadoraDbContext db,
				CancellationToken ct) =>
			{
			page = page <= 0 ? 1 : page;
			pageSize = pageSize <= 0 ? 20 : Math.Min(pageSize, 100);

			var q = db.Locacoes.AsNoTracking();

			if (status is not null)
				q = q.Where(l => l.Status == status);

			var total = await q.CountAsync(ct);

			var items = await q
				.OrderByDescending(l => l.CriadoEm)
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.Select(l => new LocacaoDto(
					l.Id, l.ClienteId, l.VeiculoId, l.Status,
					l.Retirada, l.Prevista, l.Devolucao, l.CriadoEm))
				.ToListAsync(ct);

			return Results.Ok(new { page, pageSize, total, items });
		})
		.WithName("ListarLocacoes");

		return app;
	}
}