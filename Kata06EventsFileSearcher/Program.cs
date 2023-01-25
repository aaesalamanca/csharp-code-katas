using Kata06EventsFileSearcher;

FileSearcher fileSearcher = new();

EventHandler<FileFoundArgs> onFileFound = (sender, args) =>
{
    Console.WriteLine("\t" + args.FoundFile);

    //if (args.FoundFile.Contains(".csproj"))
    //{
    //    Console.WriteLine($"Search cancelled at file `{args.FoundFile}`.");
    //    args.CancelRequest = true;
    //}
};
fileSearcher.FileFound += onFileFound;

fileSearcher.DirectoryFound += (sender, args) =>
{
    Console.WriteLine($"Entering `{args.CurrentDirectory}`.");
    Console.WriteLine($"\t{args.CompletedDirectories} of {args.TotalDirectories} completed...");
};

Console.WriteLine("####### Show Files #######");
fileSearcher.Search("..\\..\\..\\", "*");

Console.WriteLine();

Console.WriteLine("####### Show Directories & Files #######");
fileSearcher.Search("..\\..\\..\\", "*", true);

fileSearcher.FileFound -= onFileFound;
fileSearcher.Search("..\\..\\..\\", "*");
