namespace Kata06EventsFileSearcher;

internal class FileFoundArgs
{
    public string FoundFile { get; }
    public bool CancelRequest { get; set; }

    public FileFoundArgs(string foundFile) => FoundFile = foundFile;
}
