# Repository Structure

**Version**: 1.0  
**Last Updated**: December 30, 2025  
**Purpose**: Single source of truth for repository structure

> **Note**: This document should be referenced from `README.md` and other documentation files. When the structure changes, update this file first, then update references.

---

## Complete Repository Structure

```text
csharp-modernization-in-practice/
│
├── .github/
│   ├── workflows/
│   │   └── build-and-test.yml
│   └── pull_request_template.md
│
├── .gitignore
│
├── CODE_OF_CONDUCT.md
├── LICENSE
├── CONTRIBUTING.md
├── README.md
├── SECURITY.md
│
├── docs/
│   ├── 01_repository-structure.md (this file)
│   ├── architecture-decisions/
│   │   ├── ADR-001-primary-constructors.md
│   │   ├── ADR-002-collection-expressions.md
│   │   ├── ADR-003-ref-readonly-parameters.md
│   │   └── ADR-004-switch-expressions.md
│   ├── images/
│   │   └── .gitkeep
│   └── review-reports/
│       └── .gitkeep
│
├── src/
│   ├── legacy/
│   │   ├── AppHost/
│   │   │   └── Program.cs
│   │   ├── Domain/
│   │   │   ├── Models/
│   │   │   ├── Policies/
│   │   │   └── Rules/
│   │   └── Workflows/
│   │
│   └── modern/
│       ├── AppHost/
│       │   └── Program.cs
│       ├── Domain/
│       │   ├── Models/
│       │   ├── Policies/
│       │   └── Rules/
│       └── Workflows/
│
├── tests/
│   ├── Legacy.Tests/
│   │   ├── Domain/
│   │   └── Workflows/
│   │
│   └── Modern.Tests/
│       ├── Domain/
│       └── Workflows/
│
├── source-material/
│   └── intention-of-this-repo.md
│
└── tools/
    └── psscripts/
        ├── Compare-DocFiles.ps1
        ├── Find-DuplicateContent.ps1
        ├── Get-FileStats.ps1
        ├── Get-MarkdownSummary.ps1
        ├── Get-RepoStats.ps1
        ├── Quick-HealthCheck.ps1
        ├── Test-ContentCompliance.ps1
        ├── Validate-FileReferences.ps1
        └── Verify-ZeroCopy.ps1

```

---

## Key Structure Notes

### Repository Purpose

> **📋 Important**: This repository demonstrates how selected C# 12, 13, and 14 language features can be applied to modernize an existing console-based application. The focus is on **practical, high-impact improvements** in readability, safety, and maintainability.

This repository is organized to enable **side-by-side comparison** between legacy and modernized code:

- **Legacy code** (`src/legacy/`) represents traditional C# style (pre-C# 12)
- **Modern code** (`src/modern/`) shows modernized implementations using C# 12–14
- **Tests** validate correctness and demonstrate benefits of modernization

### File Naming Conventions

- **Source Files**: Use descriptive names that clearly indicate domain concepts
- **Organization**: Content organized by domain (Models, Policies, Rules, Workflows)
- **Structure**: Parallel structure between `legacy/` and `modern/` for easy comparison

### Content Organization

1. **Legacy Implementation** (`src/legacy/`): Traditional C# style, representative of existing systems
   - AppHost: Console application entry point
   - Domain: Business logic, models, policies, and rules
   - Workflows: Business process orchestration

2. **Modern Implementation** (`src/modern/`): Modernized code using C# 12–14 features
   - Same structure as legacy for direct comparison
   - Demonstrates practical application of modern language features

3. **Tests** (`tests/`): Unit tests for both implementations
   - Legacy.Tests: Tests for traditional implementation
   - Modern.Tests: Tests for modernized implementation
   - Same test cases applied to both to ensure correctness

4. **Architecture Decisions** (`docs/architecture-decisions/`): ADR-style documentation
   - Documents decisions about which C# features to adopt and why

### Special Directories

- **`docs/`**: Additional documentation, architecture decisions, images, and planning materials
- **`source-material/`**: Source materials and planning documents
- **`tools/`**: PowerShell scripts for repository maintenance and validation

---

## Purpose of Each Folder

### `src/legacy/`

Traditional C# implementation (pre-C# 12) that represents existing codebases. This serves as the baseline for comparison.

### `src/modern/`

Modernized implementation using C# 12–14 features. Each modernization step follows a **Before → After → Why it matters** pattern.

### `tests/`

Unit tests validating correctness and demonstrating benefits. Both implementations are tested with the same test cases to ensure behavioral equivalence.

### `docs/architecture-decisions/`

Architecture Decision Records (ADRs) documenting:

- Which C# features to adopt
- Context and rationale
- Consequences and trade-offs

---

## Update Protocol

**When repository structure changes**:

1. ✅ **Update this file first** (`docs/01_repository-structure.md`)
2. ✅ **Update references** in:
   - `README.md` - Reference this file
   - Other documentation files as needed
3. ✅ **Verify consistency** across all documentation

**Self-Check Question**: "Did I update `docs/01_repository-structure.md` first?" - If no, STOP and do it NOW.

---

## References

- **Repository Structure**: This file (`docs/01_repository-structure.md`)
- **Learning Path**: `README.md`
- **Architecture Decisions**: `docs/architecture-decisions/`
