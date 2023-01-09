namespace Kata04GenerateConsumeAsyncStream;

internal class ProgressStatus : IProgress<int>
{
    Action<int> _action;

    public ProgressStatus(Action<int> action) => _action = action;

    public void Report(int value) => _action(value);
}
