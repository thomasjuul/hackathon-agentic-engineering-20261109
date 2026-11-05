import { useEffect, useState } from 'react';
import { request } from './api';
export default function App() {
  const [status, setStatus] = useState('Checking the API and database…');
  useEffect(() => { request<{ database: boolean }>('/api/health')
    .then(value => setStatus(value.database ? 'API and PostgreSQL are ready.' : 'Database is unavailable.'))
    .catch(() => setStatus('Cannot reach the API. Check the API terminal.')); }, []);
  return <main className="welcome"><p className="eyebrow">AGENTIC ENGINEERING · HACKATHON</p>
    <h1>From Request to Review</h1><p>A small application. A complete development journey.</p>
    <section className="card"><h2>Ready for the first build</h2><p role="status">{status}</p>
    <p>Your first task: show the request list and open a request.</p>
    <p>Read TASK.md, write two acceptance examples, and give Codex a small, clear task.</p></section></main>;
}
