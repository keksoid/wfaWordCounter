using FileStatistics.API;
using FileStatistics.Interfaces;
using FileStatistics.Interfaces.AnsiFileWordCounter;
using System.ComponentModel.Design;

namespace wfaWordCounter
{
    public partial class WordCountStatView : Form
    {
        #region Private methods
        /// <summary>
        /// Global services for analisys
        /// </summary>
        private readonly ServiceContainer _analysisServices = new();        
        
        /// <summary>
        /// Cache with listview items for list view with analysis data sorted by current sort settings
        /// </summary>
        private readonly List<ListViewItem> _viewItemsCache = new();

        /// <summary>
        /// Index of fixed column in lv with Word data
        /// </summary>
        private const int WordColIdx = 0;
        
        /// <summary>
        /// Index of fixed column in lv with WordCount data
        /// </summary>
        private const int WordCountColIdx = 1;

        #region Sort settings in listview       
        /// <summary>
        /// Current sort column index
        /// </summary>
        private int _sortColIdx = WordCountColIdx;

        /// <summary>
        /// Current sort direction
        /// </summary>        
        private SortOrder _sortDir = SortOrder.Descending;
        #endregion

        private const string FormCaption = "WordCounter";

        /// <summary>
        /// Token source to cancel current task
        /// </summary>
        private CancellationTokenSource? _ctsStopCurrentTask;

        /// <summary>
        /// Initialize all global services
        /// </summary>
        private void InitServices()
        {
            //register AnsiFileWordCountAnalyzerFactory service
            _analysisServices.AddService(typeof(IFileAnalyzerFactory), new AnsiFileWordCountAnalyzerFactory());
        }

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
                case WordColIdx: 
                    if(_sortDir == SortOrder.Ascending)
                        return string.Compare(leftWord.Text, rightWord.Text, StringComparison.CurrentCulture);
                    else
                        return string.Compare(rightWord.Text, leftWord.Text, StringComparison.CurrentCulture);

                case WordCountColIdx:
                    if(!int.TryParse(leftWord.SubItems[WordCountColIdx].Text, out var leftWordCount))
                        leftWordCount = 0;
                    
                    if(!int.TryParse(rightWord.SubItems[WordCountColIdx].Text, out var rightWordCount))
                        rightWordCount = 0;

                    return _sortDir == SortOrder.Ascending ? leftWordCount - rightWordCount : rightWordCount - leftWordCount;    
                    
                default: 
                    return 0;
            }
        }        
        
        /// <summary>
        /// Configure controls state depending on current analysis state
        /// </summary>
        /// <param name="analysisInProgress">Is analysis in progress</param>
        private void UpdateControls(bool analysisInProgress)
        {
            //can't start new analysis if analisys in progress
            msiAnalyzeFile.Enabled = !analysisInProgress;

            //can't exit app without stopping current analisys
            msiExitApp.Enabled = !analysisInProgress;

            //make progress bar and cancel analysis button visible if analisys in progress 
            pbAnaysis.Visible = analysisInProgress;            

            btnCancelAnalysis.Visible = analysisInProgress;
            btnCancelAnalysis.Enabled = analysisInProgress;
        }

        /// <summary>
        /// Call back from analysis to show it's progress
        /// </summary>
        /// <param name="status"></param>
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
        /// Fill virtual cache for lvWordCount with provided statistics
        /// </summary>
        /// <param name="stat">Statistics from analyzed file</param>
        private void FillLVWord(IAnsiFileWordCountStatistics stat)
        {
            //clear current virtual cache data
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

                //reset sort settings to values, according functional requirements
                _sortColIdx = 1;
                _sortDir = SortOrder.Descending;

                //sort cache with actual settings
                _viewItemsCache.Sort(CompareWordStats);

                //fill lv from cache
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

            var fullFilePath = openFileDialog.FileName;

            UpdateControls(true);
            
            //get factory for file analyzer from global registered services cache
            if (_analysisServices.GetService(typeof(IFileAnalyzerFactory)) is not IFileAnalyzerFactory factory)
                return;

            var fileAnalyzer = factory.GetAnalyzer(fullFilePath);

            _ctsStopCurrentTask = new CancellationTokenSource();
            try
            {
                //starting analysis
                var analyzeTask = fileAnalyzer.AnalyzeAsync(_ctsStopCurrentTask.Token, new Progress<AnalysisStatus>(OnAnalisysProgress));
                if (await analyzeTask is not IAnsiFileWordCountStatistics stat)
                    return;

                //refilling with new data, only if succfully awaited it, otherwise, previous statistics still available in listview
                FillLVWord(stat);
                
                lblAllWordCount.Text = $"All word Count: {stat.Count}";

                this.Text = $"{FormCaption}: {Path.GetFileName(fullFilePath)}";
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
            //filling lv item from virtual cache
            if (e.ItemIndex >= 0 && e.ItemIndex < _viewItemsCache.Count)
                e.Item = _viewItemsCache[e.ItemIndex];
            else
                e.Item = null;
        }

        //sorting listview on column click
        private void lvWordCount_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //reverse sort order if click's been done on the same column
            if (e.Column == _sortColIdx)
                _sortDir = _sortDir == SortOrder.Ascending? SortOrder.Descending : SortOrder.Ascending;
            else//or just change sort column ids
                _sortColIdx = _sortColIdx == WordColIdx ? WordCountColIdx : WordColIdx;

            //reorder items in virtual cache 
            _viewItemsCache.Sort(CompareWordStats);

            //then repaint listview
            lvWordCount.Refresh();
        }

        private void msiExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCancelAnalysis_Click(object sender, EventArgs e)
        {
            if (_ctsStopCurrentTask == null)
                return;

            if (MessageBox.Show("Do you want to stop current analysis?", "WorkCounter", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _ctsStopCurrentTask.Cancel();
            }
        }

        private void WordCountStatView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_ctsStopCurrentTask == null)
                return;

            if (MessageBox.Show("Do you want to stop current analysis and exit application?", "WorkCounter", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _ctsStopCurrentTask.Cancel();
            }
            else
                e.Cancel = true;
        }
        #endregion
        #endregion

        #region Public methods

        public WordCountStatView()
        {
            InitializeComponent();
            InitServices();
        }        
        #endregion
    }
}