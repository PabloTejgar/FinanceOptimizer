using FinanceOptimizer.Domain.Transactions;
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

    /// <summary>
    /// Transactions stored in the system.
    /// </summary>
    public DbSet<Transaction> Transactions => Set<Transaction>();

    /// <summary>
    /// Configures the entity model.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinanceDbContext).Assembly);
    }
}