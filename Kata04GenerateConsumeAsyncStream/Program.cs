using Kata04GenerateConsumeAsyncStream;
using System.Runtime.CompilerServices;

CancellationTokenSource cts = new();

IProgress<int> progressReporter = new ProgressStatus(
    (value) => Console.WriteLine($"Received {value} numbers in total.")
);

try
{
    Console.WriteLine("####### Consume sync stream #######");

    await Task.Delay(2000);

    foreach (int number in await GenerateSyncStream(cts.Token, progressReporter))
    {
        Console.WriteLine(number);
    }
}
catch (OperationCanceledException)
{
    Console.WriteLine("Work has been cancelled.");
}

Console.WriteLine("####### Consume async stream #######");

await Task.Delay(2000);

var numbersCount = 0;
await foreach (int number in GenerateAsyncStream())
{
    Console.WriteLine(number);
    Console.WriteLine($"Received {++numbersCount} numbers in total.");
}

Console.WriteLine("####### Consume async stream with cancellation token #######");

await Task.Delay(2000);

numbersCount = 0;
await foreach (int number in GenerateAsyncStream().WithCancellation(cts.Token))
{
    Console.WriteLine(number);
    Console.WriteLine($"Received {++numbersCount} numbers in total.");
}

static async Task<List<int>> GenerateNext2500Numbers(int seed, CancellationToken cancel)
{
    List<int> numbers = new();
    for (int i = seed; i < seed + 2500; i++)
    {
        numbers.Add(i);
    }

    await Task.Delay(1000, cancel);

    return numbers;
}

static async Task<List<int>> GenerateSyncStream(CancellationToken cancel, IProgress<int> progress)
{
    List<int> numbers = new();

    for (var i = 0; i < 10; i++)
    {
        numbers.AddRange(await GenerateNext2500Numbers(numbers.Count, cancel));
        progress.Report(numbers.Count);
        cancel.ThrowIfCancellationRequested();
    }

    return numbers;
}

static async IAsyncEnumerable<int> GenerateAsyncStream(
    [EnumeratorCancellation] CancellationToken cancel = default
)
{
    for (int i = 0, j = 0; i < 10; i++)
    {
        List<int> numbers = await GenerateNext2500Numbers(j, cancel);

        j += numbers.Count;

        foreach (int number in numbers)
        {
            yield return number;
        }
    }
}
