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
        // TODO BUILD 1: add list and detail GET endpoints. See docs/api-contract.md.
    }
}
