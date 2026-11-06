# Build session 4: Mark a request Reviewed and check the result

**When:** Day 2, 09:30–11:30. **Time:** 90 minutes core, up to 25 optional, then 5 for reflection.

## What you are learning

**Evaluation, observability, and governance.** Evaluation asks “Did it work as expected?” Observability asks “Can we see what happened?” Governance asks “What may the agent do, and who accepts the result?” You will practise all three on one feature.

## What the app should do

A complete request can become Reviewed. The app records that action. An incomplete request cannot be reviewed, and a Reviewed request cannot be edited.


## Work through the core task

Start with the examples below and decide what each result should be. Create `workshop_verifier` to run application checks and `workshop_reviewer` to inspect the changes independently. Create `verify-change`, `review-change`, and `trace-behavior` to guide checking, reviewing, and following an action through its response, log, and saved activity. Use the same authoring approach you practised in session 2. A correlation ID is the reference number connecting the response and log. Try the skill through `workshop_verifier` and improve it using what you observe.

Use your domain advisor to clarify the review transition and your technical advisor to plan saving status and activity together. Have the implementer use your business-rule, API, and React skills to add Mark reviewed and the activity list. The server must check the rules even if someone bypasses the browser button. Save the Reviewed status and its activity together. Reviewing the same request again must not create a second activity entry.

Try a successful review and an incomplete review attempt. Follow a real response correlation ID to its message in the API terminal. A rejected review must not create a “Marked reviewed” activity. Use remote Microsoft Learn to clarify saving related changes together, and remote OpenAI Docs for a question about agent permissions or human review. Keep request descriptions and credentials out of logs.

If an example fails, use the bounded loop to investigate and repair it. If nothing fails in your run, ask the facilitator for a failed example to inspect and label it as supplied. Have your verifier report the actual results and your reviewer inspect the changes. Check both whether the app works and whether Codex used the right information, stayed within the task, reported honestly, and stopped as agreed. You decide whether to accept the change, request more work, or defer it.

## Try this with Codex

Start with this instruction and adapt it to your work:

```text
We are doing session 4. Help me create workshop_verifier and workshop_reviewer with verify-change, review-change, and trace-behavior. Use our domain/technical advisors and implementation skills to add Mark reviewed and its activity using the supplied helpers. Check the rules on the server. Verify incomplete review, repeated review, saved status, and editing after review. Show one real response/log/activity trace. Have the verifier and reviewer report separately. Explain the results plainly before I decide whether to accept the change.
```

Then, when ready:

```text
Now assess how Codex worked, separately from whether the app passed its checks. Did it use the agreed context, stay within scope, report failures, and stop at the agreed point? Add a short record of actual checks, repairs, elapsed time, limitations, and my decision.
```

Read Codex's plan and results yourself. If a role, skill, or remote tool is unavailable, record the problem and ask the facilitator. An unavailable tool is not a successful tool call.

## How you know it worked

- A complete request becomes Reviewed and remains Reviewed after reload.
- A missing name, title, or budget blocks review. Spaces-only names/titles also block it.
- A direct API review call cannot bypass the rules.
- Repeating review adds no duplicate activity.
- Reviewed requests cannot be edited in the UI or through the API.
- One real action can be followed through its response, log, and saved activity when successful.

Run `dotnet test Workshop.slnx` from your working-copy root. Run `npm test` and `npm run build` from its `web/` folder. Ask Codex to run these with you and explain any failures. See [setup](00-before-first-build.md) for the full commands. Add checks for the new examples too; old passing tests alone do not prove the new feature works.


## If you finish the core early

- **Optional 1 — Review diagnostics panel:** the more approachable challenge.
- **Optional 2 — Local failure-investigation workbench:** a harder challenge with more design work.

Both involve building a useful feature. Choose either; Optional 2 does not require Optional 1. See [the challenge steps and prompts](optional-challenges.md#session-4). Save your working core first. Completing optional work is never required for a later session or the final goal.
