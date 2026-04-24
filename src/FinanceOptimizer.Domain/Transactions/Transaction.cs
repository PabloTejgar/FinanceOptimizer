namespace FinanceOptimizer.Domain.Transactions;

/// <summary>
/// Represents a financial transaction in the system.
/// </summary>
public sealed class Transaction
{
    /// <summary>
    /// Unique identifier of the transaction.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Date when the transaction was booked.
    /// </summary>
    public DateOnly BookingDate { get; private set; }

    /// <summary>
    /// Description or concept of the transaction.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Monetary value of the transaction.
    /// </summary>
    public Money Amount { get; private set; }

    /// <summary>
    /// Category assigned to the transaction.
    /// </summary>
    public TransactionCategory Category { get; private set; }

    private Transaction() { }

    /// <summary>
    /// Creates a new transaction with the specified data.
    /// </summary>
    public Transaction(
        Guid id,
        DateOnly bookingDate,
        string description,
        Money amount,
        TransactionCategory category = TransactionCategory.Unknown)
    {
        Id = id;
        BookingDate = bookingDate;
        Description = string.IsNullOrWhiteSpace(description)
            ? throw new ArgumentException("Description cannot be empty.", nameof(description))
            : description.Trim();
        Amount = amount;
        Category = category;
    }

    /// <summary>
    /// Assigns a category to the transaction.
    /// </summary>
    public void CategorizeAs(TransactionCategory category)
    {
        Category = category;
    }
}