Draft speaker notes • Day 1, 15:00–15:45 • 45 minutes • Facilitated discussion

## Purpose and takeaway

Participants connect the workshop's greenfield case to the existing systems they maintain. No separate case, live coding exercise or repository access is required.

Core message: in an existing system, discovering and preserving behavior is part of the task.

## Suggested discussion flow

| Minutes | Segment | Facilitator notes |
| --- | --- | --- |
| 0–5 | Reflect on today's builds | What did having a prepared starter make easier? What did the harness add? |
| 5–15 | Compare project conditions | Discuss conventions, dependencies, undocumented behavior, data and ownership in participants' own projects. |
| 15–30 | Discuss one bounded change | In small groups, choose a familiar maintenance task and identify needed context, constraints, baseline checks and human decisions. No code or separate case is required. |
| 30–40 | Share approaches | Compare what agents could investigate, what must remain stable and where a human must decide. |
| 40–45 | Takeaways and wrap-up handoff | Each group names one practice to take home and one unresolved question. Move directly to the 15:45 wrap-up. |

## Speaker notes

Greenfield work offers more freedom to choose structure, but it still has constraints. Brownfield work adds existing behavior, consumers, data and operating assumptions that may not be fully documented. Neither mode eliminates the need for acceptance and verification.

Before asking for implementation, ask for a map supported by files and observations. The agent should distinguish confirmed behavior, inferred behavior and unresolved questions. Documentation and code can disagree; surface the disagreement instead of choosing silently.

Characterization checks can capture current behavior before a change. They do not prove that the current behavior is correct. Domain review may be needed to decide what must be preserved and what is a defect.

Keep the first change small. Avoid combining a feature request with a broad refactor, dependency upgrade and schema redesign. When a public contract or data change is necessary, explain compatibility, migration and rollback considerations explicitly.

## Discussion prompts

- What would need to change for today's approach to work in a project you maintain?
- Which conventions and dependencies would an agent need to discover before editing?
- How would you establish current behavior when documentation or tests are incomplete?
- What is one small task you could safely delegate, and what evidence would let you accept it?
- Which access, data boundaries and decisions must remain under human control?

## Reconnaissance prompt to take home

```txt
Investigate this proposed change without editing files.
Identify the entry points, affected components, callers, tests and
data dependencies. Cite the files supporting your findings.
Separate confirmed facts from assumptions.
Propose the smallest change, the behavior that must remain stable,
the checks needed, and the questions requiring a human decision.
```

## Transfer checklist

- Select one low-risk, bounded task in an existing project.
- Establish approved access and relevant data boundaries.
- Identify the authoritative requirement and component owner.
- Capture a baseline and the checks that protect existing behavior.
- Delegate a small increment and review the evidence.
- Record what made the workflow useful and what still required human judgment.

## Demonstration and case scope

Demo 07, `07-brownfield.md`, is optional reference material for later use, not a scheduled live demo. There is no brownfield build session or required export extension. Preserve the existing export when refining the case; adding Status can remain an optional extension.

Demo 08, `08-release-showcase.md`, remains an optional short release/showcase example on Day 2, outside this discussion.

## Closing line

“The useful result is a change you understand, can verify and can safely build on.”
