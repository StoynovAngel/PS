namespace WelcomeExtended.Loggers;

public static class Logger
{
    private static readonly string FILE_PATH = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Logs", "log.txt");

    public static void LogToFile(string message)
    {
        EnsureLogDirectoryExists();
        string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        string log = $"{date}: {message}";
        File.AppendAllText(FILE_PATH, log + Environment.NewLine);
    }

    public static void LogToFile(string message, Exception e)
    {
        string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        string log = $"{date}: {message}, Exception: {e}";
        File.AppendAllText(FILE_PATH, log + Environment.NewLine);
    }
    
    private static void EnsureLogDirectoryExists()
    {
        var logDirectory = Path.GetDirectoryName(FILE_PATH);
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }
    }
}