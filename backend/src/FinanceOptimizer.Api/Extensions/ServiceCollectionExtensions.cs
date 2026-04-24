using FinanceOptimizer.Application;
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

        services.AddApplication();
        services.AddInfrastructure(configuration);

        services
            .AddHealthChecks()
            .AddDbContextCheck<FinanceDbContext>("postgres");

        var allowedOrigins = configuration
            .GetSection("Cors:AllowedOrigins")
            .Get<string[]>() ?? [];

        services.AddCors(options =>
        {
            options.AddPolicy("Frontend", policy =>
            {
                policy
                    .WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        return services;
    }
}