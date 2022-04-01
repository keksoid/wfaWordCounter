using System.Text;
using FileStatistics.Interfaces;

namespace FileStatistics.Impl;

/// <summary>
/// Base IFileStatistics implementation
/// </summary>
internal class FileStatistics : IFileStatistics
{
    #region Public members
        
    /// <summary>
    /// Contains all information, collected during analysis
    /// </summary>
    /// <remarks>Availble to all FileAnalyzers</remarks>
    public StringBuilder Summary { get; } = new StringBuilder();
    

    #region IFileStatistics implementation
    public string GetSummary()
    {
        return Summary.ToString();
    }

    public AnalysisResult AnalysisResult { get; set; }
    #endregion
    #endregion
}