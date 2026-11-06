# What has been checked

Your case uses PostgreSQL installed on Windows, with a default local port of 5432. You start, check, and publish the app with standard .NET and npm commands. The setup guide includes PostgreSQL PATH instructions and lets you use VS Code or VS Code Insiders.

## Your starting point and references

Work in `case/start-here` through the five sessions. It starts with two agents and three skills. All six saved reference versions and the session acceptance checks are included in your package. Use references for help or recovery, explain what was supplied, and keep practising the task yourself.

Your guides address you directly and include the case, brief, session cards, glossary, Codex prompts, and optional challenges. The setup guide focuses on preparation; agent/skill/MCP guidance is in the harness guide and session cards. Workshop help is centralised in `case/docs`; the project contains only project-specific documents.

## Checks completed while preparing your material

- All six API test projects passed in the native-PostgreSQL edition: 5, 6, 12, 14, 16, and 17 checks respectively, totalling 70. These tests use SQLite, a separate temporary database. They do not prove that the PostgreSQL app journey works.
- The starter solution also passed with `-m:1`. Parallel solution restore failed without diagnostics in the restricted authoring environment; the API projects were restored and tested directly.
- Package structure, staged agent/skill counts, remote-only MCP configuration, archive contents, and local help links were checked.
- Subsequent wording and packaging revisions did not change application source. API runtime tests were not repeated for these documentation-only changes.

## Checks still needed before the event

Ask your facilitator to confirm that the managed Windows setup has been rehearsed, including the installed PostgreSQL connection, frontend tests/build, the real database/browser journey, and local release retaining saved data. Live Codex custom-agent/skill discovery, remote documentation access, and hosted CI also need rehearsal. The wording has not yet been tested with someone unfamiliar with the stack.

When you run your own checks, record what actually passed, failed, or could not run. A passing old test does not prove a new feature works. The existing SQLitePCLRaw 2.1.11 dependency may produce a vulnerability warning; dependency updates are separate from this wording change.

## Limits of your case

Your app uses a fixed disposable schema with EnsureCreated, not a production migration strategy. It has one fictional caseworker and no sign-in system. Your local release is a training exercise, not a production deployment.

The downloadable material has not been published to GitHub by this update. Your repository may contain an earlier case revision until its case folder is updated. Keep your own work and database intact when updating files.

## Project and workshop layout

Your project folders contain application code, tests, agent configuration, and business/API/development notes. Session cards, challenges, authoring templates, glossary, and workshop help are kept only in `case/docs`. No local TASK.md or copied session guides are required by project guidance. Application code and dependencies are unchanged; structure and reference checks cover this layout change.

## Business and technical implementation guidance

You create domain/technical advisors and business-rule/API implementation skills in session 2, then a coordinator, loop skill, and React implementation skill in session 3. In session 4 you create the verifier/reviewer roles and checking/review/tracing skills. The core reference grows from 2 agents/3 skills to 4/6, 5/8, 7/11, and finally 7/12. Earlier authoring/role timing is superseded by this progression. The starter stays unchanged and no optional work becomes a prerequisite.

Definition format, stage availability, documentation references, and application-source preservation are checked for this revision. Live Codex role/skill discovery, remote tool calls, and native PostgreSQL/browser rehearsal remain separate pre-event checks.

A source-level planning exercise used the domain/technical advisor definitions and implementation skills on an edit/save request. It produced concrete business examples and a file-based implementation plan. An early-stage React-skill availability ambiguity was corrected. This did not run the app, discover live Codex roles, or establish project MCP connectivity.
