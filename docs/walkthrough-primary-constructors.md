# Guided Walkthrough: Primary Constructors (C# 12)

This walkthrough demonstrates how primary constructors modernize a simple domain model while preserving behavior.

---

## Step 1: Legacy Implementation

```csharp
public sealed class OperationCommand
{
    public string CommandName { get; }
    public DateTime RequestedAt { get; }
    public string RequestedBy { get; }

    public OperationCommand(
        string commandName,
        DateTime requestedAt,
        string requestedBy)
    {
        CommandName = commandName;
        RequestedAt = requestedAt;
        RequestedBy = requestedBy;
    }
}
```

### Observations

- Boilerplate-heavy
- Constructor intent is split across multiple lines
- Noise obscures the domain concept

---

## Step 2: Modernized Implementation (C# 12)

```csharp
public sealed class OperationCommand(
    string commandName,
    DateTime requestedAt,
    string requestedBy)
{
    public string CommandName { get; } = commandName;
    public DateTime RequestedAt { get; } = requestedAt;
    public string RequestedBy { get; } = requestedBy;
}
```

### What Changed

- Constructor definition is explicit and compact
- No loss of clarity or safety
- Immutability is preserved

---

## Step 3: Behavioral Validation via Test

```csharp
[Fact]
public void OperationCommand_Should_Preserve_Values()
{
    var now = DateTime.UtcNow;

    var cmd = new OperationCommand("RunReport", now, "system");

    Assert.Equal("RunReport", cmd.CommandName);
    Assert.Equal(now, cmd.RequestedAt);
    Assert.Equal("system", cmd.RequestedBy);
}
```

### Result

- Behavior is unchanged
- Code is shorter and clearer
- Easier to review and maintain

---

## Key Takeaway

Primary constructors reduce accidental complexity without changing the mental model of the code.

This makes them ideal for **incremental modernization** of domain models.

