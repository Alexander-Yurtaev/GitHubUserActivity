using System.Text.Json.Serialization;

namespace GitHubUserActivity.Cli.Models;

public class ErrorMessage
{
    public ErrorMessage()
    {

    }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("documentation_url")]
    public string DocumentationUrl { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}