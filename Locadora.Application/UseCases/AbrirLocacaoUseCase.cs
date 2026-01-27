using Locadora.Application.DTOs;
using Locadora.Application.Events;
using Locadora.Application.Ports;

namespace Locadora.Application.UseCases;

public sealed class AbrirLocacaoUseCase
{
    private readonly IClienteRepository _clientes;
    private readonly IVeiculoRepository _veiculos;
    private readonly ILocacaoRepository _locacoes;
    private readonly IUnitOfWork _uow;
    private readonly IEventBus _bus;

    public AbrirLocacaoUseCase(
        IClienteRepository clientes,
        IVeiculoRepository veiculos,
        ILocacaoRepository locacoes,
        IUnitOfWork uow,
        IEventBus bus)
    {
        _clientes = clientes;
        _veiculos = veiculos;
        _locacoes = locacoes;
        _uow = uow;
        _bus = bus;
    }

    public async Task<AbrirLocacaoResponse> ExecuteAsync(AbrirLocacaoRequest req, CancellationToken ct = default)
    {
        if (req.Prevista < req.Retirada)
            throw new ArgumentException("A data prevista não pode ser anterior à data de retirada.");

        if (!await _clientes.ExistsAsync(req.ClienteId, ct))
            throw new ArgumentException("Cliente não encontrado.");

        var locacaoId = Guid.NewGuid();

        await _uow.ExecuteInTransactionAsync(async tct =>
        {
            var ok = await _veiculos.TryMarcarComoIndisponivelAsync(req.VeiculoId, tct);
            if (!ok)
                throw new InvalidOperationException("Veículo indisponível para locação.");

            await _locacoes.AddAsync(locacaoId, req.ClienteId, req.VeiculoId, req.Retirada, req.Prevista, tct);
        }, ct);

        // publica evento depois do commit (bom hábito)
        await _bus.PublishAsync(
            new VeiculoLocado(locacaoId, req.VeiculoId, req.ClienteId, DateTime.UtcNow),
            ct);

        return new AbrirLocacaoResponse(locacaoId, req.ClienteId, req.VeiculoId, "ATIVA");
    }
}
