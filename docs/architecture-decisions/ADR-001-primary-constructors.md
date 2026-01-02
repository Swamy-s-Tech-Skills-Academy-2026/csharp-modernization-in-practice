# ADR-001: Use Primary Constructors for Domain Models

**Status:** Accepted  
**Date:** 2025-12-30  
**Applies to:** C# 12+

## Context

Domain models contained repetitive constructor and property boilerplate. The traditional approach required explicit constructor definitions with parameter assignments, adding noise without improving clarity.

## Decision

Adopt primary constructors for simple, immutable domain entities. This reduces boilerplate while maintaining the same runtime behavior and immutability guarantees.

## Consequences

### Positive

- **Reduced code size**: Approximately 30-40% reduction in boilerplate for domain models
- **Clearer intent**: Constructor parameters are immediately visible in the class declaration
- **Easier code review**: Less code to review, faster comprehension
- **No runtime impact**: Primary constructors compile to the same IL as traditional constructors

### Negative

- **Learning curve**: Developers unfamiliar with C# 12 may need brief orientation
- **Tooling**: Some older IDE versions may not fully support primary constructor syntax highlighting

## Example

### Before (Traditional)

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

### After (C# 12)

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

## Notes

This decision applies to simple, immutable domain models. Complex constructors with validation logic or initialization logic may still benefit from explicit constructors.

