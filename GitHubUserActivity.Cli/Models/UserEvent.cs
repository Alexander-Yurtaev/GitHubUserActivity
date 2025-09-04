using System.Text.Json.Serialization;

namespace GitHubUserActivity.Cli.Models;

public class UserEvent
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string EventType { get; set; }
}