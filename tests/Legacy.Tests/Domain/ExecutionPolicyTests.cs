using Legacy.Domain.Models;
using Legacy.Domain.Policies;

namespace Legacy.Tests.Domain;

public class ExecutionPolicyTests
{
    [Fact]
    public void RunReport_Should_Have_Thirty_Second_Timeout()
    {
        var cmd = new OperationCommand("RunReport", DateTime.UtcNow, "system");

        var timeout = ExecutionPolicy.GetTimeout(cmd);

        Assert.Equal(TimeSpan.FromSeconds(30), timeout);
    }

    [Fact]
    public void RunSync_Should_Have_Two_Minute_Timeout()
    {
        var cmd = new OperationCommand("RunSync", DateTime.UtcNow, "system");

        var timeout = ExecutionPolicy.GetTimeout(cmd);

        Assert.Equal(TimeSpan.FromMinutes(2), timeout);
    }
}

