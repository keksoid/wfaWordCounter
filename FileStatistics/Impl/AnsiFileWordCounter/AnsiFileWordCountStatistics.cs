using System.Text;
using FileStatistics.Interfaces.AnsiFileWordCounter;

namespace FileStatistics.Impl.AnsiFileWordCounter
{
    /// <summary>
    /// Statistics class for word counter in ansi encoded files
    /// </summary>
    internal class AnsiFileWordCountStatistics : FileStatistics, IAnsiFileWordCountStatistics
    {
        #region Private members
        /// <summary>
        /// Container for words statitics
        /// </summary>
        /// <remarks>
        /// Key : word
        /// Value : word occurence in file
        /// </remarks>
        private readonly Dictionary<string, int> _words = new ();

        #endregion

        #region Public members
        public AnsiFileWordCountStatistics():base()
        {
            
        }             

        #region IAnsiFileWordCountStatistics implementation

        public IEnumerable<string> Words => _words.Keys;

        public int this[string word]
        {
            get
            {
                if (_words.TryGetValue(word, out var resValue))
                {
                    return resValue;
                }
                else
                { //if word doesn't exists in collection - valid value 0, no exception
                    return 0;
                }
            }
            set => _words[word] = value;
        }

        public int Count => _words.Count;

        #endregion

        #endregion
    }
}
