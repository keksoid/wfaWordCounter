using System.Text;
using FileStatistics.Interfaces;

namespace FileStatistics.Impl;

internal class FileStatistics : IFileStatistics
{
    public StringBuilder Summary { get; } = new StringBuilder();

    

    #region IFileStatistics implementation
    public string GetSummary()
    {
        return Summary.ToString();
    }

    public AnalysisResult AnalysisResult { get; set; }
    #endregion
}