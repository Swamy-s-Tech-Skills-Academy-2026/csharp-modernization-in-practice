using Modern.Domain.Models;

namespace Modern.Domain.Workflows;

/// <summary>
/// Workflow executor using C# 12 default lambda parameters.
/// Note: Default lambda parameters must be null and checked, as they cannot be compile-time constants.
/// This demonstrates the pattern while working within language constraints.
/// </summary>
public static class WorkflowExecutor
{
    public static void Execute(
        OperationCommand command,
        Action<OperationCommand, bool>? step = null)
    {
        step ??= (cmd, log) => { if (log) Console.WriteLine($"Executing: {cmd.CommandName}"); };
        step(command, true);
    }
}

