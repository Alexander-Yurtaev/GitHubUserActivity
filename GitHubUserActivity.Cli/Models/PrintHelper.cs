namespace GitHubUserActivity.Cli.Models;

public static class PrintHelper
{
    public static void PrintUserEvents(UserEvent[]? userEvents, string userName)
    {
        if (userEvents is null || userEvents.Length == 0)
        {
            Console.WriteLine("The user has no events.");
            return;
        }

        IEnumerable<IGrouping<string, UserEvent>> dict = userEvents.GroupBy(keySelector: @event => @event.EventType, @event => @event);
        foreach (IGrouping<string, UserEvent> events in dict)
        {
            ShowEvent(events.Key, events.Count(), userName);
        }
    }

    public static void ShowEvent(string eventsKey, int eventsCount, string userName)
    {
        Console.WriteLine(EventTemplates.TryGetValue(eventsKey, out var template)
            ? string.Format(template, eventsCount, userName)
            : $"Unknown Event Type: '{eventsKey}'");
    }

    private static readonly Dictionary<string, string> EventTemplates = new()
    {
        {"PushEvent", "Pushed {0} commits to {1}"},
        {"WatchEvent", "Watch was {0} to {1}"},
        {"DeleteEvent", "Deleted {0} by {1}"},
        {"CreateEvent", "Created {0} by {1}"},
        {"IssueCommentEvent", "Comment for Issue {0} by {1}"},
        {"IssuesEvent", "Opened {0} new issues by {1}"},
        {"PullRequestEvent", "PullRequest was {0} times by {1}"},
        {"PullRequestReviewCommentEvent", "PullRequestReview was commented {0} times by {1}"},
        {"PullRequestReviewEvent", "PullRequest was reviewed {0} times by {1}"},
    };
}
