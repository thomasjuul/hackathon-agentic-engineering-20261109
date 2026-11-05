using Microsoft.EntityFrameworkCore;
namespace Workshop.Api;

public static class Endpoints
{
    public static void MapWorkshopEndpoints(this WebApplication app)
    {
        app.MapGet("/api/health", async (WorkshopDb db) =>
            Results.Ok(new { status = "ok", database = await db.Database.CanConnectAsync() }));

        // Supplied brownfield behavior; introduced to participants in build session 5.
        app.MapGet("/api/requests/export", async (WorkshopDb db) =>
        {
            var requests = await db.Requests.AsNoTracking().OrderBy(x => x.Municipality).ToListAsync();
            return Results.File(CsvExporter.Export(requests), "text/csv; charset=utf-8", "requests.csv");
        });

        app.MapGet("/api/requests", async (WorkshopDb db) =>
            Results.Ok(await db.Requests.AsNoTracking().OrderBy(x => x.Municipality)
            .Select(x => new RequestSummary(x.Id, x.Municipality, x.ProjectTitle, x.Status)).ToListAsync()));
        app.MapGet("/api/requests/{id:guid}", async Task<IResult> (Guid id, WorkshopDb db) =>
        {
            var request = await db.Requests.AsNoTracking().Include(x => x.Activity).SingleOrDefaultAsync(x => x.Id == id);
            return request is null ? Results.NotFound(new { message = "Request not found." })
                : Results.Ok(RequestDetail.From(request));
        });

        app.MapPost("/api/requests/{id:guid}/check", async Task<IResult> (Guid id, WorkshopDb db) =>
        {
            var request = await db.Requests.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return request is null ? Results.NotFound(new { message = "Request not found." })
                : Results.Ok(Readiness.Evaluate(request));
        });

        app.MapPut("/api/requests/{id:guid}", async Task<IResult> (Guid id, RequestUpdate update, WorkshopDb db) =>
        {
            var request = await db.Requests.Include(x => x.Activity).SingleOrDefaultAsync(x => x.Id == id);
            if (request is null) return Results.NotFound(new { message = "Request not found." });
            if (request.Status == RequestStatus.Reviewed)
                return Results.Conflict(new { message = "Reviewed requests cannot be edited." });
            request.Municipality = update.Municipality?.Trim() ?? "";
            request.ProjectTitle = update.ProjectTitle?.Trim() ?? "";
            request.Description = update.Description?.Trim() ?? "";
            request.BudgetAttached = update.BudgetAttached;
            request.Version++;
            await db.SaveChangesAsync();
            return Results.Ok(RequestDetail.From(request));
        });
    }
}
