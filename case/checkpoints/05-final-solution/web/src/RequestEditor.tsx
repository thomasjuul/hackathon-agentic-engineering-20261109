import { useState } from 'react';
import { api } from './api';
import type { RequestDetail, RequestUpdate } from './types';
export function RequestEditor({ request, onSaved, onBusyChange }: { request: RequestDetail; onSaved: (value: RequestDetail) => void; onBusyChange: (value: boolean) => void }) {
  const [editing, setEditing] = useState(false);
  const [draft, setDraft] = useState<RequestUpdate>(request);
  const [saving, setSaving] = useState(false);
  const [error, setError] = useState('');
  if (request.status === 'Reviewed') return null;
  if (!editing) return <button className="secondary" onClick={() => { setDraft(request); setError(''); setEditing(true); }}>Edit request</button>;
  async function save(event: React.FormEvent) {
    event.preventDefault(); setSaving(true); onBusyChange(true); setError('');
    try { const updated = await api.save(request.id, draft); onSaved(updated); setEditing(false); }
    catch (error) { setError(error instanceof Error ? error.message : 'Saving failed.'); }
    finally { setSaving(false); onBusyChange(false); }
  }
  return <form onSubmit={event => void save(event)} className="editor" aria-label="Edit request">
    <label>Municipality<input value={draft.municipality} onChange={event => setDraft({ ...draft, municipality: event.target.value })} disabled={saving} /></label>
    <label>Project title<input value={draft.projectTitle} onChange={event => setDraft({ ...draft, projectTitle: event.target.value })} disabled={saving} /></label>
    <label>Description<textarea value={draft.description} onChange={event => setDraft({ ...draft, description: event.target.value })} disabled={saving} /></label>
    <label className="checkbox"><input type="checkbox" checked={draft.budgetAttached} onChange={event => setDraft({ ...draft, budgetAttached: event.target.checked })} disabled={saving} />Budget attached</label>
    {error && <p className="error" role="alert">{error}</p>}
    <div className="actions"><button className="primary" disabled={saving}>{saving ? 'Saving…' : 'Save changes'}</button>
      <button type="button" className="secondary" disabled={saving} onClick={() => setEditing(false)}>Cancel</button></div>
  </form>;
}
