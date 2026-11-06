# Optional challenges

Finish the core task first. Then choose **Optional 1** for a more approachable feature, or **Optional 2** for a deliberately harder one. You can choose either: Optional 2 never requires Optional 1, and later core sessions do not require any optional work.

These are real building tasks, so a full challenge may take longer than the available optional time. The windows are 10, 20, 10, 25, and 20 minutes across sessions 1–5. Start with the suggested first step, stop for the next topic, and continue later if you want. Effort estimates are rough guides.

Save a working core version before starting. Keep unfinished optional changes separate so they do not block the next session. Keep the same four fields, three rules, two statuses, and application stack.

## How to work with Codex

Ask for a plan and relevant files first. Use only agents/skills already available in your session; create any extra definition the challenge asks for. Give one implementer responsibility for code changes at a time. Have someone else check/review the result; before custom verifier/reviewer agents exist, the main Codex session can help with checks and you review the work.

Use remote Microsoft Learn or OpenAI Docs to answer a relevant technical question and explain how the answer affects the design. Record the real tool call and source URL in `docs/evidence.md`. Use the browser/API/tests to check the app. Optional remote GitHub access is never needed to finish a challenge.

Ask afterwards: “What did the session concept help us do, what did Codex do, and what decision or check stayed with us?” See [words and concepts](words-and-concepts.md) for unfamiliar terms.

## Session 1

### Optional 1: Searchable request workspace

**Level:** More approachable. **Full challenge estimate:** 20–30 minutes. **Start from:** this session’s completed core.

Let the caseworker find requests by municipality or project title.

**What you do:**

Add a search box that works with the requests already loaded. Ignore upper/lowercase differences. Then show how many requests match. If none match, show a useful message instead of a blank area.

Agree what happens to the selected request when search hides it. Keep the displayed details consistent with that choice. Then give Codex a short context note explaining the screen, relevant files, examples, and limits. Use that note to guide the change.

**Finished result:** A search box, result count, clear no-results message, and consistent details view, plus your context note.

**A useful first step:** Add search and a result count first; then decide how hidden selections behave.

**Try this with Codex:**

```text
Add municipality/title search to session-1 core using loaded data. Ignore case, show the count and a useful no-results message, and define how selection behaves when filtered out. First write a short context note and plan. Keep this separate from later core features.
```

### Optional 2: URL-driven workspace with browser navigation

**Level:** Difficult. **Full challenge estimate:** 35–60 minutes. **Start from:** this session’s completed core.

Make a link that opens the same search and selected request in another browser tab.

**What you do:**

Store the search text and selected request in the URL. Define what to show for an unknown ID, invalid query value, or selected request hidden by search. Then restore the screen when opening a link or reloading the page. Include search itself; do not assume Optional 1 exists.

Make browser Back and Forward update the screen correctly, without repeated navigation or old details appearing. Then keep URL parsing and screen updates understandable. Demonstrate a copied link, reload, Back, and Forward.

**Finished result:** A shareable list/detail screen whose URL and displayed content stay in agreement.

**A useful first step:** Put the selected request in the URL and restore it on reload; add search and navigation handling next.

**Try this with Codex:**

```text
Starting from session-1 core only, put search and selected-request state in the URL. Define invalid/unknown/filtered-selection behavior first. Support copied links, reload, and Back/Forward. Explain how you avoid repeated updates and stale details. Show a small first step before implementing.
```

## Session 2

### Optional 1: Documentation specialist and batch readiness

**Level:** More approachable. **Full challenge estimate:** 20–35 minutes. **Start from:** this session’s completed core.

Add a Check all view that checks several requests and shows the result for each.

**What you do:**

Create workshop_docs and a research-docs skill. Their job is to find useful official sources, explain whether they apply, and record the source and decision. Then use the new agent/skill for a real remote lookup, then add Check all using the existing server endpoints. The server still decides readiness.

Show progress. If one check fails, keep the successful results visible and show which request failed. Then add a way to retry a failed check. Write a reusable task brief and use it to guide that change.

**Finished result:** A working Check all view, visible progress/results/errors, retry, and reusable research/task guidance.

**A useful first step:** Create and try the documentation agent/skill, then show results for a few requests.

**Try this with Codex:**

```text
Help me create workshop_docs and research-docs and use them for a relevant remote lookup. Add Check all through our existing endpoints. Show progress and results per request, retain successes if one fails, and allow retry. Keep the rules on the server and explain how the reusable guidance helped.
```

### Optional 2: Advanced harness and cancellable batch runner

**Level:** Difficult. **Full challenge estimate:** 45–75 minutes. **Start from:** this session’s completed core.

Build a Check all process that can be cancelled and restarted safely.

**What you do:**

Create a documentation specialist and plan-change skill. Write who edits which files, what each person/agent hands over, how disagreements are resolved, and when to stop. Include the research guidance needed without Optional 1. Then build the results/progress view and allow at most three checks to run at once. Add cancellation and retry for failed requests only.

Give each run an identity so a late reply from an earlier run cannot replace newer results. Cancelling a browser call does not prove the server stopped working. Then use controlled delayed and failed responses to demonstrate the three-check limit, partial failure, cancellation, and a safe restart.

**Finished result:** A cancellable batch runner with progress, partial results, retry, and protection from old responses, built using your new planning guidance.

**A useful first step:** Design the work plan and run identity, then build a three-at-a-time checking queue.

**Try this with Codex:**

```text
From session-2 core, create a documentation specialist and plan-change skill with file ownership, handoffs, disagreement handling, and stopping rules. Use them to build Check all with at most three active checks, cancellation, retry-failed-only, and protection from earlier run responses. Include the screen yourself. Demonstrate controlled delays and failures in small agreed steps.
```

## Session 3

### Optional 1: Unsaved-change protection

**Level:** More approachable. **Full challenge estimate:** 15–25 minutes. **Start from:** this session’s completed core.

Help the caseworker avoid losing changes they have not saved.

**What you do:**

Show when the draft differs from the saved information. “Dirty” is the common technical word for this state. Then add Cancel to restore the saved values. Before switching to another request, offer Stay here or Discard changes when there is an unsaved draft.

Keep the draft if saving fails. Use the bounded development loop and record the route Codex actually took.

**Finished result:** An unsaved-changes indicator, Cancel, and a clear stay/discard choice before changing requests.

**A useful first step:** Add the unsaved indicator and Cancel, then protect request switching.

**Try this with Codex:**

```text
Improve session-3 editing with an unsaved-changes indicator, Cancel, and a stay/discard choice before selecting another request. Keep drafts after a failed save. Use our development graph and stop after two repairs or 20 minutes, whichever comes first. Show the app edit states separately from Codex’s work steps.
```

### Optional 2: Race-safe editing across requests

**Level:** Difficult. **Full challenge estimate:** 40–70 minutes. **Start from:** this session’s completed core.

Keep the right draft and details visible even when server replies arrive late.

**What you do:**

Describe the editing states for each request: loading, changed but unsaved, saving, failed, and saved. Include the draft protection needed without assuming Optional 1. Then allow only one save at a time for the same request. Match replies to the request and operation they belong to. An old reply must not overwrite a newer selection or erase a newer draft.

Create a controlled test: save request A, move to B, then allow A’s delayed reply to arrive. B must remain correct, and errors must preserve the right draft. Then split the work into small separately reviewed runs. Explain that browser safeguards alone do not solve simultaneous updates from different clients.

**Finished result:** An editing implementation organised around explicit states, with a repeatable delayed-response demonstration and stated limits.

**A useful first step:** Draw the edit states and demonstrate the A-save/B-selection problem, then add response matching.

**Try this with Codex:**

```text
From session-3 core, design editing that handles late replies safely. Include unsaved-change protection, one save at a time per request, and matching responses to the correct request/operation. First explain the states. Demonstrate delayed A-save after selecting B. Work in separately agreed bounded runs and state the limits for other clients.
```

## Session 4

### Optional 1: Review diagnostics panel

**Level:** More approachable. **Full challenge estimate:** 20–35 minutes. **Start from:** this session’s completed core.

Add a small development-only panel that helps explain a review attempt.

**What you do:**

Show the action, result, time, and existing correlation ID: the reference number connecting a response and server log. Then for a successful review, connect the result to its saved activity. For a rejected review, connect the result to its log message without inventing a saved activity.

Demonstrate a successful complete request and an incomplete review sent directly to the API. Have a teammate inspect the result before accepting the change.

**Finished result:** A working diagnostics panel showing real success and rejection information.

**A useful first step:** Show the real result and correlation ID for one review attempt.

**Try this with Codex:**

```text
Build a development-only review diagnostics panel using our existing correlation header and logging. Show action, outcome, time, and correlation ID. Trace a success to activity and a rejection to its log. Keep descriptions and credentials out of logs; do not add fake activity for rejected actions.
```

### Optional 2: Local failure-investigation workbench

**Level:** Difficult. **Full challenge estimate:** 50–90 minutes. **Start from:** this session’s completed core.

Build a repeatable way to investigate review failures and produce a readable report.

**What you do:**

Use a separate disposable database or controlled test setup. Cover incomplete review rejection, repeating review without duplicate activity, and rejecting edits after review. Then run the scenarios and capture actual API results, correlation IDs, and relevant logs/activity. Mark each passed, failed, or blocked.

Build a report or viewer that connects each scenario to its observed evidence and an explanation. Then in an isolated copy, deliberately introduce a defect. Ask Codex to investigate within a bounded loop, repair it, and compare before/after results. A human still decides whether the repair is acceptable.

**Finished result:** A runnable investigation tool and readable report showing an actual diagnosed and repaired defect.

**A useful first step:** Run one rejection scenario against an isolated setup and generate its report; extend to the other scenarios next.

**Try this with Codex:**

```text
From session-4 core, build a local investigation workbench for incomplete review rejection, repeated review with one activity, and editing protection after review. Use a separate disposable setup and never erase the demo database. Capture actual API/log/activity results in a readable report. Plan isolation first, work in bounded steps, and demonstrate a controlled defect and repair.
```

## Session 5

### Optional 1: Filtered CSV export across UI and API

**Level:** More approachable. **Full challenge estimate:** 25–40 minutes. **Start from:** this session’s completed core.

Let the caseworker export all requests, only New requests, or only Reviewed requests.

**What you do:**

Inspect the exporter, its callers, and tests before changing it. Agree how the three choices should behave. Then add the choice in the screen and matching filtering on the server. Include a useful filename. No filter must keep the session-5 export, including Status.

Reject unknown filter values with a clear error. Demonstrate all three choices and the earlier unfiltered call. Then write a short note explaining which parts of the app are affected and what the caseworker sees differently.

**Finished result:** A working screen-to-server filtered export with the original default behavior preserved.

**A useful first step:** Add the server filter while keeping the no-filter result unchanged, then add the screen control.

**Try this with Codex:**

```text
Inspect the session-5 exporter and callers. Add All/New/Reviewed export choices and matching server filtering with a helpful filename. Preserve the default Status-bearing export and formatting. Reject unknown values, demonstrate the choices and old caller, and explain the effect on existing use.
```

### Optional 2: Two export contracts with a legacy consumer

**Level:** Difficult. **Full challenge estimate:** 45–75 minutes. **Start from:** this session’s completed core.

Support an older program that can only read the original two-column export.

**What you do:**

Build a small runnable “old consumer”: a program that accepts exactly Municipality and Project title and rejects the added Status column. Then keep the core Status-bearing endpoint. Add a clearly separate route for the old two-column format. Share the existing formatting/escaping code instead of making two unrelated implementations.

Demonstrate the old consumer succeeding with the old-format route and rejecting the new format. Both exports should have predictable output. Then write a short compatibility note: who needs each format, how the older consumer could move to the new one, and when the old route could eventually be retired. No deployment or Optional 1 is needed.

**Finished result:** Two explicit export formats, shared formatting, a runnable older consumer, and a practical migration note.

**A useful first step:** Build the two-column consumer and show why the new output breaks it; then add the separate old-format route.

**Try this with Codex:**

```text
From session-5 core, build an old consumer that requires exactly the original two columns. Keep our current Status-bearing export and add a separate legacy two-column route using shared formatting. Demonstrate compatible and incompatible calls. Explain the compatibility impact and possible migration. Do not assume filtering exists.
```
