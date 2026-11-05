# Build session 1: See requests and open their details

**Learning:** Prompt and context engineering. **When:** 10:30-11:30 on day 1.

The business case is still four fields, three rules, and two statuses. Read docs/rules.md.

Use the prepared [agent harness](agent-harness.md) for the role definitions, skill catalogue, MCP tools, and setup.

## Learning outcome

Explain prompt versus context using your task. Show one instruction or context improvement and how you checked Codex understood the task.

## Core task

1. Write two acceptance examples: opening Fjordby shows its school project; opening Sødal shows its library project.
2. Ask Codex to inspect AGENTS.md, docs/rules.md, docs/api-contract.md, api/WorkshopDb.cs, and web/src/api.ts before editing.
3. Ask for a short plan. Identify one assumption and confirm or correct it before implementation. Implement GET /api/requests and GET /api/requests/{id} in api/Endpoints.cs.
4. Replace the health-only web/src/App.tsx with a request list and selectable detail panel. Keep health and database plumbing intact.
5. Use the existing types and API client. Show municipality, title, description, budget checkbox value, and status as read-only details.
6. Run Verify.ps1 and check both examples in the browser. Save your changes and write a short review note.

## Required agent, skill, and MCP practice

1. Delegate framing/context mapping to workshop_analyst with $frame-task/$map-context, then give the accepted slice to workshop_implementer with $implement-slice. Keep one writer.
2. Read fictional rules/contracts directly from the repository. Use OpenAI Docs MCP to clarify repository instructions/context, and Microsoft Learn MCP for a relevant minimal-API routing or JSON-response question. Fetch original supporting pages and explain the decision they inform.
3. Inspect two requests with the browser/direct API and write actual observations and source references directly in docs/evidence.md.

Keep this within the existing core time. Report unavailable remote calls as blocked and ask the facilitator for help; never invent a lookup result.

## Acceptance examples

- Both selections show their own correct data.
- Unknown request IDs return 404.
- The existing CSV exporter is unchanged.

For task help, adaptable prompts, and troubleshooting, use the shared [go-to guide](go-to-guide.md).

## Suggested Codex task

> Read the brief, repository guidance, API contract, and existing code. Plan and implement only the list and details. Verify two different selections and report the actual results before I review the change.

## Optional tasks

### Optional 1: Searchable request workspace

Add case-insensitive municipality/title search, a result count, and an empty state using loaded data.

**Deliverable:** A searchable list/detail workspace and a short context brief.

### Optional 2: URL-driven workspace with browser navigation

Starting from the session-1 core, implement search and selected-request state in the URL. Specify how unknown IDs, invalid query values, and filtered-out selections behave.

**Deliverable:** A shareable workspace whose URL and screen remain consistent across reload and browser navigation.

Optional 2 is deliberately more difficult and starts from this session's core; Optional 1 is not required. See the [steps and Codex prompts](optional-challenges.md#session-1). Choose a working slice and stop for the next topic; neither level is needed later.

## Reflection and evidence

Run `powershell -File .\Verify.ps1` from your working copy. Existing green checks alone do not prove the new feature works. Write and run checks for your acceptance examples.

The instructor can supply the session-1 acceptance pack, or a fresh recovery copy of `01-after-build-1`. Preserve your own work first.

At the session close, explain the concept in your own words, how you used it with Codex, and one thing you would improve. Keep the record short. If implementation blocks progress, use facilitator support or a clearly identified recovery checkpoint so you can practise the next concept. Optional features never determine learning success.
