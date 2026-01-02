using Legacy.Domain.Models;

namespace Legacy.Domain.Rules;

/// <summary>
/// Classifies commands in legacy implementation.
/// Uses traditional if-else logic.
/// </summary>
public static class CommandClassifier
{
    public static string Classify(OperationCommand command)
    {
        if (command.CommandName.Length < 5)
            return "Simple";

        if (command.CommandName.StartsWith("Run"))
            return "Execution";

        return "Administrative";
    }
}

