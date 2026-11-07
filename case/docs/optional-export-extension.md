# Optional extension: Add Status to an existing export

**When:** After the core builds and showcase preparation, or after the event. This is not a scheduled session or a requirement for completion. Allow roughly 45–85 minutes if you choose to continue.

The Day 1 brownfield discussion needs no live demo or coding case. This retained exercise is optional practice for later.

## What you are learning

**From greenfield to brownfield.** Greenfield means starting something new. Brownfield means changing something that already exists. Before changing existing code, find out how it works and what others rely on. Here, the CSV exporter has worked since the starter.

## What the app should do

The export keeps Municipality and Project title, then adds a final Status column containing New or Reviewed.


## Optional task

Begin by understanding the export that already exists. Create and use `change-brownfield`, a skill for inspecting existing code before changing it. Ask `workshop_analyst` to find the exporter, the code that uses it, and its tests. Download the current CSV and run the old tests before editing.

Ask the domain advisor to confirm what New and Reviewed mean in the export. Ask the technical advisor how to reuse the formatter and preserve its existing callers. Agree that Status will be the last column, containing New or Reviewed. Keep Municipality and Project title in their existing order, with their current values, row ordering, and file formatting. Ask Codex to explain any unfamiliar formatting terms using the actual CSV.

Ask `workshop_implementer` to use `change-brownfield` and `implement-slice` for a small change that keeps the supplied formatting helper. Add a check for both statuses and update only the old expectations affected by the new column. Use remote Microsoft Learn for a relevant file or text-encoding question and explain how the answer helps.

Export a New request and a Reviewed request, then compare the files before and after your change. Run the checks, stop the API and frontend with Ctrl+C, and restart using the same database. Confirm your saved information is still there. Ask `workshop_reviewer` to inspect the change and results, then record what you changed and verified.

## Try this with Codex

Start with this instruction and adapt it to your work:

```text
We have completed the core and are choosing the optional export extension. Help me create and use change-brownfield. Inspect the existing exporter, callers, and tests before editing. Explain what must stay the same. Then add Status as the final column with a small change, check both status values, and show that the original behavior still works. Use the analyst, implementer, and reviewer in sequence. Wait for my acceptance.
```

Then, when ready:

```text
Help me rehearse the final demonstration: open an incomplete request, correct and save it, mark it Reviewed, show its activity, and export both statuses. Show one actual passing check and one improvement in how we used Codex. Identify any supplied recovery work honestly.
```

Read Codex's plan and results yourself. If a role, skill, or remote tool is unavailable, record the problem and ask the facilitator. An unavailable tool is not a successful tool call.

## How you know it worked

- The header is Municipality,Project title,Status.
- Rows contain New or Reviewed as their last value.
- The original two columns and formatting remain correct.
- Saved app data remains after restart.
- You can explain a change in how you worked with Codex.

Run `dotnet test Workshop.slnx` from your working-copy root. Run `npm test` and `npm run build` from its `web/` folder. Ask Codex to run these with you and explain any failures. See [setup](00-before-first-build.md) for the full commands. Add checks for the new examples too; old passing tests alone do not prove the new feature works.


## Further optional challenges

- **Optional 1 — Filtered CSV export across UI and API:** the more approachable challenge.
- **Optional 2 — Two export contracts with a legacy consumer:** a harder challenge with more design work.

Both involve building a useful feature. Choose either; Optional 2 does not require Optional 1. See [the challenge steps and prompts](optional-challenges.md#export-extensions). Save your working core first. Completing optional work is never required for a later session or the final goal.
