namespace Kata05DelegatesLogger;

internal class FileLogger
{
    readonly string _logPath;

    public FileLogger(string path)
    {
        _logPath = path;
        Logger.WriteMessage += LogMessage;
    }

    public void DetachLog() => Logger.WriteMessage -= LogMessage;

    void LogMessage(string message)
    {
        try
        {
            using StreamWriter fileStream = File.AppendText(_logPath);
            fileStream.WriteLine(message);
            fileStream.Flush();
        }
        catch (Exception) { }
    }
}
