# GitHub Copilot Instructions for Architecture Reasoning in Practice

**Version**: 2.0  
**Last Updated**: December 29, 2025  
**Repository**: `architecture-reasoning-in-practice`  
**Critical Principle**: Update this file IMMEDIATELY when repository structure changes

---

## 🎯 Repository Purpose

**Architecture Reasoning in Practice** is a personal learning repository documenting hands-on practice in architectural reasoning across senior and staff-level technical roles.

### What This Repository Provides

- **Structured Thinking**: Systematic approaches to architectural problems
- **Trade-off Analysis**: Frameworks for evaluating options and making informed decisions
- **Clear Communication**: Techniques for articulating architectural decisions effectively
- **Practice Scenarios**: Real-world problems and ambiguous situations for practice
- **Decision-Making Frameworks**: Tools and methods for architectural judgment

### Target Audience

- Swamy (personal learning journey)
- Senior Software Engineers
- Principal Software Engineers
- Staff Engineers
- Software Architects
- Solution Architects
- AI Architects
- Engineering Managers
- Principal Consultants

### Business Value

- Develops real-world architectural judgment
- Enhances decision-making capability
- Improves communication of architectural decisions
- Practice for senior technical evaluation contexts and professional growth

---

## 🎯 Primary Directives

### 1. Architecture Reasoning Content Rules (MANDATORY)

**All content creation must follow these rules, with applicability based on content type:**

- **Practice Content** (`src/`): Organized by thinking modes (foundations, structuring, trade-offs, role perspectives, scenarios)
- **Scenarios** (`src/05_evaluation-scenarios/`): Real-world architectural problems and decision-making exercises (reasoning practice, not answer keys)
- **Resources** (`src/resources/`): Logical naming, frameworks and reference materials

See: `.cursor/rules/01_educational-content-rules.mdc` for complete details and applicability.

### 2. Automation-First Approach

✅ **ALWAYS**: Create reusable PowerShell scripts for repetitive tasks  
✅ **ALWAYS**: Use existing scripts in `tools/psscripts/` first  
✅ **ALWAYS**: Enhance existing scripts rather than duplicating  
❌ **NEVER**: Execute individual commands for tasks repeated 2+ times

**Decision Tree**:

1. Check `tools/psscripts/` for existing script
2. Enhance existing script if close match
3. Create new `.ps1` for any repeated task
4. Document with examples and parameters

**Available Automation** (tools/psscripts/):

- `Get-FileStats.ps1` - File statistics analysis
- `Get-MarkdownSummary.ps1` - Markdown file analysis
- `Get-RepoStats.ps1` - Repository overview
- `Compare-DocFiles.ps1` - Compare multiple files
- `Find-DuplicateContent.ps1` - Find duplicate headings
- `Quick-HealthCheck.ps1` - Fast workspace health check
- `Validate-FileReferences.ps1` - Validate file references in markdown
- `Verify-ZeroCopy.ps1` - **Zero-copy policy verification** (checks for verbatim text from source material)

### 3. Update Verification Protocol (CRITICAL)

**After ANY structural change, IMMEDIATELY update**:

1. ✅ **`docs/01_repository-structure.md`** - **UPDATE THIS FIRST** (Single source of truth)
2. ✅ `.github/copilot-instructions.md` - Reference to `docs/01_repository-structure.md` (THIS FILE)
3. ✅ `README.md` - Reference to `docs/01_repository-structure.md`
4. ✅ `.cursor/rules/02_repository-structure.mdc` - Reference to `docs/01_repository-structure.md`
5. ✅ Relevant documentation files

**Self-Check Question**: "Did I update `docs/01_repository-structure.md` first?" - If no, STOP and do it NOW.

### 4. File Naming Validation (CRITICAL)

**Before creating or committing ANY numbered file, validate naming**:

1. ✅ **Check for `00_` prefix**: **NEVER ALLOWED** - Use `01_` instead
2. ✅ **Verify scope**: Rule applies to **ALL files** including:
   - Practice content (`src/01_reasoning-foundations/`, `src/02_answer-structuring/`, etc.)
   - Documentation files (`docs/`)
   - Any numbered files anywhere in repository
3. ✅ **Quick validation**: Run `Get-ChildItem -Recurse -Filter "*00_*"` to find violations
4. ✅ **NO EXCEPTIONS**: `00_` is NEVER allowed, even for meta/documentation files

**Self-Check Question**: "Does this file use `00_` prefix?" - If yes, RENAME to `01_` or appropriate number.

### 5. Chain-of-Thought + ReAct + Reasoning

**Apply systematic reasoning to every task using this framework**:

#### Chain-of-Thought (CoT)

Break down complex problems into logical steps:

- **Decompose**: Split large tasks into smaller, manageable components
- **Sequential Logic**: Show clear progression from problem → solution
- **Explicit Reasoning**: Articulate WHY each step is necessary
- **Intermediate Steps**: Don't jump to conclusions; show the work

**Example**: "To consolidate docs, I need to: 1) Read all files, 2) Identify unique content, 3) Extract and merge, 4) Verify no loss, 5) Update references"

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
   - Run validation tools (markdownlint, Quick-HealthCheck)
   - Update documentation (rules files, README.md)
   - Test edge cases

6. **REFLECT** 🤔
   - What worked well?
   - What could be improved?
   - What would prevent this issue in the future?
   - Update instructions/scripts based on learnings

#### System 2 Reasoning

**Engage deliberate, analytical thinking for complex decisions**:

- **Question Assumptions**: Don't accept requirements at face value
- **Consider Trade-offs**: Every decision has pros and cons
- **Think Long-term**: How will this affect future work?
- **Pattern Recognition**: Have we solved similar problems before?
- **Meta-cognition**: Monitor your own reasoning process

**Red Flags Requiring Deep Analysis**:

- ⚠️ Structural changes (affects multiple files)
- ⚠️ Deletions (potential information loss)
- ⚠️ Consolidations (complexity in merging)
- ⚠️ New patterns (precedent-setting decisions)
- ⚠️ User frustration (indicates process failure)

#### Practical Application

**For Simple Tasks** (read file, create script):

- Quick CoT: "Need to read file → use read_file tool → done"
- Minimal reasoning sufficient

**For Complex Tasks** (consolidate docs, restructure):

- Full ReAct cycle required
- Multiple OBSERVE → ANALYZE → PLAN → ACT → VERIFY iterations
- Deep System 2 reasoning for critical decisions
- Document reasoning in commit messages

**When User Points Out Mistakes**:

1. **Acknowledge**: "You're right, I missed X"
2. **Root Cause**: "This happened because..."
3. **Immediate Fix**: Correct the issue
4. **Prevention**: "I'm adding [protocol/check/script] to prevent recurrence"
5. **Update Instructions**: Modify THIS FILE to embed learning

---

## 📁 Repository Structure

> **📋 Single Source of Truth**: The complete and up-to-date repository structure is maintained in [`docs/01_repository-structure.md`](../docs/01_repository-structure.md). This file should be referenced for the authoritative structure. When the structure changes, update that file first, then update references here.

For the complete repository structure, see: **[docs/01_repository-structure.md](../docs/01_repository-structure.md)**

**Quick Overview**:

- `src/01_reasoning-foundations/` - Problem framing, clarification strategies, assumptions
- `src/02_answer-structuring/` - Top-down communication, depth control, time-boxed reasoning
- `src/03_tradeoff-articulation/` - Cost vs scale, simplicity vs flexibility, risk framing
- `src/04_role-perspectives/` - How different roles think when solving the same problem
- `src/05_evaluation-scenarios/` - Vague problems, conflicting requirements, legacy modernization
- `src/resources/` - Frameworks, tools, and reference materials

---

## 🔧 Development Guidelines

### When Working with Architecture Reasoning Content

1. **Follow Thinking Mode Structure**: Content organized by Architecture Reasoning thinking modes
2. **Use Descriptive Names**: Files use clear, descriptive names (e.g., `problem-framing.md`, `cqrs-selective-application.md`)
3. **Keep Modular**: Recommended ≤150 lines per file (split if needed)
4. **Include Practical Examples**: Add real-world examples and use cases
5. **Focus on Reasoning**: Content emphasizes how to think, reason, and communicate, not implementation details

### When Creating Educational Content

#### File Naming

- ✅ Use descriptive names: `problem-framing.md`, `decision-rationale-framing.md`, `micro-frontends-rationale.md`
- ✅ Thinking mode folders use numbered prefixes: `src/01_reasoning-foundations/`, `src/02_answer-structuring/`
- ✅ Content files do NOT use numbered prefixes - use descriptive names only

#### Content Structure

- ✅ Recommended ≤150 lines per file
- ✅ Split into multiple parts if content exceeds 150 lines (use `-part1`, `-part2` suffixes)
- ✅ Each part should be self-contained
- ✅ Include practical examples and use cases
- ✅ Focus on reasoning patterns, trade-offs, and articulation, not system design depth

### Security Best Practices

- ❌ **NEVER** commit API keys or secrets
- ✅ **ALWAYS** use environment variables or GitHub Secrets
- ✅ **ALWAYS** add sensitive files to `.gitignore`

### Source Material Staging (Local Only)

If a `source-material/` folder exists locally, treat it as an **intake/staging area** for raw notes.

- ❌ **NEVER MODIFY** files under `source-material/` (read-only for analysis).
- ❌ **NEVER COPY** content verbatim into `src/` (follow the Zero-Copy / transformative policy).
- ✅ **ALWAYS TRANSFORM**: create original outlines, examples, and explanations in `src/`.
- ✅ Assume `source-material/` is **git-ignored** and may **not** appear on GitHub; don’t add repo structure links that depend on it.

---

## 📋 Code Quality Standards

### Markdown Files

- Use proper heading hierarchy (H1 → H2 → H3)
- Include code fence language specifications
- Follow markdownlint rules
- Use UTF-8 encoding
- Line length ~120 chars (tables/URLs may exceed)

### Code Examples

- Include GitHub CLI, Git commands, and workflow examples
- Use proper syntax highlighting
- Include comments explaining steps
- Keep examples simple and focused

---

## 🚀 Content Creation Workflow

### Architecture Reasoning Workflow

1. **Thinking Mode Alignment**: Ensure content fits the appropriate thinking mode folder
2. **Practical Examples**: Include real-world scenarios and use cases
3. **Reasoning Focus**: Emphasize how to think, reason, and communicate, not implementation details
4. **Cross-Reference**: Link related topics across thinking modes
5. **Transformative Content**: Follow zero-copy policy - create original content, not reformatted source material

### Zero-Copy Policy Verification (MANDATORY)

**Before creating ANY content from source material:**

1. ✅ **Read source material for intent only** - Don't copy notes verbatim
2. ✅ **Create fresh outline** - Different sectioning than source
3. ✅ **Use original examples** - Avoid source examples, create new ones
4. ✅ **Transform all quotes** - Even "Key Principle" quotes must be original phrasing
5. ✅ **Verify no verbatim text** - Run verification check before committing

**Verification Command** (run before committing):
```powershell
# Automated zero-copy verification
.\tools\psscripts\Verify-ZeroCopy.ps1

# For stricter checking (checks phrases, not just quotes)
.\tools\psscripts\Verify-ZeroCopy.ps1 -Strict
```

**Manual Verification** (also recommended):
- Search for known source material phrases in new content
- Check all "Key Principle" quotes for originality
- Verify example structures are not copied from source

**Common Violation Patterns to Avoid**:
- ❌ Copying "Key Principle" quotes verbatim from source
- ❌ Using exact phrasing from source material examples
- ❌ Mirroring source outline or section order
- ❌ Light paraphrasing (changing a few words)

**Required Transformation**:
- ✅ Complete rewording of all concepts
- ✅ Original examples and analogies
- ✅ Different structure and organization
- ✅ Fresh phrasing for all quotes and principles

### Quality Gate Questions

Before publishing any content:

1. ✅ Does this focus on reasoning, articulation, or decision-making?
2. ✅ **Is ALL content transformative? (No verbatim text from sources)**
3. ✅ Are practical examples included?
4. ✅ Is the content clear and easy to follow?
5. ✅ Does this fit naturally in the thinking mode progression?
6. ✅ Does this avoid system design depth (which belongs in `system-design-in-practice`)?
7. ✅ Is this content within 150 lines for effective delivery?

---

## 📝 Local Quality Checks

Before committing changes:

### Markdown Linting

```bash
npx markdownlint-cli2 "**/*.md"
```

### Link Checking (Lychee via Docker)

```bash
docker run --rm -v "${PWD}:/input:ro" lycheeverse/lychee --config /input/lychee.toml "/input/**/*.md"
```

### Pre-Commit Checklist

- [ ] **Zero-Copy Policy Verified**: No verbatim text from source material (check all quotes and examples)
- [ ] Run markdownlint and fix any issues
- [ ] Run Lychee link checker (if Docker available)
- [ ] Verify all file references point to existing files
- [ ] Check that code fences have language specifications
- [ ] Ensure proper blank lines around headings and lists
- [ ] **Manual Verification**: Search for known source material phrases in new content
- [ ] Verify file naming follows conventions

---

## 🔗 Quick Links

- [Repository Structure](../docs/01_repository-structure.md)
- [Learning Path](../README.md)
- [Contributing](../CONTRIBUTING.md)

---

## 📞 Support

- **Issues**: Use GitHub Issues for questions or suggestions
- **Learning**: Follow the thinking mode progression (01_reasoning-foundations → 05_evaluation-scenarios)
- **Practice**: Work through scenarios systematically to develop reasoning skills

---

