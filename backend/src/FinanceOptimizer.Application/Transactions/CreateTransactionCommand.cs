namespace FinanceOptimizer.Application.Transactions;

/// <summary>
/// Command containing the data required to import a transaction.
/// </summary>
public sealed record CreateTransactionCommand(
    DateOnly BookingDate,
    string Description,
    decimal Amount,
    string Currency);