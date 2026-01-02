using Modern.Domain.Models;
using Modern.Domain.Rules;

namespace Modern.Tests.Domain;

public class CommandClassifierTests
{
    [Fact]
    public void Run_Command_Should_Be_Classified_As_Execution()
    {
        var cmd = new OperationCommand("RunSync", DateTime.UtcNow, "system");

        var classification = CommandClassifier.Classify(cmd);

        Assert.Equal("Execution", classification);
    }

    [Fact]
    public void Short_Command_Should_Be_Classified_As_Simple()
    {
        var cmd = new OperationCommand("Test", DateTime.UtcNow, "system");

        var classification = CommandClassifier.Classify(cmd);

        Assert.Equal("Simple", classification);
    }
}

