# Recovery and repeatable demonstrations

Continue in your own working copy throughout the workshop. Optional tasks are never prerequisites. Use a recovery baseline only when needed to rejoin the core path, with facilitator support.

| Starting or resuming | Recovery baseline | Verify before continuing |
| --- | --- | --- |
| Session 1 | 00-before-first-build | Health screen and database connection |
| Session 2 | 01-after-build-1 | Two different requests show the correct details |
| Session 3 | 02-after-build-2 | Readiness identifies missing information, including whitespace |
| Session 4 | 03-after-build-3 | Edit, save, recheck, and reload |
| Session 5 | 04-after-build-4 | Complete requests can be reviewed; incomplete review and reviewed edits are rejected |
| Final rehearsal | 05-final-solution | Full journey, activity, CSV statuses, and restart |

The participant pack contains only checkpoint 00. The facilitator supplies the selected recovery source; completed checkpoints have not yet been certified by a Windows rehearsal. Use only baselines verified before the event.

Stop the app and save your source and evidence. Create a new folder using New-Workspace.ps1 with the selected checkpoint and a unique Destination; never copy over participant-work. For example, from the full instructor distribution:

```powershell
powershell -File .\scripts\Stop.ps1
powershell -File .\scripts\New-Workspace.ps1 -Checkpoint 02-after-build-2 -Destination .\recovery-session-2
powershell -File .\scripts\Verify.ps1 -Workspace .\recovery-session-2
powershell -File .\scripts\Start.ps1 -Workspace .\recovery-session-2
```

Open the new folder in VS Code Insiders, inspect what it supplies, and demonstrate the behavior in the table. Record the recovery in your evidence; supplied implementation is not evidence that Codex built it in your run. Use that folder explicitly in subsequent launcher and verification commands. Keep the earlier folder for comparison.

## Prepare fresh demo data

All local workspaces share the same workshop database. A source recovery does not reset data. Reviewed requests are read-only, so rehearsal can consume the incomplete examples.

Before a fresh rehearsal, preserve any data you need, stop the API, and run the supplied reset from the distribution root:

```powershell
powershell -File .\scripts\Stop.ps1
powershell -File .\scripts\Reset-Data.ps1
```

Read the warning and type RESET only when you intend to erase the shared workshop request data. Restart your chosen workspace to seed the original examples. Do not reset during a running API session. This explicit training reset is outside the application workflow; do not add a reopen feature to the core exercise.

Demonstrate Fjordby with its missing budget, correct and save it, reload, mark it Reviewed, and show its activity. Keep another request New. Open http://127.0.0.1:5080/api/requests/export and confirm both statuses in the final column. Show a passing check, the traced graph, the Codex execution record, and one improvement in how you worked.
