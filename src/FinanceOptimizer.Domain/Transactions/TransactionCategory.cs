namespace FinanceOptimizer.Domain.Transactions;

/// <summary>
/// Represents the category of a financial transaction.
/// </summary>
public enum TransactionCategory
{
    /// <summary>
    /// Unknown or uncategorized transaction.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Housing-related expenses (rent, mortgage, etc.).
    /// </summary>
    Housing = 1,

    /// <summary>
    /// Food and groceries.
    /// </summary>
    Food = 2,

    /// <summary>
    /// Transportation expenses.
    /// </summary>
    Transport = 3,

    /// <summary>
    /// Subscription-based services.
    /// </summary>
    Subscriptions = 4,

    /// <summary>
    /// Health-related expenses.
    /// </summary>
    Health = 5,

    /// <summary>
    /// Leisure and entertainment.
    /// </summary>
    Leisure = 6,

    /// <summary>
    /// Income transactions.
    /// </summary>
    Income = 7
}