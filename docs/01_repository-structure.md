# Repository Structure

**Version**: 3.1  
**Last Updated**: December 30, 2025  
**Purpose**: Single source of truth for repository structure

> **Note**: This document should be referenced from `.github/copilot-instructions.md`, `.cursor/rules/02_repository-structure.mdc`, `README.md`, and other documentation files. When the structure changes, update this file first, then update references.

---

## Complete Repository Structure

```text
architecture-reasoning-in-practice/
│
├── .copilot/
│   ├── settings.json
│   └── tmp/
│       ├── all-files.txt
│       ├── markdown-inventory.json
│       └── markdown-summary.txt
│
├── .cursor/
│   └── rules/
│       ├── 01_educational-content-rules.mdc
│       ├── 02_repository-structure.mdc
│       ├── 03_quality-assurance.mdc
│       ├── 04_markdown-standards.mdc
│       ├── 05_primary-directives.mdc
│       ├── 06_cross-domain-integration.mdc
│       ├── 07_file-naming-conventions.mdc
│       └── README.md
│
├── .github/
│   ├── ISSUE_TEMPLATE/
│   │   ├── bug_report.md
│   │   ├── config.yml
│   │   ├── content_suggestion.md
│   │   └── question.md
│   ├── workflows/
│   │   └── content-compliance.yml
│   ├── copilot-instructions.md
│   └── pull_request_template.md
│
├── .gitignore
├── .markdownlint-cli2.yaml
├── .markdownlint.json
├── .markdownlintignore
│
├── CODE_OF_CONDUCT.md
├── LICENSE
├── CONTRIBUTING.md
├── README.md
├── SECURITY.md
├── lychee.toml
│
├── src/
│   ├── .gitkeep
│   ├── 01_reasoning-foundations/
│   │   ├── problem-framing.md
│   │   ├── clarification-strategies.md
│   │   ├── assumptions-and-constraints.md
│   │   └── decision-rationale-framing.md
│   │
│   ├── 02_answer-structuring/
│   │   ├── top-down-communication.md
│   │   ├── depth-control.md
│   │   ├── time-boxed-reasoning.md
│   │   └── architecture-explanation-structure.md
│   │
│   ├── 03_tradeoff-articulation/
│   │   ├── cost-vs-scale.md
│   │   ├── simplicity-vs-flexibility.md
│   │   ├── risk-and-failure-framing.md
│   │   ├── cqrs-selective-application.md
│   │   ├── polyglot-persistence-rationale.md
│   │   ├── genai-production-integration.md
│   │   ├── micro-frontends-rationale.md
│   │   └── edge-security-layered-defense.md
│   │
│   ├── 04_role-perspectives/
│   │   ├── staff-engineer.md
│   │   ├── principal-engineer.md
│   │   ├── architect.md
│   │   └── engineering-manager.md
│   │
│   ├── 05_evaluation-scenarios/
│   │   ├── vague-problem.md
│   │   ├── conflicting-requirements.md
│   │   ├── legacy-modernization.md
│   │   ├── explaining-complex-architecture.md
│   │   ├── managing-complexity-trade-offs.md
│   │   └── microservices-transaction-management.md
│   │
│   └── resources/
│       ├── frameworks.md
│       ├── reference-materials.md
│       └── tools.md
│
├── docs/
│   ├── 01_repository-structure.md (this file)
│   ├── images/
│   │   └── .gitkeep
│   ├── review-reports/
│   │   └── .gitkeep
│   ├── templates/
│   │   ├── scenario-template.md
│   │   └── pattern-note-template.md

└── tools/
   └── psscripts/
      ├── .gitkeep
      ├── Compare-DocFiles.ps1
      ├── Find-DuplicateContent.ps1
      ├── Get-FileStats.ps1
      ├── Get-MarkdownSummary.ps1
      ├── Get-RepoStats.ps1
      ├── Quick-HealthCheck.ps1
      ├── Test-ContentCompliance.ps1
      └── Validate-FileReferences.ps1

```

---

## Key Structure Notes

### Repository Purpose

> **📋 Important Distinction**: This repository focuses on reasoning and articulation. Detailed system designs and implementations live in `system-design-in-practice`.

This repository is organized by **thinking modes**, not topics or systems. It focuses on:

- How senior people think, reason, and communicate
- Reasoning under senior technical evaluation contexts (promotion panels, design reviews, leadership conversations)
- Not system design depth or implementation details

### File Naming Conventions

- **Content Files**: Use descriptive names that clearly indicate the thinking mode or reasoning dimension
- **Organization**: Content organized by reasoning dimensions (foundations, structuring, articulation, perspectives, scenarios)
- **Structure**: Organized by thinking modes to avoid system design overlap

### Content Organization

1. **Reasoning Foundations** (`01_reasoning-foundations/`): Problem framing, clarification strategies, assumptions and constraints, decision rationale framing

2. **Answer Structuring** (`02_answer-structuring/`): Top-down communication, depth control, time-boxed reasoning, architecture explanation structure

3. **Trade-off Articulation** (`03_tradeoff-articulation/`): Cost vs scale, simplicity vs flexibility, risk and failure framing, CQRS, polyglot persistence, GenAI integration, micro-frontends, edge security

4. **Role Perspectives** (`04_role-perspectives/`): How different roles think when solving the same ambiguous problem

5. **Evaluation Scenarios** (`05_evaluation-scenarios/`): Vague problems, conflicting requirements, legacy modernization, explaining complex architecture, managing complexity, microservices transaction management

6. **Resources** (`resources/`): Frameworks, tools, and reference materials

### Special Directories

- **`docs/`**: Additional documentation, images, and planning materials
- **`docs/templates/`**: Standard templates for scenarios and pattern-style notes

---

## Purpose of Each Folder

### `src/01_reasoning-foundations/`

Reasoning fundamentals: how to frame problems, extract constraints, and surface assumptions.

### `src/02_answer-structuring/`

How to communicate: top-down structuring, controlling depth, and time-boxing your reasoning.

### `src/03_tradeoff-articulation/`

How to compare options and defend choices: trade-offs, risk, and failure framing.

### `src/04_role-perspectives/`

Role-anchored reasoning perspectives: how focus changes across Staff/Principal/Architect/EM contexts.

### `src/05_evaluation-scenarios/`

Open-ended scenarios designed for reasoning practice. These are not “answer keys” and should avoid full system designs.

### `src/resources/`

Reusable reference artifacts (checklists, templates, frameworks). Avoid duplicating practice-note content.

---

## Templates

- Scenario template: [`docs/templates/scenario-template.md`](templates/scenario-template.md)
- Pattern-style note template: [`docs/templates/pattern-note-template.md`](templates/pattern-note-template.md)

---

## Update Protocol

**When repository structure changes**:

1. ✅ **Update this file first** (`docs/01_repository-structure.md`)
2. ✅ **Update references** in:
   - `.github/copilot-instructions.md` - Reference this file
   - `.cursor/rules/02_repository-structure.mdc` - Reference this file
   - `README.md` - Reference this file
3. ✅ **Verify consistency** across all documentation

**Self-Check Question**: "Did I update `docs/01_repository-structure.md` first?" - If no, STOP and do it NOW.

---

## References

- **Repository Structure**: This file (`docs/01_repository-structure.md`)
- **Learning Path**: `README.md`
- **GitHub Copilot Instructions**: `.github/copilot-instructions.md`
