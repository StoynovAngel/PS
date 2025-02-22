using Welcome.Model;

namespace WelcomeExtended.Loggers;

public static class Logger
{
    private static readonly string FILE_PATH_ERRORS = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Logs", "log.txt");
    private static readonly string FILE_PATH_ACTIVITY = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Logs", "log_activity.txt");
    
    public static void LogToFile(string message)
    {
        EnsureLogDirectoryExists();
        string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        string log = $"{date}: {message}";
        File.AppendAllText(FILE_PATH_ERRORS, log + Environment.NewLine);
    }

    public static void LogToFile(string message, Exception e)
    {
        string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        string log = $"{date}: {message}, Exception: {e}";
        File.AppendAllText(FILE_PATH_ERRORS, log + Environment.NewLine);
    }

    public static void LoginActivity(User? user, String message)
    {
        string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        string log = $"{date}: Status: {message} {user}"; 
        File.AppendAllText(FILE_PATH_ACTIVITY, log + Environment.NewLine);
    }
    
    public static void LoginActivity(String message)
    {
        string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        string log = $"{date}: Status: {message}"; 
        File.AppendAllText(FILE_PATH_ACTIVITY, log + Environment.NewLine);
    }
    
    private static void EnsureLogDirectoryExists()
    {
        var logDirectory = Path.GetDirectoryName(FILE_PATH_ERRORS);
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }
    }
}