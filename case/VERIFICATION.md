# Verification status

## Current scope

The participant starter contains two custom agents and three skills. Reference checkpoints progress through 2/3, 2/3, 4/6, 5/8, 5/9, and 5/10 agents/skills. The full six-agent/twelve-skill example library is instructor-only, including optional documentation/planning examples. MCP configuration references existing remote Microsoft Learn and OpenAI Docs services, plus disabled optional read-only GitHub. No MCP server implementation, local launch command, loopback MCP endpoint, or stdio server is shipped.

## Structural and packaging checks

Project XML/JSON, six checkpoint layouts, role TOML, skill frontmatter, remote-only HTTPS configuration, document links/anchors, embedded task cards, and participant archive contents are checked. These checks do not execute the application or demonstrate live remote tool discovery.

## Still required before participant distribution

1. Run the existing Verify.ps1 against all six checkpoints on the intended Windows setup.
2. Verify actual PostgreSQL integration, browser journey, and local published release.
3. Check remote Microsoft Learn/OpenAI Docs connectivity, actual tool discovery, custom-agent delegation, and skill activation in VS Code Insiders/Codex.
4. Prepare approved GitHub authentication only if that optional remote connection will be used.
5. Rehearse the core path with a less experienced participant and preserve verified dependency locks.

## Remote-only revision - 4 November 2026

Removed the superseded local MCP servers, their protocol tests, and configuration generator. Updated skills, agents, core exercises, optional tasks, and go-to guidance. Application observations now use ordinary browser/API/test tools; handoffs are written directly to docs/evidence.md. Remote documentation calls record original sources and the decisions they inform, separately from runtime evidence. Historical local-server test results do not validate this remote setup.

Live remote connections and full application/Windows rehearsal have not been executed by this revision.

## Participant-authored harness revision - 4 November 2026

Session 2 requires creating two agents and three skills, discovering and using each, and revising one from feedback. Later sessions author coordinator/loop/handoff, tracing, and brownfield definitions. Added inactive scaffolds, stage-aware checks, and starter archive guards against completed-answer leakage. Optional definitions are not prerequisites. Static checks do not prove client activation, live remote calls, or that timing targets fit a beginner rehearsal.

## Presenter demo rehearsal - 4 November 2026

Added nine presenter demos under instructor/demos. Their dedicated verification record distinguishes script/factory checks and SQLite API execution from unrun Docker/browser/Codex/MCP/release work. Rehearsal found and fixed application-assigned ActivityEntry GUID tracking in all checkpoints by explicitly configuring ValueGeneratedNever. The review checkpoint now passes 16 API checks and final checkpoint 17. Seeded whitespace/review-gate failures and supplied recovery were executed successfully. See instructor/demos/VERIFICATION.md for exact results and remaining work.

## Organization-neutral wording revision - 5 November 2026

Updated case wording, app titles, package metadata, filenames/folders, links, and internal workshop runtime labels to neutral terms. Regenerated instructor diffs and learner/source/full archives. The final scan checks current source and nested archive paths/content for the removed branding. This revision does not change the business rules or learning progression; historical deliveries remain historical versions.
