# From Request to Review

A two-day hackathon about working with Codex and understanding agentic engineering.

## Why you are here

The goal is to understand the concepts, practise using them, and become more confident solving tasks with Codex. You do not need to be an expert in C#, React, or databases.

You will improve one small application during five build sessions. Each session introduces a way of working with an agent, then gives you a task where you can try it. Use the prepared code, ask for explanations, and check the results yourself.

## The story

A fictional municipality sends your company a request about a project. A caseworker needs to open the request, check its information, correct anything missing, and mark it Reviewed.

For example, Fjordby asks about a school renovation. The request has no budget attached. The app should explain what is missing. The caseworker ticks Budget attached, saves the change, and can then mark the request Reviewed.

All names, data, and rules are made up. You do not need finance knowledge or knowledge of your company's procedures. The budget checkbox is part of the exercise; no document upload is needed.

## Four fields, three rules, two statuses

A request has four fields:

| Field | What it contains |
| --- | --- |
| Municipality name | For example, Fjordby |
| Project title | For example, School renovation |
| Short description | Optional text about the project |
| Budget attached | A checkbox |

Before the request can be marked Reviewed:

Municipality name must be filled in. Then project title must be filled in.

Budget attached must be checked.

A name or title containing only spaces counts as empty. You can save incomplete information and come back to it later.

The saved status is either **New** or **Reviewed**. “Information missing” and “Ready to review” are explanations of the checks, not extra statuses. After a request becomes Reviewed, it cannot be edited.

## What you build over the two days

| Build session | What the app gains | What you practise with Codex |
| --- | --- | --- |
| 1: See the requests | A list and details for the selected request | Give a clear instruction and useful context |
| 2: Check the information | A message explaining what is missing | Create agents and skills that guide repeatable work |
| 3: Correct and save | Editing, saving, and updated checks | Try, check, repair, and stop within agreed limits |
| 4: Review the request | Mark Reviewed and show its activity | Check results, follow what happened, and review the change |
| 5: Improve an existing export | Add Status to the existing CSV download | Understand existing code and preserve behavior while changing it |

The same approach applies across the software development lifecycle: understand the need, plan, build, check, review, release, and improve. The app itself does not need an AI feature or model API key. Your learning comes from how you work with Codex to develop it.

## Get your case material

Clone [the hackathon repository](https://github.com/twoday-ai/hackathon-agentic-engineering-20261109). Open `case/start-here` in VS Code or VS Code Insiders and work there throughout the five sessions. Everything for the case is under `case`: guides, starting code, checks, and all six saved versions in `case/checkpoints`. Use completed checkpoints for reference or recovery and explain any supplied work. The repository also has `demos` for hackathon demonstrations and `slides` for presentation material; these are separate from your case work.

## Before the first build

Use .NET 10/C#, React/TypeScript, PostgreSQL installed on Windows, VS Code or VS Code Insiders, and Codex. The [setup guide](00-before-first-build.md) explains the direct commands and local database preparation. Complete setup before the event so build time can focus on the concepts.

The starter contains the app structure, three sample requests, existing tests, two example agents, and three example skills. You create more agents and skills during the sessions. It also references remote Microsoft Learn and OpenAI Docs MCP services; no MCP server is installed on your laptop.

## A few words you will meet

| Word | Meaning in this workshop |
| --- | --- |
| Prompt | Your instruction to Codex |
| Context | The information Codex needs, such as rules, code, and examples |
| Harness | The guidance and tools around the agent |
| Custom agent | An agent with a particular job, such as clarifying business rules or planning an API feature |
| Skill | Written steps the agent can reuse |
| MCP | A way for Codex to use tools from a service, such as documentation search |
| Loop and graph | Repeating work based on results, and a picture of the possible next steps |
| Evaluation, observability, governance | Checking results, seeing what happened, and deciding who may act or accept work |
| Brownfield | Changing code that already exists |

You do not need to learn all these words now. Each session explains its concept using the current task. The [word guide](words-and-concepts.md) is there when you need it.

## Guidance you can reuse in a project

In session 2 you create a business-rule advisor and a technical advisor. Your new skills describe how to implement business rules and API features using the existing project. Session 3 adds a React implementation skill. These help decide how the code should work, not only whether a check passes. Session 4 adds dedicated verifier/reviewer roles to assess the software change. You check and review the work yourself throughout both days.

## How to work in each session

Read the session card's goal and examples. Then ask Codex to inspect the relevant files and explain a small plan.

Check its assumptions, then let it make the agreed change. Then try the app and run relevant checks. Ask what passed, failed, or could not run.

Inspect the changed lines and decide whether to accept them. Then write a short note about what you learned and what you would improve.

Work in pairs or groups of three if helpful. Take turns directing Codex, checking the app, and reviewing changes. Everyone should operate Codex and explain at least one decision.

In session 2, creating two agents and three skills is a central task. Your session-2 advisors and skills guide business rules and API implementation. In session 3 you add coordination and React implementation guidance; session 4 adds dedicated checking/review roles and tracing. Session 5 adds existing-code change guidance. You will try the definitions, inspect their actual use, and improve them. This is more useful than simply copying completed answers.

## Your five session cards

- [Session 1 — See requests and open their details](01-build-session-1.md), day 1, 10:30–11:30.
- [Session 2 — Give Codex reusable guidance](02-build-session-2.md), day 1, 13:00–14:30.
- [Session 3 — Correct missing information and save it](03-build-session-3.md), day 1, 15:00–15:45.
- [Session 4 — Mark a request Reviewed and check the result](04-build-session-4.md), day 2, 09:30–11:30.
- [Session 5 — Add Status to an existing export](05-build-session-5.md), day 2, 12:30–14:30.

## Core and optional work

The **core** takes you through every topic and toward the final demonstration. Start there in every session.

If you finish early, choose **Optional 1** for a more approachable challenge or **Optional 2** for a deliberately harder one. Both involve building something useful. You can choose either; Optional 2 does not require Optional 1. No optional task is needed to complete a later session or reach the case goal.

The [challenge guide](optional-challenges.md) gives steps, prompts, effort estimates, and a manageable first step. Full challenges may take longer than the optional window. Save the core first and stop when the next topic starts.

## If you get stuck

Use the [go-to guide](go-to-guide.md) for explanations, prompts, and troubleshooting. Ask Codex: “Explain this using our app and give me one small next step.”

Ask the facilitator for help before a blocker consumes the session. A supplied checkpoint is a saved code version that can help you catch up. Keep your own work, inspect the supplied code, and say what was supplied. The aim is to experience all the concepts, not finish every line of code unaided.

## The final demonstration

Show this short journey:

Open an incomplete request and explain what is missing. Then correct it, save, and reload to show the change was stored.

Mark it Reviewed and show the activity entry. Then export requests with their status, keeping at least one New and one Reviewed.

Show one actual passing check and explain one improvement in how you worked with Codex. Use your simple graph and work notes to explain a decision.

The app's **Mark reviewed** action changes a request. Your acceptance of **code changes** is a separate human review decision.

Success means you can explain a concept, show where you applied it, and describe how you guided and checked Codex's work. A polished interface or extra feature is not the goal. Be clear about anything unfinished, untested, or supplied by the facilitator.
