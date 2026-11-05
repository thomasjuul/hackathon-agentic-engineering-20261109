# Case: From Request to Review

## Your challenge

A fictional municipality sends your company a request about a project. Help a caseworker see the request, check its basic information, fix anything missing, and mark it reviewed.

You will build a small application with Codex. The main goal is to learn how to guide, verify, and review an agent’s work throughout development. You are engineering how Codex develops and changes the application. Autonomy means giving Codex a bounded goal, verification tools, feedback, and clear stopping conditions. The application itself needs no LLM integration.

## The whole business case

A request has four fields:

- Municipality name.
- Project title.
- Short description.
- “Budget attached” checkbox.

There are three rules: municipality name is required, project title is required, and the budget must be attached before the request can be marked reviewed. Empty or whitespace-only names and titles count as missing. Description is optional.

A request starts as **New**. When the information is complete, the caseworker can mark it **Reviewed**. Reviewed requests are read-only.

Example: “Fjordby — School renovation” has no budget attached. The application explains what is missing. Tick the checkbox and save; the request is ready to review.

All data and rules are fictional. No finance knowledge or actual document upload is needed.

## Your five build sessions

| Session | Practise with Codex | Application task |
| --- | --- | --- |
| 1 | Give the agent context and clear acceptance examples | See requests and open their details |
| 2 | Give the agent reusable instructions and verification tools | Show what information is missing |
| 3 | Trace graph branches and delegate a bounded feedback loop | Edit, save, and recheck a request |
| 4 | Evaluate the app and Codex run, observe results, and review changes | Mark reviewed and show the activity |
| 5 | Understand existing code, preserve behavior, and release | Add status to an existing CSV export |

## How to work

For each task: explain what should happen, give Codex the relevant context, let it implement a small change, run checks, and inspect the evidence before accepting the work.

Use .NET 10, C#, TypeScript, React, PostgreSQL, Windows Docker Desktop, VS Code Insiders, and Codex. Complete [setup before the event](case/docs/00-before-first-build.md).

Rotate who operates Codex. Use the supplied examples and recovery checkpoints when needed. Optional challenges add depth; none is required for a later session.

## Your final demonstration

Open an incomplete request, fix it, mark it reviewed, show the activity entry, and export it with its status. Show one passing check, your workflow graph and agent execution record, and explain one improvement you made to how you worked with Codex. If you need fresh examples for rehearsal, follow the [recovery and demo instructions](case/docs/recovery-and-demo.md).

Success means you understand the concepts, can show how to apply them, and feel more confident using Codex to solve given tasks. Explain what you tried, how you checked the result, and what you would change next time. Use a recovery checkpoint if needed to continue through all topics, and identify supplied work clearly.

## Optional challenges

Faster teams can build a searchable workspace, a batch readiness view, a resilient edit workflow, a diagnostic view, or a compatible filtered export. Each challenge applies the session concepts with Codex and has a meaningful deliverable. Choose the current session challenge after completing its core; no optional work is needed for later sessions or the final goal. Use a saved core baseline, stop at the scheduled session close, and continue unfinished stretch work later if desired.

See the [challenge guide](case/docs/optional-challenges.md) for steps, effort estimates, and extensions.

## Your go-to guide and optional levels

Use the [participant go-to guide](case/docs/go-to-guide.md) throughout the workshop for concept explanations, task-specific Codex prompts, and troubleshooting. Read the relevant section before a task or when you get stuck.

Every session offers [Optional 1 and Optional 2](case/docs/optional-challenges.md). Optional 1 is more approachable; Optional 2 is deliberately difficult. Both have a meaningful deliverable and suggested Codex instructions. Choose either after the core: Optional 2 does not depend on Optional 1. Save a core baseline and keep the next core session independent.

## Prepared agents, skills, and remote MCP

The starter includes two example agents and three example skills. Participants create two more agents and three skills as a vital session-2 task, then add coordination/tracing/brownfield workflows in later sessions. The pack includes inactive authoring scaffolds and project-scoped references to Microsoft Learn and OpenAI Docs remote MCP servers. No MCP server runs on the participant laptop. Read the [agent harness guide](case/docs/agent-harness.md), inspect .codex/config.toml in your active working copy, and verify remote tool discovery before the event. Optional remote GitHub is disabled until approved authentication/repository access is ready.
