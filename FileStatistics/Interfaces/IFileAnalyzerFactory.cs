namespace FileStatistics.Interfaces;

public interface IFileAnalyzerFactory
{
    IFileAnalyzer GetAnalizer(string fileName);
}