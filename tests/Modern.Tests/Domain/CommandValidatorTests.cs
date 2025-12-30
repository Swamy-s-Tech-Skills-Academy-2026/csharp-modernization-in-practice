using Modern.Domain.Rules;

namespace Modern.Tests.Domain;

public class CommandValidatorTests
{
    [Theory]
    [InlineData("RunReport")]
    [InlineData("QueryStatus")]
    [InlineData("CheckHealth")]
    public void Command_With_Valid_Prefix_Should_Pass(string command)
    {
        Assert.True(CommandValidator.HasValidPrefix(command));
    }

    [Theory]
    [InlineData("InvalidCommand")]
    [InlineData("Test")]
    public void Command_With_Invalid_Prefix_Should_Fail(string command)
    {
        Assert.False(CommandValidator.HasValidPrefix(command));
    }
}

