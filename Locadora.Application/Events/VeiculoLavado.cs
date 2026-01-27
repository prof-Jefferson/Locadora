namespace Locadora.Application.Events;

public sealed record VeiculoLavado(Guid VeiculoId, DateTime OcorridoEmUtc);
