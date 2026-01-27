using Locadora.Application.DTOs;
using Locadora.Application.Events;   
using Locadora.Application.Ports;

namespace Locadora.Application.Events;

public sealed record VeiculoDevolvido(Guid LocacaoId, Guid VeiculoId, Guid ClienteId, DateTime OcorridoEmUtc);
