# Agents and skills for real project work

The guidance you create should help you build the application, not just check a workshop exercise. An agent has a job; a skill describes a repeatable way to do it. Keep both grounded in the code and rules of this project.

## Business-rule advisor

In session 2, create `workshop_domain_advisor`. Its job is to clarify what the app should do. For this case, it explains when a request is ready, why incomplete drafts can be saved, and why Reviewed requests cannot be edited. It uses your local rules rather than inventing company policy.

Ask it: “What should happen if the name contains only spaces? Does that block saving or only review? Show the relevant rule and an example.” Its output should give the implementer an agreed business decision, not just a test result.

## Technical advisor

Also create `workshop_technical_advisor`. Its job is to recommend a small design using the project you already have. For example, it can explain why the readiness calculation belongs on the server, what the API should return, and how the React screen should use that response.

Ask it: “Where should each part of this feature go? Show the relevant files and explain one design choice. Keep the current components and avoid adding layers we do not need.” The advisor recommends; one implementer makes the changes.

## Implementation skills

| Skill | What you write into it | How you use it here |
| --- | --- | --- |
| implement-business-rules | Read the business rules, clarify examples, and keep one authoritative server rule path | Implement readiness and later the review transition |
| implement-api-feature | Follow the existing API shape, separate rules from HTTP handling, and use the current persistence approach | Add checking, saving, and review endpoints |
| implement-react-feature | Use existing components/types/client, manage saving and errors, and display the server result | Build editing and review interactions |
| change-brownfield | Understand existing callers and preserve behavior outside the agreed change | Add Status without breaking the existing export |

You create the first two implementation skills in session 2 and the React skill in session 3. You create change-brownfield in the optional export extension. The skills belong in the application's `.agents/skills/` folder when you author them. Keep the workshop examples and authoring templates here in `case/docs`.

## A small example of useful guidance

“Read our rules and the existing evaluator before editing. Keep the rule decision on the server. Use the existing endpoint and typed API client. Preserve incomplete draft saving. Show the saved server response in the screen and keep the draft if saving fails.”

Turn that idea into your own procedure: when to use it, what to read, how to make the change, what to return, and when to ask you about an unclear decision. Use it on the feature, then improve it based on what happened. Do not simply copy a completed checkpoint and call that authoring.

## Checks still matter

You check and review changes throughout both days. In session 4, you create dedicated verifier/reviewer agents and their skills. They assess business correctness, code structure, error handling, persistence, and real app behavior. Their purpose is to help you judge a software change. You still decide whether to accept it.

Keep one code writer at a time and use only definitions available in your current session. These are small project conventions that you can adapt to another codebase, rather than a framework you must build before doing useful work.
