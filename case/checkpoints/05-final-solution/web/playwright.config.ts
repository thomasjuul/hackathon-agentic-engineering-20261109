import { defineConfig } from '@playwright/test';

const connection = process.env.WORKSHOP_E2E_CONNECTION;
if (!connection) throw new Error('Use scripts/Test-Browser.ps1 or provide WORKSHOP_E2E_CONNECTION for a separate disposable PostgreSQL database.');

export default defineConfig({
  testDir: './e2e',
  fullyParallel: false,
  workers: 1,
  retries: 0,
  timeout: 60_000,
  use: { baseURL: 'http://127.0.0.1:5173', trace: 'retain-on-failure' },
  webServer: [
    {
      command: 'dotnet run --project ../api/Workshop.Api.csproj --no-launch-profile -- --urls http://127.0.0.1:5080',
      url: 'http://127.0.0.1:5080/api/health',
      env: { ConnectionStrings__Workshop: connection, ASPNETCORE_ENVIRONMENT: 'Development' },
      timeout: 120_000,
      reuseExistingServer: false
    },
    { command: 'npm run dev', url: 'http://127.0.0.1:5173', reuseExistingServer: false }
  ]
});
