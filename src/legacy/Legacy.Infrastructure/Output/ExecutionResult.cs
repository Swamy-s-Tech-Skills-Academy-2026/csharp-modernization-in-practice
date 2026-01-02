namespace Legacy.Infrastructure.Output;

/// <summary>
/// Legacy execution result type.
/// Uses an explicit class to model the result shape.
/// </summary>
public sealed class ExecutionResult
{
    public bool Success { get; }
    public string Message { get; }
    public DateTime CompletedAt { get; }

    public ExecutionResult(bool success, string message, DateTime completedAt)
    {
        Success = success;
        Message = message;
        CompletedAt = completedAt;
    }
}
