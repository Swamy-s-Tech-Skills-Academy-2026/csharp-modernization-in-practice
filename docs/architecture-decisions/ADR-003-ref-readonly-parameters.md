# ADR-003: Use `ref readonly` for Read-Only Evaluation APIs

**Status:** Accepted  
**Date:** 2025-12-30  
**Applies to:** C# 12+

## Context

Evaluation methods and inspectors did not mutate inputs but allowed mutation accidentally. Traditional value parameter passing could lead to defensive copying or accidental mutations, and did not communicate immutability intent at the API boundary.

## Decision

Mark parameters as `ref readonly` for evaluation and inspection methods that do not mutate their inputs. This expresses immutability intent and prevents accidental mutation.

## Consequences

### Positive

- **Compiler-enforced safety**: Prevents accidental mutation of parameters
- **Clearer API contracts**: Callers understand the method will not modify the input
- **Performance awareness**: Signals intent to avoid unnecessary copying
- **Minimal call-site impact**: Callers use `ref` keyword, which is explicit and clear

### Negative

- **Call-site verbosity**: Requires `ref` keyword at call sites
- **Learning curve**: Developers may need to understand `ref readonly` semantics

## Example

### Before (Traditional)

```csharp
public static bool IsSafe(OperationCommand command)
{
    return !RestrictedCommands.Contains(command.CommandName);
}
```

### After (C# 12)

```csharp
public static bool IsSafe(ref readonly OperationCommand command)
{
    return !RestrictedCommands.Contains(command.CommandName);
}
```

### Call Site

```csharp
var cmd = new OperationCommand("RunReport", DateTime.UtcNow, "system");
var isSafe = CommandSafetyEvaluator.IsSafe(ref cmd);
```

## Notes

This pattern is particularly useful for:
- Evaluators and validators
- Policy engines
- Read-only inspection logic
- Performance-sensitive code paths

Avoid using `ref readonly` for simple value types or when the overhead is not justified.

