namespace FileStatistics.Interfaces;

/// <summary>
/// Base interface for collected file statistics
/// </summary>
public interface IFileStatistics
{
    /// <summary>
    /// Result of analysis
    /// </summary>
    AnalysisResult AnalysisResult { get; }

    /// <summary>
    /// Summary info collected during analysis
    /// </summary>
    /// <returns></returns>
    string GetSummary();
}