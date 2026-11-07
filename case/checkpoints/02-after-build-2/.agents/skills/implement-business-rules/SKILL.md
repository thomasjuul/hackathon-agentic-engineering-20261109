---
name: implement-business-rules
description: Turn a business requirement into explicit examples and shared server-side behavior without inventing policy.
---

1. Read the current task, docs/rules.md, docs/api-contract.md, and existing rule/persistence code. Separate confirmed rules, examples, and unresolved questions. Ask the human when a business decision is missing; documentation services do not decide local policy.
2. Describe valid and invalid examples, including empty/whitespace input, optional fields, incomplete saves, and allowed state changes where relevant. Keep readiness as a derived result and status as saved state. Do not add new business fields or requirements without approval.
3. Propose one authoritative server-side rule path using the project's existing evaluator. Reuse it from checking, saving, and review where the contract requires it; do not duplicate business decisions in the browser. Keep pure rule evaluation separate from HTTP responses and database writes.
4. As an advisor, return the rule decisions and implementation guidance without editing. As the agreed implementer, make the smallest change using existing code. Preserve draft saving and reviewed read-only behavior when relevant. Explain how the behavior follows the business requirement.
5. Exercise the actual examples with focused tests and the app. Report what changed and any unresolved business decision. A passing unrelated test is not proof of the new rule.

6. The readiness evaluator handles required information. Keep the existing server-side write guard for Reviewed read-only state; do not invent a rule framework just to express that guard.
