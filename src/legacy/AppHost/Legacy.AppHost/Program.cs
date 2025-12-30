using Legacy.Domain.Models;
using Legacy.Domain.Rules;
using Legacy.Domain.Workflows;

var command = new OperationCommand(
    "RunReport",
    DateTime.UtcNow,
    "system");

if (!CommandSafetyEvaluator.IsSafe(command))
{
    Console.WriteLine("Command is not allowed.");
    return;
}

WorkflowExecutor.Execute(command);
Console.WriteLine("Command executed successfully.");
