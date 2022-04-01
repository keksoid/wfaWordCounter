using FileStatistics.Interfaces;
using System.Text;

namespace FileStatistics.Impl.AnsiFileWordCounter
{
    /// <summary>
    /// Counts word occurrency in provided Ansi text file
    /// </summary>
    internal class AnsiFileWordCountAnalyzer : FileAnalyzer
    {
        #region Private members
        /// <summary>
        /// Current word builder
        /// </summary>
        private readonly StringBuilder _wordBuilder;

        /// <summary>
        /// Statistics for all words, found in file
        /// </summary>
        private readonly AnsiFileWordCountStatistics _stats;

        /// <summary>
        /// Checks if character is word separator
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool IsWordSeparator(char character)
        {
            return char.IsWhiteSpace(character) || 
                char.IsSeparator(character) || 
                (
                    char.IsPunctuation(character) && 
                    (character != ':')// it's punctuation char, but it's shouldn't be according functional requirenments
                );
        }

        #endregion

        #region Protected members
               
        protected override IFileStatistics GetFileStatistics()
        {            
            return _stats;
        }

        protected override ByteProcessingResult OnProcessNextByte(byte readByte)
        {
            //convert read byte to character
            var character = (char)readByte;

            //if we're on separator
            if (IsWordSeparator(character))
            {                
                //build current word
                var curWord = _wordBuilder.ToString();
               
                //update word occurrence statistics
                if(curWord.Length > 0)
                {
                    _stats[curWord] += 1;
                    _wordBuilder.Clear();
                }                   
            }
            else//append character to current word
                _wordBuilder.Append(character);

            return ByteProcessingResult.Continue;
        }
        #endregion

        #region Public Members        
        public AnsiFileWordCountAnalyzer(string fullFilePath) : base(fullFilePath)
        {
            _stats = new();
            _wordBuilder = new();
        }

        public override async Task<IFileStatistics> Analyze()
        {            
            _wordBuilder.Clear();
            
            await base.Analyze();

            //build the last word in file
            var curWord = _wordBuilder.ToString();
            if (curWord.Length > 0)
            {
                _stats[curWord.ToString()] += 1;
                _wordBuilder.Clear();
            }            
            return _stats;
        }
        #endregion
    }
}
