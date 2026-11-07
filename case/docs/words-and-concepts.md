# Words and concepts

You do not need to memorise these terms. Look up a word when you meet it in a task. Each session explains its own main concept too.

## Working with Codex

| Word | What it means here | Example |
| --- | --- | --- |
| Agentic engineering | Designing how an agent does useful work, and how you check that work | Give Codex a clear task, useful information, checks, and a stopping point |
| Prompt | The instruction you give Codex | “Show the requests and let me open one” |
| Context | Information Codex needs for the task | Our three rules and the code already in the project |
| Harness | The instructions, roles, skills, and tools around Codex | The guidance that helps it work consistently |
| Custom agent | An agent given a particular job | A domain advisor explains business rules; a technical advisor plans the implementation |
| Skill | Written steps an agent can reuse | How to implement an API feature using project conventions |
| MCP | Model Context Protocol: a way for Codex to use tools offered by a service | Search official documentation through Microsoft Learn |
| Loop | Try, check the result, and improve it if needed | Fix a failed check and run it again |
| Graph | A picture showing possible next steps | A passing check goes to review; a failure may go to repair |
| Bounded task | Work with clear limits | Change only this feature; stop after two repairs or 20 minutes |
| Handoff | A short note passed to the next agent or person | What changed, what was checked, and what remains |
| Evaluation | Compare a result with what you expected | An incomplete request must not become Reviewed |
| Observability | Make it possible to see what happened | Connect a failed action to the server's log message |
| Governance | Agree who may do what and who decides acceptance | Codex proposes a change; you inspect it and decide |
| Greenfield | Starting something new | The first version of a small application |
| Brownfield | Changing something that already exists | Add a column without breaking the existing export |
| SDLC | Software development lifecycle: the work from understanding a need to maintaining a solution | Plan, build, check, review, release, improve |

## The application and its files

| Word | What it means here |
| --- | --- |
| Frontend / UI | The part you see and use in the browser. Written with React and TypeScript |
| Backend / API | The server code that receives requests from the browser. Written with C# and .NET |
| PostgreSQL / database | The installed program that stores the application's saved information |
| Endpoint | An API address that performs a particular action, such as saving a request |
| Contract | An agreement about what an API or file accepts and returns |
| JSON | A text format the browser and API use to exchange data |
| CSV | A text file containing rows and columns, which can be opened in a spreadsheet |
| Readiness | Whether the three required items are present. This is a check result, not a saved status |
| Activity | A saved record of an action in the app, such as “Marked reviewed” |
| Log | Messages written by the running server to help explain what happened |
| Correlation ID | A reference number that connects one API call to its log messages |
| Diff | A view showing the lines of code or text that changed |
| Acceptance example | A concrete example of what should happen when the task is complete |
| Regression check | A check that earlier behavior still works after a change |
| Checkpoint | A saved version of the code. Supplied checkpoints can help you catch up |
| Seed data | The three fictional requests the app creates in a new database |
| Fixture | A controlled test setup, often with made-up data or delayed responses |
| Concurrency | More than one operation happening at the same time |
| Stale response | A reply from an older operation that arrives after a newer one |
| Idempotent action | Repeating the action has no additional effect. Reviewing twice must not add two activities |

If an explanation still feels too technical, ask: “Explain this term using our request application and one example. Do not change any files.”
