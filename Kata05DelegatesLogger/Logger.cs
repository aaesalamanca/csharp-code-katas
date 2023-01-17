namespace Kata05DelegatesLogger;

internal static class Logger
{
    public static Action<string>? WriteMessage;

    public static void LogMessage(Severity severity, string component, string message)
    {
        string outputMessage = $"{DateTime.Now, -25}{severity, 15}{component, 20}\t{message, 30}";
        WriteMessage?.Invoke(outputMessage);
    }
}
