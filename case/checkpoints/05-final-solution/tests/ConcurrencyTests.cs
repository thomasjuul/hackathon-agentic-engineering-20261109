using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Workshop.Api;
using Xunit;

namespace Workshop.Tests;

public sealed class ConcurrencyTests
{
    [Fact]
    public async Task Stale_review_cannot_overwrite_a_newer_incomplete_edit()
    {
        using var app = new ApiFactory();
        using var client = app.CreateClient();
        using var reviewerScope = app.Services.CreateScope();
        using var editorScope = app.Services.CreateScope();
        var reviewerDb = reviewerScope.ServiceProvider.GetRequiredService<WorkshopDb>();
        var editorDb = editorScope.ServiceProvider.GetRequiredService<WorkshopDb>();
        var stale = await reviewerDb.Requests.SingleAsync(x => x.Id == SeedData.Sodal);
        var current = await editorDb.Requests.SingleAsync(x => x.Id == SeedData.Sodal);
        current.BudgetAttached = false;
        current.Version++;
        await editorDb.SaveChangesAsync();
        stale.Status = RequestStatus.Reviewed;
        stale.Version++;
        stale.Activity.Add(ActivityRecorder.Reviewed(stale.Id, "stale-test"));
        await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => reviewerDb.SaveChangesAsync());
        using var verifyScope = app.Services.CreateScope();
        var db = verifyScope.ServiceProvider.GetRequiredService<WorkshopDb>();
        var saved = await db.Requests.AsNoTracking().SingleAsync(x => x.Id == SeedData.Sodal);
        Assert.Equal(RequestStatus.New, saved.Status);
        Assert.False(saved.BudgetAttached);
        Assert.Empty(await db.Activities.ToListAsync());
    }
}
