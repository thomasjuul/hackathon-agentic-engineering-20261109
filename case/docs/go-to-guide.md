# Your go-to guide

Use this when you need a clearer explanation, a smaller next step, or an idea for what to ask Codex. Adapt the prompts to your work. Read the answer and decide whether it fits before accepting a change.

## Find what you need

| I need help with… | Open |
| --- | --- |
| Understanding the task for this session | Its session card, linked below |
| A word I have not seen before | [Words and concepts](words-and-concepts.md) |
| Starting the app or running checks | [Setup](00-before-first-build.md) |
| Creating agents, skills, or using remote docs | [Harness guide](agent-harness.md) |
| Deciding when Codex should repair or stop | [Execution graph](execution-graph.md) |
| Writing a short record of my work | [Evidence template](evidence-template.md) |
| Catching up without losing my changes | [Recovery](recovery-and-demo.md) |
| A bigger challenge after the core | [Optional challenges](optional-challenges.md) |

## A useful pattern for any task

Tell Codex what you want, give it the relevant information, ask for a small plan, and check the result. You can split planning and implementation into separate requests.

```text
We are doing [session and task]. Read AGENTS.md and the current task.
Goal: [what the caseworker should be able to do].
Example: [action] should produce [result I can see].
Use our existing fields, rules, code, and components.
First inspect the relevant files. Explain a small plan and any assumptions.
Do not edit yet. Explain unfamiliar terms using this app.
```

After you review the plan:

```text
Implement the agreed change. Keep within our task and use the agents/skills
available in this session. Run relevant checks and show the changed lines.
Tell me what passed, failed, or could not run. Stop if the task is unclear
or blocked. I will review the result before accepting it.
```

Open the current session card in `case/docs` and give Codex that task explicitly.

## Session 1: Prompt and context

A **prompt** is your instruction. **Context** is the information needed to follow it. Our rules, example requests, and existing code are context.

Open [session 1](01-build-session-1.md). Useful files in your working copy are `AGENTS.md`, `docs/rules.md`, `docs/api-contract.md`, `web/src/App.tsx`, and `api/Endpoints.cs`.

```text
Use workshop_analyst with $frame-task and $map-context.
Explain where the browser screen, API, and saved requests live.
Point to the actual files. What already works, and what is missing for session 1?
Give me a small plan for selecting Fjordby and then Sodal. Do not edit yet.
```

Then ask workshop_implementer to use `$implement-slice` on the agreed change. Use the remote documentation questions in the card. Check both selections yourself.

If the plan grows too large:

```text
Keep this to the request list and details using the existing project.
Leave editing, review actions, new fields, sign-in, and new services for now.
Show the smallest useful next step.
```

## Session 2: Harness

A **harness** is the guidance and tools around the agent. A custom agent has a job; a skill describes a reusable procedure. You create two advisors and three skills in this session, then use them to make business and implementation decisions.

Open [session 2](02-build-session-2.md) and the [harness guide](agent-harness.md).

```text
Show me one starter agent and one starter skill. Explain the difference.
Help me design workshop_domain_advisor and workshop_technical_advisor, plus
implement-business-rules, implement-api-feature, and use-mcp. Use the templates and remote OpenAI Docs.
For each, explain its purpose, steps, output, and stopping point.
Let me review the design before you create the files.
```

After the files are created:

```text
Confirm which new agents and skills you can find. Have the domain advisor explain our rule examples and the technical advisor plan
the API change. Use all three skills with the implementer to build readiness. Show the actual results. If anything did not load,
say so. Help me improve one instruction based on what happened.
```

If you are unsure what an implementation skill should say, describe the project convention you want repeated. For example: keep rules in the existing server evaluator, return its result through the API, and let the screen display that result. Use [practical examples](engineering-examples.md) to help write the guidance.

## Session 3: Loop and graph

A **loop** tries, checks, and repairs. A **graph** shows the routes the work can take. You create a coordinator, a loop skill, and a React implementation skill. The coordinator leaves a short handoff; you do not need a separate handoff skill or a graph engine.

Open [session 3](03-build-session-3.md) and the [simple graph](execution-graph.md).

```text
Help me create workshop_coordinator, run-bounded-loop, and implement-react-feature.
Use the technical advisor to plan how the form and API work together. Let the
implementer use our API/React skills to build editing, saving, and rechecking.
Keep one code writer and stop after two repairs or 20 minutes, whichever is first.
I will monitor the time. If blocked, explain the blocker and stop.
Show which route through our graph was actually taken.
```

If a check fails:

```text
Explain the failure in plain language. What did we expect, and what happened?
Suggest one small repair. Check whether our agreed time/repair budget remains
before continuing. Do not change unrelated code to make the check disappear.
```

## Session 4: Check the result and understand what happened

**Evaluation:** compare expected and actual results. **Observability:** follow what happened. **Governance:** agree boundaries and let a person accept the change.

Open [session 4](04-build-session-4.md). Create workshop_verifier and workshop_reviewer, plus verify-change, review-change, and trace-behavior. Use them to check real application results and connect a response with its log and saved activity. The correlation ID is the reference number that connects the response and log.

```text
After creating the session-4 roles and skills, use workshop_verifier with
$verify-change and $trace-behavior.
Check incomplete review, successful review, repeated review, and editing after review.
Explain which checks actually ran. Follow one real action through the response,
server log, and activity where one was saved. Do not invent observations.
```

Then ask for a separate review:

```text
Ask workshop_reviewer to use $review-change on the actual diff and results.
What is correct, what needs attention, and what remains untested?
Also assess whether Codex stayed within the task and stopped as agreed.
Give a recommendation; leave the acceptance decision to me.
```

The app's **Mark reviewed** button changes a business request. Your review of **code changes** is a separate human decision.

## Optional export extension: Change existing code

**Brownfield** means code already exists and people may rely on its behavior. Here, the CSV exporter already works. Understand it before adding Status.

Open [the optional export extension](optional-export-extension.md). Create and use `change-brownfield`.

```text
Inspect the exporter, its callers, its tests, and an actual download before editing.
Explain what changes and what stays the same. Add Status as the last column.
Preserve the original two columns, row ordering, and formatting helper.
Check New and Reviewed values, show the actual file comparison, and ask the reviewer
to inspect the result. Explain unfamiliar formatting terms using this CSV.
```

Restart the API/frontend with the same database and check that saved values remain. Use the [release guide](06-final-solution.md) for the final journey and local release commands.

## When you are stuck

| What is happening? | What to ask Codex or do next |
| --- | --- |
| I do not understand the instruction | “Explain this using our request app. What is the first thing I should do?” |
| I do not understand a term | “Give one example of this term from our current task. Do not change files.” |
| The plan is too large | “Reduce this to one useful step that fits our current session.” |
| The app does not start | Share the failing command and relevant output. Ask Codex to check tools, working folder, PostgreSQL connection, and ports before changing code |
| A command fails | “Explain what failed and the smallest useful diagnostic check. Do not reinstall tools or erase data.” |
| Codex says it used a tool | Ask to see the actual result. If unavailable, record it as blocked |
| The tests pass but the screen is wrong | Give the browser example that failed. Ask which test would catch it |
| A custom agent or skill is missing | Check the active folder and files with the facilitator. See the harness guide |
| I am running out of time | Save your work, record the blocker, and ask the facilitator for help or a fresh recovery copy |

From the working-copy root, use `dotnet test Workshop.slnx`. From `web/`, use `npm test` and `npm run build`. Run the API and frontend in separate terminals and stop them with Ctrl+C. The [setup guide](00-before-first-build.md) has the exact commands. Never erase training data to fix a compilation problem.

## A useful closing question

“What did I learn, where did I use it, and what did I check myself?” A short, honest answer matters more than finishing an extra feature.
