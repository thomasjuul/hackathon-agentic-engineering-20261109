# Session 5 acceptance checks

The instructor releases this pack at the start of session 5. It contains expected behavior, not implementation code.
Copy ApiTests.cs and CsvTests.cs to the matching tests folder in your working copy.
Preserve any tests you wrote: merge these examples or put your tests in an additional file.
The new tests are expected to fail before the task is implemented. Run `dotnet test Workshop.slnx`, then `npm test` and `npm run build` from `web/` after your change.
CSV fixtures intentionally change their header expectation only in session 5.
API integration uses SQLite; real PostgreSQL browser verification is a separate final check.

After completing the task, merge the web/ files into the matching workspace web/ folder to enable the optional real-PostgreSQL browser check. Follow docs/06-final-solution.md to create a fresh dedicated database and run `npm run test:browser` against installed PostgreSQL.
