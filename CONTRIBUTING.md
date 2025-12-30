# Contributing to C# Modernization in Practice

This repository demonstrates how selected C# 12, 13, and 14 language features can be applied to modernize an existing console-based application.

## Purpose

This repository focuses on **practical, high-impact improvements** in readability, safety, and maintainability. The focus is not on showcasing every new feature, but on demonstrating how incremental language upgrades improve code quality without architectural rewrites.

## Repository Structure

See [`docs/01_repository-structure.md`](docs/01_repository-structure.md) for the complete repository structure (single source of truth). See [README.md](README.md) for the learning path and modernization overview.

## Focus Areas

This repository demonstrates:

- **C# 12 Features**: Primary constructors, collection expressions, `ref readonly` parameters, type aliases
- **C# 13 Features**: Pattern matching improvements, required members evolution
- **C# 14 Features**: Switch expressions, declarative policies

Each modernization step follows a **Before → After → Why it matters** pattern.

## Code Contribution Guidelines

### Before/After Structure

- **Legacy code** (`src/legacy/`) represents traditional C# style (pre-C# 12)
- **Modern code** (`src/modern/`) shows modernized implementations using C# 12–14
- Maintain parallel structure between legacy and modern for easy comparison

### Modernization Principles

1. **Incremental**: Changes should be incremental, not disruptive
2. **Comparable**: Every change should be easily comparable between legacy and modern
3. **Testable**: All changes must have corresponding tests
4. **Documented**: Architecture decisions should be documented in `docs/architecture-decisions/`

### Test Requirements

- Same test cases should be applied to both legacy and modern implementations
- Tests should validate correctness and demonstrate benefits
- Test projects should target `.NET 10`

## Architecture Decision Records (ADRs)

When making significant modernization decisions, create an ADR in `docs/architecture-decisions/`:

- Document the context
- Explain the decision
- Describe consequences and trade-offs

See existing ADRs for examples:

- ADR-001: Primary Constructors
- ADR-002: Collection Expressions
- ADR-003: `ref readonly` Parameters
- ADR-004: Switch Expressions

## Notes

- This repository focuses on language-level modernization, not architectural rewrites
- The goal is to show how modern C# improves code quality without changing the problem domain
- All examples should be realistic and applicable to enterprise codebases
