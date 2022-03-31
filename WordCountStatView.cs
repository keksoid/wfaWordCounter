using FileStatistics.Impl.AnsiFileWordCounter;

namespace wfaWordCounter
{
    public partial class WordCountStatView : Form
    {
        public WordCountStatView()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var factory = new AnsiFileWordCountAnalyzerFactory();
            var fileAnalyzer = factory.GetAnalizer("test.txt");
            var stat = await fileAnalyzer.Analize();
            label1.Text = stat.GetSummary();
        }
    }
}