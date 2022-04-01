namespace FileStatistics.Interfaces.AnsiFileWordCounter;

/// <summary>
/// Interface for word statistics from ansi text file
/// </summary>
public interface IAnsiFileWordCountStatistics : IFileStatistics
{
    /// <summary>
    /// All unique words found in file
    /// </summary>
    IEnumerable<string> Words { get; }

    /// <summary>
    /// Collected word occurrence in file
    /// </summary>
    /// <param name="word"></param>
    /// <returns>Word occurrence in file</returns>
    int this[string word] { get; }

    /// <summary>
    /// Unique Word count found in file
    /// </summary>
    int Count { get; }
}