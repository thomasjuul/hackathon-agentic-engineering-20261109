# Before the first build session

Complete these steps before the hackathon. You will work in `case/start-here` throughout the five build sessions.

## 1. Install the tools

- .NET 10 SDK.
- Node.js 22.12 or newer, including npm.
- Git.
- PostgreSQL 17 installed on Windows, including command-line tools.
- VS Code or VS Code Insiders, with C# tooling, a PostgreSQL extension, and Codex. Sign in to Codex.

### Add PostgreSQL to PATH

1. Find the folder containing `psql.exe`, usually `C:\Program Files\PostgreSQL\17\bin`. Use your actual installation location.
2. In Windows Start, search for **Edit environment variables for your account**.
3. Under **User variables**, select **Path → Edit → New** and add the `bin` folder. Keep the existing entries. If no user Path exists, create one named `Path`.
4. Save with **OK**, then close and reopen PowerShell and your editor.
5. Check in a new terminal:

```powershell
psql --version
```

## 2. Clone and open the repository

In PowerShell:

```powershell
git clone https://github.com/twoday-ai/hackathon-agentic-engineering-20261109.git
Set-Location hackathon-agentic-engineering-20261109
```

If you already cloned the repository, use your existing local copy.

| Folder | What you will find |
| --- | --- |
| `case/start-here` | Your starting code and working folder |
| `case/docs` | Your guides and session cards |
| `case/checkpoints` | All six saved versions for reference and recovery |
| `demos` | Demonstrations from the hackathon |
| `slides` | Presentation slides |

Open `case/start-here` with **File → Open Folder**, or use the command for your editor:

| Editor | Command from the repository root |
| --- | --- |
| VS Code | `code .\case\start-here` |
| VS Code Insiders | `code-insiders .\case\start-here` |

Keep working in `start-here`; the checkpoints are supplied reference copies.

## 3. Create the local database

Keep your installed PostgreSQL server running on `localhost:5432`. Connect as the installation administrator through your PostgreSQL extension, or run:

```powershell
psql -h localhost -p 5432 -U postgres -d postgres
```

In the database connection, run these statements once, separately with autocommit enabled:

```sql
CREATE ROLE workshop LOGIN PASSWORD 'workshop-local-only';
CREATE DATABASE request_workshop OWNER workshop;
```

If the role or database already exists, reuse your approved training setup. These credentials are for local fictional training data. If you use different connection details, use those in step 5 too.

## 4. Install project dependencies

Open a terminal in `case/start-here`, which contains `Workshop.slnx`, `api`, and `web`:

```powershell
dotnet restore Workshop.slnx
Set-Location web
npm install
Set-Location ..
```

Keep the generated `web/package-lock.json`. Use `npm ci` for later clean installations with that file.

## 5. Start the application

In terminal 1, from `case/start-here`:

```powershell
$env:ConnectionStrings__Workshop = 'Host=localhost;Port=5432;Database=request_workshop;Username=workshop;Password=workshop-local-only'
dotnet run --project api --no-launch-profile --urls http://127.0.0.1:5080
```

In terminal 2, from `case/start-here`:

```powershell
Set-Location web
npm run dev
```

Open http://127.0.0.1:5173. Check http://127.0.0.1:5080/api/health for a working database connection. Keep both terminals open. Stop each process with Ctrl+C; keep PostgreSQL running.

## 6. Run the checks

From `case/start-here`:

```powershell
dotnet test Workshop.slnx
Set-Location web
npm test
npm run build
Set-Location ..
```

Open [build session 1](01-build-session-1.md) in `case/docs` when you are ready to begin.
