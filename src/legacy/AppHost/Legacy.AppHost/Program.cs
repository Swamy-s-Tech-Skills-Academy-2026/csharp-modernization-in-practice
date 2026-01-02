using System.Text;
using Legacy.Domain.Models;
using Legacy.Domain.Rules;
using Legacy.Domain.Workflows;

// Set console encoding to UTF-8 for proper emoji/icon display
Console.OutputEncoding = Encoding.UTF8;

// Header
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║     C# Modernization in Practice - Legacy Implementation       ║");
Console.WriteLine("║              Traditional C# (Pre-C# 12 Style)                  ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
Console.ResetColor();
Console.WriteLine();

// Traditional C# Features Used
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("📋 Traditional C# Patterns Demonstrated:");
Console.ResetColor();
Console.WriteLine("   • Explicit constructors with parameter assignments");
Console.WriteLine("   • Traditional collection initialization (new List<T>)");
Console.WriteLine("   • Value parameter passing");
Console.WriteLine("   • Traditional array initialization");
Console.WriteLine("   • If-else conditional logic");
Console.WriteLine("   • Method overloads for optional behavior");
Console.WriteLine();

// Command Creation
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("🔧 Creating Operation Command...");
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

// Safety Evaluation
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("🔒 Evaluating Command Safety (Traditional Parameter Passing)...");
Console.ResetColor();

if (!CommandSafetyEvaluator.IsSafe(command))
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

// Workflow Execution
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("⚙️  Executing Workflow (Method Overload Pattern)...");
Console.ResetColor();
WorkflowExecutor.Execute(command);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("   ✅ Command executed successfully.");
Console.ResetColor();
Console.WriteLine();

// Footer
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║              Legacy Implementation Completed                   ║");
Console.WriteLine("║     Compare with Modern implementation to see improvements     ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
Console.ResetColor();
