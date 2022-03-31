using System.Text;
using FileStatistics.Interfaces.AnsiFileWordCounter;

namespace FileStatistics.Impl.AnsiFileWordCounter
{
    internal class AnsiFileWordCountStatistics : FileStatistics, IAnsiFileWordCountStatistics
    {
        #region Private members

        private readonly IDictionary<string, int> _words = new Dictionary<string, int>();

        #endregion

        #region Public members
        public AnsiFileWordCountStatistics():base()
        {
            this.Summary.Append("This is just a summary string");
        }             

        #region IAnsiFileWordCountStatistics

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
                {
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
