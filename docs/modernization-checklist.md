# C# Modernization Checklist (12–14)

Use this checklist when reviewing or upgrading existing code.

---

## Domain Models

- [ ] Can primary constructors reduce boilerplate?
- [ ] Are required members enforcing invariants?
- [ ] Are value objects immutable by default?

---

## Collections & Configuration

- [ ] Can collection expressions simplify initialization?
- [ ] Are static policies clearly expressed and read-only?

---

## APIs & Intent

- [ ] Should parameters be `ref readonly`?
- [ ] Is immutability communicated at the API boundary?
- [ ] Are complex return types aliased for readability?

---

## Business Rules

- [ ] Can conditionals be replaced with switch expressions?
- [ ] Are rules centralized rather than scattered?
- [ ] Does the compiler help enforce completeness?

---

## Tests

- [ ] Do tests validate behavior, not implementation?
- [ ] Are legacy and modern versions functionally equivalent?
- [ ] Do tests highlight safety improvements?

---

## General

- [ ] Is the modernization incremental and reversible?
- [ ] Is the intent clearer than before?
- [ ] Did we avoid over-engineering?

