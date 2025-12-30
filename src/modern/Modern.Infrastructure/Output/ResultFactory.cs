using System;
using ExecutionResult =
    (bool Success, string Message, DateTime CompletedAt);

namespace Modern.Infrastructure.Output;

/// <summary>
/// Result factory using C# 12 type aliases for complex types.
/// Improves readability of complex return types.
/// </summary>
public static class ResultFactory
{
    public static ExecutionResult Success(string message) =>
        (true, message, DateTime.UtcNow);

    public static ExecutionResult Failure(string message) =>
        (false, message, DateTime.UtcNow);
}

