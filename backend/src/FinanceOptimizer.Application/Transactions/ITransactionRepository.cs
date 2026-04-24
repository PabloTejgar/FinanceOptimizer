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

    /// <summary>
    /// Get all transactions async.
    /// </summary>
    /// <returns>return transactions</returns>
    Task<List<Transaction>> GetAllAsync(CancellationToken cancellationToken);
}