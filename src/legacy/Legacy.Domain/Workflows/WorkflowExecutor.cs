using Legacy.Domain.Models;

namespace Legacy.Domain.Workflows;

/// <summary>
/// Workflow executor in legacy implementation.
/// Uses method overloads for optional behavior.
/// </summary>
public static class WorkflowExecutor
{
    public static void Execute(OperationCommand command)
    {
        Execute(command, true);
    }

    public static void Execute(OperationCommand command, bool log)
    {
        if (log)
            Console.WriteLine($"Executing: {command.CommandName}");
    }
}

