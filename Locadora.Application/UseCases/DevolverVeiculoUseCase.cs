using Locadora.Application.DTOs;
using Locadora.Application.Events;
using Locadora.Application.Ports;

namespace Locadora.Application.UseCases;

public sealed class DevolverVeiculoUseCase
{
    private readonly ILocacaoRepository _locacoes;
    private readonly IVeiculoRepository _veiculos;
    private readonly IUnitOfWork _uow;
    private readonly IEventBus _bus;

    public DevolverVeiculoUseCase(
        ILocacaoRepository locacoes,
        IVeiculoRepository veiculos,
        IUnitOfWork uow,
        IEventBus bus)
    {
        _locacoes = locacoes;
        _veiculos = veiculos;
        _uow = uow;
        _bus = bus;
    }

    public async Task<DevolverLocacaoResponse> ExecuteAsync(Guid locacaoId, DevolverLocacaoRequest req, CancellationToken ct = default)
    {
        var info = await _locacoes.GetInfoAsync(locacaoId, ct);
        if (info is null)
            throw new ArgumentException("Locação não encontrada.");

        if (info.Status != "ATIVA")
            throw new InvalidOperationException("A locação não está ativa.");

        var dataDevolucao = req.Devolucao ?? DateOnly.FromDateTime(DateTime.UtcNow);

        await _uow.ExecuteInTransactionAsync(async tct =>
        {
            var ok = await _locacoes.EncerrarAsync(locacaoId, dataDevolucao, tct);
            if (!ok)
                throw new InvalidOperationException("Não foi possível encerrar a locação (talvez já tenha sido encerrada).");

            await _veiculos.MarcarComoDisponivelAsync(info.VeiculoId, tct);
        }, ct);

        await _bus.PublishAsync(new VeiculoDevolvido(locacaoId, info.VeiculoId, info.ClienteId, DateTime.UtcNow), ct);

        return new DevolverLocacaoResponse(locacaoId, info.VeiculoId, "ENCERRADA");
    }
}
