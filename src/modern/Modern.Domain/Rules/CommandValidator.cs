using System.Runtime.CompilerServices;

namespace Modern.Domain.Rules;

/// <summary>
/// Validates command names using C# 12 inline arrays.
/// Demonstrates low-allocation validation logic with fixed-size buffers.
/// </summary>
public static class CommandValidator
{
    [InlineArray(3)]
    private struct AllowedPrefixes
    {
        private string _element0;
    }

    private static readonly AllowedPrefixes Prefixes =
        new() { "Run", "Query", "Check" };

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

