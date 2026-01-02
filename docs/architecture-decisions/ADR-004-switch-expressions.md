# ADR-004: Centralize Business Rules with Switch Expressions

**Status:** Accepted  
**Date:** 2025-12-30  
**Applies to:** C# 13-14

## Context

Business rules and policy decisions were scattered across multiple conditional blocks. This made it difficult to reason about all possible cases, review policy logic, and ensure completeness.

## Decision

Use switch expressions to model decision tables explicitly. This centralizes business rules and makes them easier to reason about and review.

## Consequences

### Positive

- **Declarative rule definitions**: Rules are expressed as data-like structures
- **Easier reasoning**: All cases are visible in one place
- **Compiler assistance**: Compiler helps enforce completeness
- **Better reviewability**: Reviewers can see all policy decisions at once
- **Safer extension**: Adding new cases is explicit and visible

### Negative

- **Learning curve**: Developers may need to understand switch expression syntax
- **Not suitable for complex logic**: Very complex conditions may still benefit from if-else

## Example

### Before (Traditional)

```csharp
public static TimeSpan GetTimeout(OperationCommand command)
{
    if (command.CommandName == "RunReport")
        return TimeSpan.FromSeconds(30);

    if (command.CommandName == "RunSync")
        return TimeSpan.FromMinutes(2);

    return TimeSpan.FromSeconds(10);
}
```

### After (C# 14)

```csharp
public static TimeSpan GetTimeout(OperationCommand command) =>
    command.CommandName switch
    {
        "RunReport" => TimeSpan.FromSeconds(30),
        "RunSync" => TimeSpan.FromMinutes(2),
        _ => TimeSpan.FromSeconds(10)
    };
```

## Notes

Switch expressions are ideal for:
- Policy tables
- Configuration mappings
- Simple business rule routing
- Command pattern implementations

For complex conditional logic with multiple conditions per branch, traditional if-else may still be more readable.

