using FileStatistics.Interfaces;

namespace FileStatistics.Impl.AnsiFileWordCounter;

public class AnsiFileWordCountAnalyzerFactory : IFileAnalyzerFactory
{
    public IFileAnalyzer GetAnalyzer(string fileName)
    {
        return new AnsiFileWordCountAnalyzer(fileName);
    }
}