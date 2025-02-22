namespace UI_Project;

public class LoggerEntry
{
    public DateTime Date { get; set; }
    public string EventDetails { get; set; }
}

public static class Logger
{
    public static IEnumerable<LoggerEntry> GetEntries()
    {
        return new List<LoggerEntry>
        {
            new LoggerEntry { Date = DateTime.Now, EventDetails = "Event 1" },
            new LoggerEntry { Date = DateTime.Now.AddMinutes(-5), EventDetails = "Event 2" }
        };
    }
}