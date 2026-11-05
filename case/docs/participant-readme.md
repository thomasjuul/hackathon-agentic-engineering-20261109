# From Request to Review — participant pack

The goal of this hackathon is to become more familiar with agentic engineering: understand its concepts, practise applying them, and use Codex to solve given tasks. The sample application provides a shared exercise for that learning.

Start with docs/00-before-first-build.md. Open PowerShell in this folder and run:

```powershell
powershell -File .\scripts\Check-Setup.ps1
powershell -File .\scripts\New-Workspace.ps1
powershell -File .\scripts\Start.ps1
```

Open participant-work in VS Code Insiders. Your first task is in TASK.md. Continue in the same working copy through all five sessions; use the next session card from docs/ as you progress.

The instructor releases each session's acceptance tests separately and can provide a recovery copy without overwriting your work. This pack intentionally contains only the starter code, not reference answers.

You are engineering how Codex develops and changes the application. Autonomy means giving Codex a bounded goal, verification tools, feedback, and clear stopping conditions. The application itself needs no LLM integration.

Use .NET 10, C#, React/TypeScript, PostgreSQL, Windows Docker Desktop, VS Code Insiders, and Codex. See docs/execution-graph.md and docs/recovery-and-demo.md.

Four fields, three rules, two statuses. The goal is to learn how to specify, build, verify, review, release, and maintain a small application with Codex.

## Optional challenges

Faster teams can build a searchable workspace, a batch readiness view, a resilient edit workflow, a diagnostic view, or a compatible filtered export. Each challenge applies the session concepts with Codex and has a meaningful deliverable. Choose the current session challenge after completing its core; no optional work is needed for later sessions or the final goal. Use a saved core baseline, stop at the scheduled session close, and continue unfinished stretch work later if desired.

See the [challenge guide](optional-challenges.md) for steps, effort estimates, and extensions.

## Your go-to guide and optional levels

Use the [participant go-to guide](go-to-guide.md) throughout the workshop for concept explanations, task-specific Codex prompts, and troubleshooting. Read the relevant section before a task or when you get stuck.

Every session offers [Optional 1 and Optional 2](optional-challenges.md). Optional 1 is more approachable; Optional 2 is deliberately difficult. Both have a meaningful deliverable and suggested Codex instructions. Choose either after the core: Optional 2 does not depend on Optional 1. Save a core baseline and keep the next core session independent.

## Prepared agents, skills, and remote MCP

The starter includes two example agents and three example skills. Participants create two more agents and three skills as a vital session-2 task, then add coordination/tracing/brownfield workflows in later sessions. The pack includes inactive authoring scaffolds and project-scoped references to Microsoft Learn and OpenAI Docs remote MCP servers. No MCP server runs on the participant laptop. Read the [agent harness guide](agent-harness.md), inspect .codex/config.toml in your active working copy, and verify remote tool discovery before the event. Optional remote GitHub is disabled until approved authentication/repository access is ready.
