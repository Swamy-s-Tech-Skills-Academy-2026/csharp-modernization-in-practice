using Modern.Domain.Models;
using Modern.Domain.Workflows;

namespace Modern.Tests.Workflows;

public class WorkflowExecutorTests
{
    [Fact]
    public void Workflow_Should_Execute_With_Default_Step()
    {
        var cmd = new OperationCommand("RunCheck", DateTime.UtcNow, "system");

        // Should not throw
        WorkflowExecutor.Execute(cmd);
    }

    [Fact]
    public void Workflow_Should_Allow_Custom_Execution_Step()
    {
        var invoked = false;
        var cmd = new OperationCommand("RunCheck", DateTime.UtcNow, "system");

        WorkflowExecutor.Execute(
            cmd,
            (c, _) => invoked = true);

        Assert.True(invoked);
    }
}

