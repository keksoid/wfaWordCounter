using FileStatistics.API;
using FileStatistics.Interfaces;
using FileStatistics.Interfaces.AnsiFileWordCounter;

namespace wfaWordCounter
{
    public partial class WordCountStatView : Form
    {
        private readonly List<ListViewItem> _viewItemsCache = new();

        private int _sortColIdx = 1;
        private SortOrder _sortDir = SortOrder.Descending;
        private CancellationTokenSource? _ctsStopAnalisys;

        private int CompareWordStats(ListViewItem left, ListViewItem right)
        {
            switch (_sortColIdx)
            {
                case 0: 
                    if(_sortDir == SortOrder.Ascending)
                        return string.Compare(left.Text, right.Text, StringComparison.CurrentCulture);
                    else
                        return string.Compare(right.Text, left.Text, StringComparison.CurrentCulture);
                case 1:
                    if (_sortDir == SortOrder.Ascending)
                        return int.Parse(left.SubItems[1].Text) - int.Parse(right.SubItems[1].Text);
                    else
                        return int.Parse(right.SubItems[1].Text) - int.Parse(left.SubItems[1].Text);
                default: 
                    return 0;
            }
        }        
        
        private void UpdateControls(bool analysisInProgress)
        {
            msiAnalyzeFile.Enabled = !analysisInProgress;
            msiExitApp.Enabled = !analysisInProgress;

            pbAnaysis.Visible = analysisInProgress;
            pbAnaysis.Enabled = analysisInProgress;

            btnCancelAnalysis.Visible = analysisInProgress;
            btnCancelAnalysis.Enabled = analysisInProgress;
        }

        private void OnAnalisysProgress(AnalysisStatus status)
        {
            //that mean's we need to setup progress bar
            if (status.CompleteStatus == 0)
            {
                pbAnaysis.Minimum = 0;
                pbAnaysis.Maximum = status.StepsCount;
                pbAnaysis.Step = 1;
                pbAnaysis.Value = 0;
                pbAnaysis.Visible = true;
                pbAnaysis.Enabled = true;
            }
            else
                pbAnaysis.PerformStep();
        }

        private async void msiAnalyzeFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            if(string.IsNullOrEmpty(openFileDialog.FileName)||(!File.Exists(openFileDialog.FileName)))
                return;

            UpdateControls(true);

            var factory = new AnsiFileWordCountAnalyzerFactory();
            var fileAnalyzer = factory.GetAnalyzer(openFileDialog.FileName);
            _ctsStopAnalisys = new CancellationTokenSource();
            try
            {
                if (await fileAnalyzer.AnalyzeAsync(_ctsStopAnalisys.Token, new Progress<AnalysisStatus>(OnAnalisysProgress)) is not IAnsiFileWordCountStatistics stat)
                    return;            

                _viewItemsCache.Clear();
                _viewItemsCache.Capacity = stat.Count;
                lvWordCount.VirtualListSize = 0;

                lblAllWordCount.Text = $"All word Count: {stat.Count}";
                stat.Words.ToList().ForEach(
                    word =>
                    {
                        var lvItem = new ListViewItem(word);
                        lvItem.SubItems.Add(stat[word].ToString());
                        _viewItemsCache.Add(lvItem);
                    });

                _viewItemsCache.Sort(CompareWordStats);

                lvWordCount.VirtualListSize = _viewItemsCache.Count;
                lvWordCount.Refresh();
            }
            catch (OperationCanceledException)
            {
                lblAllWordCount.Text = "Analysis was canceled";
            }
            finally
            {
                _ctsStopAnalisys.Dispose();
                _ctsStopAnalisys = null;
                
                UpdateControls(false);
            }
        }        

        private void lvWordCount_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex >= 0 && e.ItemIndex < _viewItemsCache.Count)
                e.Item = _viewItemsCache[e.ItemIndex];
            else
                e.Item = null;
        }

        private void lvWordCount_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _sortColIdx)
                _sortDir = _sortDir == SortOrder.Ascending? SortOrder.Descending : SortOrder.Ascending;
            else
                _sortColIdx = _sortColIdx == 0 ? 1 : 0;

            _viewItemsCache.Sort(CompareWordStats);
            lvWordCount.Refresh();
        }

        private void msiExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCancelAnalysis_Click(object sender, EventArgs e)
        {
            _ctsStopAnalisys?.Cancel();
        }

        public WordCountStatView()
        {
            InitializeComponent();
        }
    }
}