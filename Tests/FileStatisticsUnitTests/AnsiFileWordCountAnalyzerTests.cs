using FileStatistics.Impl.AnsiFileWordCounter;
using FileStatistics.Interfaces.AnsiFileWordCounter;
using System.Threading.Tasks;
using Xunit;

namespace FileStatisticsUnitTests
{
    public class AnsiFileWordCountAnalyzerTests
    {
        [Fact]        
        public void AnsiFileWordCountAnalyzerFactoryAlwaysNotNullWhenCreated()
        {
            var factory = new AnsiFileWordCountAnalyzerFactory();
            Assert.NotNull(factory);
        }

        [Fact]        
        public void AnsiFileWordCountAnalyzerAlwaysNotNullWhenCreated()
        {
            var factory = new AnsiFileWordCountAnalyzerFactory();
            var fileAnalyzer = factory.GetAnalyzer(string.Empty);
            Assert.NotNull(fileAnalyzer);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]        
        public async Task FileNameIsEmptyOrNull(string fileName)
        {
            var factory = new AnsiFileWordCountAnalyzerFactory();
            var fileAnalyzer = factory.GetAnalyzer(fileName);
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
            var fileAnalyzer = factory.GetAnalyzer(fileName);
            var stat = await fileAnalyzer.Analyze();   
            
            Assert.Equal(FileStatistics.Interfaces.AnalysisResult.ErrorFileNotFound, stat.AnalysisResult);
        }

        [Theory]
        [InlineData(@"Resources\Sample.txt", "filii", 6)]       
        [InlineData(@"Resources\Sample.txt", "Gomer", 2)]       
        [InlineData(@"Resources\Sample.txt", "1:7", 1)]       
        [InlineData(@"Resources\Sample.txt", "autem", 3)]       
        [InlineData(@"Resources\Sample.txt", "et", 24)]       
        public async Task WordCountStatisticsTestSuccess(string fileName, string word, int expectedWordCount)
        {
            var factory = new AnsiFileWordCountAnalyzerFactory();
            var fileAnalyzer = factory.GetAnalyzer(fileName);
            var stat = await fileAnalyzer.Analyze() as IAnsiFileWordCountStatistics;

            Assert.True(stat != null);
            Assert.Equal(FileStatistics.Interfaces.AnalysisResult.Complete, stat?.AnalysisResult);            
            Assert.Equal(expectedWordCount, stat?[word]);            
        }
        
        [Theory]
        [InlineData(@"Resources\Sample.txt", 91)]        
        [InlineData(@"Resources\Sample2.txt", 21)]        
        [InlineData(@"Resources\Sample3.txt", 70)]        
        public async Task AllWordCountTest(string fileName, int expectedWordCount)
        {
            var factory = new AnsiFileWordCountAnalyzerFactory();
            var fileAnalyzer = factory.GetAnalyzer(fileName);
            var stat = await fileAnalyzer.Analyze() as IAnsiFileWordCountStatistics;

            Assert.True(stat != null);
            Assert.Equal(FileStatistics.Interfaces.AnalysisResult.Complete, stat?.AnalysisResult);            
            Assert.Equal(expectedWordCount, stat?.Count);
        }
    }
}