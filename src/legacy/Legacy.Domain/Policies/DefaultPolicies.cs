namespace Legacy.Domain.Policies;

/// <summary>
/// Default operational policies in legacy implementation.
/// Uses traditional collection initialization.
/// </summary>
public static class DefaultPolicies
{
    public static readonly IReadOnlyList<string> RestrictedCommands =
        new List<string>
        {
            "DeleteAll",
            "ShutdownSystem",
            "ResetEnvironment"
        };
}

