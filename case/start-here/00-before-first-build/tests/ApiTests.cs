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

}
