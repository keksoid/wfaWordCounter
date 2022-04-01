using FileStatistics.Impl.AnsiFileWordCounter;
using FileStatistics.Interfaces;

namespace FileStatistics.API;

public class AnsiFileWordCountAnalyzerFactory : IFileAnalyzerFactory
{
    public IFileAnalyzer GetAnalyzer(string fileName)
    {
        return new AnsiFileWordCountAnalyzer(fileName);
    }
}