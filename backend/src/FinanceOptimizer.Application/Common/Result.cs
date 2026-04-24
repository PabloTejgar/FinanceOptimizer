namespace FinanceOptimizer.Application.Common;

/// <summary>
/// Represents the result of an application operation.
/// </summary>
public sealed class Result<T>
{
    /// <summary>
    /// Indicates whether the operation succeeded.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Value returned by the operation when successful.
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// Errors returned by the operation when failed.
    /// </summary>
    public IReadOnlyCollection<ApplicationError> Errors { get; }

    private Result(T value)
    {
        IsSuccess = true;
        Value = value;
        Errors = Array.Empty<ApplicationError>();
    }

    private Result(IReadOnlyCollection<ApplicationError> errors)
    {
        IsSuccess = false;
        Value = default;
        Errors = errors;
    }

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    public static Result<T> Success(T value) => new(value);

    /// <summary>
    /// Creates a failed result.
    /// </summary>
    public static Result<T> Failure(params ApplicationError[] errors) => new(errors);
}