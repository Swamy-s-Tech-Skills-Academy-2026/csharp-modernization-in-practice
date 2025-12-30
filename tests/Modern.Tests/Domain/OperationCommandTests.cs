using Modern.Domain.Models;

namespace Modern.Tests.Domain;

public class OperationCommandTests
{
    [Fact]
    public void OperationCommand_Should_Preserve_Constructor_Values()
    {
        var now = DateTime.UtcNow;
        var cmd = new OperationCommand("RunReport", now, "system");

        Assert.Equal("RunReport", cmd.CommandName);
        Assert.Equal(now, cmd.RequestedAt);
        Assert.Equal("system", cmd.RequestedBy);
    }
}

