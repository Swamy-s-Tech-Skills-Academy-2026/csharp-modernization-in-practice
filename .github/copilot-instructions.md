# GitHub Copilot Instructions for C# Modernization in Practice

**Version**: 1.0  
**Last Updated**: December 30, 2025  
**Repository**: `csharp-modernization-in-practice`  
**Critical Principle**: Update this file IMMEDIATELY when repository structure changes

---

## 🎯 Repository Purpose

**C# Modernization in Practice** demonstrates how selected C# 12, 13, and 14 language features can be applied to modernize an existing console-based application.

### What This Repository Provides

- **Before/After Comparisons**: Side-by-side legacy and modernized code
- **Practical Examples**: Real-world modernization scenarios
- **Architecture Decisions**: ADR-style documentation of modernization choices
- **Test Coverage**: Unit tests validating correctness and demonstrating benefits

### Target Audience

- Software Engineers modernizing C# codebases
- Architects evaluating language feature adoption
- Principal/Staff Engineers leading modernization efforts
- Development teams planning C# upgrades

### Business Value

- Demonstrates practical application of modern C# features
- Shows incremental modernization approach
- Validates correctness through comprehensive testing
- Provides reference implementation for modernization projects

---

## 🎯 Primary Directives

### 1. Before/After Structure (MANDATORY)

**All code must maintain parallel structure between legacy and modern implementations:**

- **Legacy code** (`src/legacy/`): Traditional C# style (pre-C# 12), representative of existing systems
- **Modern code** (`src/modern/`): Modernized implementations using C# 12–14
- **Tests** (`tests/`): Same test cases applied to both implementations

**Purpose**: Enables side-by-side comparison and demonstrates modernization benefits.

### 2. Zero-Copy Policy (MANDATORY)

**CRITICAL**: All content (documentation, code comments, markdown files) must be transformative, not reformative.

❌ **NEVER** copy text verbatim from books, articles, websites, videos, or third-party materials  
❌ **NEVER** mirror a source's outline, section order, headings, or example sequence  
❌ **NEVER** use "light paraphrasing" — must transform completely  
❌ **NEVER** copy quotes verbatim — even "Key Principle" quotes must use original phrasing  
✅ **ALWAYS** create original content with fresh explanations and examples  
✅ **ALWAYS** write code examples from first principles  
✅ Brief quotations allowed ONLY with quotation marks and source citation

**Verification**: Run `.\tools\psscripts\Verify-ZeroCopy.ps1` before committing to check for:

- Exact quote matches from source material
- Near-exact matches (potential quote matches)
- Phrase matches (in strict mode: `-Strict`)

**Remember**: All content must be transformative, not reformative. Even quotes and "Key Principle" sections must use original phrasing.

### 3. Modernization Principles

✅ **ALWAYS**: Make incremental, comparable changes  
✅ **ALWAYS**: Document architecture decisions in `docs/architecture-decisions/`  
✅ **ALWAYS**: Maintain test coverage for both implementations  
✅ **ALWAYS**: Focus on practical, high-impact improvements  
❌ **NEVER**: Make architectural rewrites (focus on language-level modernization)  
❌ **NEVER**: Remove legacy code (keep for comparison)

### 4. Update Verification Protocol (CRITICAL)

**After ANY structural change, IMMEDIATELY update**:

1. ✅ **`docs/01_repository-structure.md`** - **UPDATE THIS FIRST** (Single source of truth)
2. ✅ `.github/copilot-instructions.md` - Reference to `docs/01_repository-structure.md` (THIS FILE)
3. ✅ `README.md` - Reference to `docs/01_repository-structure.md`
4. ✅ `.cursor/rules/02_repository-structure.mdc` - Reference to `docs/01_repository-structure.md`
5. ✅ Relevant documentation files

**Self-Check Question**: "Did I update `docs/01_repository-structure.md` first?" - If no, STOP and do it NOW.

### 5. C# Feature Selection

**Focus on practical, high-impact language features**:

- **C# 12**: Primary constructors, collection expressions, `ref readonly` parameters, type aliases
- **C# 13**: Pattern matching improvements, required members evolution
- **C# 14**: Switch expressions, declarative policies

**Not a feature catalog**: Demonstrate modernization value, not exhaustive coverage.

### 6. Chain-of-Thought + ReAct + Reasoning

**Apply systematic reasoning to every task using this framework**:

#### Chain-of-Thought (CoT)

Break down complex problems into logical steps:

- **Decompose**: Split large tasks into smaller, manageable components
- **Sequential Logic**: Show clear progression from problem → solution
- **Explicit Reasoning**: Articulate WHY each modernization step is necessary
- **Intermediate Steps**: Don't jump to conclusions; show the work

#### ReAct (Reasoning + Acting)

Interleave thinking with action in iterative cycles:

1. **OBSERVE** 🔍
   - Current state: What exists now?
   - User request: What is being asked?
   - Context: What's the broader situation?
   - Constraints: What limitations exist?

2. **ANALYZE** 🧠
   - Root cause: Why does this issue exist?
   - Dependencies: What else is affected?
   - Implications: What are the consequences?
   - Alternatives: What other approaches exist?

3. **PLAN** 📋
   - Step-by-step approach with clear milestones
   - Verification points at each step
   - Rollback strategy if issues arise
   - Resource requirements (scripts, tools, time)

4. **ACT** ⚡
   - Execute with automation where possible
   - Use existing scripts before creating new ones
   - Make incremental changes, not big bangs
   - Document as you go

5. **VERIFY** ✅
   - Check results against expected outcomes
   - Run validation tools (build, test)
   - Update documentation
   - Test edge cases

6. **REFLECT** 🤔
   - What worked well?
   - What could be improved?
   - What would prevent this issue in the future?
   - Update instructions/scripts based on learnings

---

## 📁 Repository Structure

> **📋 Single Source of Truth**: The complete and up-to-date repository structure is maintained in [`docs/01_repository-structure.md`](../docs/01_repository-structure.md). This file should be referenced for the authoritative structure. When the structure changes, update that file first, then update references here.

For the complete repository structure, see: **[docs/01_repository-structure.md](../docs/01_repository-structure.md)**

**Quick Overview**:

- `src/legacy/` - Traditional C# style (pre-C# 12)
- `src/modern/` - Modernized implementations using C# 12–14
- `tests/` - Unit tests for both implementations
- `docs/architecture-decisions/` - ADR-style documentation

---

## 🔧 Development Guidelines

### When Working with Code

1. **Maintain Parallel Structure**: Keep legacy and modern code in sync structurally
2. **Document Changes**: Create ADRs for significant modernization decisions
3. **Test Both Implementations**: Ensure same test cases work for both
4. **Focus on Language Features**: Demonstrate C# 12–14 features, not architectural changes

### When Creating Modernization Examples

1. **Start with Legacy**: Begin with traditional C# code
2. **Apply Modern Features**: Show how C# 12–14 features improve the code
3. **Document Benefits**: Explain why the modernization matters
4. **Test Equivalence**: Ensure both implementations behave the same

### Security Best Practices

- ❌ **NEVER** commit API keys or secrets
- ✅ **ALWAYS** use environment variables or GitHub Secrets
- ✅ **ALWAYS** add sensitive files to `.gitignore`

---

## 📋 Code Quality Standards

### C# Code

- Follow C# coding conventions
- Use meaningful names
- Include XML documentation comments
- Keep methods focused and single-purpose

### Tests

- Use xUnit or NUnit
- Same test cases for both legacy and modern implementations
- Clear test names describing what is being tested
- Test both correctness and demonstrate benefits

---

## 🚀 Modernization Workflow

### Creating a Modernization Example

1. **Identify Feature**: Choose a C# 12–14 feature to demonstrate
2. **Create Legacy Code**: Write traditional C# implementation
3. **Create Modern Code**: Apply modern C# features
4. **Write Tests**: Create tests for both implementations
5. **Document Decision**: Create ADR if significant
6. **Update README**: Add to modernization steps overview

### Quality Gate Questions

Before publishing any modernization:

1. ✅ Does this demonstrate a practical C# 12–14 feature?
2. ✅ Is the before/after comparison clear?
3. ✅ Are tests comprehensive and passing?
4. ✅ Is the modernization documented?
5. ✅ Does this improve readability, safety, or maintainability?

---

## 📝 Local Quality Checks

Before committing changes:

### Build and Test

```bash
dotnet build
dotnet test
```

### Pre-Commit Checklist

- [ ] Code builds without errors
- [ ] All tests pass for both legacy and modern implementations
- [ ] **Zero-Copy Policy verified**: Run `.\tools\psscripts\Verify-ZeroCopy.ps1` (if source material exists)
- [ ] ADRs updated (if significant changes)
- [ ] README updated (if structure changed)
- [ ] Documentation is clear and accurate

---

## 🔗 Quick Links

- [Repository Structure](../docs/01_repository-structure.md)
- [Learning Path](../README.md)
- [Contributing](../CONTRIBUTING.md)

---

## 📞 Support

- **Issues**: Use GitHub Issues for questions or suggestions
- **Modernization**: Follow the modernization steps in README.md
- **Examples**: Review `src/legacy/` and `src/modern/` for before/after comparisons

---
