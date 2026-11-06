# Build session 1: See requests and open their details

**When:** Day 1, 10:30–11:30. **Time:** 45 minutes core, up to 10 optional, then 5 for reflection.

## What you are learning

**Prompt and context engineering.** Your prompt tells Codex what to do. Context gives it the information needed to do the task correctly: the rules, examples, and existing code.

## What the app should do

Show a list of requests. When you select one, show its municipality, project title, description, budget checkbox value, and status. The details are read-only in this session.

## Work through the core task

Start by describing two examples in your own words: opening Fjordby should show its school project, and opening Sodal should show its library project. Give these examples to Codex together with the project rules and existing code.

Ask the supplied `workshop_analyst` agent to use `frame-task` and `map-context` to inspect the project and suggest a small plan. Discuss anything unclear before changing code. Use the remote OpenAI Docs connection to look up how AGENTS.md guides Codex, and Microsoft Learn to look up how an API returns “not found”. Ask how those answers help with your task.

When you agree with the plan, ask `workshop_implementer` to use `implement-slice` to build the request list and details. Use the existing fields, API client, and components. Leave editing and Mark reviewed for later sessions.

Try the result by selecting Fjordby and then Sodal. Check that each shows its own details and that the details cannot be edited. Ask Codex to run the checks below and show what changed, then review the result before accepting it.

## Try this with Codex

First ask for a plan:

```text
We are doing session 1: request list and read-only details.
Read AGENTS.md, docs/rules.md, and docs/api-contract.md.
Use workshop_analyst with $frame-task and $map-context to inspect the existing code.
Explain a small plan and any assumptions. Use the remote documentation questions
above to clarify project instructions and API not-found behavior. Do not edit yet.
```

After you review the plan:

```text
Use workshop_implementer with $implement-slice to build the agreed list and details.
Opening Fjordby must show its school project; opening Sodal must show its library project.
Keep the four existing fields and status read-only. Run the checks and show what changed.
Leave the acceptance decision to me.
```

## How you know it worked

- All three supplied requests appear in the list.
- Selecting each request shows its own correct details.
- The details cannot be edited yet.

Run the API checks from `case/start-here`:

```powershell
dotnet test Workshop.slnx
```

Run the frontend checks from `case/start-here/web`:

```powershell
npm test
npm run build
```

You can ask Codex to run these commands and explain the results.


## If you finish the core early

- **Optional 1:** Add search, a result count, and a no-results message.
- **Optional 2:** Put search and selection in the URL, with reload and Back/Forward support.

See [the challenge steps and prompts](optional-challenges.md#session-1). Choose either; Optional 2 does not require Optional 1. Neither is needed for the next session.
