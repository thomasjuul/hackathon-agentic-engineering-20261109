# Build session 3: Correct missing information and save it

**When:** Day 1, 15:00–15:45. **Time:** 30 minutes core, up to 10 optional, then 5 for reflection.

## What you are learning

**Loop and graph engineering.** A loop means trying a change, checking it, and repairing it if needed. A graph shows the possible next steps. Here, a passing check leads to human review; a failed check may lead to repair. A blocker means stop and explain.

## What the app should do

The caseworker can edit the four existing fields, save, and see the updated information after reloading the page.


## Work through the core task

Give Codex one clear goal: let the caseworker correct the existing fields, save the request, and see the updated readiness result. Create `workshop_coordinator` and `run-bounded-loop` to organise the work. Also create `implement-react-feature`, a skill for using the existing React components and typed API client, showing saving/error feedback, and keeping a draft when saving fails.

Ask the technical advisor how to connect the edit form, API call, and saved response without putting business rules in the screen. Use the domain advisor if a business decision is unclear. Let the coordinator sequence one implementer using the business-rule, API, and React skills where relevant. Use the main Codex session or analyst for checks and review the result yourself; the dedicated verifier and reviewer come in session 4.

Follow the [execution graph](execution-graph.md). Allow at most two repairs or 20 minutes of agent work, whichever comes first. You monitor the time. If blocked or out of time, stop and explain what remains. You do not need to build a graph framework.

You should be able to save incomplete information as a draft. After a successful save, the screen should show the saved values and updated readiness. Try Fjordby by ticking Budget attached, saving, and reloading. If saving fails, keep the draft and show an error. Review the change and have the coordinator leave a short development handoff in `docs/evidence.md`.

## Try this with Codex

Start with this instruction and adapt it to your work:

```text
We are doing session 3. Help me create workshop_coordinator, run-bounded-loop, and implement-react-feature. Use our technical advisor to plan the form/API boundary, then have the implementer use the API and React skills to build editing, saving, and rechecking. Leave a short handoff in docs/evidence.md. Explain the route using the supplied graph. Keep one code writer. Stop after two repair attempts or 20 minutes, or sooner if blocked. I will monitor the time. Show results for human review.
```

Then, when ready:

```text
Check Fjordby by ticking Budget attached, saving, and reloading. Explain what was saved and which checks actually ran. Record the route taken, any repairs, and why you stopped. Do not claim that a prompt enforces a timer.
```

Read Codex's plan and results yourself. If a role, skill, or remote tool is unavailable, record the problem and ask the facilitator. An unavailable tool is not a successful tool call.

## How you know it worked

- Correcting and saving the budget changes the readiness result.
- Saved values remain after a page reload.
- A failed save keeps the draft and shows an error.
- Your record states the stopping rule and why the run ended.

Run `dotnet test Workshop.slnx` from your working-copy root. Run `npm test` and `npm run build` from its `web/` folder. Ask Codex to run these with you and explain any failures. See [setup](00-before-first-build.md) for the full commands. Add checks for the new examples too; old passing tests alone do not prove the new feature works.


## If you finish the core early

- **Optional 1 — Unsaved-change protection:** the more approachable challenge.
- **Optional 2 — Race-safe editing across requests:** a harder challenge with more design work.

Both involve building a useful feature. Choose either; Optional 2 does not require Optional 1. See [the challenge steps and prompts](optional-challenges.md#session-3). Save your working core first. Completing optional work is never required for a later session or the final goal.
