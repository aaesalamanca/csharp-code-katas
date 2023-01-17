using Kata05DelegatesLogger;

Logger.LogMessage(Severity.Verbose, "Component 1", "First Log Message");

Logger.WriteMessage += Console.WriteLine;

Logger.LogMessage(Severity.Trace, "Component 2", "Second Log Message");

FileLogger fileLogger = new("Log.txt");

Logger.LogMessage(Severity.Information, "Component 3", "Third Log Message");
Logger.LogMessage(Severity.Warning, "Component 4", "Fourth Log Message");
Logger.LogMessage(Severity.Error, "Component 5", "Fifth Log Message");

fileLogger.DetachLog();

Logger.LogMessage(Severity.Critical, "Component 6", "Sixth Log Message");
