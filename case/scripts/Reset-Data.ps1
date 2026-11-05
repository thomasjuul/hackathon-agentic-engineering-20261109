. (Join-Path $PSScriptRoot 'Common.ps1')
if (Test-LocalPort 5080) { throw 'Stop the running API first. This command must not reset data underneath an active app.' }
Write-Host 'This removes all request data in the SHARED local request_workshop database, across checkpoints.'
$answer = Read-Host 'Type RESET to delete workshop requests and restore the examples on next startup'
if ($answer -cne 'RESET') { Write-Host 'Cancelled. Nothing changed.'; return }
Invoke-Checked 'docker' ((Get-ComposeArguments) + @('exec','-T','postgres','psql','-U','workshop','-d','request_workshop',
    '-v','ON_ERROR_STOP=1','-c','DROP SCHEMA public CASCADE; CREATE SCHEMA public;'))
Write-Host 'The next API startup recreates the schema and seeds three examples.'
