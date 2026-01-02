# C# Modernization in Practice (C# 12–14)

[![License](https://img.shields.io/badge/License-MIT-purple)](LICENSE)
[![Status](https://img.shields.io/badge/Status-Active-success)](https://github.com/Swamy-s-Tech-Skills-Academy-2026/csharp-modernization-in-practice)
[![C# Version](https://img.shields.io/badge/C%23-12--14-orange)](https://github.com/Swamy-s-Tech-Skills-Academy-2026/csharp-modernization-in-practice)
![Format](https://img.shields.io/badge/Format-Practice%20Showcase-yellow)
![Built with](https://img.shields.io/badge/Built%20with-.NET%2010-brown)
[![Maintainer](https://img.shields.io/badge/Maintainer-Viswanatha%20Swamy%20P%20K-blue)](https://github.com/Swamy-s-Tech-Skills-Academy-2026)

**Repository**: [csharp-modernization-in-practice](https://github.com/Swamy-s-Tech-Skills-Academy-2026/csharp-modernization-in-practice)

> **⚠️ IMPORTANT: This is NOT a course or official curriculum. This is Swamy's personal learning journey and practice showcase.**

This repository demonstrates how selected **C# 12, 13, and 14 language features** can be applied to modernize an existing console-based application. The focus is on **practical, high-impact improvements** in readability, safety, and maintainability within realistic workflows.

The goal of this repo is to showcase **incremental language-level modernization** that improves code quality without architectural rewrites, providing side-by-side comparisons between legacy and modernized implementations.

This repository demonstrates how modern C# language features reduce boilerplate, strengthen domain modeling, and improve maintainability through realistic, end-to-end workflows.

> **📋 Important Distinction**: This repository focuses on language-level modernization. Architectural changes and system design patterns belong in separate repositories.

---

## 📌 Disclaimer

This is **Swamy's personal learning** repository and practice showcase, not official course material or a packaged curriculum.

---

## 📑 Table of Contents

- [Who This Is For / Who This Is Not For](#-who-this-is-for--who-this-is-not-for)
- [Focus Areas](#-focus-areas)
- [How to Use This Repository](#-how-to-use-this-repository)
- [Objectives](#-objectives)
- [Modernization Structure](#-modernization-structure)
- [Repository Structure Overview](#-repository-structure-overview)
- [How to Run](#-how-to-run)
- [Architecture Decision Records](#-architecture-decision-records)
- [Status](#-status)
- [Development & Quality Assurance](#️-development--quality-assurance)
- [Contributing](#-contributing)
- [About & Community](#-about--community)
- [License](#-license)

---

## 👥 Who This Is For / Who This Is Not For

### ✅ Who This Is For

- Software Engineers modernizing C# codebases
- Architects evaluating language feature adoption
- Principal/Staff Engineers leading modernization efforts
- Development teams planning C# upgrades
- Engineers seeking practical examples of C# 12–14 features
- Teams looking for before/after modernization comparisons
- Anyone wanting to understand incremental language-level improvements

### ❌ Who This Is Not For

- Those seeking official course materials or structured curriculum
- People looking for a complete, ready-to-use course (this is a personal practice showcase)
- Those who want passive learning without hands-on exploration
- Anyone expecting step-by-step tutorials (this focuses on practical examples)
- Those seeking architectural pattern walkthroughs (see other repositories instead)
- Developers looking for exhaustive C# feature coverage (this focuses on high-impact features)

---

## 🎓 Focus Areas

This repository demonstrates practical application of modern C# features:

| Focus Area | C# Features | Practice Location |
|------------|------------|-------------------|
| **Reduce Boilerplate** | Primary constructors, collection expressions, type aliases | `src/legacy/` → `src/modern/` |
| **Express Intent Explicitly** | `ref readonly` parameters, required members, pattern matching | `src/legacy/` → `src/modern/` |
| **Centralize Business Rules** | Switch expressions, declarative policies | `src/legacy/` → `src/modern/` |

### Modernization Steps

#### Step 1: Reduce Boilerplate (C# 12)

- **Primary constructors**: Eliminate constructor boilerplate
- **Collection expressions**: Cleaner data initialization
- **Type aliases**: Improved readability of complex types

**Result**: Fewer lines of code, clearer domain intent

#### Step 2: Express Intent Explicitly (C# 12–13)

- **`ref readonly` parameters**: Express immutability intent
- **Required members**: Compile-time safety for required data
- **Pattern matching**: Clearer business rules

**Result**: Safer APIs, fewer invalid states

#### Step 3: Centralize Business Rules (C# 13–14)

- **Switch expressions**: Declarative policy definitions
- **Enhanced pattern matching**: Better rule expression

**Result**: Easier reasoning, better reviewability

> **Note**: Each modernization step follows a **Before → After → Why it matters** pattern. See [`docs/01_repository-structure.md`](docs/01_repository-structure.md) for the complete structure.

---

## 🚀 How to Use This Repository

### Recommended Learning Path

1. **Explore Before/After Comparisons** (`src/legacy/` vs `src/modern/`)
   - Review side-by-side code comparisons
   - Understand how modern C# features improve code quality
   - Analyze the practical benefits of each modernization step

2. **Study Architecture Decision Records** (`docs/architecture-decisions/`)
   - Review ADR-001 through ADR-004 for modernization decisions
   - Understand the context, decisions, and consequences
   - Learn when and why to adopt specific C# features

3. **Run the Examples**
   - Build and test both legacy and modern implementations
   - Verify functional equivalence
   - Experience the improvements firsthand

4. **Apply to Your Codebase**
   - Use the examples as reference for your own modernization
   - Follow the incremental approach demonstrated
   - Document your decisions using the ADR format

### Quick Start

```bash
# Clone the repository
git clone https://github.com/Swamy-s-Tech-Skills-Academy-2026/csharp-modernization-in-practice.git
cd csharp-modernization-in-practice

# Build the solution
dotnet build

# Run tests for both implementations
dotnet test

# Run the modernized application
dotnet run --project src/modern/AppHost
```

---

## 🎯 Objectives

- Demonstrate practical application of C# 12–14 language features
- Show incremental modernization approach without architectural rewrites
- Provide side-by-side comparisons of legacy vs modernized code
- Validate correctness through comprehensive testing
- Document modernization decisions through Architecture Decision Records
- Serve as a reference implementation for modernization projects

---

## 🧭 Modernization Structure

Content is organized to enable **side-by-side comparison**:

- **Legacy Code** (`src/legacy/`): Traditional C# style (pre-C# 12), representative of existing systems
- **Modern Code** (`src/modern/`): Modernized implementations using C# 12–14 features
- **Tests** (`tests/`): Same test cases applied to both implementations to ensure behavioral equivalence
- **Architecture Decisions** (`docs/architecture-decisions/`): ADR-style documentation of modernization choices

Each modernization step demonstrates:

- **Before**: Traditional C# implementation
- **After**: Modernized implementation using C# 12–14 features
- **Why it matters**: Benefits in readability, safety, and maintainability

---

## 🗂 Repository Structure Overview

> **📋 Single Source of Truth**: The complete and up-to-date repository structure is maintained in [`docs/01_repository-structure.md`](docs/01_repository-structure.md). This file should be referenced for the authoritative structure.

For the complete repository structure with all file names and details, see: **[`docs/01_repository-structure.md`](docs/01_repository-structure.md)**

**Quick Overview**:

```text
csharp-modernization-in-practice/
├── src/
│   ├── legacy/          # Traditional C# (pre-C# 12)
│   └── modern/          # Modernized using C# 12–14
├── tests/
│   ├── Legacy.Tests/    # Tests for legacy implementation
│   └── Modern.Tests/    # Tests for modernized implementation
└── docs/
    └── architecture-decisions/  # ADR-style documentation
```

---

## 🏃 How to Run

### Prerequisites

- .NET 10 SDK or later
- Your preferred IDE (Visual Studio, VS Code, Rider, etc.)

### Build and Test

```bash
# Build the solution
dotnet build

# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity normal
```

### Run the Application

```bash
# Run the modernized application
dotnet run --project src/modern/AppHost

# Run the legacy application (for comparison)
dotnet run --project src/legacy/AppHost
```

### Key Takeaway

Modern C# improves code quality **without changing the problem domain**. The same workflows become easier to read, test, and evolve.

---

## 📋 Architecture Decision Records

Architecture Decision Records (ADRs) document significant modernization decisions:

- **ADR-001**: Use Primary Constructors for Domain Models
- **ADR-002**: Prefer Collection Expressions for Static Policies
- **ADR-003**: Use `ref readonly` for Read-Only Evaluation APIs
- **ADR-004**: Centralize Business Rules with Switch Expressions

Each ADR includes:

- **Status**: Accepted/Proposed/Deprecated
- **Applies to**: C# version
- **Context**: Why the decision was needed
- **Decision**: What was decided
- **Consequences**: Trade-offs and outcomes

See `docs/architecture-decisions/` for complete ADR documentation.

---

## 🚧 Status

This repository is **actively evolving** as a personal practice showcase for C# modernization.

---

## 🛠️ Development & Quality Assurance

### Code Quality Checks (Local)

Run build and tests before opening a PR:

```bash
# Build the solution
dotnet build

# Run all tests
dotnet test --verbosity normal
```

### Documentation Quality Checks (Local)

Run Markdown lint against README and all documentation:

```bash
# From repo root - lint all markdown files
npx --yes markdownlint-cli2 "README.md" "docs/**/*.md" ".github/**/*.md"
```

This uses the repository's `.markdownlint.json` configuration automatically.

### Link Validation (Lychee)

Run link checker to validate all links in documentation:

```bash
# Validate all links (recommended; matches CI behavior)
docker run --rm -w /input -v "${PWD}:/input" lycheeverse/lychee:latest --config lychee.toml --no-progress README.md docs/**/*.md .github/**/*.md
```

### Pre-Commit Checklist

Before committing changes:

- [ ] Code builds without errors (`dotnet build`)
- [ ] All tests pass for both legacy and modern implementations (`dotnet test`)
- [ ] Zero-Copy Policy verified (if source material exists): Run `.\tools\psscripts\Verify-ZeroCopy.ps1`
- [ ] ADRs updated (if significant changes)
- [ ] README updated (if structure changed)
- [ ] Run markdownlint and fix any issues
- [ ] Run Lychee link checker (if Docker available)
- [ ] Verify all file references point to existing files
- [ ] Check that code fences have language specifications
- [ ] Ensure proper blank lines around headings and lists

---

## 🤝 Contributing

Contributions are welcome and encouraged. You may contribute in the following ways:

- Bug fixes and corrections
- Documentation improvements
- New modernization examples
- Additional C# feature demonstrations
- Test coverage improvements
- Architecture Decision Records
- Tooling, scripts, or automation enhancements

Please review [CONTRIBUTING.md](CONTRIBUTING.md) for detailed contribution guidelines.

---

## 📞 About & Community

### [Swamy's Tech Skills Academy](https://www.linkedin.com/company/swamy-s-tech-skills-academy) & [ShyvnTech](https://www.linkedin.com/company/shyvntech)

This repository is stewarded and supported by **Swamy's Tech Skills Academy** and **ShyvnTech**. It is focused on helping software engineers and teams modernize C# codebases through practical examples and incremental approaches.

You can connect with the community to:

- Follow structured learning journeys and deep-dive content
- Participate in knowledge-sharing discussions
- Explore mentoring, workshops, and custom training opportunities
- Develop C# modernization and language feature adoption capabilities

---

## 📜 License

This project is licensed under the [MIT License](LICENSE). See the [LICENSE](LICENSE) file for details.

---

> 🎓 **C# Modernization in Practice** — Designed and maintained by `Viswanatha Swamy P K`  
> Empowering software engineers and teams to modernize C# codebases through practical examples and incremental improvements.  
> © 2025 Swamy's Tech Skills Academy, ShyvnTech & Srivari Software Solutions
