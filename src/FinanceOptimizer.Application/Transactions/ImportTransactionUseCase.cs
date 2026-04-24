using FinanceOptimizer.Domain.Transactions;

namespace FinanceOptimizer.Application.Transactions;

/// <summary>
/// Use case responsible for importing a transaction into the system.
/// </summary>
public sealed class ImportTransactionUseCase
{
    private readonly ITransactionRepository _repository;

    /// <summary>
    /// Initializes a new instance of the use case.
    /// </summary>
    public ImportTransactionUseCase(ITransactionRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the transaction import process.
    /// </summary>
    public async Task<Guid> ExecuteAsync(
        ImportTransactionCommand command,
        CancellationToken cancellationToken)
    {
        var transaction = new Transaction(
            Guid.NewGuid(),
            command.BookingDate,
            command.Description,
            new Money(command.Amount, command.Currency));

        await _repository.AddAsync(transaction, cancellationToken);

        return transaction.Id;
    }
}