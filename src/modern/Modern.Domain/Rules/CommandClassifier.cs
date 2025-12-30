using Modern.Domain.Models;

namespace Modern.Domain.Rules;

/// <summary>
/// Classifies commands using C# 13 pattern matching.
/// Declarative business rules with improved readability.
/// </summary>
public static class CommandClassifier
{
    public static string Classify(OperationCommand command) =>
        command.CommandName switch
        {
            { Length: < 5 } => "Simple",
            var name when name.StartsWith("Run") => "Execution",
            _ => "Administrative"
        };
}

