# Target API contract (introduced gradually)
All JSON uses camelCase; status is "New" or "Reviewed".
- GET /api/health -> {status:"ok", database:true} (provided before session 1).
- GET /api/requests -> [{id, municipality, projectTitle, status}] (build 1).
- GET /api/requests/{id} -> {id, municipality, projectTitle, description,
  budgetAttached, status, readiness, activity} (build 1).
- POST /api/requests/{id}/check -> {isReady, missingFields:string[]} (build 2).
- PUT /api/requests/{id} with {municipality, projectTitle, description, budgetAttached}
  -> updated detail; saves incomplete drafts; 409 if Reviewed (build 3).
- POST /api/requests/{id}/review -> updated detail; 400 if incomplete (build 4).
- GET /api/requests/export -> CSV download (existing supplied behavior).

Before build 2 readiness is null. Before build 4 activity is empty.
A review activity has action, actor, occurredAt (ISO date), and correlationId.
A missing request returns 404. Errors include a readable message.
The correlation header is X-Correlation-ID. Review is repeatable without duplicate activity.
The workshop has one development-only caseworker, not an authentication system.
