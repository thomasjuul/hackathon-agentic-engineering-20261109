. (Join-Path $PSScriptRoot 'Common.ps1')
foreach ($tool in @('dotnet','node','npm','docker')) { Assert-Tool $tool }
$sdks = & dotnet --list-sdks
if (-not ($sdks -match '^10\.0\.')) { throw '.NET 10 SDK is required (not just its runtime).' }
$nodeVersion = [version]((& node -p 'process.versions.node').Trim())
if ($nodeVersion -lt [version]'22.12.0') { throw 'Install Node.js 22.12 or newer; workshop reference version is 22.14.' }
Invoke-Checked 'docker' @('info','--format','{{.OSType}}')
$osType = (& docker info --format '{{.OSType}}').Trim()
if ($osType -ne 'linux') { throw 'Use Linux containers in Docker Desktop.' }
Invoke-Checked 'docker' @('compose','version')
foreach ($port in @(5080, 5173)) {
    if (Test-LocalPort $port) { throw "Port $port is occupied. Stop the earlier workshop app." }
}
Write-Host 'Basic tools and ports are ready.'
Write-Host 'Also open VS Code Insiders, confirm Codex sign-in, and complete the first verified startup.'
