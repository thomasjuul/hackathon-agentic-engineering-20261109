---
name: implement-api-feature
description: Implement a small ASP.NET Core feature using the existing API contract, server rules, and persistence patterns.
---

1. Inspect the current endpoints, request/response shapes, rule evaluator, database context, error handling, API client, and tests. Use docs/api-contract.md as the agreed interface. Consult remote Microsoft Learn for a relevant framework question and explain which design choice it informs.
2. Plan a narrow change using the project's existing structure. Keep transport concerns in endpoints, business decisions in the shared rule evaluator, and persistence in the existing database path. Preserve typed browser-client compatibility and expected status codes; do not introduce extra layers or packages without a reason.
3. As an advisor, return the file map, intended behavior, and design tradeoff only. As the agreed implementer, build the feature using existing helpers and asynchronous database operations. Preserve the project's concurrency fields and save related state/activity together when required. Do not change schema or connection strategy unless the task calls for it.
4. Keep error responses useful and compatible. Apply server rules to direct API calls as well as browser actions. Do not expose credentials or raw descriptions in logs.
5. Run focused API tests and relevant existing checks. When a browser caller changes, verify its real request/response behavior too. Report API behavior and untested provider assumptions accurately.
