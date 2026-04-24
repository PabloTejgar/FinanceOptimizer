using Microsoft.EntityFrameworkCore;

namespace FinanceOptimizer.Infrastructure.Persistence;

/// <summary>
/// Entity Framework database context for the Finance Optimizer application.
/// </summary>
public sealed class FinanceDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the database context.
    /// </summary>
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
        : base(options)
    {
    }
}