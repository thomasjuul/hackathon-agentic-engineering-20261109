---
name: verify-change
description: Verify an implementation change and distinguish actual results from untested claims.
---

1. Read current acceptance examples. Run powershell -File .\Verify.ps1 in the active working copy, or the distribution script with the actual -Workspace path.
2. Report actual commands/results as passed, failed, or not run. Preserve expectations and distinguish existing coverage from the new feature.
3. Inspect application behavior through the browser, direct API calls, and supplied tests. Use Microsoft Learn MCP to resolve a relevant testing/persistence question; documentation is not runtime proof.
4. Return reproducible evidence and gaps for human review. Record the handoff in docs/evidence.md; a written claim does not certify that a check ran.
