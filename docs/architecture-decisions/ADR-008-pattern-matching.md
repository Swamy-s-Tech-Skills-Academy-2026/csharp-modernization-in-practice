# ADR-008: Use Pattern Matching for Business Rule Classification

**Status:** Accepted  
**Date:** 2025-12-30  
**Applies to:** C# 13+

## Context

Business rule classification used traditional if-else chains. This made it difficult to see all classification rules at once and to ensure completeness.

## Decision

Use pattern matching (switch expressions) for business rule classification. This makes rules declarative and easier to reason about.

## Consequences

### Positive

- **Declarative business rules**: Rules are expressed clearly and concisely
- **Easier reasoning**: All classification cases are visible in one expression
- **Safer extension**: Adding new cases is explicit
- **Compiler assistance**: Compiler helps ensure completeness

### Negative

- **Learning curve**: Developers may need to understand pattern matching syntax
- **Not suitable for all cases**: Very complex conditions may still benefit from if-else

## Example

### Before (Traditional)

```csharp
public static string Classify(OperationCommand command)
{
    if (command.CommandName.Length < 5)
        return "Simple";

    if (command.CommandName.StartsWith("Run"))
        return "Execution";

    return "Administrative";
}
```

### After (C# 13)

```csharp
public static string Classify(OperationCommand command) =>
    command.CommandName switch
    {
        { Length: < 5 } => "Simple",
        var name when name.StartsWith("Run") => "Execution",
        _ => "Administrative"
    };
```

## Notes

Pattern matching is ideal for:
- Business rule classification
- Data routing based on properties
- Policy decisions based on object state
- Command pattern implementations

For very complex conditional logic, traditional if-else may still be more readable.

