# Build session 1: Understand and improve the request workspace

**When:** Day 1, 10:30-11:30. **Time:** 45 minutes core, up to 10 optional, then 5 for reflection.

## What is already available

The app opens directly to the request list. Fjordby, Sodal and Vesteng are loaded from PostgreSQL through the API. Selecting a request displays its municipality, project title, description, budget attachment indicator and status. This working list/detail flow is supplied functionality, not something you need to create.

## What you are learning

Prompt and context engineering: explain a desired improvement, identify the relevant code and contracts, agree on observable examples, and verify the result.

## Work through the core task

1. Run the supplied app and open Fjordby, then Sodal. Confirm that the selected request and details match.
2. Ask `workshop_analyst` to use `frame-task` and `map-context` to trace the browser, API and database flow. Read AGENTS.md, docs/rules.md and docs/api-contract.md.
3. Write two acceptance examples for the supplied selection behavior. Inspect its existing tests and identify what they prove and what still needs manual checking.
4. Choose one small improvement to the existing workspace, such as clearer missing-information copy, a more useful empty state, or a request count. Agree on its expected behavior before editing.
5. Ask `workshop_implementer` to use `implement-slice` for that improvement. Preserve the existing list and details. Leave business-rule checks, editing and review actions for later sessions.
6. Try the result, run the checks, inspect the diff and decide whether to accept it. Record what was supplied versus what you changed.

Use the remote OpenAI Docs connection to investigate how AGENTS.md guides Codex, and Microsoft Learn to investigate API not-found behavior. Explain how the answers affect your plan.

## Try this with Codex

```text
The request list and read-only details already work.
Read AGENTS.md, docs/rules.md and docs/api-contract.md.
Use workshop_analyst with $frame-task and $map-context to trace the current flow.
Propose one small usability improvement with two acceptance examples.
Do not rebuild the supplied list or add editing/review behavior. Do not edit yet.
```

After reviewing the plan:

```text
Use workshop_implementer with $implement-slice to implement the agreed improvement.
Preserve correct request selection and the existing API contracts.
Run the relevant checks and show the diff and actual results.
Leave the acceptance decision to me.
```

## How you know it worked

- All three supplied requests appear from the database.
- Selecting different requests shows the correct read-only details.
- The agreed improvement meets its acceptance examples.
- The UI contains only business-facing language.

Run `dotnet test Workshop.slnx` from the application root, followed by `npm test` and `npm run build` from `web/`.

## If you finish early

- Optional 1: add search, a result count and a no-results message.
- Optional 2: put search and selection in the URL with reload and Back/Forward support.

See [the challenge steps and prompts](optional-challenges.md#session-1). These extensions are not required by subsequent sessions. Checkpoint 01 preserves the common supplied list/detail baseline; each team's chosen usability improvement may differ.
