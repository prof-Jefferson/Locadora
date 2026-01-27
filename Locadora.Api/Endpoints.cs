using Locadora.Application.DTOs;
using Locadora.Application.Ports;
using Locadora.Application.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

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

        return app;
    }
}
