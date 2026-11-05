param([string]$Workspace = '', [switch]$SkipInstall)
. (Join-Path $PSScriptRoot 'Common.ps1')
$Workspace = Resolve-Workspace $Workspace
foreach ($tool in @('dotnet','node','npm','docker')) { Assert-Tool $tool }
if (Test-LocalPort 5080) { throw 'Port 5080 is in use. Stop the earlier API before launching another checkpoint.' }
if (Test-LocalPort 5173) { throw 'Port 5173 is in use. Stop the earlier browser server before launching another checkpoint.' }
if ($env:WORKSHOP_POSTGRES_PORT -and $env:WORKSHOP_POSTGRES_PORT -ne '54329') { throw 'Start uses port 54329. Clear WORKSHOP_POSTGRES_PORT first.' }
$compose = Get-ComposeArguments
Invoke-Checked 'docker' ($compose + @('up','-d','--wait','--wait-timeout','60'))
Push-Location $Workspace
try { Invoke-Checked 'dotnet' @('restore','Workshop.slnx') } finally { Pop-Location }
if (-not $SkipInstall) { Install-WebDependencies $Workspace }
$hostExecutable = (Get-Process -Id $PID).Path
$escaped = $Workspace.Replace("'", "''")
$apiCommand = "`$env:ConnectionStrings__Workshop = 'Host=localhost;Port=54329;Database=request_workshop;Username=workshop;Password=workshop-local-only'; Set-Location '$escaped'; dotnet run --project api --no-launch-profile --urls http://127.0.0.1:5080"
$webCommand = "Set-Location '$escaped/web'; npm run dev"
$processes = @()
foreach ($command in @($apiCommand, $webCommand)) {
    $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($command))
    $process = Start-Process -FilePath $hostExecutable -ArgumentList @('-NoExit','-EncodedCommand',$encoded) -PassThru
    $processes += @{ id = $process.Id; started = $process.StartTime.ToUniversalTime().ToString('o') }
}
$processes | ConvertTo-Json | Set-Content (Join-Path $Workspace '.processes.json') -Encoding UTF8
$ready = $false
for ($attempt = 0; $attempt -lt 60; $attempt++) {
    try {
        $health = Invoke-RestMethod 'http://127.0.0.1:5080/api/health' -TimeoutSec 1
        if ($health.database -and (Test-LocalPort 5173)) { $ready = $true; break }
    } catch { }
    Start-Sleep -Milliseconds 500
}
if (-not $ready) { throw 'The app did not become ready. Check both new terminal windows; run scripts/Stop.ps1 before retrying.' }
Write-Host 'Open http://127.0.0.1:5173 in your browser. Both terminal windows must stay open.'
Write-Host 'Stop the app with scripts/Stop.ps1 -Workspace <this workspace>.'
