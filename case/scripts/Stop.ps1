param([string]$Workspace = '', [switch]$Database)
. (Join-Path $PSScriptRoot 'Common.ps1')
$Workspace = Resolve-Workspace $Workspace
$state = Join-Path $Workspace '.processes.json'
if (Test-Path $state) {
    foreach ($saved in (Get-Content $state -Raw | ConvertFrom-Json)) {
        $process = Get-Process -Id $saved.id -ErrorAction SilentlyContinue
        if ($process -and $process.StartTime.ToUniversalTime().ToString('o') -eq $saved.started) {
            Invoke-Checked 'taskkill' @('/PID', [string]$saved.id, '/T', '/F')
        }
    }
    Remove-Item $state
} else { Write-Host 'No recorded launcher windows. Close any manually started API and Vite terminals yourself.' }
if ($Database) { Invoke-Checked 'docker' ((Get-ComposeArguments) + @('stop','postgres')) }
Write-Host 'Stopped launcher processes. Database data was preserved.'
