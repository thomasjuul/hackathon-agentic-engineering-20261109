param([string]$Workspace = '', [switch]$SkipInstall)
. (Join-Path $PSScriptRoot 'Common.ps1')
$Workspace = Resolve-Workspace $Workspace
foreach ($tool in @('dotnet','node','npm')) { Assert-Tool $tool }
Push-Location $Workspace
try { Invoke-Checked 'dotnet' @('test','Workshop.slnx','--verbosity','minimal') } finally { Pop-Location }
if (-not $SkipInstall) { Install-WebDependencies $Workspace }
Push-Location (Join-Path $Workspace 'web')
try {
    Invoke-Checked 'npm' @('test')
    Invoke-Checked 'npm' @('run','build')
} finally { Pop-Location }
Write-Host 'PASS: API relational integration tests, frontend tests, and production frontend build.'
Write-Host 'These API tests use isolated SQLite. Run Test-Browser.ps1 for actual PostgreSQL and a real browser.'
