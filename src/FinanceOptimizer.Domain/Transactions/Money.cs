namespace FinanceOptimizer.Domain.Transactions;

/// <summary>
/// Represents a monetary value with amount and currency.
/// </summary>
public sealed record Money(decimal Amount, string Currency)
{
    /// <summary>
    /// Factory method for creating a Money instance in Euros.
    /// </summary>
    public static Money Euro(decimal amount) => new(amount, "EUR");
}