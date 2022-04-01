using FileStatistics.Interfaces;
using System.Text;

namespace FileStatistics.Impl.AnsiFileWordCounter
{
    internal class AnsiFileWordCountAnalyzer : IFileAnalyzer
    {
        private readonly string _fileName;

        public AnsiFileWordCountAnalyzer(string fileName)
        {
            _fileName = fileName;
        }

        public async Task<IFileStatistics> Analyze()
        {            
            var stats = new AnsiFileWordCountStatistics();
            if (string.IsNullOrEmpty(_fileName))
            {
                stats.Summary.Append("File name is not provided!");
                stats.AnalysisResult = AnalysisResult.ErrorFileNameIsEmptyOrNull;
                return stats;
            }

            if(!File.Exists(_fileName))
            {
                stats.AnalysisResult = AnalysisResult.ErrorFileNotFound;
                stats.Summary.Append($"File {_fileName} doesn't exists!");
                return stats;
            }

            await using var sourceStream =
                new FileStream(
                    _fileName,
                    FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize: 4096, useAsync: true
                );

            var sb = new StringBuilder();
                        
            byte[] buffer = new byte[0x1000];
            int numRead;
            
            while ((numRead = await sourceStream.ReadAsync(buffer)) != 0)
            {
                for(int i = 0; i<numRead; i++)
                {
                    var symb = (char)buffer[i];


                    if(char.IsWhiteSpace(symb) || char.IsSeparator(symb) || (char.IsPunctuation(symb)&&(symb!=':')))
                    {
                        
                        var curWord = sb.ToString();
                        if (string.IsNullOrEmpty(curWord))
                            continue;

                        stats[curWord] += 1;
                        sb.Clear();
                    }
                    else
                        sb.Append(symb);                    
                }                
            }

            if (sb.Length > 0)
            {                
                stats[sb.ToString()] += 1;
            }

            return stats;
        }
    }
}
