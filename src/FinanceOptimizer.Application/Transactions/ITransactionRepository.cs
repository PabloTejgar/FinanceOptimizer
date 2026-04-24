using FinanceOptimizer.Domain.Transactions;

namespace FinanceOptimizer.Application.Transactions;

/// <summary>
/// Abstraction for persisting transactions.
/// </summary>
public interface ITransactionRepository
{
    /// <summary>
    /// Adds a new transaction to the storage.
    /// </summary>
    Task AddAsync(Transaction transaction, CancellationToken cancellationToken);
}