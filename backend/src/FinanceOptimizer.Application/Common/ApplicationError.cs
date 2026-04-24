namespace FinanceOptimizer.Application.Common;

/// <summary>
/// Represents an application-level error.
/// </summary>
public sealed record ApplicationError(string Code, string Message);