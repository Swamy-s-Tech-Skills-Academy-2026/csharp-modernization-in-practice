namespace Legacy.Domain.Models;

/// <summary>
/// Represents an operational command in the legacy implementation.
/// Traditional C# style (pre-C# 12) with explicit constructor.
/// </summary>
public sealed class OperationCommand
{
    public string CommandName { get; }
    public DateTime RequestedAt { get; }
    public string RequestedBy { get; }

    public OperationCommand(
        string commandName,
        DateTime requestedAt,
        string requestedBy)
    {
        CommandName = commandName;
        RequestedAt = requestedAt;
        RequestedBy = requestedBy;
    }
}

