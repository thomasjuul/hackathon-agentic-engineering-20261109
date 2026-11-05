param(
    [ValidateSet('00-before-first-build','01-after-build-1','02-after-build-2','03-after-build-3','04-after-build-4','05-final-solution')]
    [string]$Checkpoint = '00-before-first-build',
    [string]$Destination = ''
)
. (Join-Path $PSScriptRoot 'Common.ps1')
if (-not $Destination) { $Destination = Join-Path $WorkshopRoot 'participant-work' }
if (Test-Path $Destination) { throw 'Destination already exists. Choose a NEW folder so your work is preserved.' }
$source = Join-Path (Join-Path $WorkshopRoot 'checkpoints') $Checkpoint
if (-not (Test-Path $source)) { throw 'This checkpoint is not included in your distribution. Ask the instructor for a recovery copy.' }
New-Item -ItemType Directory -Path $Destination -Force | Out-Null
Get-ChildItem $source -Force | Copy-Item -Destination $Destination -Recurse -Force
Write-Host "Workspace created: $Destination"
Write-Host 'Open that folder in VS Code Insiders. Read TASK.md before asking Codex to edit.'
