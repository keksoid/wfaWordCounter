namespace FileStatistics.Interfaces.AnsiFileWordCounter;

public interface IAnsiFileWordCountStatistics : IFileStatistics
{
    IEnumerable<string> Words { get; }

    int this[string word] { get; }

    int Count { get; }
}