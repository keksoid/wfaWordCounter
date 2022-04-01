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
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msiAnalyzeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.msiExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblAllWordCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.msMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.33673F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.66327F));
            this.tableLayoutPanel1.Controls.Add(this.lvWordCount, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAllWordCount, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.66391F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.336088F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 363);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lvWordCount
            // 
            this.lvWordCount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colWord,
            this.colWordCount});
            this.tableLayoutPanel1.SetColumnSpan(this.lvWordCount, 2);
            this.lvWordCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWordCount.Location = new System.Drawing.Point(3, 3);
            this.lvWordCount.Name = "lvWordCount";
            this.lvWordCount.Size = new System.Drawing.Size(778, 334);
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
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(784, 24);
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
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Ansi text files(*.txt)|*.txt";
            this.openFileDialog.InitialDirectory = "C:\\";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.ShowReadOnly = true;
            // 
            // lblAllWordCount
            // 
            this.lblAllWordCount.AutoSize = true;
            this.lblAllWordCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAllWordCount.Location = new System.Drawing.Point(3, 340);
            this.lblAllWordCount.Name = "lblAllWordCount";
            this.lblAllWordCount.Size = new System.Drawing.Size(223, 23);
            this.lblAllWordCount.TabIndex = 2;
            this.lblAllWordCount.Text = "All word count:";
            this.lblAllWordCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WordCountStatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 387);
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
    }
}