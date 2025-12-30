namespace Legacy.Domain.Rules;

/// <summary>
/// Validates command names in legacy implementation.
/// Uses traditional array initialization.
/// </summary>
public static class CommandValidator
{
    private static readonly string[] Prefixes =
    {
        "Run", "Query", "Check"
    };

    public static bool HasValidPrefix(string commandName)
    {
        foreach (var prefix in Prefixes)
        {
            if (commandName.StartsWith(prefix))
                return true;
        }
        return false;
    }
}

