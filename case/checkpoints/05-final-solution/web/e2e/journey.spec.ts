import { test, expect } from '@playwright/test';
import { readFile } from 'node:fs/promises';

const fjordby = '11111111-1111-1111-1111-111111111111';

test('correct, reload, review, protect, and export a real PostgreSQL request', async ({ page, request }) => {
  const blocked = await request.post(`http://127.0.0.1:5080/api/requests/${fjordby}/review`);
  expect(blocked.status()).toBe(400);

  await page.goto('/');
  await page.getByRole('button', { name: /Fjordby/ }).click();
  await expect(page.getByText('Budget must be attached.')).toBeVisible();
  await expect(page.getByRole('button', { name: 'Mark reviewed' })).toBeDisabled();

  await page.getByRole('button', { name: 'Edit request' }).click();
  await page.getByRole('checkbox', { name: 'Budget attached' }).check();
  await page.getByRole('button', { name: 'Save changes' }).click();
  await expect(page.getByRole('heading', { name: 'Ready to review' })).toBeVisible();
  await page.reload();
  await page.getByRole('button', { name: /Fjordby/ }).click();
  await expect(page.getByRole('heading', { name: 'Ready to review' })).toBeVisible();

  const reviewResponse = page.waitForResponse(response => response.url().endsWith(`/${fjordby}/review`));
  await page.getByRole('button', { name: 'Mark reviewed' }).click();
  const reviewed = await reviewResponse;
  expect(reviewed.ok()).toBeTruthy();
  expect(reviewed.headers()['x-correlation-id']).toBeTruthy();
  await expect(page.getByText('Marked reviewed', { exact: true })).toBeVisible();
  await expect(page.getByRole('button', { name: 'Edit request' })).toHaveCount(0);

  const rejectedEdit = await request.put(`http://127.0.0.1:5080/api/requests/${fjordby}`, {
    data: { municipality: 'Changed', projectTitle: 'Changed', description: '', budgetAttached: false }
  });
  expect(rejectedEdit.status()).toBe(409);
  const repeatedReview = await request.post(`http://127.0.0.1:5080/api/requests/${fjordby}/review`);
  expect(repeatedReview.ok()).toBeTruthy();
  const repeatedBody = await repeatedReview.json();
  expect(repeatedBody.activity).toHaveLength(1);
  expect(repeatedBody.municipality).toBe('Fjordby');

  const downloadEvent = page.waitForEvent('download');
  await page.getByRole('link', { name: 'Export CSV' }).click();
  const download = await downloadEvent;
  const csv = await readFile((await download.path())!, 'utf8');
  expect(csv.startsWith('Municipality,Project title,Status\r\n')).toBeTruthy();
  expect(csv).toContain('"Fjordby","School renovation","Reviewed"');
  expect(csv).toContain('"Vesteng","","New"');
});
