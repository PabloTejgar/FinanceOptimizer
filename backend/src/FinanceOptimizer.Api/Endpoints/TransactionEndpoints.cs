using FinanceOptimizer.Application.Common;
using FinanceOptimizer.Application.Transactions;

namespace FinanceOptimizer.Api.Endpoints;

/// <summary>
/// Provides transaction HTTP endpoints.
/// </summary>
public static class TransactionEndpoints
{
    /// <summary>
    /// Maps transaction endpoints.
    /// </summary>
    public static IEndpointRouteBuilder MapTransactionEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/transactions")
            .WithTags("Transactions");

        group.MapPost("/", async (
            CreateTransactionRequest request,
            CreateTransactionUseCase useCase,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateTransactionCommand(
                request.BookingDate,
                request.Description,
                request.Amount,
                request.Currency);

            var result = await useCase.ExecuteAsync(command, cancellationToken);

            if (!result.IsSuccess)
            {
                return Results.BadRequest(new ValidationErrorResponse(result.Errors));
            }

            var transactionId = result.Value!;

            return Results.Created(
                $"/transactions/{transactionId}",
                new CreateTransactionResponse(transactionId));
        });

        group.MapGet("/", async (
            ITransactionRepository repository,
            CancellationToken cancellationToken) =>
        {
            var transactions = await repository.GetAllAsync(cancellationToken);

            var response = transactions
                .Select(transaction => new TransactionResponse(
                    transaction.Id,
                    transaction.BookingDate,
                    transaction.Description,
                    transaction.Amount.Amount,
                    transaction.Amount.Currency,
                    transaction.Category.ToString()))
                .ToList();

            return Results.Ok(response);
        });

        return endpoints;
    }
}

/// <summary>
/// Request used to create a transaction.
/// </summary>
public sealed record CreateTransactionRequest(
    DateOnly BookingDate,
    string Description,
    decimal Amount,
    string Currency);

/// <summary>
/// HTTP response returned when a transaction is created.
/// </summary>
public sealed record CreateTransactionResponse(Guid Id);

/// <summary>
/// HTTP response returned for a transaction.
/// </summary>
public sealed record TransactionResponse(
    Guid Id,
    DateOnly BookingDate,
    string Description,
    decimal Amount,
    string Currency,
    string Category);

/// <summary>
/// HTTP response returned when validation fails.
/// </summary>
public sealed record ValidationErrorResponse(
    IReadOnlyCollection<ApplicationError> Errors);