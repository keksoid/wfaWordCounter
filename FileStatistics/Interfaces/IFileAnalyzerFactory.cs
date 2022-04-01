namespace FileStatistics.Interfaces;

/// <summary>
/// Base interface for building FileAnalyzer
/// </summary>
/// <remarks>Look for specific implementor of this interface to create FileAnalyzer in FileStatistics.API namespace</remarks>
public interface IFileAnalyzerFactory
{
    /// <summary>
    /// Returns specific analyzer
    /// </summary>
    /// <param name="fullFilePath">Full path to file to analyze</param>
    /// <returns>Created or cached file analyzer</returns>
    IFileAnalyzer GetAnalyzer(string fullFilePath);
}