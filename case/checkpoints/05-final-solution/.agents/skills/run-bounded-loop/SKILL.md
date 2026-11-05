---
name: run-bounded-loop
description: Execute an agreed goal through plan, implement, check, repair, stop, and human-review branches.
---

1. State goal, allowed actions, acceptance examples, at most two repair iterations, and 20-minute agent execution budget unless the current task explicitly agrees a smaller budget.
2. Ask the operator to monitor elapsed time. A prompt is not an enforced timer. Use feedback from actual checks for a focused repair; initial implementation is not a repair iteration.
3. Stop on success, ambiguity, blocker, iteration cap, or time cap. Do not start a new run automatically. Return visited graph branches, attempts, evidence, stop reason, and remaining work.
