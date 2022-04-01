using FileStatistics.Impl.AnsiFileWordCounter;
using FileStatistics.Interfaces;

namespace FileStatistics.API;

/// <summary>
/// Builder factory for word occurrence analyzer in ansi-encoded text files
/// </summary>
public class AnsiFileWordCountAnalyzerFactory : IFileAnalyzerFactory
{
    #region IFileAnalyzerFactory implementation    
    /// <summary>
    /// Returns word occurrence analyzer in ansi-encoded text files
    /// </summary>
    /// <param name="fullFilePath">Full path to file to analyze</param>
    /// <returns></returns>
    public IFileAnalyzer GetAnalyzer(string fullFilePath)
    {
        return new AnsiFileWordCountAnalyzer(fullFilePath);
    }
    #endregion
}