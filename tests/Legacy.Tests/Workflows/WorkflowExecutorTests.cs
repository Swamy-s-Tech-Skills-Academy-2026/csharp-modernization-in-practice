using Legacy.Domain.Models;
using Legacy.Domain.Workflows;

namespace Legacy.Tests.Workflows;

public class WorkflowExecutorTests
{
    [Fact]
    public void Workflow_Should_Execute_With_Default_Logging()
    {
        var cmd = new OperationCommand("RunCheck", DateTime.UtcNow, "system");

        // Should not throw
        WorkflowExecutor.Execute(cmd);
    }

    [Fact]
    public void Workflow_Should_Execute_With_Custom_Logging()
    {
        var cmd = new OperationCommand("RunCheck", DateTime.UtcNow, "system");

        // Should not throw
        WorkflowExecutor.Execute(cmd, log: false);
    }
}

