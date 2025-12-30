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
