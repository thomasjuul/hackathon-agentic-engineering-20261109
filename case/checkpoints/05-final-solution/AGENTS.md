# Project guidance

Implement the task provided in the current request. Read `docs/rules.md` and `docs/api-contract.md` before proposing changes. Ask for clarification when the requested behavior is unclear.

The application uses .NET 10/C#, React/TypeScript, and PostgreSQL. Server code is in `api/`, browser code in `web/src/`, and tests in `tests/` and `web/src/`. Use the existing components and API types. Keep changes within the agreed project scope; do not add business fields, services, or authentication without a request.

Use one code writer at a time. Run `dotnet test Workshop.slnx` at the project root, then `npm test` and `npm run build` in `web/`. Report actual outcomes and anything not run. Record useful development decisions and check results in `docs/evidence.md`. A human reviews the changes before accepting them.

Available custom agents: workshop_analyst, workshop_coordinator, workshop_domain_advisor, workshop_implementer, workshop_reviewer, workshop_technical_advisor, workshop_verifier.
Available skills: change-brownfield, frame-task, implement-api-feature, implement-business-rules, implement-react-feature, implement-slice, map-context, review-change, run-bounded-loop, trace-behavior, use-mcp, verify-change.

Use only definitions that exist. Microsoft Learn and OpenAI Docs MCP provide remote reference tools; optional remote GitHub requires approved access. Read local business rules directly. Documentation is not runtime evidence. Do not launch an MCP server locally or expose credentials. Role instructions do not grant extra permissions.

Use the domain advisor to clarify business decisions and the technical advisor to plan changes using existing code. The implementer applies only the implementation skills listed as available here after the plan is agreed. For browser work before a React skill exists, follow the existing components and typed API client. These roles guide implementation, not only verification.
