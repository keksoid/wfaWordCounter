namespace FileStatistics.Interfaces;

public interface IFileAnalyzerFactory
{
    IFileAnalyzer GetAnalyzer(string fileName);
}