# ADR-006: Use Type Aliases for Complex Result Types

**Status:** Accepted  
**Date:** 2025-12-30  
**Applies to:** C# 12+

## Context

Complex tuple return types reduced readability and made it difficult to understand the semantic meaning of return values. Long tuple type signatures added cognitive load.

## Decision

Use type aliases (using aliases) for complex return types, especially tuples. This improves readability and makes intent explicit.

## Consequences

### Positive

- **Improved readability**: Shorter, semantic type names
- **Semantic clarity**: Type names express intent, not just structure
- **Easier refactoring**: Changing the underlying type only requires updating the alias
- **Better documentation**: Type names serve as inline documentation

### Negative

- **Namespace management**: Aliases must be defined in appropriate scopes
- **Tooling**: Some IDEs may not show aliases as prominently as concrete types

## Example

### Before (Traditional)

```csharp
public static (bool Success, string Message, DateTime CompletedAt)
    CreateSuccess(string message)
{
    return (true, message, DateTime.UtcNow);
}
```

### After (C# 12)

```csharp
using ExecutionResult =
    (bool Success, string Message, DateTime CompletedAt);

public static ExecutionResult Success(string message) =>
    (true, message, DateTime.UtcNow);
```

## Notes

Type aliases are ideal for:
- Complex tuple types
- Frequently used generic types
- Result types that appear in multiple places
- Types that benefit from semantic naming

Avoid creating aliases for simple, well-understood types where the alias adds no value.

