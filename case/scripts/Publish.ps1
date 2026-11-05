param([string]$Workspace = '', [string]$Destination = '')
. (Join-Path $PSScriptRoot 'Common.ps1')
$Workspace = Resolve-Workspace $Workspace
if (-not $Destination) { $Destination = Join-Path $WorkshopRoot ('releases/' + (Get-Date -Format 'yyyyMMdd-HHmmss')) }
$Destination = [IO.Path]::GetFullPath($Destination)
if (Test-Path $Destination) { throw 'Release destination already exists. Choose a new folder to preserve the earlier release.' }
Install-WebDependencies $Workspace
Push-Location (Join-Path $Workspace 'web')
try { Invoke-Checked 'npm' @('run','build') } finally { Pop-Location }
Push-Location $Workspace
try { Invoke-Checked 'dotnet' @('publish','api/Workshop.Api.csproj','-c','Release','-o',$Destination) }
finally { Pop-Location }
$webRoot = Join-Path $Destination 'wwwroot'
New-Item -ItemType Directory -Path $webRoot -Force | Out-Null
Get-ChildItem (Join-Path $Workspace 'web/dist') -Force | Copy-Item -Destination $webRoot -Recurse -Force
Write-Host "Local release created: $Destination"
Write-Host 'Stop the development API and browser server, keep PostgreSQL running, then:'
Write-Host "  Set-Location '$Destination'"
Write-Host '  dotnet Workshop.Api.dll --urls http://127.0.0.1:5080'
Write-Host 'Open http://127.0.0.1:5080. The API now serves the built React app too.'
