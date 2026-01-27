using Locadora.Application.Events;
using Locadora.Application.Ports;
using Locadora.Application.UseCases;
using Locadora.Infrastructure.Events;
using Locadora.Infrastructure.Events.Handlers;
using Locadora.Infrastructure.Persistence;
using Locadora.Infrastructure.Repositories;
using Locadora.Infrastructure.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Locadora.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddLocadoraInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var cs = config.GetConnectionString("MariaDb");

        services.AddDbContext<LocadoraDbContext>(opt =>
            opt.UseMySql(cs, ServerVersion.AutoDetect(cs)));

        // UoW + Repositories
        services.AddScoped<IUnitOfWork, UnitOfWorkEf>();
        services.AddScoped<IClienteRepository, ClienteRepositoryEf>();
        services.AddScoped<IVeiculoRepository, VeiculoRepositoryEf>();
        services.AddScoped<ILocacaoRepository, LocacaoRepositoryEf>();

        // Event bus + stores + handlers
        services.AddSingleton<IEventBus, InMemoryEventBus>();
        services.AddSingleton<IOrdemServicoStore, InMemoryOrdemServicoStore>();

        services.AddSingleton<PatioHandler>();
        services.AddSingleton<LavaRapidoHandler>();
        services.AddSingleton<ManutencaoHandler>();

        return services;
    }

    public static IServiceCollection AddLocadoraApplication(this IServiceCollection services)
    {
        // Use cases
        services.AddScoped<ListarVeiculosDisponiveisUseCase>();
        services.AddScoped<AbrirLocacaoUseCase>();
        services.AddScoped<DevolverVeiculoUseCase>();
        services.AddScoped<ConcluirLavagemUseCase>();

        return services;
    }
}
