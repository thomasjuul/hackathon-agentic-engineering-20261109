import { request } from './api';
it('turns an API rejection into a readable message', async () => {
  vi.spyOn(globalThis, 'fetch').mockResolvedValue(new Response(JSON.stringify({ message: 'Request is read-only.' }), { status: 409 }));
  await expect(request('/api/example')).rejects.toThrow('Request is read-only.');
});
