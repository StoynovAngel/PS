using System.Collections.Concurrent;
using System.Text;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers;

public class HashLogger : ILogger
{
    private readonly ConcurrentDictionary<int, string> logMessage;
    private readonly string name;

    public HashLogger(string name)
    {
        this.name = name;
        logMessage = new ConcurrentDictionary<int, string>();
    }


    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var message = formatter(state, exception);
        switch (logLevel)
        {
            case LogLevel.Critical:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case LogLevel.Error:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                break;
            case LogLevel.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
        Console.WriteLine("===LOGGER===");
        var messageToBeLogged = new StringBuilder();
        messageToBeLogged.Append($"[{logLevel}]");
        messageToBeLogged.AppendFormat("[{0}]", name);
        Console.WriteLine(messageToBeLogged);
        Console.WriteLine($"{formatter(state, exception)}");
        Console.WriteLine("===LOGGER===");
        Console.ResetColor();
        logMessage[eventId.Id] = message;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public void printAllMessages()
    {
        foreach (var entry in logMessage)
        {
            {
                Console.WriteLine($"EventId: {entry.Key}, Message: {entry.Value}");
            }
        }
    }

    public void printLogById(int eventId)
    {
        if (logMessage.TryGetValue(eventId, out string? message))
        {
            Console.WriteLine($"EventId: {eventId}, Message: {message}");
        }
        else
        {
            Console.WriteLine($"No log found for EventId: {eventId}");
        }
    }
    
    public void deleteEventById(int eventId)
    {
        if (logMessage.TryRemove(eventId, out _))
        {
            Console.WriteLine($"Deleted log for EventId: {eventId}");
        }
        else
        {
            Console.WriteLine($"No log found to delete for EventId: {eventId}");
        }
    }
}