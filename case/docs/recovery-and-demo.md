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

Your case material includes all six checkpoints in `case/checkpoints`. They are supplied reference/recovery versions. Ask the facilitator which one fits your current session; use baselines verified in the pre-event rehearsal.


Stop the API and frontend with Ctrl+C. Save your source and evidence. In File Explorer, copy the complete selected folder from `case/checkpoints` into a new folder such as `case/recovery-session-2`; preserve `.agents` and `.codex`. Never merge it over your working copy. Open the new folder and use the direct dependency, test, and startup commands in [setup](00-before-first-build.md).

Inspect the supplied behavior in the table and record the recovery in your evidence. Supplied implementation is not evidence that Codex built it in your run. Keep the earlier folder for comparison.

## Prepare fresh demonstration data

Changing source folders does not reset PostgreSQL. Continue with `request_workshop` to retain saved requests. For a fresh rehearsal, stop the API and create a new, empty database using the administrative connection in the setup guide:

```sql
CREATE DATABASE request_workshop_rehearsal_01 OWNER workshop;
```

Use a new suffix for each fresh rehearsal. In the API terminal, change only the database name in `ConnectionStrings__Workshop` to the actual new name, then start the API normally. It creates the fixed schema and original fictional examples automatically. Keep the earlier database intact. Do not reset or delete data to fix a compilation error.

This training preparation is outside the application workflow; do not add a reopen feature to the core exercise.

Demonstrate Fjordby with its missing budget, correct and save it, reload, mark it Reviewed, and show its activity. Keep another request New. Open http://127.0.0.1:5080/api/requests/export and confirm both statuses in the final column. Show a passing check, the traced graph, the Codex execution record, and one improvement in how you worked.
