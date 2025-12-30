# ADR-007: Use Inline Arrays for Fixed-Size Buffers (Selective)

**Status:** Accepted  
**Date:** 2025-12-30  
**Applies to:** C# 12+

## Context

Small fixed-size collections used traditional arrays, which allocated on the heap. For performance-sensitive validation logic with small, fixed collections, this added unnecessary allocation overhead.

## Decision

Use inline arrays selectively for small, fixed-size buffers in performance-sensitive code paths. This demonstrates performance awareness without unsafe code.

## Consequences

### Positive

- **Zero allocations**: Inline arrays are stack-allocated
- **Performance awareness**: Demonstrates understanding of allocation costs
- **Safer than pointers**: Type-safe alternative to unsafe code
- **Explicit intent**: Fixed-size nature is clear in the code

### Negative

- **Complexity**: More complex than traditional arrays
- **Limited use cases**: Only suitable for small, fixed-size collections
- **Learning curve**: Developers need to understand inline array syntax

## Example

### Before (Traditional)

```csharp
private static readonly string[] Prefixes =
{
    "Run", "Query", "Check"
};
```

### After (C# 12)

```csharp
[InlineArray(3)]
private struct AllowedPrefixes
{
    private string _element0;
}

private static readonly AllowedPrefixes Prefixes =
    new() { "Run", "Query", "Check" };
```

## Notes

**Important Constraint**: Use inline arrays sparingly and only when:
- The collection size is small and fixed
- Performance is a concern
- The code path is hot
- The intent is clear from context

Avoid overusing inline arrays. For most scenarios, traditional arrays or collections are more appropriate and maintainable.

