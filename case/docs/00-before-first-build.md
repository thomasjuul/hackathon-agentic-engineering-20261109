# Before the first build session

Complete this before the event. Aim to arrive with a working green health screen, not an installation task.

## 1. Install and sign in

Use the organisation-approved versions of:

- Windows with Docker Desktop using Linux containers and WSL 2.
- .NET 10 SDK (the runtime alone is insufficient).
- Node.js 22.12 or newer; reference version 22.14.0, including npm.
- VS Code Insiders, its C# tools, and Codex. Sign in and try one small read-only task.
- Git if your team wants to checkpoint its work with commits.

The core app requires no model API key and no external business service. Ports: browser 5173, API 5080, local PostgreSQL 54329.

The PostgreSQL password is a public local-training value. The container port binds to localhost. This is a single-user workshop setup.

## 2. Open PowerShell at the distribution root

Run the commands from the folder containing workshop.json and compose.yaml:

```powershell
powershell -File .\scripts\Check-Setup.ps1
powershell -File .\scripts\New-Workspace.ps1
powershell -File .\scripts\Start.ps1
```

The copy is created at participant-work. It is the folder to open in VS Code Insiders. Both new terminal windows must stay open. Visit http://127.0.0.1:5173 and confirm the API and PostgreSQL are ready.

The launcher restores .NET packages, installs browser packages, starts PostgreSQL, and seeds three fictional requests. Approve network access according to your organisation's policies. On first frontend installation npm creates a package-lock.json; preserve it and the launcher then uses npm ci. No lockfile has been pre-generated in this distribution because dependency installation was unavailable during authoring.

## 3. Verify the baseline

```powershell
powershell -File .\scripts\Verify.ps1
```

This runs API tests with isolated SQLite, frontend tests, and a frontend production build. It does not modify your demo database. Initial green checks verify the supplied foundation; they do not mean future exercises are implemented.

## 4. Read the tiny case

Municipality name, project title, description, and Budget attached. Three required items: name, title, budget. New becomes Reviewed. Reviewed is read-only.

Before session 1, write two examples of selecting different requests. Read participant-work/TASK.md. Keep reference answer checkpoints closed while doing the exercises.

## 5. Preserve work and recover safely

The participant-work folder is your evolving application across all five sessions. You do not automatically switch checkpoints after every session. Checkpoints are reference answers and recovery starting points. Use the baseline map in [Recovery and demonstration](recovery-and-demo.md); the instructor supplies recovery sources missing from the participant pack. Inspect and verify the recovered behavior before continuing.

To recover, stop the app and create a new folder rather than copying over your work:

```powershell
powershell -File .\scripts\Stop.ps1
powershell -File .\scripts\New-Workspace.ps1 -Checkpoint 02-after-build-2 -Destination .\recovery-session-2
powershell -File .\scripts\Start.ps1 -Workspace .\recovery-session-2
```

All workspaces use the same local demo database so requests survive a restart or source change. To restore the original examples, stop the API, run scripts/Reset-Data.ps1, type RESET when prompted, then start again. A data reset affects every workspace using this shared local database.

## If something fails

- Tool missing: fix it before build time. Restart PowerShell after installation so PATH updates.
- Database unavailable: start Docker Desktop, choose Linux containers, and inspect docker compose logs.
- Package restore blocked: ask the environment facilitator about the approved proxy, certificates, or package source.
- Port occupied: use scripts/Stop.ps1 for the recorded launcher, or close manually started app terminals.
- Script execution blocked: follow your organisation's approved PowerShell policy; do not bypass it as a workshop instruction.
- Exported requests already reviewed: use a confirmed data reset if fresh seed data is needed.

Use the exact Windows configuration for the rehearsal. Local source checks on another operating system cannot establish that this setup works on a managed Windows laptop.

## Prepared agents, skills, and remote MCP

The starter includes two example agents and three example skills. Participants create two more agents and three skills as a vital session-2 task, then add coordination/tracing/brownfield workflows in later sessions. The pack includes inactive authoring scaffolds and project-scoped references to Microsoft Learn and OpenAI Docs remote MCP servers. No MCP server runs on the participant laptop. Read the [agent harness guide](agent-harness.md), inspect .codex/config.toml in your active working copy, and verify remote tool discovery before the event. Optional remote GitHub is disabled until approved authentication/repository access is ready.
