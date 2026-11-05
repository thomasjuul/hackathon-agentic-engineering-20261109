# Build session 2: Show what information is missing

**Learning:** Harness engineering. **When:** 13:00-14:30 on day 1.

The business case is still four fields, three rules, and two statuses. Read docs/rules.md.

Use the prepared agent harness guide in the distribution's shared docs/agent-harness.md for the role definitions, skill catalogue, MCP tools, and setup.

## Learning outcome

Create custom agents and reusable skills yourself, use them on the readiness task, and improve them using observed feedback. Editing an existing example alone does not meet this outcome.

## Core task - 65 minutes

Reserve approximately 35 minutes for harness design/creation/discovery/use, 20 for the small readiness implementation, and 10 for verification/reflection within this budget. These are rehearsal targets. Protect harness creation if implementation needs facilitator support.

1. Inspect the two starter agents and three starter skills. Explain agent responsibility versus reusable procedure. Read the rules and write complete, missing-field, and whitespace examples.
2. Use inactive templates/custom-agent.toml and templates/workflow.SKILL.md scaffolds. Consult OpenAI Docs remote MCP for formats. Before generating files, design a verifier that runs checks/reports evidence and an independent reviewer that inspects diff/evidence without editing.
3. Create .codex/agents/workshop_verifier.toml and .codex/agents/workshop_reviewer.toml. Specify purpose, inputs, procedure, relevant skills, outputs, allowed changes, and stopping conditions. Do not copy completed answer checkpoints.
4. Create three new .agents/skills/<name>/SKILL.md files: verify-change, review-change, and use-mcp. Define triggers, steps, context/tools, evidence, and stopping/human-review behavior. Verification names the real command and distinguishes pass/fail/not-run; review separates recommendation from human acceptance; MCP use discovers tools, searches/fetches original remote sources, and explains applicability.
5. Update AGENTS.md to route the task through these roles/procedures. Confirm actual discovery, explicitly invoke every new skill, and delegate to both new custom agents. File creation or mentioning a role does not prove activation.
6. Use the new harness to implement the three server readiness checks and show Ready to review/Information missing. Keep rules on the server and reuse the existing evaluator/DTO.
7. Have the new verifier report actual results and the new reviewer assess diff/evidence. Improve at least one authored definition after feedback. Record authored files, actual use, improvement, remote sources, and human decision in docs/evidence.md.

## Required agent, skill, and MCP practice

- **Create:** two agents and three skills absent from the starter.
- **Use:** delegate to both new roles and invoke each new skill on the current task, including a relevant remote documentation lookup.
- **Improve:** revise a responsibility, procedure, or handoff after observing its effect.
- **Explain:** what belongs in a role, skill, AGENTS.md, and remote connection; report blocked attempts accurately.

If you recover a completed harness, label it supplied and still create/exercise a distinct role or skill before claiming the authoring outcome. Facilitators may supply an implementation slice to preserve time for this learning. No optional work is required.

## Acceptance examples

- A complete request is ready.
- Empty or whitespace-only names and titles are missing.
- Unchecked budget is missing; optional description never blocks.

For task help, adaptable prompts, and troubleshooting, use the shared go-to guide in the distribution's shared docs/go-to-guide.md.

## Suggested Codex task

> Help me create the session-2 harness from only two starter agents and three skills. First propose responsibilities for two new agents and procedures for three new skills; wait for my design review. Then help me author them from scaffolds, confirm discovery, and exercise each on the readiness task. Improve one definition after feedback. Do not copy reference answers or claim file creation proves activation.

## Optional tasks

### Optional 1: Documentation specialist and batch readiness

Create workshop_docs and a research-docs skill, demonstrate a remote source lookup, then use the guidance to implement batch readiness through existing endpoints.

**Deliverable:** A batch readiness UI and reusable task brief, with successful and failed results visible.

### Optional 2: Advanced harness and cancellable batch runner

From session-2 core, author a documentation specialist and plan-change skill specifying ownership, handoffs, conflicting findings, and stopping rules. Use them to implement the cancellable batch runner with at most three concurrent checks. Include needed research guidance yourself; Optional 1 is not required.

**Deliverable:** A robust batch execution component, progress UI, and evidence of cancellation and stale-result handling.

Optional 2 is deliberately more difficult and starts from this session's core; Optional 1 is not required. See the steps and Codex prompts in the distribution's shared docs/optional-challenges.md. Choose a working slice and stop for the next topic; neither level is needed later.

## Reflection and evidence

Run `powershell -File .\Verify.ps1` from your working copy. Existing green checks alone do not prove the new feature works. Write and run checks for your acceptance examples.

The instructor can supply the session-2 acceptance pack, or a fresh recovery copy of `02-after-build-2`. Preserve your own work first.

At the session close, explain the concept in your own words, how you used it with Codex, and one thing you would improve. Keep the record short. If implementation blocks progress, use facilitator support or a clearly identified recovery checkpoint so you can practise the next concept. Optional features never determine learning success.
