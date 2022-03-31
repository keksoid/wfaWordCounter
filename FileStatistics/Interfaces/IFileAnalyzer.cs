namespace FileStatistics.Interfaces;

public interface IFileAnalyzer
{
    Task<IFileStatistics> Analyze();
}