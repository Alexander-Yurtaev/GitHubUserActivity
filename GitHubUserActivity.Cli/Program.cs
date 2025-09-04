using GitHubUserActivity.Cli;

string username = args.Any() ? args[0] : "";

if (string.IsNullOrEmpty(username))
{
    Console.WriteLine("You need enter a GitHub-username");
    return;
}

ApiClient client = new ApiClient("https://api.github.com/users/");
string request = $"{username}/events";

UserEvent[]? userEvents = null;

try
{
    userEvents = await client.GetAsync<UserEvent[]>(request);
}
catch (HttpRequestException ex)
{
    Console.WriteLine($"ERROR: {ex.Message}");
    return;
}


Console.WriteLine($"userEvents: {userEvents?.Length ?? 0}");