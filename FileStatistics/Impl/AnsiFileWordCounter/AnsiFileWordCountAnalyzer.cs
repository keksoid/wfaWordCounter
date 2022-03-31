using FileStatistics.Interfaces;

namespace FileStatistics.Impl.AnsiFileWordCounter
{
    internal class AnsiFileWordCountAnalyzer : IFileAnalyzer
    {
        private readonly string _fileName;

        public AnsiFileWordCountAnalyzer(string fileName)
        {
            _fileName = fileName;
        }

        public async Task<IFileStatistics> Analize()
        {
            var stats = new AnsiFileWordCountStatistics();

            return await Task.FromResult(stats);
        }
    }
}
