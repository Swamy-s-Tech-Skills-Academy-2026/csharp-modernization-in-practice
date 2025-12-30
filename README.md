# C# Modernization in Practice (C# 12–14)

Modern C# console application showcasing selected C# 12, 13, and 14 features for application modernization. Focused on readability, safety, and productivity, this repo demonstrates how recent language enhancements reduce boilerplate, strengthen domain modeling, and improve maintainability through realistic, end-to-end workflows.

This repository demonstrates how selected C# 12, 13, and 14 language features
can be applied to modernize an existing console-based application.

The focus is not on showcasing every new feature, but on **practical,
high-impact improvements** in readability, safety, and maintainability
within realistic workflows.

---

## Why This Repository Exists

Many codebases run correctly but are:

- Verbose
- Difficult to reason about
- Hard to evolve safely

Modern C# addresses these problems at the **language level**.
This repo shows how incremental language upgrades improve code quality
without architectural rewrites.

---

## How to Navigate This Repository

- `src/legacy/`  
  Traditional C# style (pre-C# 12), representative of existing systems

- `src/modern/`  
  Modernized implementations using C# 12–14

- `tests/`  
  Unit tests validating correctness and demonstrating benefits

Each modernization step follows a **Before → After → Why it matters** pattern.

---

## Modernization Steps Overview

### Step 1: Reduce Boilerplate (C# 12)

- Primary constructors
- Collection expressions
- Type aliases

Result:

- Fewer lines of code
- Clearer domain intent

---

### Step 2: Express Intent Explicitly (C# 12–13)

- `ref readonly` parameters
- Required members
- Pattern matching

Result:

- Safer APIs
- Fewer invalid states

---

### Step 3: Centralize Business Rules (C# 13–14)

- Switch expressions
- Declarative policies

Result:

- Easier reasoning
- Better reviewability

---

## How to Run

```bash
dotnet build
dotnet test
dotnet run --project src/modern/AppHost
````

---

## Key Takeaway

Modern C# improves code quality **without changing the problem domain**.
The same workflows become easier to read, test, and evolve.

```

---

# 2. Before / After Folder Split

### Repository Layout

```

src/
├── legacy/
│    ├── AppHost/
│    │    └── Program.cs
│    ├── Domain/
│    │    ├── Models/
│    │    ├── Policies/
│    │    └── Rules/
│    └── Workflows/
│
├── modern/
│    ├── AppHost/
│    │    └── Program.cs
│    ├── Domain/
│    │    ├── Models/
│    │    ├── Policies/
│    │    └── Rules/
│    └── Workflows/
│
tests/
├── Legacy.Tests/
└── Modern.Tests/

```

### Purpose of This Split

- Enables **side-by-side comparison**
- Prevents “the old code disappeared” objections
- Makes modernization incremental and auditable
- Ideal for walkthroughs and reviews

---

# 3. Architecture Decision Notes (ADR-Style, Lightweight)

Create a folder:

```

docs/architecture-decisions/

```

---

## ADR-001: Use Primary Constructors for Domain Models

**Status:** Accepted  
**Applies to:** C# 12+

### Context
Domain models contained repetitive constructor and property boilerplate.

### Decision
Adopt primary constructors for simple, immutable domain entities.

### Consequences
- Reduced code size
- Clear constructor intent
- No impact on runtime behavior

---

## ADR-002: Prefer Collection Expressions for Static Policies

**Status:** Accepted  
**Applies to:** C# 12+

### Context
Policy definitions were verbose and visually noisy.

### Decision
Use collection expressions for static, read-only data.

### Consequences
- Improved readability
- Easier policy scanning
- No behavioral change

---

## ADR-003: Use `ref readonly` for Read-Only Evaluation APIs

**Status:** Accepted  
**Applies to:** C# 12+

### Context
Evaluation methods did not mutate inputs but allowed mutation accidentally.

### Decision
Mark parameters as `ref readonly` to express immutability intent.

### Consequences
- Compiler-enforced safety
- Clearer API contracts
- Minimal call-site impact

---

## ADR-004: Centralize Business Rules with Switch Expressions

**Status:** Accepted  
**Applies to:** C# 13–14

### Context
Business rules were scattered across conditional blocks.

### Decision
Use switch expressions to model decision tables explicitly.

### Consequences
- Declarative rule definitions
- Easier reasoning and review
- Compiler assistance for completeness

---

# 4. CI-Ready Test Project Structure

### Test Projects

```

tests/
├── Legacy.Tests/
│    ├── Domain/
│    └── Workflows/
│
├── Modern.Tests/
│    ├── Domain/
│    └── Workflows/

```

Each test project targets:
- `.NET 10`
- Same test cases applied to both implementations

---

### Example Test Naming Convention

```

OperationCommandTests.cs
CommandSafetyEvaluatorTests.cs
ExecutionPolicyTests.cs

````

---

### Example CI Workflow (GitHub Actions)

```yaml
name: build-and-test

on:
  push:
  pull_request:

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4

      - name: Setup .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: 10.x

      - name: Restore
        run: dotnet restore

      - name: Build
        run: dotnet build --no-restore

      - name: Test
        run: dotnet test --no-build --verbosity normal
````

---

# 5. Why This Design Is Strong

- Modernization is **incremental**, not disruptive
- Every change is:

  - Comparable
  - Testable
  - Documented
- Tests prove correctness, not just compilation
- Repo is suitable for:

  - Learning
  - Internal reference
  - Modernization experiments

---
