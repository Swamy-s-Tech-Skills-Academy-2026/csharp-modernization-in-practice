using Modern.Domain.Models;
using Modern.Domain.Policies;

namespace Modern.Domain.Rules;

/// <summary>
/// Evaluates command safety using C# 12 ref readonly parameter.
/// Expresses immutability intent and prevents accidental mutation.
/// </summary>
public static class CommandSafetyEvaluator
{
    public static bool IsSafe(ref readonly OperationCommand command)
    {
        return !DefaultPolicies.RestrictedCommands
            .Contains(command.CommandName);
    }
}

