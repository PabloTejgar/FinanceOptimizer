namespace FinanceOptimizer.Domain.Transactions;

/// <summary>
/// Represents a monetary value with amount and currency.
/// </summary>
public sealed record Money
{
    /// <summary>
    /// Monetary amount.
    /// </summary>
    public decimal Amount { get; }

    /// <summary>
    /// ISO 4217 currency code.
    /// </summary>
    public string Currency { get; }

    /// <summary>
    /// Creates a monetary value.
    /// </summary>
    public Money(decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new ArgumentException("Currency cannot be empty.", nameof(currency));
        }

        currency = currency.Trim().ToUpperInvariant();

        if (currency.Length != 3)
        {
            throw new ArgumentException("Currency must be a 3-letter ISO code.", nameof(currency));
        }

        Amount = amount;
        Currency = currency;
    }

    /// <summary>
    /// Factory method for creating a Money instance in Euros.
    /// </summary>
    public static Money Euro(decimal amount) => new(amount, "EUR");
}