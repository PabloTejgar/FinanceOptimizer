using FinanceOptimizer.Application.Common;

namespace FinanceOptimizer.Application.Transactions;

/// <summary>
/// Validates the data required to create a transaction.
/// </summary>
public sealed class CreateTransactionCommandValidator
{
    /// <summary>
    /// Validates the specified command.
    /// </summary>
    public IReadOnlyCollection<ApplicationError> Validate(CreateTransactionCommand command)
    {
        var errors = new List<ApplicationError>();

        if (command.BookingDate == default)
        {
            errors.Add(new ApplicationError(
                "transactions.booking_date_required",
                "Booking date is required."));
        }

        if (string.IsNullOrWhiteSpace(command.Description))
        {
            errors.Add(new ApplicationError(
                "transactions.description_required",
                "Description is required."));
        }

        if (command.Amount == 0)
        {
            errors.Add(new ApplicationError(
                "transactions.amount_cannot_be_zero",
                "Amount cannot be zero."));
        }

        if (string.IsNullOrWhiteSpace(command.Currency))
        {
            errors.Add(new ApplicationError(
                "transactions.currency_required",
                "Currency is required."));
        }
        else if (command.Currency.Trim().Length != 3)
        {
            errors.Add(new ApplicationError(
                "transactions.currency_invalid",
                "Currency must be a 3-letter ISO code."));
        }

        return errors;
    }
}