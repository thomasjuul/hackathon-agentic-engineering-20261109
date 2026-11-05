using System.Text;
using Workshop.Api;
using Xunit;

namespace Workshop.Tests;
public sealed class CsvTests
{
    [Fact]
    public void Export_preserves_column_order_and_line_endings()
    {
        var csv = Encoding.UTF8.GetString(CsvExporter.Export([
        new ProjectRequest { Municipality = "Fjordby", ProjectTitle = "School" }]));
        Assert.Equal("Municipality,Project title,Status\r\n\"Fjordby\",\"School\",\"New\"\r\n", csv);
    }

    [Fact]
    public void Export_preserves_Unicode_and_escapes_quotes_and_commas()
    {
        var csv = Encoding.UTF8.GetString(CsvExporter.Export([
        new ProjectRequest { Municipality = "Sødal", ProjectTitle = "Library, \"North\"" }]));
        Assert.Contains("\"Sødal\",\"Library, \"\"North\"\"\"", csv);
    }

    [Theory]
    [InlineData("=1+1")]
    [InlineData("  @SUM(A1)")]
    public void Export_neutralizes_formula_like_text(string title)
    {
        var csv = Encoding.UTF8.GetString(CsvExporter.Export([
        new ProjectRequest { Municipality = "Fjordby", ProjectTitle = title }]));
        Assert.Contains("\"'" + title + "\"", csv);
    }

    [Fact]
    public void Export_includes_both_statuses_without_losing_existing_fields()
    {
        var csv = Encoding.UTF8.GetString(CsvExporter.Export([
        new ProjectRequest { Municipality = "Fjordby", ProjectTitle = "School", Status = RequestStatus.New },
        new ProjectRequest { Municipality = "Sødal", ProjectTitle = "Library", Status = RequestStatus.Reviewed }]));
        Assert.Contains("\"Fjordby\",\"School\",\"New\"", csv);
        Assert.Contains("\"Sødal\",\"Library\",\"Reviewed\"", csv);
    }
}
