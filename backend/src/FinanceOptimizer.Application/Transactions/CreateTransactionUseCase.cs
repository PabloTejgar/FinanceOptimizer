using FinanceOptimizer.Application.Common;
using FinanceOptimizer.Domain.Transactions;

namespace FinanceOptimizer.Application.Transactions;

/// <summary>
/// Use case responsible for creating a transaction.
/// </summary>
public sealed class CreateTransactionUseCase
{
    private readonly ITransactionRepository _repository;
    private readonly CreateTransactionCommandValidator _validator;

    /// <summary>
    /// Initializes a new instance of the use case.
    /// </summary>
    public CreateTransactionUseCase(
        ITransactionRepository repository,
        CreateTransactionCommandValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    /// <summary>
    /// Executes the transaction creation process.
    /// </summary>
    public async Task<Result<Guid>> ExecuteAsync(
        CreateTransactionCommand command,
        CancellationToken cancellationToken)
    {
        var errors = _validator.Validate(command);

        if (errors.Any())
        {
            return Result<Guid>.Failure(errors.ToArray());
        }

        var transaction = new Transaction(
            Guid.NewGuid(),
            command.BookingDate,
            command.Description,
            new Money(command.Amount, command.Currency));

        await _repository.AddAsync(transaction, cancellationToken);

        return Result<Guid>.Success(transaction.Id);
    }
}