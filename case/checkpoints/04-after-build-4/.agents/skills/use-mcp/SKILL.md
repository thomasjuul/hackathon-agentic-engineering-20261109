---
name: use-mcp
description: Discover MCP tools, choose the narrowest relevant capability, and report actual calls and limitations.
---

1. Discover actual tools on openaiDeveloperDocs and microsoft_learn; use their published schema rather than guessed tool names. These are remote HTTP servers, not local processes.
2. Ask a precise question, search, fetch the original supporting page, and explain how it affects the current task. Prefer official product documentation and relevant versions.
3. Use optional remote github only after approved authentication and repository access, with read-only mode. Do not send secrets or private source to public documentation searches.
4. Record server/tool, query, source URL, relevant claim, and implementation decision in docs/evidence.md. If unavailable, mark the lookup blocked and continue with clearly labelled supplied local contracts. Do not claim a remote call occurred.
