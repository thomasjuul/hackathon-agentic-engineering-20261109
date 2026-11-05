# Participant go-to guide

Use this guide when you are unsure what to do next, need help explaining a concept, or want a starting point for a Codex instruction. Adapt the examples to your task. Read the plan and results yourself; a suggested prompt is a starting point, not a guarantee of a correct result.

The goal is to understand agentic engineering concepts, practise applying them, and become more confident using Codex to solve given tasks. Keep the business case small and leave time to reflect.

## Find help quickly

| I need help with | Go to |
| --- | --- |
| Starting the application or missing tools | [Setup](00-before-first-build.md) |
| Giving Codex a clear task and relevant context | [Session 1](#session-1-prompt-and-context) |
| Instructions, knowledge, tools, and skills | [Session 2](#session-2-harness) |
| Goals, feedback, branches, and stopping | [Session 3](#session-3-loop-and-graph) and [execution graph](execution-graph.md) |
| Checking results, tracing an action, and human review | [Session 4](#session-4-evaluation-observability-and-governance) |
| Changing code someone else wrote | [Session 5](#session-5-brownfield) |
| Something has gone wrong | [Troubleshooting](#when-you-are-stuck) |
| Harder tasks | [Optional 1 and Optional 2](optional-challenges.md) |
| Catching up or restoring demo examples | [Recovery and demonstration](recovery-and-demo.md) |

## Use the prepared agent harness

The [agent harness guide](agent-harness.md) explains the starter examples, participant-created harness progression, and remote Microsoft Learn/OpenAI Docs MCP references. No MCP server runs locally. Inspect the supplied .codex/config.toml and confirm remote discovery before the event.

```text
Use workshop_analyst with $frame-task and $map-context to read the local case
and map the current task. The main Codex session can use remote OpenAI Docs
or Microsoft Learn directly. From session 2, use the new $use-mcp skill.
Discover tools, search, fetch the supporting page, and explain the decision.
Use one workshop_implementer as writer. From session 2, use the verifier and
reviewer you created; before that perform checks/review with the main session. Inspect runtime behavior through
normal browser/API/test tools. Record the handoff and source URLs directly
in docs/evidence.md. Report unavailable remote calls as blocked.
```

Use only the roles needed. Mentioning a role or server does not prove it was discovered or used. The optional remote GitHub connection requires approved access and is not part of the basic path.

## Before each task

1. State which session and task you are doing. Your working copy's TASK.md may still contain the previous session: replace it with the current session card, or paste the current task explicitly into Codex. Do not let it continue an old task.
2. Identify the intended behavior and one or two examples. Ask Codex to inspect relevant files before suggesting edits.
3. Agree the scope, checks, and stopping conditions. Split a large goal into a small first slice.
4. Review the plan, then let Codex implement. Ask for actual verification evidence and inspect the changes before accepting them.

Reusable task scaffold:

```text
We are doing [session and task]. Read AGENTS.md and the current task below.
Goal: [what the user should be able to do].
Relevant context: [rules, API contract, files, examples].
Examples: [input/action] should produce [observable result].
Scope: [allowed changes]. Keep the four fields, three rules, and two statuses.
First inspect the code and explain your plan and assumptions.
Then implement the smallest coherent change and run the relevant checks.
Stop for unclear requirements or a blocker. Report checks that could not run.
Finish with what changed, actual check results, limitations, and a diff for my review.
```

For a task deliberately split into planning and implementation, end the first instruction with: `Inspect and plan only. Wait for my review before editing.` After reviewing, give the implementation instruction yourself.

## Session 1: Prompt and context

**Prompt:** what you ask Codex to do. **Context:** the information it needs to do it correctly. Useful context includes the task, existing code, contracts, rules, and acceptance examples.

**Where to look:** AGENTS.md, docs/rules.md, docs/api-contract.md, api/Endpoints.cs, api/WorkshopDb.cs, web/src/api.ts, and web/src/App.tsx in your working copy. The shared [session card](01-build-session-1.md) describes the task.

Start by understanding the solution:

```text
Explain how this prepared application is organised. Locate the React screen,
typed API client, API endpoints, database, and seed data. Show the actual files
you used. Explain which parts already work and which session-1 parts are missing.
Do not edit anything yet. Identify assumptions you would need me to confirm.
```

Then give the first implementation task:

```text
Implement only the session-1 request list and detail view using the supplied
types and API client. Opening Fjordby must show its school project; opening
Sodal must show its library project. Preserve the health screen plumbing and
existing CSV exporter. First explain the plan, then implement and verify both
selections. Show the changes and actual check results before I accept them.
```

If Codex proposes a much larger solution:

```text
Reduce the plan to the current list/detail task. Use the existing architecture.
Do not add authentication, new services, new business fields, or later-session
features. Explain what you removed from the plan and implement the first slice.
```

**Check your understanding:** Which information belonged in the prompt, which came from the repository, and which assumption did you confirm?

## Session 2: Harness

**Harness:** the instructions, knowledge, tools, and verification workflow surrounding the agent. AGENTS.md gives reusable guidance; the verification skill describes a repeatable procedure. Neither replaces checking what actually happened.

**Where to look:** docs/rules.md, api/Readiness.cs, API contracts, tests/, templates/verify-change.SKILL.md, and [session 2](02-build-session-2.md).

Create the harness as a core task, rather than editing a completed library:

1. Inspect the two supplied roles and three skills; decide which responsibilities and procedures are missing.
2. Plan two new agents (verifier and reviewer) and three new skills (verify-change, review-change, use-mcp).
3. Author from the inactive scaffolds, update routing, confirm discovery, and use every new definition on readiness.
4. Revise one definition from observed feedback and explain why the revision helps.

Start with a design prompt:

~~~text
We have only workshop_analyst/workshop_implementer and frame-task/map-context/
implement-slice. Help me design two new agents: a verifier that runs actual
checks and an independent reviewer that inspects diff/evidence without editing.
Also propose verify-change, review-change, and use-mcp skills. For each, state
purpose/trigger, inputs, procedure, tools, output/evidence, boundaries, and stop
conditions. Consult remote OpenAI Docs for formats. Do not create files until
I have reviewed the responsibilities.
~~~

After reviewing the design:

~~~text
Create the agreed definitions from templates/custom-agent.toml and
templates/workflow.SKILL.md in the active project discovery locations.
Do not read completed checkpoints or overwrite the starter examples.
Update AGENTS.md to route the readiness task through our new harness.
Confirm which new roles/skills Codex actually discovers, then use each on the
task. Label unavailable discovery as blocked; file existence is not activation.
~~~

Then exercise and improve them:

~~~text
Implement exactly the three server readiness rules and display the result.
Invoke our new verify-change, review-change, and use-mcp skills, delegate to
our new verifier and reviewer, and collect actual outputs. Use remote docs
for a relevant technical question; keep the fictional rules authoritative.
Identify a gap in one authored definition, propose a revision, and exercise
the revision. Record authored files, use, feedback, sources, and human decision.
~~~

The [session-2 card](02-build-session-2.md) gives detailed completion criteria. A recovered answer harness is supplied work: author/exercise a distinct role or skill yourself as well.

If a skill or command is not found:

```text
The expected verification skill/command is unavailable. Inspect its path and the
repository instructions. Explain the mismatch without inventing a successful run.
Suggest the smallest correction. Do not install unrelated tools or rewrite the app.
```

**Check your understanding:** What could the next Codex task reuse without repeating it in the prompt?

## Session 3: Loop and graph

**Loop:** use feedback to check and repair work. **Graph:** the steps and branches that determine what happens next. The [supplied graph](execution-graph.md) describes the development workflow; the application's editing states are a separate thing.

**Where to look:** the execution graph, the current API contract, editing code, and [session 3](03-build-session-3.md).

```text
Goal: a caseworker can edit the existing four fields, save, see updated readiness,
and reload without losing the saved values. Follow Plan, Implement, Check,
Repair if needed, then Human review. Stop after at most two repair iterations
or 20 minutes of agent execution, whichever comes first, or earlier if blocked.
Keep incomplete drafts allowed and Reviewed requests read-only. Report the
branches visited, repair attempts, actual checks, and stopping reason.
```

You monitor the time and stop the run when the budget is reached. A prompt is not an enforced timer. Initial implementation does not count as a repair iteration. Do not invent a failed attempt if the first implementation passes.

When a check fails:

```text
Here is the command and relevant failure output: [paste]. Explain the likely
cause using the current code. Make one focused repair within our remaining
budget and rerun the relevant check. Do not weaken the expected behavior to
make the result green. Stop and explain the blocker if you cannot establish it.
```

**Check your understanding:** Why did the run continue, repair, stop, or request a human decision?

## Session 4: Evaluation, observability, and governance

**Evaluation:** compare behavior against expected outcomes. **Observability:** collect evidence to understand what happened. **Governance:** set boundaries and retain the right human decisions. Evaluate the application and Codex's work separately.

**Where to look:** [session 4](04-build-session-4.md), api/ActivityRecorder.cs, existing logs/correlation header, and docs/evidence.md in your working copy.

```text
Implement Mark reviewed using the supplied helper. Recheck readiness on the
server, reject incomplete requests even through direct API calls, and persist
status and activity together. Reviewed requests must reject editing. Repeated
review must not create duplicate activity. Run the supplied examples and show
actual results, the changed files, and anything needing human review.
```

Follow one action:

```text
Help me trace this review attempt using the existing correlation header,
structured server log, response, and activity entry if one was created.
Explain what each source proves and what it does not prove. Do not log raw
request descriptions or invent an activity entry for a rejected action.
```

Review the agent's work:

```text
Summarise the goal, context used, files changed, commands actually run, failures,
repairs, and stopping reason. Identify scope changes or unverified claims.
Show the diff and the evidence I should inspect before I decide whether to
accept, request changes, or defer. Do not treat your own summary as approval.
```

**Check your understanding:** What proves the application works? What shows Codex followed your instructions? What decision remains yours?

## Session 5: Brownfield

**Brownfield:** change existing software while respecting its behavior and callers. Inspect before editing, identify the intended contract change, and preserve everything outside it.

**Where to look:** api/CsvExporter.cs, its endpoint/callers, tests/CsvTests.cs, and [session 5](05-build-session-5.md).

```text
Inspect the existing CSV exporter, endpoint, callers, and tests before editing.
Explain its headers, ordering, encoding, line endings, quoting, and formula
handling. Propose the smallest change to append Status with New or Reviewed.
Identify the expectations intentionally affected and what must stay unchanged.
Wait for my review of the impact before implementing.
```

After reviewing the plan:

```text
Implement the agreed Status column change. Preserve the first two column names,
order and values, municipality ordering, encoding, line endings, and escaping.
Update only expectations affected by the added column; preserve earlier coverage.
Show exports containing both statuses and run the core regression checks.
Stop and restart without resetting data, then verify saved information remains.
```

You can download directly from `http://127.0.0.1:5080/api/requests/export`; a UI export button is not required for the core.

**Check your understanding:** What did Codex need to learn about the existing code before it was safe to change it?

## When you are stuck

| Situation | What to do or ask Codex |
| --- | --- |
| I do not understand a concept | `Explain [concept] using our current task. Give one concrete example and one decision I need to make. Do not implement yet.` |
| I do not know what to ask next | `Restate the current session goal. Compare it with the code and suggest the smallest next task. Explain why it helps.` |
| Codex changes too much | `Stop. Summarise changes outside the agreed scope. Propose how to isolate or undo only those changes while preserving my earlier work. Wait for my review.` |
| The app does not start | Follow the setup guide. Share the failing command and relevant output: `Diagnose this startup failure before changing application code. Distinguish a missing tool, Docker/database issue, port conflict, and application error.` |
| Browser data looks wrong | `Trace this selected request from the browser through the typed client, endpoint, and stored data. Identify where observed values first differ. Inspect before editing.` |
| All tests pass but the feature fails | `Explain which behavior these checks actually cover. Identify the missing acceptance example and use it to reproduce the failure.` |
| A command cannot run | `Report the exact blocker and which claims remain unverified. Suggest an available manual check; do not describe it as equivalent to a test that was not run.` |
| Save or review fails | `Inspect the response and correlation ID. Explain whether the failure is an intended rule, a read-only restriction, a connection problem, or an implementation defect.` |
| We are running out of time | Stop the loop, record the blocker, and ask the facilitator for the appropriate recovery checkpoint. Follow the recovery guide; preserve your work. |

From the distribution root, use the supplied Start, Stop, and Verify scripts with your actual `-Workspace` path. From your working copy, its Start.ps1 and Verify.ps1 wrappers are available. Read the setup guide rather than guessing new commands. Never reset shared training data to fix a compilation error.

## Choosing optional work

Every session has **Optional 1** (an approachable feature challenge) and **Optional 2** (a difficult challenge involving more coordination, state, or compatibility). You can choose either after the core. Optional 2 is self-contained from the current core baseline; Optional 1 is not a prerequisite. Neither is needed for later sessions.

Use the detailed [optional tasks and suggested prompts](optional-challenges.md). Save a core baseline, agree one slice, keep an execution budget, and stop for the next topic even if the full challenge is unfinished. Label partial results and supplied code honestly.

## Before accepting a result

Explain what changed in your own words. Inspect the diff, run or observe the relevant example, check the reported evidence, and make the human decision yourself. Record one concept you understand better and one way you would improve your next Codex task. Use [final demonstration guidance](06-final-solution.md) to prepare your showcase.
