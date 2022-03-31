namespace FileStatistics.Interfaces;

public interface IFileStatistics
{
    AnalysisResult AnalysisResult { get; }

    string GetSummary();
}