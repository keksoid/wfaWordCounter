namespace FileStatistics.Interfaces;

/// <summary>
/// Base interface for file analyzers
/// </summary>
public interface IFileAnalyzer
{
    /// <summary>
    /// Analyze file asyncronously
    /// </summary>
    /// <remarks>File provided by a special factory of specified FileAnalyzer</remarks>
    /// <returns>task of analysis that can be awaited</returns>
    Task<IFileStatistics> AnalyzeAsync();
}