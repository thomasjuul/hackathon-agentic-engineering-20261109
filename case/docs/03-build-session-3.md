# Build session 3: Correct missing information and save it

**Learning:** Loop and graph engineering. **When:** 15:00-15:45 on day 1.

The business case is still four fields, three rules, and two statuses. Read docs/rules.md.

Use the prepared [agent harness](agent-harness.md) for the role definitions, skill catalogue, MCP tools, and setup.

## Learning outcome

Explain the loop and graph using your run. Show the goal, feedback, branches, and stopping rule you gave Codex.

## Core task

Before the loop task, create workshop_coordinator and two new skills: run-bounded-loop and record-handoff. Specify one writer, handoffs, a two-repair/20-minute stopping rule, and concise evidence. Use the new coordinator and both skills on this task. Do not assume the optional plan-change skill exists.

1. State the goal: fix the existing request fields, save them, and show the new readiness result.
2. Read the supplied execution graph in the shared docs/execution-graph.md. Trace the pass, repair, blocked, and human-review branches during your run; explain any unvisited branch. No graph framework is required.
3. Delegate at most two repair iterations or 20 minutes of execution, whichever comes first.
4. Implement PUT /api/requests/{id}. Allow incomplete drafts, trim string fields, and keep Reviewed requests read-only. Increment the supplied internal Version when saving.
5. Add a small edit form using the existing four fields. Disable conflicting actions while a save is pending and show an error if saving fails.
6. Correct the missing budget, save, reload, and confirm the change persists. Review the diff and record attempts and outcome.

## Required agent, skill, and MCP practice

1. Ask workshop_coordinator to use $run-bounded-loop to sequence one implementer and verifier with an explicit handoff, repair branch, budget, and review point.
2. Use OpenAI Docs MCP to check how custom agents inherit permissions and Microsoft Learn MCP for the SaveChangesAsync/persistence behavior relevant to this task. Apply the findings rather than merely collecting links.
3. Read the previous handoff directly from docs/evidence.md. Inspect saved values before/after through browser/API tools, then append actual checks, visited branches, and stopping reason.

Keep this within the existing core time. Report unavailable remote calls as blocked and ask the facilitator for help; never invent a lookup result.

## Acceptance examples

- Correcting the budget produces Ready to review.
- Saved values survive browser reload.
- Failed save retains the draft and shows a useful message.

For task help, adaptable prompts, and troubleshooting, use the shared [go-to guide](go-to-guide.md).

## Suggested Codex task

> Let the caseworker edit and save the four existing fields and rerun readiness. Plan, implement, and verify within two repair iterations or 20 minutes. Stop if blocked and give me evidence for review.

## Optional tasks

### Optional 1: Unsaved-change protection

Show when a draft differs from saved values and provide Cancel to restore those values.

**Deliverable:** A usable dirty/Cancel/navigation workflow and a traced Codex run.

### Optional 2: Race-safe editing across requests

Starting from the session-3 core, define a per-request edit state machine including loading, dirty, saving, failed, and saved. Include the necessary draft protection without assuming Optional 1.

**Deliverable:** A state-based editing implementation with controlled race demonstrations and documented concurrency limits.

Optional 2 is deliberately more difficult and starts from this session's core; Optional 1 is not required. See the [steps and Codex prompts](optional-challenges.md#session-3). Choose a working slice and stop for the next topic; neither level is needed later.

## Reflection and evidence

Run `powershell -File .\Verify.ps1` from your working copy. Existing green checks alone do not prove the new feature works. Write and run checks for your acceptance examples.

The instructor can supply the session-3 acceptance pack, or a fresh recovery copy of `03-after-build-3`. Preserve your own work first.

At the session close, explain the concept in your own words, how you used it with Codex, and one thing you would improve. Keep the record short. If implementation blocks progress, use facilitator support or a clearly identified recovery checkpoint so you can practise the next concept. Optional features never determine learning success.
