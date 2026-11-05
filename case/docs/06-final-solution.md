# Final solution and local release

The reference source in the full instructor distribution is checkpoints/05-final-solution. Your participant-work copy should now implement the same core behavior. In the commands below, use participant-work instead of the reference path to verify or release your own code. The optional browser check requires the session-5 web acceptance files from the instructor.

## Final checks

```powershell
powershell -File .\scripts\Verify.ps1 -Workspace .\checkpoints\05-final-solution
powershell -File .\scripts\Test-Browser.ps1
```

Stop other workshop processes before browser verification. That script creates a separate disposable PostgreSQL project on port 55433 and deletes only its own test volume afterward. It requires Docker and downloads a Playwright Chromium browser on first use.

The API test suite uses SQLite for fast, isolated relational checks; it does not prove PostgreSQL compatibility. The browser test exercises the actual Npgsql provider, PostgreSQL, API, and React journey together.

## Create a local release

This packages the compiled API and built browser application together:

```powershell
powershell -File .\scripts\Publish.ps1 -Workspace .\checkpoints\05-final-solution
```

Use your participant-work path instead if releasing your own implementation. The script prints the new release folder. Stop the development app, keep Docker PostgreSQL running, and follow its instructions to run the release. Open http://127.0.0.1:5080, which now serves both the built frontend and API.

Confirm that the saved requests remain present. This is a local release exercise, not a production deployment.

## Five-minute demonstration

Lead with what you learned: explain a concept, show how you applied it, and describe how you used Codex to solve a given task. Use the journey below to illustrate those points. If you used a recovery checkpoint, identify supplied work and explain what you inspected and practised yourself.

1. Open Fjordby, whose budget is missing.
2. Show the explanation, edit the checkbox, save, and reload.
3. Mark it Reviewed and show the activity entry and read-only result.
4. Keep another request New. Export CSV and show both statuses in the final column.
5. Show one test result, the traced execution graph and agent execution record, and explain one improvement to context, instructions, verification, or stopping rules.

If earlier practice has reviewed the examples, use the explicit confirmed reset first. Do not reset data during a running API session.

## Handover

Keep the source changes, package-lock.json generated during preparation, acceptance checks, evidence sheet, and release notes. Record known limitations:

- One development-only caseworker; no authentication or authorization system.
- Checkbox assertions rather than real documents.
- Fixed disposable workshop schema using EnsureCreated; no production migration strategy.
- Local release only; no high-availability, production hosting, or compliance claim.
