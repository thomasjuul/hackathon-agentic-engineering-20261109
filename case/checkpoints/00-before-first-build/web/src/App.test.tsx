import { render, screen } from '@testing-library/react';
import App from './App';
it('shows whether the API and database are available', async () => {
  vi.spyOn(globalThis, 'fetch').mockResolvedValue(new Response(JSON.stringify({ database: true })));
  render(<App />);
  expect(await screen.findByText('API and PostgreSQL are ready.')).toBeInTheDocument();
});
