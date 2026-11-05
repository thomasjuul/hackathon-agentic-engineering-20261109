# Build session 4: Mark complete requests reviewed and see an activity entry

**Learning:** Evaluation, observability, and governance. **When:** 09:30-11:30 on day 2.

The business case is still four fields, three rules, and two statuses. Read docs/rules.md.

Use the prepared [agent harness](agent-harness.md) for the role definitions, skill catalogue, MCP tools, and setup.

## Learning outcome

Explain evaluation, observability, and governance using one result from your run. Show how evidence informed your human review decision.

## Core task

Before tracing review, create trace-behavior yourself. Specify inputs, response/correlation/log/activity steps, evidence limits, and escalation. Invoke it through the verifier and improve it after feedback.

1. Write a small evaluation table: complete request succeeds; missing name, title, or budget blocks; reviewed request is read-only.
2. Implement POST /api/requests/{id}/review. Recheck readiness on the server, set Reviewed, increment Version, and call ActivityRecorder.Reviewed.
3. Save status and activity in the same SaveChanges call. Repeated review should return the current request without duplicate activity.
4. Add the Mark reviewed button and activity list to App.tsx. The browser disables review while incomplete; the server must also reject a direct API call.
5. Use the existing correlation header and structured server log to follow one action. Do not log raw request contents.
6. Ask Codex to fix one failing evaluation example within the bounded loop. If no failure occurs, inspect a facilitator-supplied failed run and label that evidence clearly. Run checks and inspect its actual diff before accepting it.
7. Complete docs/evidence.md: record the goal, context, allowed actions, checks run, failures, repair attempts, elapsed time, stop reason, and human decision. Evaluate Codex context use, scope, reporting accuracy, and stopping behavior separately from application correctness. Application logs/activity observe the app; this execution record observes the development agent.

## Required agent, skill, and MCP practice

1. Ask workshop_verifier to use $trace-behavior/$verify-change for actual review outcomes, correlation IDs, and activity. Use browser/API calls, tests, and the existing server log.
2. Use Microsoft Learn MCP to research the transaction/concurrency behavior relevant to atomic review/activity persistence. Use OpenAI Docs MCP for a question about inherited permissions or human review boundaries. Keep documentation claims separate from runtime evidence.
3. Delegate diff/evidence review to workshop_reviewer. Record findings, source URLs, actual results, stop reason, and the human decision in docs/evidence.md.

Keep this within the existing core time. Report unavailable remote calls as blocked and ask the facilitator for help; never invent a lookup result.

## Acceptance examples

- Incomplete requests cannot be reviewed, including through a direct API request.
- Empty or whitespace-only names and titles block review.
- Reviewed requests stay reviewed after reload; both browser editing and direct API updates are rejected.
- A human assesses the Codex execution record before accepting the change.
- One review action produces one persisted activity record with a correlation ID.

For task help, adaptable prompts, and troubleshooting, use the shared [go-to guide](go-to-guide.md).

## Suggested Codex task

> Implement the simple review action and activity using the supplied helpers. Enforce the rules on the server and verify the evaluation examples. Show actual check results and a diff for human review; the application button is not a substitute for reviewing code changes.

## Optional tasks

### Optional 1: Review diagnostics panel

Add a development-only panel for a review attempt: action, outcome, time, and the existing correlation ID.

**Deliverable:** A working diagnostics panel and an explained success/rejection trace.

### Optional 2: Local failure-investigation workbench

Starting from the session-4 core, build a local script/fixture-based workbench for three scenarios: incomplete review rejection, repeated review with no duplicate activity, and an edited request remaining read-only after review.

**Deliverable:** An executable local scenario workbench and investigation report demonstrating a diagnosed and repaired defect.

Optional 2 is deliberately more difficult and starts from this session's core; Optional 1 is not required. See the [steps and Codex prompts](optional-challenges.md#session-4). Choose a working slice and stop for the next topic; neither level is needed later.

## Reflection and evidence

Run `powershell -File .\Verify.ps1` from your working copy. Existing green checks alone do not prove the new feature works. Write and run checks for your acceptance examples.

The instructor can supply the session-4 acceptance pack, or a fresh recovery copy of `04-after-build-4`. Preserve your own work first.

At the session close, explain the concept in your own words, how you used it with Codex, and one thing you would improve. Keep the record short. If implementation blocks progress, use facilitator support or a clearly identified recovery checkpoint so you can practise the next concept. Optional features never determine learning success.
