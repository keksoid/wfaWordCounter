using FileStatistics.Impl.AnsiFileWordCounter;
using FileStatistics.Interfaces.AnsiFileWordCounter;
using System.Threading.Tasks;
using Xunit;

namespace FileStatisticsUnitTests
{
    public class AnsiFileWordCountAnalyzerTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]        
        public async Task FileNameIsEmptyOrNull(string fileName)
        {
            var factory = new AnsiFileWordCountAnalyzerFactory();
            var fileAnalyzer = factory.GetAnalizer(fileName);
            var stat = await fileAnalyzer.Analyze();            

            Assert.Equal(FileStatistics.Interfaces.AnalysisResult.ErrorFileNameIsEmptyOrNull, stat.AnalysisResult);
        }
        
        [Theory]
        [InlineData("path1")]
        [InlineData("asdfasd")]
        [InlineData("fvsbtf")]
        public async Task FileNotFoundTest(string fileName)
        {
            var factory = new AnsiFileWordCountAnalyzerFactory();
            var fileAnalyzer = factory.GetAnalizer(fileName);
            var stat = await fileAnalyzer.Analyze();   
            
            Assert.Equal(FileStatistics.Interfaces.AnalysisResult.ErrorFileNotFound, stat.AnalysisResult);
        }

        [Theory]
        [InlineData(@"Resources\Sample.txt")]       
        public async Task SampleTestSuccess(string fileName)
        {
            var factory = new AnsiFileWordCountAnalyzerFactory();
            var fileAnalyzer = factory.GetAnalizer(fileName);
            var stat = await fileAnalyzer.Analyze() as IAnsiFileWordCountStatistics;

            Assert.True(stat != null);
            Assert.Equal(FileStatistics.Interfaces.AnalysisResult.Complete, stat.AnalysisResult);            
            Assert.Equal(6, stat["filii"]);
            Assert.Equal(2, stat["Gomer"]);
            Assert.Equal(1, stat["1:7"]);
            Assert.Equal(3, stat["autem"]);
            Assert.Equal(24, stat["et"]);
        }
        
        [Theory]
        [InlineData(@"Resources\Sample.txt", 91)]        
        [InlineData(@"Resources\Sample2.txt", 21)]        
        [InlineData(@"Resources\Sample3.txt", 70)]        
        public async Task WordCountTest(string fileName, int wordCount)
        {
            var factory = new AnsiFileWordCountAnalyzerFactory();
            var fileAnalyzer = factory.GetAnalizer(fileName);
            var stat = await fileAnalyzer.Analyze() as IAnsiFileWordCountStatistics;

            Assert.True(stat != null);
            Assert.Equal(FileStatistics.Interfaces.AnalysisResult.Complete, stat.AnalysisResult);            
            Assert.Equal(wordCount, stat.Count);
        }
    }
}