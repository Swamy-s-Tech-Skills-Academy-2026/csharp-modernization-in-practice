using Modern.Domain.Models;
using Modern.Domain.Rules;
using Modern.Domain.Workflows;

var command = new OperationCommand(
    "RunReport",
    DateTime.UtcNow,
    "system");

if (!CommandSafetyEvaluator.IsSafe(ref command))
{
    Console.WriteLine("Command is not allowed.");
    return;
}

WorkflowExecutor.Execute(command);
Console.WriteLine("Command executed successfully.");
