namespace Modern.Domain.Policies;

/// <summary>
/// Default operational policies using C# 12 collection expressions.
/// Cleaner initialization with less noise.
/// </summary>
public static class DefaultPolicies
{
    public static readonly IReadOnlyList<string> RestrictedCommands =
    [
        "DeleteAll",
        "ShutdownSystem",
        "ResetEnvironment"
    ];
}

