using FinanceOptimizer.Application.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceOptimizer.Application;

/// <summary>
/// Provides dependency injection registration methods for application services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers application services.
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateTransactionCommandValidator>();
        services.AddScoped<CreateTransactionUseCase>();

        return services;
    }
}