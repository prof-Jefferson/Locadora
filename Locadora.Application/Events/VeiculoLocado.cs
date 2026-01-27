namespace Locadora.Application.Events;

public sealed record VeiculoLocado(Guid LocacaoId, Guid VeiculoId, Guid ClienteId, DateTime OcorridoEmUtc);
