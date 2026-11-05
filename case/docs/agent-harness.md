# Agents, skills, and remote MCP

The starter supplies two example agents and three workflow skills, plus references to existing remote MCP services. Participants author the remaining core harness; completed reference implementations stay in the instructor distribution. No MCP server runs locally, in Docker, through stdio, or on a loopback URL. The sample application and PostgreSQL still run locally using the existing setup.

## Understand the three parts

| Part | Purpose | Example |
| --- | --- | --- |
| Custom agent | Assign a delegated worker a clear responsibility | Analyst maps code; reviewer assesses a diff |
| Skill | Define a reusable way of working | frame-task, run-bounded-loop, change-brownfield |
| Remote MCP server | Give Codex tools from an existing external service | Search and fetch official Microsoft Learn/OpenAI documentation |

Definitions alone do not prove that Codex discovered or used them. Inspect actual agent delegation, skill use, and remote tool calls. Documentation retrieval informs a decision; it does not prove the application works.

## Remote connections supplied

| Server | Remote endpoint | Workshop use | Default |
| --- | --- | --- | --- |
| Microsoft Learn | https://learn.microsoft.com/api/mcp | .NET 10, ASP.NET Core, EF Core, persistence, logging, and testing guidance | Enabled |
| OpenAI Docs | https://developers.openai.com/mcp | Codex instructions, skills, custom agents, permissions, and MCP guidance | Enabled |
| GitHub | https://api.githubcopilot.com/mcp/ | Inspect an approved repository, commit, or PR as brownfield context | Disabled; optional authentication required |

Microsoft Learn and OpenAI Docs are the core MCP connections. GitHub uses its remote service in read-only mode; participants do not need GitHub access for the core path. Do not create issues, comments, or PRs as part of this exercise.

## Configure the active project

Every checkpoint includes .codex/config.toml with the remote URL references. New-Workspace.ps1 copies it into the active participant-work folder. There is no server implementation to build, package to launch, configuration generator, or MCP port to manage.

Inspect the project configuration before using it:

```toml
[agents]
enabled = true
max_concurrent_threads_per_session = 3

[mcp_servers.openaiDeveloperDocs]
url = "https://developers.openai.com/mcp"
enabled = true

[mcp_servers.microsoft_learn]
url = "https://learn.microsoft.com/api/mcp"
enabled = true

[mcp_servers.github]
url = "https://api.githubcopilot.com/mcp/"
http_headers = { "X-MCP-Readonly" = "true" }
enabled = false
```

Open the active folder as a trusted project in the approved Codex client. Preserve unrelated project/personal settings if merging into an existing project. Managed policy, project trust, network/proxy restrictions, or an older client can prevent loading. Rehearse the exact VS Code Insiders/Codex setup before the event. The config contains no credentials. If optional GitHub is enabled, use the approved client authentication flow; never paste tokens into chat or commit credentials.

Check discovery through the client's MCP tools/settings. The CLI additionally offers codex mcp list and its interactive /mcp view; those commands are not universal IDE slash commands.

```text
Confirm which workshop custom agents and repo skills you can discover.
List the tools actually available on the remote Microsoft Learn and OpenAI
Docs MCP servers. Search one relevant question on each, fetch an original
supporting page, and explain what the page supports. Show source URLs.
Do not claim a remote call succeeded if it is unavailable.
```

Discover actual tool names and schemas instead of guessing. Microsoft Learn documentation describes search, fetch, and sample lookup tools, but service schemas may change. If a connection fails, report it blocked and ask the facilitator for help. Continue with supplied local contracts as a labelled fallback; do not report an ordinary file read as MCP use.

## What is supplied and what you create

| Stage | Agents available in the core reference | Skills available in the core reference | Participant authoring |
| --- | --- | --- | --- |
| Starter and after session 1 | 2 | 3 | Inspect and use the supplied examples |
| After session 2 | 4 | 6 | Create 2 agents and 3 skills, then use and improve them |
| After session 3 | 5 | 8 | Create coordinator plus loop/handoff skills |
| After session 4 | 5 | 9 | Create tracing skill |
| After session 5 | 5 | 10 | Create brownfield skill |

These counts describe the reference core path, not a grading quota or all files participants must copy. Optional agents/skills can differ. The participant pack contains only the starter; full answers and the wider example library remain instructor-only.

### Supplied examples

- Agents: workshop_analyst (frame/map context) and workshop_implementer (own one accepted slice).
- Skills: frame-task, map-context, and implement-slice.
- Remote configuration: Microsoft Learn/OpenAI Docs; optional authenticated read-only GitHub.
- Inactive scaffolds: templates/custom-agent.toml, templates/workflow.SKILL.md, and templates/verify-change.SKILL.md.

Templates are outside the active discovery locations and contain placeholders. Copy them only as the starting point for your own definition. Do not report a template as an operational agent/skill.

### Create during session 2

Create workshop_verifier and workshop_reviewer under .codex/agents/. Give the verifier responsibility for actual checks and the reviewer responsibility for independently inspecting diff/evidence. Specify inputs, outputs, tools/skills, boundaries, and stopping conditions. The reviewer recommends; the human accepts.

Create verify-change, review-change, and use-mcp under .agents/skills/<name>/SKILL.md. Define when each procedure applies, ordered steps, evidence/output, and handling of failures/ambiguity. Use the real verification command and remote documentation tools. Distinguish passed, failed, and not run.

Review the design before asking Codex to generate files. Confirm discovery; explicitly invoke each new skill and delegate to both new agents on the readiness task. Inspect actual outputs, revise at least one definition using feedback, and record what changed. Authoring and exercising the harness is essential, not an optional addition after implementing the app.

### Create during later sessions

- Session 3: workshop_coordinator, run-bounded-loop, and record-handoff. Define single-writer ownership, handoffs, feedback branches, an execution budget, and human review.
- Session 4: trace-behavior. Define how to follow real response/correlation/log/activity evidence without inventing observations.
- Session 5: change-brownfield. Define caller/contract discovery, preservation boundaries, regression checks, and review.
- Optional session-2 depth: create workshop_docs and research-docs, or create an advanced plan-change procedure and documentation specialist. These optional definitions are not prerequisites for later core work.

Project role files use name, description, and developer_instructions in TOML. Skill files use name and description YAML frontmatter followed by working instructions. Look up current details through remote OpenAI Docs. Agent names alone do not activate a role: request delegation and inspect discovery/child results. Agents inherit parent permissions/MCP connections; role instructions are not separate sandboxes. Keep one writer and at most two child agents in the basic path.

If recovering a completed checkpoint, label its definitions supplied. Still author/exercise a distinct role or skill to demonstrate the learning outcome. Do not erase the participant's earlier work or treat copying a reference answer as authoring.

## Practice throughout the sessions

| Session | Agent/skill practice | Remote MCP question | Application evidence |
| --- | --- | --- | --- |
| 1 | Analyst frames/maps; implementer builds the first slice | OpenAI repository instructions/context; Microsoft minimal-API routing/JSON | Browser/API selections |
| 2 | Create verifier/reviewer and 3 skills; invoke, evaluate, improve | OpenAI skill/custom-agent configuration; Microsoft API validation | Actual readiness checks |
| 3 | Create coordinator and loop/handoff skills; sequence bounded work | Agent permission inheritance; EF Core async persistence | Save/reload and stopping record |
| 4 | Create tracing skill; separate verification and review | EF transactions/concurrency; human review/permission boundaries | Direct API checks, correlation log, activity |
| 5 | Create brownfield skill; map callers and review compatibility | ASP.NET file/encoding behavior; optional GitHub history | CSV downloads and regression results |

Read rules, contracts, and prior handoffs directly from repository files. Use normal browser, direct HTTP, tests, and server logs for runtime behavior. Record MCP server/tool, query, original URL, supported claim, relevance, and resulting decision in docs/evidence.md. Keep a short record rather than copying large documentation pages.

## Prompt example

```text
Use only agents/skills created by this session. In session 1 the main Codex
session performs documentation research directly; from session 2 invoke the
participant-created $use-mcp skill. The workshop_docs role is optional, not a
pre-existing core dependency. Use the relevant remote Microsoft Learn or OpenAI Docs server.
Discover tools, search, fetch the original supporting page, and return the
source URL and the decision it informs. Read our fictional rules directly
from local files. Use one implementer for the accepted change, then a verifier
and separate reviewer. Run actual checks and record results and sources in
docs/evidence.md. Documentation is not proof of runtime behavior.
```

Optional 1 applies these practices to an approachable feature. Optional 2 adds harder coordination or compatibility work. Remote GitHub is available only when approved access is ready; ordinary local files/diffs remain a valid core alternative. No local browser MCP server is included: use ordinary browser tools for the application.

## Pre-event verification

Check config TOML and remote-only transport structure, then verify live connections, actual tools, custom-role discovery/delegation, and skill activation in the intended client. Static checks do not demonstrate remote connectivity. The application, PostgreSQL, browser journey, and Windows rehearsal still require their existing verification.

References checked 4 November 2026: [Codex custom agents](https://learn.chatgpt.com/docs/agent-configuration/subagents), [repo skills](https://learn.chatgpt.com/docs/build-skills), [Codex MCP configuration](https://learn.chatgpt.com/docs/mcp), [Microsoft Learn MCP](https://learn.microsoft.com/en-us/training/support/mcp-developer-reference), and [GitHub remote MCP configuration](https://github.com/github/github-mcp-server/blob/main/docs/server-configuration.md).
