# Agents, skills, and remote documentation

Use this mainly in session 2. You already know how to give Codex a task. Now you will write down guidance it can reuse.

## Start with the difference

| Part | The question it answers | Our example |
| --- | --- | --- |
| Custom agent | Who has this job? | The domain advisor explains rules; the technical advisor plans a small implementation |
| Skill | How should the job be done? | implement-api-feature describes the API implementation approach |
| AGENTS.md | What should agents know about this project? | Where the rules are and which roles to use |
| Remote MCP connection | Which outside tools can Codex use? | Search official documentation on Microsoft Learn |

A **harness** is this guidance and tooling around the agent. Think of a new colleague: a job description, a procedure, project notes, and access to reference material help them work consistently.

## What you already have

- `workshop_analyst`: helps understand the task and find the relevant code.
- `workshop_implementer`: makes one agreed change.
- Three skills: `frame-task`, `map-context`, and `implement-slice`.
- Templates in `case/docs/templates/` for your own agents and skills.
- Connections to remote Microsoft Learn and OpenAI Docs in `.codex/config.toml`.

From `case/start-here`, reach the templates at `../docs/templates/`. Copy a template into the project only when creating your own definition. The templates are starting points with blanks to fill in. They are not active agents or skills. Completed reference versions are in `case/checkpoints`; use them for help or recovery and clearly label any supplied definitions.

## What you create during the workshop

| Session | New agent | New skills | Why |
| --- | --- | --- | --- |
| 2 | workshop_domain_advisor and workshop_technical_advisor | implement-business-rules, implement-api-feature, use-mcp | Clarify rules and guide the API implementation |
| 3 | workshop_coordinator | run-bounded-loop, implement-react-feature | Organise limited work and guide the browser implementation |
| 4 | workshop_verifier and workshop_reviewer | verify-change, review-change, trace-behavior | Check the implemented behavior, code design, and real action outcomes |
| Optional export | No new agent | change-brownfield | Understand existing behavior before changing it |

Creating and trying the session 2–4 definitions is part of the core task. The export skill is optional. Do not skip it to build more app features. If code work takes too long, ask the facilitator for help so you can still practise the concept.

## Guidance you could keep in a real project

Use these definitions to shape the code, not only to confirm a result. The domain advisor turns requirements into clear rules and examples. The technical advisor explains how the API, database code, and React screen should work together. Your implementer uses those decisions and the implementation skills to build the feature.

For example, keep readiness rules in one server evaluator, keep endpoints focused on their API contract, and have the screen use the existing typed API client. That gives you reusable project conventions for the next feature too. In session 4, the verifier checks the resulting app and the reviewer assesses its code; neither is there to test whether a workshop document is correct.

See [practical examples](engineering-examples.md) for the decisions these roles and skills help you make. Keep the definitions short and specific to this project. You do not need an elaborate agent framework.

## How to create an agent or skill

Ask what it needs to read, what it should do, what result it should return, and when it should stop. Then check that business decisions and technical choices have clear owners. An advisor recommends an approach; the implementer changes the code. You remain responsible for accepting the work.

Agents go in `.codex/agents/`. Skills go in `.agents/skills/<name>/SKILL.md`. Ask Codex to consult remote OpenAI Docs for the current format. Then explicitly request the new agent and skill on the current task. Inspect the resulting work. A file on disk is not proof that Codex loaded it.

If its output is unclear, revise the instructions and explain why. Keep a short note in `docs/evidence.md`.

For example, a business-rule skill should explain where rules belong and how incomplete drafts behave. An API skill should describe the endpoint, rule, and persistence responsibilities. A React skill should describe component state and API use. These guide how you build the feature. Later, checking and review skills help assess the result.

```text
Help me design a domain advisor and an implement-business-rules skill for this project.
Explain the agent's business decisions and the skill's implementation steps separately.
Show me the templates and propose the content before creating files.
After I review it, help me create, discover, and use the new definitions.
```

Use only definitions available at the current session. Have one agent edit code at a time. A custom role does not give an agent extra permissions; it inherits the parent session's permissions and connections.

## Use remote documentation through MCP

MCP is a way for Codex to use tools provided by another service. Here, those tools search and fetch official documentation. You do not build or run an MCP server on your laptop.

| Connection | Use it for | Availability |
| --- | --- | --- |
| Microsoft Learn | .NET, API routes, database saving, logging, and tests | Included in the project configuration |
| OpenAI Docs | Codex project instructions, custom agents, skills, permissions, and MCP | Included in the project configuration |
| Remote GitHub | An approved repository's history or changes | Optional; disabled until approved access is ready |

Ask Codex to show which tools are actually available. Then ask one relevant question, fetch a supporting page, and explain what decision the answer helps with. Record the original URL. Each session card suggests questions.

```text
Show which tools you can actually use on remote Microsoft Learn and OpenAI Docs.
Use the relevant service to answer this question: [your question].
Fetch the supporting official page. Explain the answer using our current task,
give the source URL, and say what we should do differently because of it.
If the connection is unavailable, report that and do not invent a result.
```

Read our fictional business rules from local files. Check the running app using the browser, API calls, tests, and server logs. A documentation page tells you how something should work; it does not prove your code works.

## If discovery or a connection fails

Check that you opened your actual working folder and copied `.agents` and `.codex` with it. Inspect the client's tools/settings with the facilitator. Project trust, managed settings, network access, or client version can affect loading. Do not overwrite unrelated personal settings.

Record what was blocked. A normal local file read is not a remote MCP call. If you use a supplied recovery definition, label it supplied and still create and try a distinct agent or skill to practise authoring.

## Configuration reference

This is already supplied in `.codex/config.toml`; you do not need to type it again:

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

Keep one main session and at most two specialist agents active in the core path. Optional GitHub uses read-only access and is not required. Use the approved sign-in flow; never put tokens in prompts or commit them to the project.

For reference, the supplied reference solutions grow from 2 agents/3 skills to 4/6 after session 2, 5/8 after session 3, 7/11 after session 4, and optionally 7/12 after the export extension. These counts describe the reference, not a coding-speed competition.

Further reading: [custom agents](https://learn.chatgpt.com/docs/agent-configuration/subagents), [skills](https://learn.chatgpt.com/docs/build-skills), [MCP configuration](https://learn.chatgpt.com/docs/mcp), and [Microsoft Learn MCP](https://learn.microsoft.com/en-us/training/support/mcp-developer-reference).
