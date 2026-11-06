---
name: change-brownfield
description: Investigate callers and preserve existing contracts before changing a supplied component.
---

1. Map the exporter, endpoint, client, and tests. State the exact intended change and what must remain stable before editing.
2. State the intended contract change explicitly. Preserve all unaffected headers, values, row ordering, encoding, line endings, quoting, and formula neutralization. Keep any legacy output contract separate from the current one.
3. Use a minimal change, verify old and new behavior, and record an impact/migration note. Do not infer compatibility solely from compilation.
