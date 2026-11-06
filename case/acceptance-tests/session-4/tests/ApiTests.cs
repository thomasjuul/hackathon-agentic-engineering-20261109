using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Workshop.Api;
using Xunit;

namespace Workshop.Tests;

public sealed class ApiTests
{
    [Fact]
    public async Task Health_checks_the_database()
    {
        using var app = new ApiFactory();
        using var client = app.CreateClient();
        var health = await client.GetFromJsonAsync<JsonElement>("/api/health");
        Assert.True(health.GetProperty("database").GetBoolean());
    }

    [Fact]
    public async Task List_and_detail_select_the_correct_persisted_request()
    {
        using var app = new ApiFactory();
        using var client = app.CreateClient();
        var list = await client.GetFromJsonAsync<JsonElement>("/api/requests");
        Assert.Equal(3, list.GetArrayLength());
        var first = await client.GetFromJsonAsync<JsonElement>($"/api/requests/{SeedData.Fjordby}");
        var second = await client.GetFromJsonAsync<JsonElement>($"/api/requests/{SeedData.Sodal}");
        Assert.Equal("Fjordby", first.GetProperty("municipality").GetString());
        Assert.Equal("Sødal", second.GetProperty("municipality").GetString());
        Assert.Equal(HttpStatusCode.NotFound, (await client.GetAsync($"/api/requests/{Guid.NewGuid()}")).StatusCode);
    }

    [Theory]
    [InlineData("Fjordby", "School", true, 0)]
    [InlineData("", "School", true, 1)]
    [InlineData("Fjordby", "   ", true, 1)]
    [InlineData("Fjordby", "School", false, 1)]
    [InlineData(" ", "", false, 3)]
    public void Readiness_applies_exactly_the_three_rules(string name, string title, bool budget, int missing)
    {
        var result = Readiness.Evaluate(new ProjectRequest
        { Municipality = name, ProjectTitle = title, BudgetAttached = budget })!;
        Assert.Equal(missing, result.MissingFields.Count);
        Assert.Equal(missing == 0, result.IsReady);
    }

    [Fact]
    public async Task Check_endpoint_reports_the_missing_budget()
    {
        using var app = new ApiFactory();
        using var client = app.CreateClient();
        var response = await client.PostAsync($"/api/requests/{SeedData.Fjordby}/check", null);
        response.EnsureSuccessStatusCode();
        Assert.Contains("Budget must be attached.", await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task Edit_persists_and_recomputes_readiness()
    {
        using var app = new ApiFactory();
        using var client = app.CreateClient();
        var result = await client.PutAsJsonAsync($"/api/requests/{SeedData.Fjordby}",
        new RequestUpdate("Fjordby", "School renovation", "Updated description", true));
        result.EnsureSuccessStatusCode();
        var reloaded = await client.GetFromJsonAsync<JsonElement>($"/api/requests/{SeedData.Fjordby}");
        Assert.True(reloaded.GetProperty("budgetAttached").GetBoolean());
        Assert.True(reloaded.GetProperty("readiness").GetProperty("isReady").GetBoolean());
        Assert.Equal("Updated description", reloaded.GetProperty("description").GetString());
    }

    [Fact]
    public async Task Direct_API_cannot_review_an_incomplete_request()
    {
        using var app = new ApiFactory();
        using var client = app.CreateClient();
        var response = await client.PostAsync($"/api/requests/{SeedData.Fjordby}/review", null);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        var saved = await client.GetFromJsonAsync<JsonElement>($"/api/requests/{SeedData.Fjordby}");
        Assert.Equal("New", saved.GetProperty("status").GetString());
        Assert.Equal(0, saved.GetProperty("activity").GetArrayLength());
    }

    [Fact]
    public async Task Review_is_persisted_read_only_and_logged_once()
    {
        using var app = new ApiFactory();
        using var client = app.CreateClient();
        var route = $"/api/requests/{SeedData.Sodal}";
        var first = await client.PostAsync(route + "/review", null);
        first.EnsureSuccessStatusCode();
        Assert.True(first.Headers.Contains("X-Correlation-ID"));
        (await client.PostAsync(route + "/review", null)).EnsureSuccessStatusCode();
        var saved = await client.GetFromJsonAsync<JsonElement>(route);
        Assert.Equal("Reviewed", saved.GetProperty("status").GetString());
        Assert.Equal(1, saved.GetProperty("activity").GetArrayLength());
        var activity = saved.GetProperty("activity")[0];
        Assert.Equal("Marked reviewed", activity.GetProperty("action").GetString());
        Assert.False(string.IsNullOrWhiteSpace(activity.GetProperty("correlationId").GetString()));
        var edit = await client.PutAsJsonAsync(route,
        new RequestUpdate("Changed", "Changed", "Changed", false));
        Assert.Equal(HttpStatusCode.Conflict, edit.StatusCode);
        var unchanged = await client.GetFromJsonAsync<JsonElement>(route);
        Assert.Equal("Sødal", unchanged.GetProperty("municipality").GetString());
    }

}
