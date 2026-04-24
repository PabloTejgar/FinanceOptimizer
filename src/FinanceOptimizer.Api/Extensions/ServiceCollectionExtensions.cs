using FinanceOptimizer.Infrastructure;
using FinanceOptimizer.Infrastructure.Persistence;

namespace FinanceOptimizer.Api.Extensions;

/// <summary>
/// Provides extension methods for registering application services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all services required by the API.
    /// </summary>
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOpenApi();

        services.AddInfrastructure(configuration);

        services
            .AddHealthChecks()
            .AddDbContextCheck<FinanceDbContext>("postgres");

        return services;
    }
}