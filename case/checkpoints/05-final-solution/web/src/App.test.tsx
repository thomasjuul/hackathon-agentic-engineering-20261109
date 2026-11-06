import { render, screen, within } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import App from './App';
import { api } from './api';
import type { RequestDetail } from './types';
const first: RequestDetail = { id: '1', municipality: 'Fjordby', projectTitle: 'School renovation',
  description: 'School insulation.', budgetAttached: false, status: 'New', activity: [], readiness: { isReady: false, missingFields: ['Budget must be attached.'] } };
const second: RequestDetail = { ...first, id: '2', municipality: 'Sødal', projectTitle: 'Library refurbishment' };
function setup() {
  vi.spyOn(api, 'list').mockResolvedValue([first, second]);
  vi.spyOn(api, 'detail').mockImplementation(async id => structuredClone(id === '1' ? first : second));
  return userEvent.setup();
}
it('selects different requests and displays the correct details', async () => {
  const user = setup(); render(<App />);
  await user.click(await screen.findByRole('button', { name: /Fjordby/ }));
  const panel = screen.getByRole('article', { name: 'Request details' });
  expect(await within(panel).findByRole('heading', { name: 'School renovation' })).toBeInTheDocument();
  await user.click(screen.getByRole('button', { name: /Sødal/ }));
  expect(await within(panel).findByRole('heading', { name: 'Library refurbishment' })).toBeInTheDocument();
});
it('shows a useful API error', async () => {
  setup(); vi.mocked(api.list).mockRejectedValue(new Error('API unavailable.'));
  render(<App />); expect(await screen.findByRole('alert')).toHaveTextContent('API unavailable.');
});

    it('shows the server explanation for missing information', async () => {
      const user = setup(); render(<App />);
      await user.click(await screen.findByRole('button', { name: /Fjordby/ }));
      expect(await screen.findByText('Budget must be attached.')).toBeInTheDocument();
    });

    it('saves a correction and refreshes the check result', async () => {
      const user = setup();
      vi.spyOn(api, 'save').mockResolvedValue({ ...first, budgetAttached: true, readiness: { isReady: true, missingFields: [] } });
      render(<App />); await user.click(await screen.findByRole('button', { name: /Fjordby/ }));
      await user.click(await screen.findByRole('button', { name: 'Edit request' }));
      await user.click(screen.getByRole('checkbox', { name: 'Budget attached' }));
      await user.click(screen.getByRole('button', { name: 'Save changes' }));
      expect(await screen.findByRole('heading', { name: 'Ready to review' })).toBeInTheDocument();
      expect(api.save).toHaveBeenCalledWith('1', expect.objectContaining({ budgetAttached: true }));
    });
    it('preserves the draft and reports a save failure', async () => {
      const user = setup(); vi.spyOn(api, 'save').mockRejectedValue(new Error('Cannot save.'));
      render(<App />); await user.click(await screen.findByRole('button', { name: /Fjordby/ }));
      await user.click(await screen.findByRole('button', { name: 'Edit request' }));
      await user.click(screen.getByRole('button', { name: 'Save changes' }));
      expect(await screen.findByRole('alert')).toHaveTextContent('Cannot save.');
      expect(screen.getByRole('textbox', { name: 'Municipality' })).toHaveValue('Fjordby');
    });

    it('disables review while information is missing', async () => {
      const user = setup(); render(<App />);
      await user.click(await screen.findByRole('button', { name: /Fjordby/ }));
      expect(await screen.findByRole('button', { name: 'Mark reviewed' })).toBeDisabled();
    });
    it('records review and hides editing on the reviewed result', async () => {
      const user = setup();
      vi.mocked(api.detail).mockResolvedValue({ ...first, budgetAttached: true, readiness: { isReady: true, missingFields: [] } });
      vi.spyOn(api, 'review').mockResolvedValue({ ...first, budgetAttached: true, status: 'Reviewed',
        readiness: { isReady: true, missingFields: [] }, activity: [{ action: 'Marked reviewed', actor: 'Workshop caseworker', occurredAt: '2026-11-03T12:00:00Z', correlationId: 'trace-1' }] });
      render(<App />); await user.click(await screen.findByRole('button', { name: /Fjordby/ }));
      await user.click(await screen.findByRole('button', { name: 'Mark reviewed' }));
      expect(await screen.findByText('Marked reviewed')).toBeInTheDocument();
      expect(screen.queryByRole('button', { name: 'Edit request' })).not.toBeInTheDocument();
    });
