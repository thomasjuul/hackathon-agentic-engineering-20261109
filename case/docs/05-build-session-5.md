# Build session 5: Add Status to the existing CSV export

**Learning:** Greenfield to brownfield. **When:** 12:30-14:30 on day 2.

The business case is still four fields, three rules, and two statuses. Read docs/rules.md.

Use the prepared [agent harness](agent-harness.md) for the role definitions, skill catalogue, MCP tools, and setup.

## Learning outcome

Explain how working with existing code changes your approach. Show what Codex inspected before editing and how you checked earlier behavior was preserved.

## Core task

Before changing the exporter, create change-brownfield yourself. Specify caller/contract discovery, intended versus preserved behavior, regression evidence, and human review. Invoke it and explain a compatibility decision.

1. Inspect api/CsvExporter.cs, its endpoint in Endpoints.cs, tests/CsvTests.cs, and any existing Export CSV button before editing. The supplied endpoint is already available: open http://127.0.0.1:5080/api/requests/export directly if your UI has no button. A button is not a core prerequisite.
2. Run the old export tests and inspect a download. Preserve the first two header names/order, existing row values and municipality ordering, UTF-8 encoding, CRLF line endings, quoting/escaping, and formula neutralization. Only the new final Status column intentionally changes the output.
3. Add an acceptance example: header Municipality,Project title,Status; rows retain existing values and append New or Reviewed.
4. Ask Codex for a minimal change. Update only test expectations affected by the new column, preserve existing coverage, and add a new test for both statuses.
5. Export both a New request and a Reviewed request. Verify that existing quoting and formatting behavior remains unchanged.
6. Run all core checks. Stop and start the application with the launcher without resetting the database, then verify saved data.
7. Review the change. Freeze features and rehearse the final demonstration.

## Required agent, skill, and MCP practice

1. Ask workshop_analyst to map callers, workshop_implementer to use $change-brownfield/$implement-slice, and workshop_reviewer to use $review-change. Sequence the writer and reviewer.
2. Use Microsoft Learn MCP to check the file/encoding response behavior needed by the CSV change. If the workshop repository has an approved remote GitHub connection, optionally inspect a relevant commit/PR through remote github; otherwise use ordinary local files/diffs. GitHub access is not a prerequisite.
3. Compare actual CSV downloads before/after using the browser/direct API. Retrieve and append the final handoff directly in docs/evidence.md, including sources, compatibility evidence, and the human decision.

Keep this within the existing core time. Report unavailable remote calls as blocked and ask the facilitator for help; never invent a lookup result.

## Acceptance examples

- Status is the last CSV column with New or Reviewed values.
- Earlier columns, formatting, and special-character behavior remain correct.
- The app works after restart with data preserved.

For task help, adaptable prompts, and troubleshooting, use the shared [go-to guide](go-to-guide.md).

## Suggested Codex task

> Inspect the existing exporter, callers, and tests before editing. Preserve earlier columns and formatting, add Status last, and prove both New and Reviewed values. Make a minimal change and show core regression results before human review.

## Optional tasks

### Optional 1: Filtered CSV export across UI and API

Inspect the existing exporter, callers, and tests; specify an optional All/New/Reviewed export control.

**Deliverable:** An end-to-end filtered export with preserved default behavior and an impact note.

### Optional 2: Two export contracts with a legacy consumer

Starting from the session-5 core, model a legacy consumer that accepts exactly the original two columns and rejects the new Status column.

**Deliverable:** Two explicit export contracts, shared formatting, a runnable legacy consumer, and a compatibility/migration note.

Optional 2 is deliberately more difficult and starts from this session's core; Optional 1 is not required. See the [steps and Codex prompts](optional-challenges.md#session-5). Choose a working slice and stop for the next topic; neither level is needed later.

## Reflection and evidence

Run `powershell -File .\Verify.ps1` from your working copy. Existing green checks alone do not prove the new feature works. Write and run checks for your acceptance examples.

The instructor can supply the session-5 acceptance pack, or a fresh recovery copy of `05-final-solution`. Preserve your own work first.

At the session close, explain the concept in your own words, how you used it with Codex, and one thing you would improve. Keep the record short. If implementation blocks progress, use facilitator support or a clearly identified recovery checkpoint so you can practise the next concept. Optional features never determine learning success.
