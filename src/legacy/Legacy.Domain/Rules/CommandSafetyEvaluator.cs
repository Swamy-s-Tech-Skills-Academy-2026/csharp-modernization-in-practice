using Legacy.Domain.Models;
using Legacy.Domain.Policies;

namespace Legacy.Domain.Rules;

/// <summary>
/// Evaluates command safety in legacy implementation.
/// Uses traditional parameter passing.
/// </summary>
public static class CommandSafetyEvaluator
{
    public static bool IsSafe(OperationCommand command)
    {
        return !DefaultPolicies.RestrictedCommands
            .Contains(command.CommandName);
    }
}

