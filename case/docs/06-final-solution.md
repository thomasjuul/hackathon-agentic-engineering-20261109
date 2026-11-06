# Final solution and local release

Use your own working copy. Your case material includes `case/checkpoints/05-final-solution` as a supplied reference. Follow [setup](00-before-first-build.md) for installed PostgreSQL and dependency preparation.

## Choose what you need

First run the normal checks and rehearse the final demonstration. The automated browser journey is an extra check with facilitator support. A local release means building a copy that runs outside the development setup; it is not a production deployment. You can ask Codex to explain and run the commands with you.

## Final checks

At the working-copy root, run each check and inspect its result:

```powershell
dotnet test Workshop.slnx
Set-Location web
npm test
npm run build
Set-Location ..
```

The API tests use a separate temporary SQLite database; passing them does not prove that the app works with PostgreSQL. Verify the real app journey with installed PostgreSQL as well.

## Optional automated PostgreSQL/browser journey

The final reference includes Playwright configuration and the journey test. For your implementation, use the `web/` acceptance files in `case/acceptance-tests/session-5`; merge them while preserving your tests. Stop development API/frontend processes to free ports 5080 and 5173.

As the PostgreSQL administrator, create a fresh dedicated database, with autocommit enabled:

```sql
CREATE DATABASE request_workshop_e2e_01 OWNER workshop;
```

From `web/` in the working copy:

```powershell
$env:WORKSHOP_E2E_CONNECTION = 'Host=localhost;Port=5432;Database=request_workshop_e2e_01;Username=workshop;Password=workshop-local-only'
npx playwright install chromium
npm run test:browser
```

Playwright is a browser testing tool. It starts and stops its own API/frontend and tries the full journey using the actual PostgreSQL connection. Its test changes fictional data and expects fresh seeds. Use a newly created empty database and matching connection name for each repeat; never point it at your working database or a presenter database. Databases remain on your installed server after the test. Remove only your disposable test databases later through your normal database administration process.

## Create a local release

At the working-copy root, choose a new output folder; do not overwrite an earlier release:

```powershell
Set-Location web
npm run build
Set-Location ..
dotnet publish api/Workshop.Api.csproj -c Release -o ./local-release-01
New-Item -ItemType Directory -Path ./local-release-01/wwwroot
Copy-Item -Path ./web/dist/* -Destination ./local-release-01/wwwroot -Recurse
```

Stop the development API and frontend with Ctrl+C. Keep installed PostgreSQL running. In the API terminal, retain the same connection to demonstrate persistence:

```powershell
$env:ConnectionStrings__Workshop = 'Host=localhost;Port=5432;Database=request_workshop;Username=workshop;Password=workshop-local-only'
Set-Location local-release-01
dotnet Workshop.Api.dll --urls http://127.0.0.1:5080
```

Run from the release folder so the built `wwwroot` is served. Open http://127.0.0.1:5080; the API serves both the frontend and API. Confirm saved requests remain present. Stop with Ctrl+C. This is a local release exercise.

## Five-minute demonstration

Lead with what you learned: explain a concept, show how you applied it, and describe how you used Codex to solve a given task. Use the journey below to illustrate those points. If you used a recovery checkpoint, identify supplied work and explain what you inspected and practised yourself.

Open Fjordby, whose budget is missing. Then show the explanation, edit the checkbox, save, and reload.

Mark it Reviewed and show the activity entry and read-only result. Then keep another request New. Export CSV and show both statuses in the final column.

Show one test result, the traced execution graph and agent execution record, and explain one improvement to context, instructions, verification, or stopping rules.

If earlier practice has reviewed the examples, choose a fresh training database as described in the recovery guide first. Stop the API before changing its database connection.

## Handover

Keep the source changes, package-lock.json generated during preparation, acceptance checks, evidence sheet, and release notes. Record known limitations:

- One development-only caseworker; no authentication or authorization system.
- Checkbox assertions rather than real documents.
- Fixed disposable workshop schema using EnsureCreated; no production migration strategy.
- Local release only; no high-availability, production hosting, or compliance claim.
