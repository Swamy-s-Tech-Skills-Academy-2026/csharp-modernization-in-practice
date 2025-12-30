using Modern.Domain.Models;

namespace Modern.Domain.Workflows;

/// <summary>
/// Workflow executor using C# 12 default lambda parameters.
/// Avoids multiple overloads and enables flexible orchestration.
/// </summary>
public static class WorkflowExecutor
{
    public static void Execute(
        OperationCommand command,
        Action<OperationCommand, bool> step =
            (cmd, log) => { if (log) Console.WriteLine($"Executing: {cmd.CommandName}"); })
    {
        step(command, log: true);
    }
}

