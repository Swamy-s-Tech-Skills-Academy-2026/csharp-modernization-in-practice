using Modern.Infrastructure.Output;

namespace Modern.Tests.Infrastructure;

public class ResultFactoryTests
{
    [Fact]
    public void ExecutionResult_Should_Return_Success()
    {
        var result = ResultFactory.Success("Completed");

        Assert.True(result.Success);
        Assert.Equal("Completed", result.Message);
    }

    [Fact]
    public void ExecutionResult_Should_Return_Failure()
    {
        var result = ResultFactory.Failure("Error occurred");

        Assert.False(result.Success);
        Assert.Equal("Error occurred", result.Message);
    }
}

