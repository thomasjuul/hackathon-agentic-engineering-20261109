param([string]$WorkshopRoot = "")
$ErrorActionPreference = 'Stop'
if (-not $WorkshopRoot) {
  $cursor = Get-Item $PSScriptRoot
  while ($cursor -and -not (Test-Path (Join-Path $cursor.FullName 'workshop.json'))) { $cursor = $cursor.Parent }
  if (-not $cursor) { throw 'Cannot find workshop.json. Supply -WorkshopRoot pointing to the distribution root.' }
  $WorkshopRoot = $cursor.FullName
}
& (Join-Path $WorkshopRoot 'scripts/Verify.ps1') -Workspace $PSScriptRoot
