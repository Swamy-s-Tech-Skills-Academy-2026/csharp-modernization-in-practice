# ADR-005: Use Default Lambda Parameters for Flexible Workflows

**Status:** Accepted  
**Date:** 2025-12-30  
**Applies to:** C# 12+

## Context

Workflow execution required multiple method overloads to support optional behavior. This led to overload explosion and made it difficult to extend workflows with custom steps.

## Decision

Use default lambda parameters to provide flexible workflow execution with optional customization. This avoids multiple overloads while maintaining clean APIs.

## Consequences

### Positive

- **Fewer overloads**: Single method signature handles multiple scenarios
- **Flexible orchestration**: Callers can customize behavior without creating new methods
- **Cleaner APIs**: Less method proliferation
- **Extensibility**: Easy to add new workflow steps without breaking changes

### Negative

- **Learning curve**: Developers may need to understand default lambda parameter syntax
- **Debugging**: Default lambda parameters may be less visible in stack traces

## Example

### Before (Traditional)

```csharp
public static void Execute(OperationCommand command)
{
    Execute(command, true);
}

public static void Execute(OperationCommand command, bool log)
{
    if (log)
        Console.WriteLine(command.CommandName);
}
```

### After (C# 12)

```csharp
public static void Execute(
    OperationCommand command,
    Action<OperationCommand, bool> step =
        (cmd, log) => { if (log) Console.WriteLine(cmd.CommandName); })
{
    step(command, log: true);
}
```

## Notes

Default lambda parameters are particularly useful for:
- Workflow orchestration
- Pipeline processing
- Optional behavior injection
- Testability (easy to inject test doubles)

Avoid using default lambda parameters when the default behavior is complex or when it obscures the API contract.

