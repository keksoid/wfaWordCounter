namespace wfaWordCounter
{
    partial class WordCountStatView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lvWordCount = new System.Windows.Forms.ListView();
            this.colWord = new System.Windows.Forms.ColumnHeader();
            this.colWordCount = new System.Windows.Forms.ColumnHeader();
            this.lblAllWordCount = new System.Windows.Forms.Label();
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msiAnalyzeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.msiExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pbAnaysis = new System.Windows.Forms.ProgressBar();
            this.btnCancelAnalysis = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.msMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Controls.Add(this.lvWordCount, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAllWordCount, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbAnaysis, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelAnalysis, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(704, 362);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lvWordCount
            // 
            this.lvWordCount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colWord,
            this.colWordCount});
            this.tableLayoutPanel1.SetColumnSpan(this.lvWordCount, 3);
            this.lvWordCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWordCount.Location = new System.Drawing.Point(3, 3);
            this.lvWordCount.Name = "lvWordCount";
            this.lvWordCount.Size = new System.Drawing.Size(698, 326);
            this.lvWordCount.TabIndex = 0;
            this.lvWordCount.UseCompatibleStateImageBehavior = false;
            this.lvWordCount.View = System.Windows.Forms.View.Details;
            this.lvWordCount.VirtualMode = true;
            this.lvWordCount.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvWordCount_ColumnClick);
            this.lvWordCount.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvWordCount_RetrieveVirtualItem);
            // 
            // colWord
            // 
            this.colWord.Text = "Word";
            this.colWord.Width = 150;
            // 
            // colWordCount
            // 
            this.colWordCount.Text = "Occurrence";
            this.colWordCount.Width = 640;
            // 
            // lblAllWordCount
            // 
            this.lblAllWordCount.AutoSize = true;
            this.lblAllWordCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAllWordCount.Location = new System.Drawing.Point(3, 332);
            this.lblAllWordCount.Name = "lblAllWordCount";
            this.lblAllWordCount.Size = new System.Drawing.Size(144, 30);
            this.lblAllWordCount.TabIndex = 2;
            this.lblAllWordCount.Text = "All word count:";
            this.lblAllWordCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(704, 24);
            this.msMainMenu.TabIndex = 3;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiAnalyzeFile,
            this.msiExitApp});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // msiAnalyzeFile
            // 
            this.msiAnalyzeFile.Name = "msiAnalyzeFile";
            this.msiAnalyzeFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.msiAnalyzeFile.Size = new System.Drawing.Size(230, 22);
            this.msiAnalyzeFile.Text = "Open file to analyze...";
            this.msiAnalyzeFile.Click += new System.EventHandler(this.msiAnalyzeFile_Click);
            // 
            // msiExitApp
            // 
            this.msiExitApp.Name = "msiExitApp";
            this.msiExitApp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.msiExitApp.Size = new System.Drawing.Size(230, 22);
            this.msiExitApp.Text = "Exit";
            this.msiExitApp.Click += new System.EventHandler(this.msiExitApp_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Ansi text files(*.txt)|*.txt";
            this.openFileDialog.InitialDirectory = "C:\\";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.ShowReadOnly = true;
            // 
            // pbAnaysis
            // 
            this.pbAnaysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAnaysis.Location = new System.Drawing.Point(153, 335);
            this.pbAnaysis.Name = "pbAnaysis";
            this.pbAnaysis.Size = new System.Drawing.Size(428, 24);
            this.pbAnaysis.TabIndex = 3;
            this.pbAnaysis.Visible = false;
            // 
            // btnCancelAnalysis
            // 
            this.btnCancelAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelAnalysis.Location = new System.Drawing.Point(587, 335);
            this.btnCancelAnalysis.Name = "btnCancelAnalysis";
            this.btnCancelAnalysis.Size = new System.Drawing.Size(114, 24);
            this.btnCancelAnalysis.TabIndex = 4;
            this.btnCancelAnalysis.Text = "Cancel";
            this.btnCancelAnalysis.UseVisualStyleBackColor = true;
            this.btnCancelAnalysis.Visible = false;
            this.btnCancelAnalysis.Click += new System.EventHandler(this.btnCancelAnalysis_Click);
            // 
            // WordCountStatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 386);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "WordCountStatView";
            this.Text = "WordCounter";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private ListView lvWordCount;
        private ColumnHeader colWord;
        private ColumnHeader colWordCount;
        private MenuStrip msMainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem msiAnalyzeFile;
        private ToolStripMenuItem msiExitApp;
        private OpenFileDialog openFileDialog;
        private Label lblAllWordCount;
        private ProgressBar pbAnaysis;
        private Button btnCancelAnalysis;
    }
}