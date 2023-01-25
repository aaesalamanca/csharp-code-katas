namespace Kata06EventsFileSearcher;

internal class FileSearcher
{
    public event EventHandler<FileFoundArgs>? FileFound;

    event EventHandler<DirectoryFoundArgs>? _directoryFound;
    public event EventHandler<DirectoryFoundArgs>? DirectoryFound
    {
        add { _directoryFound += value; }
        remove { _directoryFound -= value; }
    }

    public void Search(string directory, string pattern) => SearchFiles(directory, pattern);

    public void Search(string directory, string pattern, bool searchSubDirs = false)
    {
        if (searchSubDirs)
        {
            string[] allDirectories = Directory.GetDirectories(
                directory,
                "*",
                SearchOption.AllDirectories
            );
            int completedDirectories = 0;
            int totalDirectories = allDirectories.Length + 1;
            foreach (string dir in allDirectories)
            {
                RaiseDirectoryFound(dir, totalDirectories, completedDirectories++);
                SearchFiles(dir, pattern);
            }

            RaiseDirectoryFound(directory, totalDirectories, completedDirectories++);
            SearchFiles(directory, pattern);
        }
        else
        {
            SearchFiles(directory, pattern);
        }
    }

    private void SearchFiles(string directory, string pattern)
    {
        foreach (string file in Directory.EnumerateFiles(directory, pattern))
        {
            FileFoundArgs args = RaiseFileFound(file);

            if (args.CancelRequest)
            {
                break;
            }
        }
    }

    FileFoundArgs RaiseFileFound(string file)
    {
        FileFoundArgs args = new(file);
        FileFound?.Invoke(this, args);
        return args;
    }

    void RaiseDirectoryFound(string dir, int totalDirectories, int completedDirectories) =>
        _directoryFound?.Invoke(
            this,
            new DirectoryFoundArgs(dir, totalDirectories, completedDirectories)
        );
}
