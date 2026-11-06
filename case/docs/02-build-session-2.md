# Build session 2: Give Codex reusable guidance

**When:** Day 1, 13:00–14:30. **Time:** 65 minutes core, up to 20 optional, then 5 for reflection.

## What you are learning

**Harness engineering.** A harness is the guidance and tools around an agent. Instead of explaining everything again in every prompt, you write down useful roles and ways of working. You will create some of these yourself.

## What the app should do

The app explains what information is missing. You also have your own agents and skills for business decisions and technical implementation.


## Work through the core task

Begin by looking at one supplied agent and one supplied skill with Codex. Use them as examples for guidance you would keep in a real project: what the business rules mean and how the code should be organised.

Create `workshop_domain_advisor` to clarify the rules and examples, and `workshop_technical_advisor` to suggest how to implement them using the existing .NET API and database code. The advisors explain their recommendations without editing; your implementer makes the agreed change. Create `implement-business-rules` to describe how rules become shared server logic, `implement-api-feature` to guide a small API change, and `use-mcp` to find supporting remote documentation. Start from the templates in `case/docs/templates` and use remote OpenAI Docs for the format. Review the proposed responsibilities before creating files.

Ask the domain advisor to explain missing names, titles, and budgets, including spaces-only values and the optional description. Ask the technical advisor where these checks belong and how the API should return them. Use remote Microsoft Learn for a relevant API question. Update AGENTS.md, confirm Codex can find the two agents and three skills, then use the implementer with your new skills to build the readiness feature. Keep the rules on the server and display its result in the browser.

Run the checks with Codex and review the actual behavior yourself. Improve one definition based on an unclear answer or implementation choice. Record which business or technical decision it helped you make. Aim for about 35 core minutes creating and trying the guidance, 20 implementing the feature, and 10 checking it. The dedicated checking and reviewing agents are created in session 4; you still check and review every change now.

## Try this with Codex

Start with this instruction and adapt it to your work:

```text
We are doing session 2. Help me design workshop_domain_advisor and workshop_technical_advisor, plus implement-business-rules, implement-api-feature, and use-mcp. Explain each job or procedure in simple language. Show me the starter examples and ask me to review the proposed responsibilities before creating files. Use remote OpenAI Docs for the format. Do not copy completed answers.
```

Then, when ready:

```text
Create the agreed agents and skills from our templates and update AGENTS.md. Confirm that Codex can find them. Use the domain advisor to explain the rules, the technical advisor to suggest a small design, and the implementer with the new skills to build the three readiness rules. Check the real result with me. Show actual results, help me improve one definition, and leave the acceptance decision to me.
```

Read Codex's plan and results yourself. If a role, skill, or remote tool is unavailable, record the problem and ask the facilitator. An unavailable tool is not a successful tool call.

## How you know it worked

- Name, title, and budget present: “Ready to review”.
- A missing name, title, or budget is named in the message.
- A name or title containing only spaces counts as missing.
- An empty description does not block readiness.
- Both advisors and all three new skills guided the implementation, or a blocked attempt is explained.
- You can explain one business decision and one technical decision that shaped the code.

Run `dotnet test Workshop.slnx` from your working-copy root. Run `npm test` and `npm run build` from its `web/` folder. Ask Codex to run these with you and explain any failures. See [setup](00-before-first-build.md) for the full commands. Add checks for the new examples too; old passing tests alone do not prove the new feature works.


## If you finish the core early

- **Optional 1 — Documentation specialist and batch readiness:** the more approachable challenge.
- **Optional 2 — Advanced harness and cancellable batch runner:** a harder challenge with more design work.

Both involve building a useful feature. Choose either; Optional 2 does not require Optional 1. See [the challenge steps and prompts](optional-challenges.md#session-2). Save your working core first. Completing optional work is never required for a later session or the final goal.
