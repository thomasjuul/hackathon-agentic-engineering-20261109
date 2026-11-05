# Workshop repository guidance
Read TASK.md for the current session and docs/rules.md for the three business rules.
Keep changes within this checkpoint. Do not inspect sibling answer checkpoints unless asked.
The application uses C#/.NET 10, React/TypeScript, and PostgreSQL. Keep existing components.
Server: api/. Browser: web/src/. Tests: tests/ and web/src/*.test.tsx.
Verification from this checkpoint: powershell -File .\Verify.ps1
Start from this checkpoint: powershell -File .\Start.ps1
Do not add extra fields, business rules, external services, or authentication.

Business rules belong in api/Readiness.cs; the browser displays the server's result.
Use $verify-change after an implementation change and report actual results.
Preserve independent acceptance behavior; do not weaken tests to hide failures.
Finish with the changed behavior, check results, limitations, and a human review point.
When delegated a bounded loop, stop after its agreed iteration or time budget.

## Workshop agent harness progression
Available agents: workshop_analyst, workshop_coordinator, workshop_implementer, workshop_reviewer, workshop_verifier.
Available skills: change-brownfield, frame-task, implement-slice, map-context, record-handoff, review-change, run-bounded-loop, trace-behavior, use-mcp, verify-change.
Use only definitions that actually exist. Session 2 creates verifier/reviewer agents and verify-change/review-change/use-mcp skills; session 3 adds coordinator and loop/handoff skills; sessions 4-5 add tracing and brownfield skills. The starter is deliberately incomplete. Keep one implementation owner. Read rules/contracts directly. Use only remote Microsoft Learn/OpenAI Docs MCP for external technical questions; optional remote GitHub needs approved access. Write evidence in docs/evidence.md. Do not launch MCP servers locally. Human review remains required.
