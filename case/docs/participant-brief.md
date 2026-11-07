# Your hackathon brief — From Request to Review

## The goal

Become more familiar with agentic engineering: understand the concepts, try them on real tasks, and use Codex with more confidence. You do not need to be an expert in the application stack.

## The case in one minute

A fictional municipality sends your company a project request. Help a caseworker see it, check what is missing, correct it, and mark it Reviewed.

The request contains municipality name, project title, an optional description, and a Budget attached checkbox. Name and title must be filled in, and budget must be checked before review. Names/titles containing only spaces count as empty.

A request starts **New**. When complete, it can become **Reviewed**. Reviewed requests cannot be edited. The budget checkbox needs no file upload. All data and rules are fictional.

## What you will do

| Session | App task | Learning focus |
| --- | --- | --- |
| 1 | Show requests and their details | Give Codex a clear task and useful information |
| 2 | Explain what information is missing | Create your own agents and reusable skills |
| 3 | Edit and save a request | Check, repair, and stop within agreed limits |
| 4 | Mark Reviewed and show activity | Check results, follow an action, and review the work |

Use .NET 10/C#, React/TypeScript, PostgreSQL installed on Windows, VS Code or VS Code Insiders, and Codex. Complete [setup before the event](00-before-first-build.md).

## Get your case material

Clone [the hackathon repository](https://github.com/twoday-ai/hackathon-agentic-engineering-20261109). Open `case/start-here` in VS Code or VS Code Insiders and work there throughout the four sessions. Everything for the case is under `case`: guides, starting code, project tests, and all six saved versions (five core stages plus an optional export reference) in `case/checkpoints`. Use completed checkpoints for reference or recovery and explain any supplied work. The repository also has `demos` for hackathon demonstrations and `slides` for presentation material; these are separate from your case work.

## How the days fit together

Day 1: Build 1 (10:30–11:30), Harness Engineering (12:30–13:30), then Build 2 (13:30–15:00). From Greenfield to Brownfield is a discussion at 15:00–15:45, followed by wrap-up; it needs no separate case or coding task.

Day 2: after follow-up, Loop and Graph Engineering opens at 09:00–09:30, followed by Build 3 (09:30–11:30). Evaluation, Observability, and Governance runs at 12:00–12:30, followed by Build 4 (12:30–14:30): complete review/activity, check and refine the solution, and prepare the showcase. Basic checks, stopping conditions and human acceptance apply throughout. Graph engineering stays high level.

## How to use the material

Read the current session card, ask Codex for a small plan, review its assumptions, then let it make the change. Try the result, inspect the checks and changed lines, and decide whether to accept the work. Take turns operating Codex in your team.

The starter supplies two agents and three skills. You create more during the core exercises. A custom agent has a job; a skill describes how to do a job. Remote Microsoft Learn/OpenAI Docs tools help you look up technical questions. No local MCP server or model API key is needed.

Keep short notes about what you tried, what happened, and what you learned. Your task is to understand and apply the concepts, not finish the most features.

## Guidance you can reuse in a project

In session 2 you create a business-rule advisor and a technical advisor. Your new skills describe how to implement business rules and API features using the existing project. Session 3 adds a React implementation skill. These help decide how the code should work, not only whether a check passes. Session 4 adds dedicated verifier/reviewer roles to assess the software change. You check and review the work yourself throughout both days.

## Help and extra challenges

Use the [go-to guide](go-to-guide.md) for explanations and suggested Codex prompts. Use [words and concepts](words-and-concepts.md) for unfamiliar terms.

Complete the core first. Optional 1 is more approachable; Optional 2 is deliberately harder. Both build useful features, but neither is needed for later sessions or the final goal. Choose either and stop for the next topic.

If blocked, save your work and ask the facilitator for help or a recovery checkpoint: a saved code version that lets you continue. Explain which work was supplied.

## At the end

Show an incomplete request, correct and save it, mark it Reviewed, show its activity, and demonstrate that reviewed requests cannot be edited. Exporting Status is optional. Show one check and explain a decision you made while working with Codex.

Be ready to answer: **What did you learn, where did you use it, and what did you check yourself?**
