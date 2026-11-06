namespace Workshop.Api;

public sealed record ReadinessResult(bool IsReady, IReadOnlyList<string> MissingFields);

public static class Readiness
{
    public static ReadinessResult? Evaluate(ProjectRequest request)
    {
        var missing = new List<string>();
        if (string.IsNullOrWhiteSpace(request.Municipality)) missing.Add("Municipality name is required.");
        if (string.IsNullOrWhiteSpace(request.ProjectTitle)) missing.Add("Project title is required.");
        if (!request.BudgetAttached) missing.Add("Budget must be attached.");
        return new ReadinessResult(missing.Count == 0, missing);
    }
}
