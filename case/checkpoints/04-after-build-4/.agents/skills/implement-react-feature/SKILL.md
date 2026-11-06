---
name: implement-react-feature
description: Build a small React and TypeScript feature using existing components, the typed API client, and clear interaction states.
---

1. Inspect the current screen, reusable components, TypeScript types, API client, and user-facing examples. Identify what the browser displays or edits and which business decisions are returned by the server.
2. Plan the smallest component/state change using existing project patterns. Use the existing typed client; avoid scattering raw HTTP calls or reproducing authoritative business rules in the browser. Do not add a state framework or UI package just for the current task.
3. As an advisor, describe the component responsibilities and interaction flow without editing. As the agreed implementer, build the feature with clear labels and appropriate loading, saving, and error feedback. Keep an entered draft after a failed save and prevent conflicting actions while saving. Do not add optional features unless requested.
4. Display the server's saved values and readiness result after success. Respect read-only state. Keep presentational details separate from API access and rule decisions so later changes can reuse the same approach.
5. Check the relevant interaction with component tests and the browser. Run npm test and npm run build in web/. Explain the component/state choice, actual results, and any remaining limitation.
