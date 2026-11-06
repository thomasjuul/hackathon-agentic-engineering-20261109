# Session 2 acceptance checks

The instructor releases this pack at the start of session 2. It contains expected behavior, not implementation code.
Copy ApiTests.cs and CsvTests.cs to the matching tests folder in your working copy.
Preserve any tests you wrote: merge these examples or put your tests in an additional file.
The new tests are expected to fail before the task is implemented. Run `dotnet test Workshop.slnx`, then `npm test` and `npm run build` from `web/` after your change.
CSV fixtures intentionally change their header expectation only in session 5.
API integration uses SQLite; real PostgreSQL browser verification is a separate final check.
