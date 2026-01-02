namespace Legacy.Infrastructure.Output;

/// <summary>
/// Result factory in the legacy implementation.
/// Provides a stable shape for callers without relying on type aliasing.
/// </summary>
public static class ResultFactory
{
    public static ExecutionResult Success(string message) =>
        new(true, message, DateTime.UtcNow);

    public static ExecutionResult Failure(string message) =>
        new(false, message, DateTime.UtcNow);
}
