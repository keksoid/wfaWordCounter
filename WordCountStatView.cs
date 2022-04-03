using FileStatistics.API;
using FileStatistics.Interfaces;
using FileStatistics.Interfaces.AnsiFileWordCounter;

namespace wfaWordCounter
{
    public partial class WordCountStatView : Form
    {
        #region Private methods
        
        private readonly List<ListViewItem> _viewItemsCache = new();

        /// <summary>
        /// Current sort column index
        /// </summary>
        private int _sortColIdx = 1;

        /// <summary>
        /// Current sort direction
        /// </summary>        
        private SortOrder _sortDir = SortOrder.Descending;

        /// <summary>
        /// Token source to cancel current task
        /// </summary>
        private CancellationTokenSource? _ctsStopCurrentTask;

        /// <summary>
        /// Ordering call back for list view item with words statistics in it
        /// </summary>
        /// <remarks>Ordering process depends on current values of _sortColIdx and _sortDir</remarks>
        /// <param name="leftWord">Left word to compare</param>
        /// <param name="rightWord">Right word to compare</param>
        /// <returns></returns>
        private int CompareWordStats(ListViewItem leftWord, ListViewItem rightWord)
        {
            switch (_sortColIdx)
            {
                case 0: 
                    if(_sortDir == SortOrder.Ascending)
                        return string.Compare(leftWord.Text, rightWord.Text, StringComparison.CurrentCulture);
                    else
                        return string.Compare(rightWord.Text, leftWord.Text, StringComparison.CurrentCulture);
                case 1:
                    if (_sortDir == SortOrder.Ascending)
                        return int.Parse(leftWord.SubItems[1].Text) - int.Parse(rightWord.SubItems[1].Text);
                    else
                        return int.Parse(rightWord.SubItems[1].Text) - int.Parse(leftWord.SubItems[1].Text);
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

        /// <summary>
        /// Fill lvWordCount with provided statistics
        /// </summary>
        /// <param name="stat">Statistics from analyzed file</param>
        private void FillLVWord(IAnsiFileWordCountStatistics stat)
        {
            _viewItemsCache.Clear();
            _viewItemsCache.Capacity = stat.Count;

            lvWordCount.BeginUpdate();
            try
            {
                //clear current data
                lvWordCount.VirtualListSize = 0;

                foreach(var word in stat.Words)
                {
                    var lvItem = new ListViewItem(word);
                    lvItem.SubItems.Add(stat[word].ToString());
                    _viewItemsCache.Add(lvItem);
                }

                _viewItemsCache.Sort(CompareWordStats);

                lvWordCount.VirtualListSize = _viewItemsCache.Count;
            }
            finally
            {
                lvWordCount.EndUpdate();
            }
            lvWordCount.Refresh();
        }

        #region Processing UI Controls callbacks
        
        private async void msiAnalyzeFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            if(string.IsNullOrEmpty(openFileDialog.FileName)||(!File.Exists(openFileDialog.FileName)))
                return;

            UpdateControls(true);

            var factory = new AnsiFileWordCountAnalyzerFactory();
            var fileAnalyzer = factory.GetAnalyzer(openFileDialog.FileName);
            _ctsStopCurrentTask = new CancellationTokenSource();
            try
            {
                if (await fileAnalyzer.AnalyzeAsync(_ctsStopCurrentTask.Token, new Progress<AnalysisStatus>(OnAnalisysProgress)) is not IAnsiFileWordCountStatistics stat)
                    return;

                FillLVWord(stat);
                
                lblAllWordCount.Text = $"All word Count: {stat.Count}";                
            }
            catch (OperationCanceledException)
            {
                lblAllWordCount.Text = "Analysis was canceled";
            }
            finally
            {
                _ctsStopCurrentTask.Dispose();
                _ctsStopCurrentTask = null;
                
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
            _ctsStopCurrentTask?.Cancel();
        }

        private void WordCountStatView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_ctsStopCurrentTask != null)
            {
                if (MessageBox.Show("Do you want to stop current analysis and exit application?", "WorkCounter", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    _ctsStopCurrentTask.Cancel();
                }
                else
                    e.Cancel = true;
            }
        }
        #endregion
        #endregion

        #region Public methods

        public WordCountStatView()
        {
            InitializeComponent();
        }
        #endregion
    }
}