using FinanceOptimizer.Infrastructure;
using FinanceOptimizer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

/// <summary>
/// Database migration executable.
/// </summary>
var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddInfrastructure(builder.Configuration);

var host = builder.Build();

using var scope = host.Services.CreateScope();

var logger = scope.ServiceProvider.GetRequiredService<ILogger<FinanceDbContext>>();
var dbContext = scope.ServiceProvider.GetRequiredService<FinanceDbContext>();

var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

if (!pendingMigrations.Any())
{
    logger.LogInformation("Database schema is already up to date.");
    return;
}

logger.LogInformation(
    "Applying pending database migrations: {Migrations}",
    string.Join(", ", pendingMigrations));

await dbContext.Database.MigrateAsync();

logger.LogInformation("Database migrations applied successfully.");