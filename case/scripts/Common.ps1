$ErrorActionPreference = 'Stop'
$WorkshopRoot = Split-Path $PSScriptRoot -Parent

function Invoke-Checked {
    param([string]$Command, [string[]]$Arguments)
    $global:LASTEXITCODE = 0
    & $Command @Arguments
    if ($LASTEXITCODE -ne 0) { throw "$Command failed (exit $LASTEXITCODE). See its output above." }
}

function Resolve-Workspace {
    param([string]$Workspace)
    if (-not $Workspace) { $Workspace = Join-Path $WorkshopRoot 'participant-work' }
    $resolved = (Resolve-Path $Workspace).Path
    if (-not (Test-Path (Join-Path $resolved 'checkpoint.json'))) { throw 'Choose a workshop workspace with checkpoint.json.' }
    return $resolved
}

function Assert-Tool {
    param([string]$Name)
    if (-not (Get-Command $Name -ErrorAction SilentlyContinue)) { throw "$Name is missing. Read docs/00-before-first-build.md." }
}

function Test-LocalPort {
    param([int]$Port)
    $client = New-Object System.Net.Sockets.TcpClient
    try { $task = $client.ConnectAsync('127.0.0.1', $Port); return ($task.Wait(300) -and $client.Connected) }
    catch { return $false }
    finally { $client.Dispose() }
}

function Get-ComposeArguments {
    return @('compose', '-p', 'request-workshop', '-f', (Join-Path $WorkshopRoot 'compose.yaml'))
}

function Install-WebDependencies {
    param([string]$Workspace)
    Push-Location (Join-Path $Workspace 'web')
    try {
        if (Test-Path 'package-lock.json') { Invoke-Checked 'npm' @('ci') }
        else { Invoke-Checked 'npm' @('install'); Write-Host 'A package-lock.json was generated. Preserve it with this workspace.' }
    } finally { Pop-Location }
}
