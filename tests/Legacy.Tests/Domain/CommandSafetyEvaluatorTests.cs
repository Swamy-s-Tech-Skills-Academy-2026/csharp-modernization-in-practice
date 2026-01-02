using Legacy.Domain.Models;
using Legacy.Domain.Rules;

namespace Legacy.Tests.Domain;

public class CommandSafetyEvaluatorTests
{
    [Fact]
    public void Restricted_Command_Should_Be_Unsafe()
    {
        var cmd = new OperationCommand("ShutdownSystem", DateTime.UtcNow, "admin");

        var isSafe = CommandSafetyEvaluator.IsSafe(cmd);

        Assert.False(isSafe);
    }

    [Fact]
    public void Safe_Command_Should_Be_Allowed()
    {
        var cmd = new OperationCommand("RunReport", DateTime.UtcNow, "system");

        var isSafe = CommandSafetyEvaluator.IsSafe(cmd);

        Assert.True(isSafe);
    }
}

