# C# Code Katas

* These example apps are code practices based on the tutorials listed below.
* There may be a few differences between the code from the tutorials and the code on this repository because, in most cases, I've tried to use more modern or best practices.

## Katas

| Name | Tutorial / Documentation | App | Notes |
| ---- | -------- | --- | ----- |
| Kata 01 Teleprompter | [Console app](https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/console-teleprompter) | Console | In order to make the code run properly, `sampleQuotes.txt` should be copied inside `.\Kata01Teleprompter\bin\Debug\net7.0\`. |
| Kata 02 Names | [Tutorial: Create a new WPF app with .NET](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/get-started/create-app-visual-studio?view=netdesktop-6.0) | WPF | |
| Kata 03 HelloWPFApp | [Tutorial: Create a simple WPF application with C#](https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-wpf?view=vs-2022) | WPF | |
| Kata 04 Generate & Consume Async Streams | [Tutorial: Generate and consume async streams using C# and .NET](https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/generate-consume-asynchronous-stream) | Console | Kata simplified without consuming GitHub GraphQL API. |
| Kata 05 Delegates Logger | [Common patterns for delegates](https://learn.microsoft.com/en-us/dotnet/csharp/delegates-patterns) | Console | It isn't a tutorial, but it's based on the code shown on the official documentation. The generated `log.txt` is under `.\Kata05DelegatesLogger\bin\Debug\net7.0\`. |
| Kata 06 Events File Searcher | [Standard .NET event patterns](https://learn.microsoft.com/en-us/dotnet/csharp/event-pattern) | Console | It isn't a tutorial, but it's based on the code shown on the official documentation. |
| Kata 07 EF Get Started | [Getting Started with EF Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli) | Console | When doing the migration and updating the database for the first time, it'll be created on `C:\Users\yourusername\AppData\Roaming\blogging.db` (you can also type `%AppData%` on the File Explorer search bar and it'll redirect you to the same folder). Use [SQLiteStudio](https://www.sqlitestudio.pl/) or [DB Browser for SQLite](https://sqlitebrowser.org/) to check and see the database. |

## Additional Notes

* C# code is formatted with [CSharpier](https://csharpier.com/) command line tool (`.csharpierignore` file included on the repository).
* XAML code is formatted with [XamlStyler](https://github.com/Xavalon/XamlStyler) command line tool.