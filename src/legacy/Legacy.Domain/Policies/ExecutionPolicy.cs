using Legacy.Domain.Models;

namespace Legacy.Domain.Policies;

/// <summary>
/// Execution policy in legacy implementation.
/// Uses traditional if-else for policy decisions.
/// </summary>
public static class ExecutionPolicy
{
    public static TimeSpan GetTimeout(OperationCommand command)
    {
        if (command.CommandName == "RunReport")
            return TimeSpan.FromSeconds(30);

        if (command.CommandName == "RunSync")
            return TimeSpan.FromMinutes(2);

        return TimeSpan.FromSeconds(10);
    }
}

