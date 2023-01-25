namespace Kata06EventsFileSearcher;

internal struct DirectoryFoundArgs
{
    public string CurrentDirectory { get; set; }
    public int TotalDirectories { get; set; }
    public int CompletedDirectories { get; set; }

    public DirectoryFoundArgs(
        string currentDirectory,
        int totalDirectories,
        int completedDirectories
    )
    {
        CurrentDirectory = currentDirectory;
        TotalDirectories = totalDirectories;
        CompletedDirectories = completedDirectories;
    }
}
