---
name: review-change
description: Review a supplied diff and evidence independently without changing the implementation.
---

1. Read the task and actual changed files. Identify correctness, contract, read-only, scope, and verification issues with file references.
2. Read rules directly from repository files and inspect actual behavior with normal browser/API tools. Use remote Microsoft Learn/OpenAI Docs MCP only for relevant external technical guidance. Do not edit code or overwrite the implementer's evidence.
3. Return prioritized findings, evidence gaps, and a recommendation. State that the human decides acceptance. A role instruction is not a separate enforced read-only sandbox.
