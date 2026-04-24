using FinanceOptimizer.Application.Transactions;
using FinanceOptimizer.Domain.Transactions;
using Microsoft.EntityFrameworkCore;

namespace FinanceOptimizer.Infrastructure.Persistence.Repositories;

/// <summary>
/// Entity Framework implementation of the transaction repository.
/// </summary>
public sealed class EfTransactionRepository : ITransactionRepository
{
    private readonly FinanceDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the repository.
    /// </summary>
    public EfTransactionRepository(FinanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Adds a new transaction to the database.
    /// </summary>
    public async Task AddAsync(Transaction transaction, CancellationToken cancellationToken)
    {
        await _dbContext.Transactions.AddAsync(transaction, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves all transactions from the data store.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of all <see
    /// cref="Transaction"/> entities. The list will be empty if no transactions are found.</returns>
    public async Task<List<Transaction>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Transactions.ToListAsync(cancellationToken);
    }
}