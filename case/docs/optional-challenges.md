# Optional 1 and Optional 2

Each session offers two substantial implementation challenges. Optional 1 is the more approachable choice. Optional 2 is deliberately difficult and requires more design, coordination, or investigation. Both practise the session concept with Codex; neither is just a list of extra validation checks.

Complete the core first, then choose either level. Each level starts from that session's core baseline: Optional 2 does not require Optional 1 or optional work from earlier sessions. If you already completed Optional 1, reuse suitable parts after inspecting them. Keep a saved core baseline and isolate unfinished work before the next core session.

The optional windows remain 10, 20, 10, 25, and 20 minutes. Effort estimates below are exploratory targets, not promises. For a short window, choose one working slice; full completion can continue after the workshop. Preserve reflection and the next topic. No optional task is required for the final goal.

Use the existing stack and the same four fields, three rules, and two statuses. No external service or model API key is needed. Ask the [go-to guide](go-to-guide.md) for task scaffolds and troubleshooting.

## Session 1

### Optional 1: Searchable request workspace

Use only the roles and skills created by this session, as shown in the [agent harness progression](agent-harness.md). Give one custom implementer ownership, obtain separate verification/review from the main Codex session, using the new custom verifier/reviewer only after session 2 has created them, and use remote Microsoft Learn/OpenAI Docs MCP to resolve a relevant design/framework question. Record its source and effect in docs/evidence.md; inspect the feature with normal browser/API tools.

**Difficulty:** Approachable. **Estimated effort:** 15-25 minutes.

**Starting point:** This session's completed core; no optional prerequisite.

**Work to do:**

1. Add case-insensitive municipality/title search, a result count, and an empty state using loaded data.
2. Define what happens to selection when filtering removes the selected request, and keep clearing search predictable.
3. Use Codex to implement and demonstrate filtering, selection, and clearing as a coherent feature.

**Deliverable:** A searchable list/detail workspace and a short context brief.

**Suggested Codex instruction:**

```text
Implement a searchable request list using the existing loaded data. Search municipality and title case-insensitively, show result count/empty state, and define selection after filtering. Inspect the existing types and component first; keep the unfiltered core journey working.
```

**First slice:** Agree a small, usable part of this feature, implement it, and record what remains. Stop at the session boundary or agreed execution limit.

**Explain afterwards:** Which session concept shaped your approach, what did you delegate to Codex, and what decision or verification remained yours?

### Optional 2: URL-driven workspace with browser navigation

Have the main Codex session split independent context/risk analysis between currently available custom roles, collect evidence, and sequence one writer. If this optional task asks for another role, create it first; do not assume a future coordinator exists. Specify each handoff and stop rule. Use remote Microsoft Learn/OpenAI Docs MCP for external technical evidence, then record actual calls, source URLs, and findings. Use normal browser tools for exploration. Optional read-only remote GitHub can inspect an approved repository/PR after authentication; it is never a prerequisite.

**Difficulty:** Difficult. **Estimated effort:** 35-60 minutes.

**Starting point:** This session's completed core; no optional prerequisite.

**Work to do:**

1. Starting from the session-1 core, implement search and selected-request state in the URL. Specify how unknown IDs, invalid query values, and filtered-out selections behave.
2. Restore the workspace on reload and direct link opening. Support browser Back/Forward without navigation loops or stale details.
3. Ask Codex to separate parsing/state synchronisation from rendering. Demonstrate a link opened in a new tab, reload, and Back/Forward.

**Deliverable:** A shareable workspace whose URL and screen remain consistent across reload and browser navigation.

**Suggested Codex instruction:**

```text
Starting from session-1 core only, build a URL-driven search/detail workspace. Define query parsing and selection rules before editing. Implement direct links, reload restoration, and Back/Forward without synchronisation loops. Include the search capability needed by this task; do not assume Optional 1 exists.
```

**First slice:** Agree a small, usable part of this feature, implement it, and record what remains. Stop at the session boundary or agreed execution limit.

**Explain afterwards:** Which session concept shaped your approach, what did you delegate to Codex, and what decision or verification remained yours?

## Session 2

### Optional 1: Documentation specialist and batch readiness

Use only the roles and skills created by this session, as shown in the [agent harness progression](agent-harness.md). Give one custom implementer ownership, obtain separate verification/review from the main Codex session, using the new custom verifier/reviewer only after session 2 has created them, and use remote Microsoft Learn/OpenAI Docs MCP to resolve a relevant design/framework question. Record its source and effect in docs/evidence.md; inspect the feature with normal browser/API tools.

**Difficulty:** Approachable. **Estimated effort:** 20-35 minutes.

**Starting point:** This session's completed core; no optional prerequisite.

**Work to do:**

1. From session-2 core, create workshop_docs and a research-docs skill with source/applicability/evidence guidance. Exercise a remote lookup, then implement Check all through existing endpoints.
2. Show progress and per-request failures while retaining successful results; keep server rules authoritative.
3. Give Codex a reusable task brief using existing instructions and verification guidance, then use it for retrying one failed request.

**Deliverable:** A batch readiness UI and reusable task brief, with successful and failed results visible.

**Suggested Codex instruction:**

```text
Help me create workshop_docs and research-docs, exercise a remote source lookup, then use the new harness to add Check all through existing endpoints. Display progress and per-request results, retain successes on partial failure, and support retrying a failed request. Keep rules on the server and show how you used the reusable guidance.
```

**First slice:** Agree a small, usable part of this feature, implement it, and record what remains. Stop at the session boundary or agreed execution limit.

**Explain afterwards:** Which session concept shaped your approach, what did you delegate to Codex, and what decision or verification remained yours?

### Optional 2: Advanced harness and cancellable batch runner

Have the main Codex session split independent context/risk analysis between currently available custom roles, collect evidence, and sequence one writer. If this optional task asks for another role, create it first; do not assume a future coordinator exists. Specify each handoff and stop rule. Use remote Microsoft Learn/OpenAI Docs MCP for external technical evidence, then record actual calls, source URLs, and findings. Use normal browser tools for exploration. Optional read-only remote GitHub can inspect an approved repository/PR after authentication; it is never a prerequisite.

**Difficulty:** Difficult. **Estimated effort:** 45-75 minutes.

**Starting point:** This session's completed core; no optional prerequisite.

**Work to do:**

1. From session-2 core, create a documentation specialist and plan-change skill with file ownership, handoffs, disagreement handling, and stopping rules. Include needed research guidance without assuming Optional 1. Use it to build batch checks with at most three concurrent requests.
2. Add cancellation, retry-failed-only, and run identifiers so late responses from an old run cannot overwrite a newer run. A cancelled browser request does not prove server work stopped.
3. Use delayed/failing responses in a development fixture to demonstrate the concurrency cap, partial failure, cancellation, and a safe restart. Explain how the harness guided Codex across bounded tasks.

**Deliverable:** A robust batch execution component, progress UI, and evidence of cancellation and stale-result handling.

**Suggested Codex instruction:**

```text
Starting from session-2 core, help me create a documentation specialist and plan-change skill with handoffs/conflict handling, then use them to build a batch readiness runner with at most three in-flight checks, cancellation, retry-failed-only, and stale-run protection. First explain the execution/state model and relevant files. Include the overview UI; Optional 1 is not assumed. Work in bounded slices and demonstrate delayed and failed responses.
```

**First slice:** Agree a small, usable part of this feature, implement it, and record what remains. Stop at the session boundary or agreed execution limit.

**Explain afterwards:** Which session concept shaped your approach, what did you delegate to Codex, and what decision or verification remained yours?

## Session 3

### Optional 1: Unsaved-change protection

Use only the roles and skills created by this session, as shown in the [agent harness progression](agent-harness.md). Give one custom implementer ownership, obtain separate verification/review from the main Codex session, using the new custom verifier/reviewer only after session 2 has created them, and use remote Microsoft Learn/OpenAI Docs MCP to resolve a relevant design/framework question. Record its source and effect in docs/evidence.md; inspect the feature with normal browser/API tools.

**Difficulty:** Approachable. **Estimated effort:** 15-25 minutes.

**Starting point:** This session's completed core; no optional prerequisite.

**Work to do:**

1. Show when a draft differs from saved values and provide Cancel to restore those values.
2. When switching requests with an unsaved draft, offer an explicit discard-or-stay choice. Retain the draft if saving fails.
3. Delegate a bounded Codex loop and trace its actual plan/check/repair/review route separately from the UI edit-state diagram.

**Deliverable:** A usable dirty/Cancel/navigation workflow and a traced Codex run.

**Suggested Codex instruction:**

```text
Improve session-3 editing with a dirty indicator, Cancel, and a discard-or-stay decision before changing requests. Keep drafts after failed saves. Follow the supplied development graph and stop after two repairs or 20 minutes, whichever comes first. Show the application states separately.
```

**First slice:** Agree a small, usable part of this feature, implement it, and record what remains. Stop at the session boundary or agreed execution limit.

**Explain afterwards:** Which session concept shaped your approach, what did you delegate to Codex, and what decision or verification remained yours?

### Optional 2: Race-safe editing across requests

Have the main Codex session split independent context/risk analysis between currently available custom roles, collect evidence, and sequence one writer. If this optional task asks for another role, create it first; do not assume a future coordinator exists. Specify each handoff and stop rule. Use remote Microsoft Learn/OpenAI Docs MCP for external technical evidence, then record actual calls, source URLs, and findings. Use normal browser tools for exploration. Optional read-only remote GitHub can inspect an approved repository/PR after authentication; it is never a prerequisite.

**Difficulty:** Difficult. **Estimated effort:** 40-70 minutes.

**Starting point:** This session's completed core; no optional prerequisite.

**Work to do:**

1. Starting from the session-3 core, define a per-request edit state machine including loading, dirty, saving, failed, and saved. Include the necessary draft protection without assuming Optional 1.
2. Serialize saves for a given request. Correlate responses with request/run identity so an old response cannot replace a newer selection or erase a newer draft. Do not imply a browser-only guard solves concurrent writes from other clients.
3. Use a controlled delayed response/failure fixture: save request A, move to B, then release A's response; demonstrate B remains correct and errors preserve the appropriate draft. Split work into separately reviewed bounded runs.

**Deliverable:** A state-based editing implementation with controlled race demonstrations and documented concurrency limits.

**Suggested Codex instruction:**

```text
Starting from session-3 core, design and implement race-safe editing across requests. Include dirty-state protection, serialize same-request saves, and prevent late responses overwriting another selection or a newer draft. First show the state model. Use controlled delays to demonstrate A-save/B-selection ordering. Agree separate bounded runs for successive slices.
```

**First slice:** Agree a small, usable part of this feature, implement it, and record what remains. Stop at the session boundary or agreed execution limit.

**Explain afterwards:** Which session concept shaped your approach, what did you delegate to Codex, and what decision or verification remained yours?

## Session 4

### Optional 1: Review diagnostics panel

Use only the roles and skills created by this session, as shown in the [agent harness progression](agent-harness.md). Give one custom implementer ownership, obtain separate verification/review from the main Codex session, using the new custom verifier/reviewer only after session 2 has created them, and use remote Microsoft Learn/OpenAI Docs MCP to resolve a relevant design/framework question. Record its source and effect in docs/evidence.md; inspect the feature with normal browser/API tools.

**Difficulty:** Approachable. **Estimated effort:** 20-35 minutes.

**Starting point:** This session's completed core; no optional prerequisite.

**Work to do:**

1. Add a development-only panel for a review attempt: action, outcome, time, and the existing correlation ID.
2. Connect a success to persisted activity and a rejection to its server log; do not fabricate activity for rejected actions.
3. Demonstrate a complete request and an incomplete direct-API review attempt. Ask a teammate to inspect the evidence before accepting the change.

**Deliverable:** A working diagnostics panel and an explained success/rejection trace.

**Suggested Codex instruction:**

```text
Build a development-only review diagnostics panel using our existing correlation header/logging. Show action, outcome, time, and correlation ID. Trace one success to activity and one rejection to the log. Keep raw descriptions and credentials out of logs; do not invent rejected-action activity.
```

**First slice:** Agree a small, usable part of this feature, implement it, and record what remains. Stop at the session boundary or agreed execution limit.

**Explain afterwards:** Which session concept shaped your approach, what did you delegate to Codex, and what decision or verification remained yours?

### Optional 2: Local failure-investigation workbench

Have the main Codex session split independent context/risk analysis between currently available custom roles, collect evidence, and sequence one writer. If this optional task asks for another role, create it first; do not assume a future coordinator exists. Specify each handoff and stop rule. Use remote Microsoft Learn/OpenAI Docs MCP for external technical evidence, then record actual calls, source URLs, and findings. Use normal browser tools for exploration. Optional read-only remote GitHub can inspect an approved repository/PR after authentication; it is never a prerequisite.

**Difficulty:** Difficult. **Estimated effort:** 50-90 minutes.

**Starting point:** This session's completed core; no optional prerequisite.

**Work to do:**

1. Starting from the session-4 core, build a local script/fixture-based workbench for three scenarios: incomplete review rejection, repeated review with no duplicate activity, and an edited request remaining read-only after review.
2. Run against a clearly disposable test database/fixture, not the shared demo database. Capture actual HTTP outcomes, correlation IDs, and relevant log/activity evidence in a structured report with pass/fail/blocked results.
3. Add a report viewer or readable local report linking scenario evidence to a diagnosis. Introduce a controlled defect in an isolated copy, ask Codex to investigate within a bounded loop, then compare evidence before/after the repair. Keep the human acceptance decision explicit.

**Deliverable:** An executable local scenario workbench and investigation report demonstrating a diagnosed and repaired defect.

**Suggested Codex instruction:**

```text
Starting from session-4 core, build a local investigation workbench for incomplete rejection, repeat-review idempotency, and read-only enforcement. Use an isolated disposable fixture, never reset the shared demo database. Capture actual HTTP/log/activity evidence and generate a readable report. Plan isolation first, then implement in bounded slices; use a controlled defect to demonstrate diagnosis and repair.
```

**First slice:** Agree a small, usable part of this feature, implement it, and record what remains. Stop at the session boundary or agreed execution limit.

**Explain afterwards:** Which session concept shaped your approach, what did you delegate to Codex, and what decision or verification remained yours?

## Session 5

### Optional 1: Filtered CSV export across UI and API

Use only the roles and skills created by this session, as shown in the [agent harness progression](agent-harness.md). Give one custom implementer ownership, obtain separate verification/review from the main Codex session, using the new custom verifier/reviewer only after session 2 has created them, and use remote Microsoft Learn/OpenAI Docs MCP to resolve a relevant design/framework question. Record its source and effect in docs/evidence.md; inspect the feature with normal browser/API tools.

**Difficulty:** Approachable. **Estimated effort:** 25-40 minutes.

**Starting point:** This session's completed core; no optional prerequisite.

**Work to do:**

1. Inspect the existing exporter, callers, and tests; specify an optional All/New/Reviewed export control.
2. Implement status filtering in UI and API with a helpful filename. No filter preserves the core export including Status; unsupported values produce a clear error.
3. Demonstrate all three choices and the unchanged original caller. Review the impact note and release note as well as the implementation.

**Deliverable:** An end-to-end filtered export with preserved default behavior and an impact note.

**Suggested Codex instruction:**

```text
Inspect the session-5 export implementation and callers before editing. Add an All/New/Reviewed export control and matching server filter. Preserve the unfiltered Status-bearing export and its formatting. Reject unknown filter values, demonstrate all choices, and explain the compatibility impact.
```

**First slice:** Agree a small, usable part of this feature, implement it, and record what remains. Stop at the session boundary or agreed execution limit.

**Explain afterwards:** Which session concept shaped your approach, what did you delegate to Codex, and what decision or verification remained yours?

### Optional 2: Two export contracts with a legacy consumer

Have the main Codex session split independent context/risk analysis between currently available custom roles, collect evidence, and sequence one writer. If this optional task asks for another role, create it first; do not assume a future coordinator exists. Specify each handoff and stop rule. Use remote Microsoft Learn/OpenAI Docs MCP for external technical evidence, then record actual calls, source URLs, and findings. Use normal browser tools for exploration. Optional read-only remote GitHub can inspect an approved repository/PR after authentication; it is never a prerequisite.

**Difficulty:** Difficult. **Estimated effort:** 45-75 minutes.

**Starting point:** This session's completed core; no optional prerequisite.

**Work to do:**

1. Starting from the session-5 core, model a legacy consumer that accepts exactly the original two columns and rejects the new Status column.
2. Retain the core endpoint with Status and add an explicitly separate legacy two-column route. Share formatting/escaping code, make contract selection explicit, and keep both outputs deterministic.
3. Implement a small runnable consumer example and demonstrate it with the legacy route and incompatible new output. Document compatibility, migration, and eventual retirement considerations without needing a deployment. Do not assume Optional 1 filtering exists.

**Deliverable:** Two explicit export contracts, shared formatting, a runnable legacy consumer, and a compatibility/migration note.

**Suggested Codex instruction:**

```text
Starting from session-5 core, create an explicit legacy two-column export alongside the current Status-bearing endpoint. First model a runnable old consumer that requires two columns. Share formatting code, preserve the core endpoint, and demonstrate compatible and incompatible consumer calls. Optional 1 is not required. Supply an impact and migration note.
```

**First slice:** Agree a small, usable part of this feature, implement it, and record what remains. Stop at the session boundary or agreed execution limit.

**Explain afterwards:** Which session concept shaped your approach, what did you delegate to Codex, and what decision or verification remained yours?

