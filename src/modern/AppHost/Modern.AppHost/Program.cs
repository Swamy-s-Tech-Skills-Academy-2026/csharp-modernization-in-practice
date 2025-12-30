using Modern.Domain.Models;
using Modern.Domain.Rules;
using Modern.Domain.Workflows;
using Modern.Domain.Policies;
using Modern.Infrastructure.Output;

// Header
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║     C# Modernization in Practice - Modern Implementation       ║");
Console.WriteLine("║              C# 12, 13, and 14 Features                        ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
Console.ResetColor();
Console.WriteLine();

// C# 12-14 Features Used
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("✨ Modern C# Features Demonstrated:");
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("   [C# 12] Primary Constructors");
Console.ResetColor();
Console.WriteLine("      → Reduces boilerplate in domain models");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("   [C# 12] Collection Expressions");
Console.ResetColor();
Console.WriteLine("      → Cleaner initialization syntax");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("   [C# 12] ref readonly Parameters");
Console.ResetColor();
Console.WriteLine("      → Expresses immutability intent");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("   [C# 12] Inline Arrays");
Console.ResetColor();
Console.WriteLine("      → Zero-allocation fixed-size buffers");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("   [C# 12] Type Aliases");
Console.ResetColor();
Console.WriteLine("      → Improved readability for complex types");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("   [C# 12] Default Lambda Parameters Pattern");
Console.ResetColor();
Console.WriteLine("      → Flexible workflow orchestration");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("   [C# 13] Pattern Matching");
Console.ResetColor();
Console.WriteLine("      → Declarative business rule classification");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("   [C# 14] Switch Expressions");
Console.ResetColor();
Console.WriteLine("      → Centralized policy decision tables");
Console.WriteLine();

// Command Creation (C# 12 Primary Constructor)
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("🔧 Creating Operation Command (C# 12 Primary Constructor)...");
Console.ResetColor();
var command = new OperationCommand(
    "RunReport",
    DateTime.UtcNow,
    "system");

Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine($"   Command: {command.CommandName}");
Console.WriteLine($"   Requested At: {command.RequestedAt:yyyy-MM-dd HH:mm:ss}");
Console.WriteLine($"   Requested By: {command.RequestedBy}");
Console.ResetColor();
Console.WriteLine();

// Command Validation (C# 12 Inline Arrays)
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("🔍 Validating Command Prefix (C# 12 Inline Arrays)...");
Console.ResetColor();
var hasValidPrefix = CommandValidator.HasValidPrefix(command.CommandName);
if (hasValidPrefix)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"   ✅ Valid prefix detected");
    Console.ResetColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"   ⚠️  Invalid prefix (continuing anyway)");
    Console.ResetColor();
}
Console.WriteLine();

// Command Classification (C# 13 Pattern Matching)
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("📊 Classifying Command (C# 13 Pattern Matching)...");
Console.ResetColor();
var classification = CommandClassifier.Classify(command);
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"   Category: {classification}");
Console.ResetColor();
Console.WriteLine();

// Timeout Policy (C# 14 Switch Expressions)
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("⏱️  Getting Execution Timeout (C# 14 Switch Expressions)...");
Console.ResetColor();
var timeout = ExecutionPolicy.GetTimeout(command);
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"   Timeout: {timeout.TotalSeconds} seconds");
Console.ResetColor();
Console.WriteLine();

// Safety Evaluation (C# 12 ref readonly)
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("🔒 Evaluating Command Safety (C# 12 ref readonly Parameter)...");
Console.ResetColor();

if (!CommandSafetyEvaluator.IsSafe(ref command))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("   ❌ Command is not allowed.");
    Console.ResetColor();
    Console.WriteLine();
    
    // Footer
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                    Execution Terminated                        ║");
    Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
    Console.ResetColor();
    return;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("   ✅ Command is safe to execute");
Console.ResetColor();
Console.WriteLine();

// Workflow Execution (C# 12 Default Lambda Parameters Pattern)
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("⚙️  Executing Workflow (C# 12 Default Lambda Parameters Pattern)...");
Console.ResetColor();
WorkflowExecutor.Execute(command);

// Result Factory (C# 12 Type Aliases)
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("📝 Creating Execution Result (C# 12 Type Aliases)...");
Console.ResetColor();
var result = ResultFactory.Success("Command completed successfully");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"   ✅ {result.Message}");
Console.WriteLine($"   Completed At: {result.CompletedAt:yyyy-MM-dd HH:mm:ss}");
Console.ResetColor();
Console.WriteLine();

// Footer
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║              Modern Implementation Completed                   ║");
Console.WriteLine("║     Modern C# features improve readability and maintainability ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
Console.ResetColor();
