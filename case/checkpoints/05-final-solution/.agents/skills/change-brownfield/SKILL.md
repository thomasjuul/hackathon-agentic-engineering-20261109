---
name: change-brownfield
description: Investigate callers and preserve existing contracts before changing a supplied component.
---

1. Map the exporter, endpoint, client, and tests. State the exact intended change and what must remain stable before editing.
2. For session 5 append Status while preserving first two headers/order/values, row order, UTF-8, CRLF, quoting, and formula neutralization. Optional 2 may add a separate legacy contract, never replace the core one.
3. Use a minimal change, verify old and new behavior, and record an impact/migration note. Do not infer compatibility solely from compilation.
