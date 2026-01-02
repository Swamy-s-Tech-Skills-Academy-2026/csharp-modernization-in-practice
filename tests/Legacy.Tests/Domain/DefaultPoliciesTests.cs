using Legacy.Domain.Policies;

namespace Legacy.Tests.Domain;

public class DefaultPoliciesTests
{
    [Fact]
    public void RestrictedCommands_Should_Contain_Shutdown()
    {
        Assert.Contains("ShutdownSystem", DefaultPolicies.RestrictedCommands);
    }

    [Fact]
    public void RestrictedCommands_Should_Contain_DeleteAll()
    {
        Assert.Contains("DeleteAll", DefaultPolicies.RestrictedCommands);
    }
}

