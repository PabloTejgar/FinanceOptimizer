using FinanceOptimizer.Application.Transactions;
using FinanceOptimizer.Infrastructure.Persistence;
using FinanceOptimizer.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceOptimizer.Infrastructure;

/// <summary>
/// Provides dependency injection registration methods for infrastructure services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers infrastructure services.
    /// </summary>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres");

        services.AddDbContext<FinanceDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<ITransactionRepository, EfTransactionRepository>();

        return services;
    }
}