# Contributing to Architecture Reasoning in Practice

This is a **personal learning repository** documenting hands-on practice in architectural reasoning.

## Purpose

This repository is primarily for personal learning and documentation. If you're following a similar learning path, feel free to use this as a reference, but please note:

- This is **not an official repository**
- Content is based on personal study and practice
- The structure and content reflect one individual's learning approach

## Focus Areas

This repository focuses on:

- **Reasoning Foundations** - Problem framing, clarification strategies, assumptions and constraints
- **Answer Structuring** - Top-down communication, depth control, time-boxed reasoning
- **Trade-off Articulation** - Cost vs scale, simplicity vs flexibility, risk and failure framing
- **Role Perspectives** - How different roles think when solving the same ambiguous problem
- **Evaluation Scenarios** - Vague problems, conflicting requirements, legacy modernization

> **📋 Important Distinction**: This repository focuses on reasoning and articulation. Detailed system designs and implementations live in `system-design-in-practice`.

## Repository Structure

See [`docs/01_repository-structure.md`](docs/01_repository-structure.md) for the complete repository structure (single source of truth). See [README.md](README.md) for the learning path.

## Content Contribution Guidelines

### Scenario Contribution Guidelines

- Must use the standard scenario template: [`docs/templates/scenario-template.md`](docs/templates/scenario-template.md)
- Must focus on reasoning practice, not “answer keys” or full system designs
- Must explicitly surface ambiguities, assumptions, and trade-offs
- Must avoid hiring-process language; use role-agnostic “senior technical evaluation contexts” framing instead

### Pattern / Note Contribution Guidelines

- Must start with a clear H1 title (`# ...`)
- Prefer pattern-oriented structure (Summary → When to Use → How to Apply)
- Keep content modular and reusable; avoid duplicating `src/resources/`

### Language & Intent Discipline

- Avoid hiring-process phrasing in repository content
- Prefer: “design review”, “promotion panel”, “leadership discussion”, “technical evaluation context”

## Notes

- This is a personal learning repository
- Content is organized for practice and skill development
- Focus is on architectural reasoning, not specific technologies
