namespace Modern.Domain.Models;

/// <summary>
/// Represents an operational command using C# 12 primary constructor.
/// Removes constructor + field boilerplate while preserving immutability.
/// </summary>
public sealed class OperationCommand(
    string commandName,
    DateTime requestedAt,
    string requestedBy)
{
    public string CommandName { get; } = commandName;
    public DateTime RequestedAt { get; } = requestedAt;
    public string RequestedBy { get; } = requestedBy;
}

