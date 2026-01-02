# ADR-002: Prefer Collection Expressions for Static Policies

**Status:** Accepted  
**Date:** 2025-12-30  
**Applies to:** C# 12+

## Context

Policy definitions and static configuration data were verbose and visually noisy. Traditional collection initialization required explicit type declarations and constructor calls, adding unnecessary syntax.

## Decision

Use collection expressions for static, read-only data. This applies to policy lists, default configurations, and other immutable collections.

## Consequences

### Positive

- **Improved readability**: Less syntax noise, clearer data focus
- **Easier policy scanning**: Policies are more visible and scannable
- **Consistent syntax**: Unified syntax across array, list, and span types
- **No behavioral change**: Collection expressions compile to appropriate collection types

### Negative

- **None significant**: Collection expressions are a pure syntax improvement

## Example

### Before (Traditional)

```csharp
public static readonly IReadOnlyList<string> RestrictedCommands =
    new List<string>
    {
        "DeleteAll",
        "ShutdownSystem",
        "ResetEnvironment"
    };
```

### After (C# 12)

```csharp
public static readonly IReadOnlyList<string> RestrictedCommands =
[
    "DeleteAll",
    "ShutdownSystem",
    "ResetEnvironment"
];
```

## Notes

Collection expressions work with arrays, lists, spans, and other collection types. The compiler selects the appropriate type based on the target type.

