using static System.Math;

namespace Kata01Teleprompter;

class Teleprompter
{
    public async Task Run()
    {
        var config = new Config();

        await Task.WhenAny(Show(config), ReadUserInput(config));
    }

    async Task Show(Config config)
    {
        foreach (string word in ReadWords())
        {
            Console.Write(word);
            if (!string.IsNullOrEmpty(word))
            {
                await Task.Delay(config.Delay);
            }
        }

        config.SetDone();
    }

    IEnumerable<string> ReadWords()
    {
        using StreamReader reader = File.OpenText("sampleQuotes.txt");
        string? line;
        while ((line = reader.ReadLine()) is not null)
        {
            int charCount = 0;
            string[] words = line.Split(' ');
            foreach (string word in words)
            {
                charCount += word.Length;
                if (charCount > 80)
                {
                    charCount = 0;

                    yield return Environment.NewLine;
                }

                yield return word + " ";
            }

            yield return Environment.NewLine;
        }
    }

    async Task ReadUserInput(Config config) =>
        await Task.Run(() =>
        {
            do
            {
                ConsoleKeyInfo readKey = Console.ReadKey(true);
                if (readKey.KeyChar == '>')
                {
                    config.UpdateDelay(-10);
                }
                else if (readKey.KeyChar == '<')
                {
                    config.UpdateDelay(10);
                }
                else if (readKey.KeyChar == 'X' || readKey.KeyChar == 'x')
                {
                    config.SetDone();
                }
            } while (!config.Done);
        });

    class Config
    {
        object _lockHandler = new object();
        public int Delay { get; private set; } = 200;

        public void UpdateDelay(int increment)
        {
            int newDelay = Min(1000, Delay + increment);
            newDelay = Max(20, newDelay);

            lock (_lockHandler)
            {
                Delay = newDelay;
            }
        }

        public bool Done { get; private set; } = false;

        public void SetDone() => Done = true;
    }
}
