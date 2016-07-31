namespace MyDownloader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            MyLIB.Components.MyMcComboBox.MyItem myItem1 = new MyLIB.Components.MyMcComboBox.MyItem();
            MyLIB.Components.MyMcComboBox.MyItem myItem2 = new MyLIB.Components.MyMcComboBox.MyItem();
            MyLIB.Components.MyMcComboBox.MyItem myItem3 = new MyLIB.Components.MyMcComboBox.MyItem();
            MyLIB.Components.MyMcComboBox.MyItem myItem4 = new MyLIB.Components.MyMcComboBox.MyItem();
            MyLIB.Components.MyMcComboBox.MyItem myItem5 = new MyLIB.Components.MyMcComboBox.MyItem();
            MyLIB.Components.MyMcComboBox.MyItem myItem6 = new MyLIB.Components.MyMcComboBox.MyItem();
            MyLIB.Components.MyMcComboBox.MyItem myItem7 = new MyLIB.Components.MyMcComboBox.MyItem();
            MyLIB.Components.MyMcComboBox.MyItem myItem8 = new MyLIB.Components.MyMcComboBox.MyItem();
            MyLIB.Components.MyMcComboBox.MyItem myItem9 = new MyLIB.Components.MyMcComboBox.MyItem();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsPreQueue = new System.Windows.Forms.BindingSource(this.components);
            this.bsLog = new System.Windows.Forms.BindingSource(this.components);
            this.bsQueue = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.stTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.stSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.stProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.menuDgvQueue = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miQueueReset = new System.Windows.Forms.ToolStripMenuItem();
            this.miQueueRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miQueueEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.miQueueDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new MyLIB.Components.TabControlWithoutHeader();
            this.tpQueue = new System.Windows.Forms.TabPage();
            this.dgvQueue = new MyLIB.Components.MyDataGridView();
            this.dgcQueueFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcQueueStatus = new MyDownloader.MyLib.Components.DataGridViewColorMarkColumn();
            this.dgcQueueFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcQueueDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcQueuePerc = new MyLIB.Components.DataGridViewProgressColumn();
            this.dgcQueueSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcQueueETL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcQueueFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.tsbQueueStart = new System.Windows.Forms.ToolStripButton();
            this.tsbQueueStop = new System.Windows.Forms.ToolStripButton();
            this.tsbQueueRemove = new System.Windows.Forms.ToolStripButton();
            this.tsbQueueUp = new System.Windows.Forms.ToolStripButton();
            this.tsbQueueDown = new System.Windows.Forms.ToolStripButton();
            this.tsbQueueEnable = new System.Windows.Forms.ToolStripButton();
            this.tsbQueueDisable = new System.Windows.Forms.ToolStripButton();
            this.tsbReset = new System.Windows.Forms.ToolStripButton();
            this.tpPreQueue = new System.Windows.Forms.TabPage();
            this.dgvPreQueue = new MyLIB.Components.MyDataGridView();
            this.dgcPreQueueFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPreQueueFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPreQueueStatusText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcPewQueue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbPreQueueStartAll = new System.Windows.Forms.ToolStripButton();
            this.tsbStartSelected = new System.Windows.Forms.ToolStripButton();
            this.tsbPrequeueCheck = new System.Windows.Forms.ToolStripButton();
            this.tsbClearPreQueue = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteFromPrequeue = new System.Windows.Forms.ToolStripButton();
            this.tsbPreQueueSetFolder = new System.Windows.Forms.ToolStripButton();
            this.tsbPreQueueUp = new System.Windows.Forms.ToolStripButton();
            this.tsbPreQueueDown = new System.Windows.Forms.ToolStripButton();
            this.tpAdd = new System.Windows.Forms.TabPage();
            this.tbText = new System.Windows.Forms.TextBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsbGetClipboard = new System.Windows.Forms.ToolStripButton();
            this.tsbParse = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.cbFontSize = new MyLIB.Components.MyMcFlatComboBox();
            this.chShutdown = new System.Windows.Forms.CheckBox();
            this.btDownloadTo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDownloadTo = new MyLIB.Components.MyTextBox();
            this.tpLog = new System.Windows.Forms.TabPage();
            this.dgvLog = new MyLIB.Components.MyDataGridView();
            this.dgcLogTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcLogMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.someConfig1 = new MyDownloader.Classes.SomeConfig(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsPreQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQueue)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuDgvQueue.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.tpPreQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreQueue)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tpAdd.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.tpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // bsQueue
            // 
            this.bsQueue.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsQueue_ListChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stTotal,
            this.stLeft,
            this.stTime,
            this.stSpeed,
            this.stProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 441);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1035, 30);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stTotal
            // 
            this.stTotal.AutoSize = false;
            this.stTotal.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stTotal.Name = "stTotal";
            this.stTotal.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.stTotal.Size = new System.Drawing.Size(110, 25);
            this.stTotal.Text = "789.56mb";
            this.stTotal.ToolTipText = "Total bytes";
            // 
            // stLeft
            // 
            this.stLeft.AutoSize = false;
            this.stLeft.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stLeft.Name = "stLeft";
            this.stLeft.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.stLeft.Size = new System.Drawing.Size(110, 25);
            this.stLeft.Text = "789.56mb";
            this.stLeft.ToolTipText = "Left bytes";
            // 
            // stTime
            // 
            this.stTime.AutoSize = false;
            this.stTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stTime.Name = "stTime";
            this.stTime.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.stTime.Size = new System.Drawing.Size(110, 25);
            this.stTime.Text = "5d 23:46";
            this.stTime.ToolTipText = "Time remaining";
            // 
            // stSpeed
            // 
            this.stSpeed.AutoSize = false;
            this.stSpeed.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stSpeed.Name = "stSpeed";
            this.stSpeed.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.stSpeed.Size = new System.Drawing.Size(130, 25);
            this.stSpeed.Text = "789.56kb/s";
            this.stSpeed.ToolTipText = "Speed";
            // 
            // stProgress
            // 
            this.stProgress.Name = "stProgress";
            this.stProgress.Size = new System.Drawing.Size(100, 24);
            // 
            // menuDgvQueue
            // 
            this.menuDgvQueue.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.menuDgvQueue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miQueueReset,
            this.miQueueRemove,
            this.toolStripSeparator1,
            this.miQueueEnable,
            this.miQueueDisable});
            this.menuDgvQueue.Name = "menuDgvQueue";
            this.menuDgvQueue.Size = new System.Drawing.Size(185, 130);
            // 
            // miQueueReset
            // 
            this.miQueueReset.Name = "miQueueReset";
            this.miQueueReset.Size = new System.Drawing.Size(184, 30);
            this.miQueueReset.Text = "↺ Reset";
            this.miQueueReset.Click += new System.EventHandler(this.miQueueReset_Click);
            // 
            // miQueueRemove
            // 
            this.miQueueRemove.Name = "miQueueRemove";
            this.miQueueRemove.Size = new System.Drawing.Size(184, 30);
            this.miQueueRemove.Text = "✘Remove";
            this.miQueueRemove.Click += new System.EventHandler(this.miQueueRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // miQueueEnable
            // 
            this.miQueueEnable.Name = "miQueueEnable";
            this.miQueueEnable.Size = new System.Drawing.Size(184, 30);
            this.miQueueEnable.Text = "＋Enable";
            this.miQueueEnable.Click += new System.EventHandler(this.miQueueEnable_Click);
            // 
            // miQueueDisable
            // 
            this.miQueueDisable.Name = "miQueueDisable";
            this.miQueueDisable.Size = new System.Drawing.Size(184, 30);
            this.miQueueDisable.Text = "－Disable";
            this.miQueueDisable.Click += new System.EventHandler(this.miQueueDisable_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpQueue);
            this.tabControl.Controls.Add(this.tpPreQueue);
            this.tabControl.Controls.Add(this.tpAdd);
            this.tabControl.Controls.Add(this.tpSettings);
            this.tabControl.Controls.Add(this.tpLog);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowTabStrip = true;
            this.tabControl.Size = new System.Drawing.Size(1035, 441);
            this.tabControl.TabIndex = 5;
            // 
            // tpQueue
            // 
            this.tpQueue.Controls.Add(this.dgvQueue);
            this.tpQueue.Controls.Add(this.toolStrip4);
            this.tpQueue.Location = new System.Drawing.Point(4, 25);
            this.tpQueue.Margin = new System.Windows.Forms.Padding(2);
            this.tpQueue.Name = "tpQueue";
            this.tpQueue.Padding = new System.Windows.Forms.Padding(2);
            this.tpQueue.Size = new System.Drawing.Size(1027, 412);
            this.tpQueue.TabIndex = 0;
            this.tpQueue.Text = "Queue";
            this.tpQueue.UseVisualStyleBackColor = true;
            // 
            // dgvQueue
            // 
            this.dgvQueue.AllowUserToAddRows = false;
            this.dgvQueue.AllowUserToDeleteRows = false;
            this.dgvQueue.AutoGenerateColumns = false;
            this.dgvQueue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvQueue.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcQueueFileName,
            this.dgcQueueStatus,
            this.dgcQueueFileSize,
            this.dgcQueueDone,
            this.dgcQueuePerc,
            this.dgcQueueSpeed,
            this.dgcQueueETL,
            this.dgcQueueFolder});
            this.dgvQueue.DataSource = this.bsQueue;
            this.dgvQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQueue.Location = new System.Drawing.Point(2, 34);
            this.dgvQueue.Margin = new System.Windows.Forms.Padding(2);
            this.dgvQueue.Name = "dgvQueue";
            this.dgvQueue.RowHeadersVisible = false;
            this.dgvQueue.RowHeadersWidth = 18;
            this.dgvQueue.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQueue.Size = new System.Drawing.Size(1023, 376);
            this.dgvQueue.TabIndex = 2;
            this.dgvQueue.UseMyContextmenu = false;
            this.dgvQueue.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQueue_CellFormatting);
            this.dgvQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvQueue_KeyDown);
            // 
            // dgcQueueFileName
            // 
            this.dgcQueueFileName.DataPropertyName = "FileName";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcQueueFileName.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcQueueFileName.HeaderText = "Filename";
            this.dgcQueueFileName.MinimumWidth = 4;
            this.dgcQueueFileName.Name = "dgcQueueFileName";
            this.dgcQueueFileName.ReadOnly = true;
            this.dgcQueueFileName.Width = 400;
            // 
            // dgcQueueStatus
            // 
            this.dgcQueueStatus.DataPropertyName = "StatusText";
            this.dgcQueueStatus.HeaderText = "Status";
            this.dgcQueueStatus.MinimumWidth = 4;
            this.dgcQueueStatus.Name = "dgcQueueStatus";
            this.dgcQueueStatus.ReadOnly = true;
            this.dgcQueueStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcQueueStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgcQueueStatus.Width = 112;
            this.dgcQueueStatus.ColorMarkNeeded += new MyDownloader.MyLib.Components.DataGridViewColorMarkColumnEvent(this.dgcQueueStatus_ColorMarkNeeded);
            // 
            // dgcQueueFileSize
            // 
            this.dgcQueueFileSize.DataPropertyName = "FileSizeText";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgcQueueFileSize.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgcQueueFileSize.HeaderText = "Size";
            this.dgcQueueFileSize.MinimumWidth = 3;
            this.dgcQueueFileSize.Name = "dgcQueueFileSize";
            this.dgcQueueFileSize.ReadOnly = true;
            this.dgcQueueFileSize.Width = 90;
            // 
            // dgcQueueDone
            // 
            this.dgcQueueDone.DataPropertyName = "BytesReadText";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgcQueueDone.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgcQueueDone.HeaderText = "Done";
            this.dgcQueueDone.Name = "dgcQueueDone";
            this.dgcQueueDone.ReadOnly = true;
            this.dgcQueueDone.Width = 90;
            // 
            // dgcQueuePerc
            // 
            this.dgcQueuePerc.DataPropertyName = "Progress";
            this.dgcQueuePerc.HeaderText = "Progress";
            this.dgcQueuePerc.Name = "dgcQueuePerc";
            this.dgcQueuePerc.ReadOnly = true;
            this.dgcQueuePerc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcQueuePerc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgcQueueSpeed
            // 
            this.dgcQueueSpeed.DataPropertyName = "SpeedText";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgcQueueSpeed.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgcQueueSpeed.HeaderText = "Speed";
            this.dgcQueueSpeed.Name = "dgcQueueSpeed";
            this.dgcQueueSpeed.ReadOnly = true;
            // 
            // dgcQueueETL
            // 
            this.dgcQueueETL.DataPropertyName = "TimeLeft";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgcQueueETL.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgcQueueETL.HeaderText = "Time";
            this.dgcQueueETL.Name = "dgcQueueETL";
            this.dgcQueueETL.ReadOnly = true;
            // 
            // dgcQueueFolder
            // 
            this.dgcQueueFolder.DataPropertyName = "Folder";
            this.dgcQueueFolder.HeaderText = "Folder";
            this.dgcQueueFolder.MinimumWidth = 4;
            this.dgcQueueFolder.Name = "dgcQueueFolder";
            this.dgcQueueFolder.ReadOnly = true;
            this.dgcQueueFolder.Width = 240;
            // 
            // toolStrip4
            // 
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbQueueStart,
            this.tsbQueueStop,
            this.tsbQueueRemove,
            this.tsbQueueUp,
            this.tsbQueueDown,
            this.tsbQueueEnable,
            this.tsbQueueDisable,
            this.tsbReset});
            this.toolStrip4.Location = new System.Drawing.Point(2, 2);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(1023, 32);
            this.toolStrip4.TabIndex = 0;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // tsbQueueStart
            // 
            this.tsbQueueStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbQueueStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbQueueStart.Image")));
            this.tsbQueueStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQueueStart.Name = "tsbQueueStart";
            this.tsbQueueStart.Size = new System.Drawing.Size(72, 29);
            this.tsbQueueStart.Text = "▶ Start";
            this.tsbQueueStart.Click += new System.EventHandler(this.tsbQueueStart_Click);
            // 
            // tsbQueueStop
            // 
            this.tsbQueueStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbQueueStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.52F);
            this.tsbQueueStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbQueueStop.Image")));
            this.tsbQueueStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQueueStop.Name = "tsbQueueStop";
            this.tsbQueueStop.Size = new System.Drawing.Size(79, 29);
            this.tsbQueueStop.Text = "● Stop";
            this.tsbQueueStop.Click += new System.EventHandler(this.tsbQueueStop_Click);
            // 
            // tsbQueueRemove
            // 
            this.tsbQueueRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbQueueRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbQueueRemove.Image")));
            this.tsbQueueRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQueueRemove.Name = "tsbQueueRemove";
            this.tsbQueueRemove.Size = new System.Drawing.Size(113, 29);
            this.tsbQueueRemove.Text = "✘ Remove";
            this.tsbQueueRemove.Click += new System.EventHandler(this.tsbQueueRemove_Click);
            // 
            // tsbQueueUp
            // 
            this.tsbQueueUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbQueueUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbQueueUp.Image")));
            this.tsbQueueUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQueueUp.Name = "tsbQueueUp";
            this.tsbQueueUp.Size = new System.Drawing.Size(28, 29);
            this.tsbQueueUp.Text = "⇑";
            this.tsbQueueUp.Click += new System.EventHandler(this.tsbQueueUp_Click);
            // 
            // tsbQueueDown
            // 
            this.tsbQueueDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbQueueDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbQueueDown.Image")));
            this.tsbQueueDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQueueDown.Name = "tsbQueueDown";
            this.tsbQueueDown.Size = new System.Drawing.Size(28, 29);
            this.tsbQueueDown.Text = "⇓";
            this.tsbQueueDown.Click += new System.EventHandler(this.tsbQueueDown_Click);
            // 
            // tsbQueueEnable
            // 
            this.tsbQueueEnable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbQueueEnable.Image = ((System.Drawing.Image)(resources.GetObject("tsbQueueEnable.Image")));
            this.tsbQueueEnable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQueueEnable.Name = "tsbQueueEnable";
            this.tsbQueueEnable.Size = new System.Drawing.Size(97, 29);
            this.tsbQueueEnable.Text = "＋Enable";
            this.tsbQueueEnable.Click += new System.EventHandler(this.tsbQueueEnable_Click);
            // 
            // tsbQueueDisable
            // 
            this.tsbQueueDisable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbQueueDisable.Image = ((System.Drawing.Image)(resources.GetObject("tsbQueueDisable.Image")));
            this.tsbQueueDisable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQueueDisable.Name = "tsbQueueDisable";
            this.tsbQueueDisable.Size = new System.Drawing.Size(101, 29);
            this.tsbQueueDisable.Text = "－Disable";
            this.tsbQueueDisable.Click += new System.EventHandler(this.tsbQueueDisable_Click);
            // 
            // tsbReset
            // 
            this.tsbReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbReset.Image = ((System.Drawing.Image)(resources.GetObject("tsbReset.Image")));
            this.tsbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReset.Name = "tsbReset";
            this.tsbReset.Size = new System.Drawing.Size(84, 29);
            this.tsbReset.Text = "↺ Reset";
            this.tsbReset.Click += new System.EventHandler(this.tsbReset_Click);
            // 
            // tpPreQueue
            // 
            this.tpPreQueue.Controls.Add(this.dgvPreQueue);
            this.tpPreQueue.Controls.Add(this.toolStrip2);
            this.tpPreQueue.Location = new System.Drawing.Point(4, 25);
            this.tpPreQueue.Margin = new System.Windows.Forms.Padding(2);
            this.tpPreQueue.Name = "tpPreQueue";
            this.tpPreQueue.Padding = new System.Windows.Forms.Padding(2);
            this.tpPreQueue.Size = new System.Drawing.Size(1027, 412);
            this.tpPreQueue.TabIndex = 1;
            this.tpPreQueue.Text = "PreQueue";
            this.tpPreQueue.UseVisualStyleBackColor = true;
            // 
            // dgvPreQueue
            // 
            this.dgvPreQueue.AllowUserToAddRows = false;
            this.dgvPreQueue.AllowUserToDeleteRows = false;
            this.dgvPreQueue.AutoGenerateColumns = false;
            this.dgvPreQueue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPreQueue.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPreQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcPreQueueFileName,
            this.dgcPreQueueFileSize,
            this.dgcPreQueueStatusText,
            this.dgcPewQueue});
            this.dgvPreQueue.DataSource = this.bsPreQueue;
            this.dgvPreQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreQueue.Location = new System.Drawing.Point(2, 34);
            this.dgvPreQueue.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPreQueue.Name = "dgvPreQueue";
            this.dgvPreQueue.RowHeadersWidth = 18;
            this.dgvPreQueue.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPreQueue.Size = new System.Drawing.Size(1023, 376);
            this.dgvPreQueue.TabIndex = 1;
            this.dgvPreQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPreQueue_KeyDown);
            this.dgvPreQueue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvPreQueue_KeyUp);
            // 
            // dgcPreQueueFileName
            // 
            this.dgcPreQueueFileName.DataPropertyName = "FileName";
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcPreQueueFileName.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgcPreQueueFileName.HeaderText = "Filename";
            this.dgcPreQueueFileName.MinimumWidth = 4;
            this.dgcPreQueueFileName.Name = "dgcPreQueueFileName";
            this.dgcPreQueueFileName.Width = 600;
            // 
            // dgcPreQueueFileSize
            // 
            this.dgcPreQueueFileSize.DataPropertyName = "FileSizeText";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgcPreQueueFileSize.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgcPreQueueFileSize.HeaderText = "Size";
            this.dgcPreQueueFileSize.MinimumWidth = 3;
            this.dgcPreQueueFileSize.Name = "dgcPreQueueFileSize";
            this.dgcPreQueueFileSize.ReadOnly = true;
            this.dgcPreQueueFileSize.Width = 90;
            // 
            // dgcPreQueueStatusText
            // 
            this.dgcPreQueueStatusText.DataPropertyName = "StatusText";
            this.dgcPreQueueStatusText.HeaderText = "Status";
            this.dgcPreQueueStatusText.MinimumWidth = 4;
            this.dgcPreQueueStatusText.Name = "dgcPreQueueStatusText";
            this.dgcPreQueueStatusText.ReadOnly = true;
            this.dgcPreQueueStatusText.Width = 112;
            // 
            // dgcPewQueue
            // 
            this.dgcPewQueue.DataPropertyName = "Folder";
            this.dgcPewQueue.HeaderText = "Folder";
            this.dgcPewQueue.MinimumWidth = 4;
            this.dgcPewQueue.Name = "dgcPewQueue";
            this.dgcPewQueue.ReadOnly = true;
            this.dgcPewQueue.Width = 240;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPreQueueStartAll,
            this.tsbStartSelected,
            this.tsbPrequeueCheck,
            this.tsbClearPreQueue,
            this.tsbDeleteFromPrequeue,
            this.tsbPreQueueSetFolder,
            this.tsbPreQueueUp,
            this.tsbPreQueueDown});
            this.toolStrip2.Location = new System.Drawing.Point(2, 2);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1023, 32);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbPreQueueStartAll
            // 
            this.tsbPreQueueStartAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPreQueueStartAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbPreQueueStartAll.Image")));
            this.tsbPreQueueStartAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreQueueStartAll.Name = "tsbPreQueueStartAll";
            this.tsbPreQueueStartAll.Size = new System.Drawing.Size(84, 29);
            this.tsbPreQueueStartAll.Text = "Start All";
            this.tsbPreQueueStartAll.Click += new System.EventHandler(this.tsbPreQueueStartAll_Click);
            // 
            // tsbStartSelected
            // 
            this.tsbStartSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbStartSelected.Image = ((System.Drawing.Image)(resources.GetObject("tsbStartSelected.Image")));
            this.tsbStartSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStartSelected.Name = "tsbStartSelected";
            this.tsbStartSelected.Size = new System.Drawing.Size(139, 29);
            this.tsbStartSelected.Text = "Start Selected";
            this.tsbStartSelected.Click += new System.EventHandler(this.tsbStartSelected_Click);
            // 
            // tsbPrequeueCheck
            // 
            this.tsbPrequeueCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPrequeueCheck.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrequeueCheck.Image")));
            this.tsbPrequeueCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrequeueCheck.Name = "tsbPrequeueCheck";
            this.tsbPrequeueCheck.Size = new System.Drawing.Size(73, 29);
            this.tsbPrequeueCheck.Text = "Check";
            this.tsbPrequeueCheck.Click += new System.EventHandler(this.tsbPrequeueCheck_Click);
            // 
            // tsbClearPreQueue
            // 
            this.tsbClearPreQueue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClearPreQueue.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearPreQueue.Image")));
            this.tsbClearPreQueue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearPreQueue.Name = "tsbClearPreQueue";
            this.tsbClearPreQueue.Size = new System.Drawing.Size(63, 29);
            this.tsbClearPreQueue.Text = "Clear";
            this.tsbClearPreQueue.Click += new System.EventHandler(this.tsbClearPreQueue_Click);
            // 
            // tsbDeleteFromPrequeue
            // 
            this.tsbDeleteFromPrequeue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDeleteFromPrequeue.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteFromPrequeue.Image")));
            this.tsbDeleteFromPrequeue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteFromPrequeue.Name = "tsbDeleteFromPrequeue";
            this.tsbDeleteFromPrequeue.Size = new System.Drawing.Size(88, 29);
            this.tsbDeleteFromPrequeue.Text = "Remove";
            this.tsbDeleteFromPrequeue.Click += new System.EventHandler(this.tsbDeleteFromPrequeue_Click);
            // 
            // tsbPreQueueSetFolder
            // 
            this.tsbPreQueueSetFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPreQueueSetFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsbPreQueueSetFolder.Image")));
            this.tsbPreQueueSetFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreQueueSetFolder.Name = "tsbPreQueueSetFolder";
            this.tsbPreQueueSetFolder.Size = new System.Drawing.Size(106, 29);
            this.tsbPreQueueSetFolder.Text = "Set Folder";
            this.tsbPreQueueSetFolder.Click += new System.EventHandler(this.tsbPreQueueSetFolder_Click);
            // 
            // tsbPreQueueUp
            // 
            this.tsbPreQueueUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPreQueueUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbPreQueueUp.Image")));
            this.tsbPreQueueUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreQueueUp.Name = "tsbPreQueueUp";
            this.tsbPreQueueUp.Size = new System.Drawing.Size(28, 29);
            this.tsbPreQueueUp.Text = "⇑";
            this.tsbPreQueueUp.Click += new System.EventHandler(this.tsbPreQueueUp_Click);
            // 
            // tsbPreQueueDown
            // 
            this.tsbPreQueueDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPreQueueDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbPreQueueDown.Image")));
            this.tsbPreQueueDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreQueueDown.Name = "tsbPreQueueDown";
            this.tsbPreQueueDown.Size = new System.Drawing.Size(28, 29);
            this.tsbPreQueueDown.Text = "⇓";
            this.tsbPreQueueDown.Click += new System.EventHandler(this.tsbPreQueueDown_Click);
            // 
            // tpAdd
            // 
            this.tpAdd.Controls.Add(this.tbText);
            this.tpAdd.Controls.Add(this.toolStrip3);
            this.tpAdd.Location = new System.Drawing.Point(4, 25);
            this.tpAdd.Name = "tpAdd";
            this.tpAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdd.Size = new System.Drawing.Size(1027, 412);
            this.tpAdd.TabIndex = 4;
            this.tpAdd.Text = "Add";
            this.tpAdd.UseVisualStyleBackColor = true;
            // 
            // tbText
            // 
            this.tbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbText.Location = new System.Drawing.Point(3, 35);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbText.Size = new System.Drawing.Size(1021, 374);
            this.tbText.TabIndex = 2;
            this.tbText.WordWrap = false;
            this.tbText.TextChanged += new System.EventHandler(this.tbText_TextChanged);
            // 
            // toolStrip3
            // 
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGetClipboard,
            this.tsbParse,
            this.tsbClear,
            this.tsbAdd});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1021, 32);
            this.toolStrip3.TabIndex = 3;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsbGetClipboard
            // 
            this.tsbGetClipboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbGetClipboard.Image = ((System.Drawing.Image)(resources.GetObject("tsbGetClipboard.Image")));
            this.tsbGetClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGetClipboard.Name = "tsbGetClipboard";
            this.tsbGetClipboard.Size = new System.Drawing.Size(186, 29);
            this.tsbGetClipboard.Text = "Get From Clipboard";
            this.tsbGetClipboard.Click += new System.EventHandler(this.tsbGetClipboard_Click);
            // 
            // tsbParse
            // 
            this.tsbParse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbParse.Image = ((System.Drawing.Image)(resources.GetObject("tsbParse.Image")));
            this.tsbParse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbParse.Name = "tsbParse";
            this.tsbParse.Size = new System.Drawing.Size(67, 29);
            this.tsbParse.Text = "Parse";
            this.tsbParse.Click += new System.EventHandler(this.tsbParse_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(63, 29);
            this.tsbClear.Text = "Clear";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(101, 29);
            this.tsbAdd.Text = "   Add >> ";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.cbFontSize);
            this.tpSettings.Controls.Add(this.chShutdown);
            this.tpSettings.Controls.Add(this.btDownloadTo);
            this.tpSettings.Controls.Add(this.label2);
            this.tpSettings.Controls.Add(this.label1);
            this.tpSettings.Controls.Add(this.tbDownloadTo);
            this.tpSettings.Location = new System.Drawing.Point(4, 25);
            this.tpSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(2);
            this.tpSettings.Size = new System.Drawing.Size(1027, 412);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            this.tpSettings.Enter += new System.EventHandler(this.tpSettings_Enter);
            this.tpSettings.Leave += new System.EventHandler(this.tpSettings_Leave);
            // 
            // cbFontSize
            // 
            this.cbFontSize.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbFontSize.ColumnNames = new string[] {
        "col1"};
            this.cbFontSize.ColumnWidths = "85";
            this.cbFontSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFontSize.DropDownHeight = 170;
            this.cbFontSize.DropDownStyle = MyLIB.Components.MyMcComboBox.CustomDropDownStyle.DropDownListSimple;
            this.cbFontSize.DropDownWidth = 109;
            this.cbFontSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFontSize.FormattingEnabled = true;
            this.cbFontSize.GridLineColor = System.Drawing.Color.LightGray;
            this.cbFontSize.GridLineHorizontal = false;
            this.cbFontSize.GridLineVertical = false;
            this.cbFontSize.IntegralHeight = false;
            myItem1.Col1 = "8";
            myItem2.Col1 = "9";
            myItem3.Col1 = "10";
            myItem4.Col1 = "11";
            myItem5.Col1 = "12";
            myItem6.Col1 = "13";
            myItem7.Col1 = "14";
            myItem8.Col1 = "15";
            myItem9.Col1 = "16";
            this.cbFontSize.Items.AddRange(new object[] {
            myItem1,
            myItem2,
            myItem3,
            myItem4,
            myItem5,
            myItem6,
            myItem7,
            myItem8,
            myItem9});
            this.cbFontSize.ItemStrings = new string[] {
        "8",
        "9",
        "10",
        "11",
        "12",
        "13",
        "14",
        "15",
        "16"};
            this.cbFontSize.Location = new System.Drawing.Point(31, 174);
            this.cbFontSize.MaxDropDownItems = 10;
            this.cbFontSize.Name = "cbFontSize";
            this.cbFontSize.Size = new System.Drawing.Size(85, 23);
            this.cbFontSize.TabIndex = 4;
            this.cbFontSize.SelectedIndexChanged += new System.EventHandler(this.cbFontSize_SelectedIndexChanged);
            // 
            // chShutdown
            // 
            this.chShutdown.AutoSize = true;
            this.chShutdown.Location = new System.Drawing.Point(31, 108);
            this.chShutdown.Name = "chShutdown";
            this.chShutdown.Size = new System.Drawing.Size(171, 20);
            this.chShutdown.TabIndex = 3;
            this.chShutdown.Text = "Shutdown when finished";
            this.chShutdown.UseVisualStyleBackColor = true;
            this.chShutdown.CheckedChanged += new System.EventHandler(this.chShutdown_CheckedChanged);
            // 
            // btDownloadTo
            // 
            this.btDownloadTo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDownloadTo.Location = new System.Drawing.Point(360, 54);
            this.btDownloadTo.Margin = new System.Windows.Forms.Padding(2);
            this.btDownloadTo.Name = "btDownloadTo";
            this.btDownloadTo.Size = new System.Drawing.Size(75, 23);
            this.btDownloadTo.TabIndex = 2;
            this.btDownloadTo.Text = ">>";
            this.btDownloadTo.UseVisualStyleBackColor = true;
            this.btDownloadTo.Click += new System.EventHandler(this.btDownloadTo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Font size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Download to:";
            // 
            // tbDownloadTo
            // 
            this.tbDownloadTo.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbDownloadTo.Location = new System.Drawing.Point(31, 54);
            this.tbDownloadTo.Margin = new System.Windows.Forms.Padding(2);
            this.tbDownloadTo.Name = "tbDownloadTo";
            this.tbDownloadTo.Size = new System.Drawing.Size(325, 22);
            this.tbDownloadTo.TabIndex = 0;
            // 
            // tpLog
            // 
            this.tpLog.Controls.Add(this.dgvLog);
            this.tpLog.Location = new System.Drawing.Point(4, 25);
            this.tpLog.Margin = new System.Windows.Forms.Padding(2);
            this.tpLog.Name = "tpLog";
            this.tpLog.Padding = new System.Windows.Forms.Padding(2);
            this.tpLog.Size = new System.Drawing.Size(1027, 412);
            this.tpLog.TabIndex = 3;
            this.tpLog.Text = "Log";
            this.tpLog.UseVisualStyleBackColor = true;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AutoGenerateColumns = false;
            this.dgvLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLog.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcLogTime,
            this.dgcLogMsg});
            this.dgvLog.DataSource = this.bsLog;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(2, 2);
            this.dgvLog.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.RowTemplate.Height = 18;
            this.dgvLog.Size = new System.Drawing.Size(1023, 408);
            this.dgvLog.TabIndex = 0;
            this.dgvLog.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLog_CellDoubleClick);
            // 
            // dgcLogTime
            // 
            this.dgcLogTime.DataPropertyName = "TimeStamp";
            dataGridViewCellStyle8.Format = "T";
            dataGridViewCellStyle8.NullValue = null;
            this.dgcLogTime.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgcLogTime.HeaderText = "Time";
            this.dgcLogTime.MinimumWidth = 3;
            this.dgcLogTime.Name = "dgcLogTime";
            this.dgcLogTime.ReadOnly = true;
            this.dgcLogTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcLogTime.Width = 80;
            // 
            // dgcLogMsg
            // 
            this.dgcLogMsg.DataPropertyName = "Msg";
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcLogMsg.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgcLogMsg.HeaderText = "Message";
            this.dgcLogMsg.MinimumWidth = 3;
            this.dgcLogMsg.Name = "dgcLogMsg";
            this.dgcLogMsg.ReadOnly = true;
            this.dgcLogMsg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgcLogMsg.Width = 800;
            // 
            // someConfig1
            // 
            this.someConfig1.ColorCompleted = System.Drawing.Color.LightGreen;
            this.someConfig1.ColorDisabled = System.Drawing.Color.DarkGray;
            this.someConfig1.ColorError = System.Drawing.Color.LightPink;
            this.someConfig1.ColorReady = System.Drawing.Color.LightSkyBlue;
            this.someConfig1.ColorRunning = System.Drawing.Color.PaleGoldenrod;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 471);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "MyDownloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPreQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQueue)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuDgvQueue.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpQueue.ResumeLayout(false);
            this.tpQueue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.tpPreQueue.ResumeLayout(false);
            this.tpPreQueue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreQueue)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tpAdd.ResumeLayout(false);
            this.tpAdd.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            this.tpLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MyLIB.Components.TabControlWithoutHeader tabControl;
        private System.Windows.Forms.TabPage tpQueue;
        private System.Windows.Forms.TabPage tpPreQueue;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.TabPage tpLog;
        private MyLIB.Components.MyDataGridView dgvLog;
        private System.Windows.Forms.BindingSource bsLog;
        private System.Windows.Forms.Button btDownloadTo;
        private System.Windows.Forms.Label label1;
        private MyLIB.Components.MyTextBox tbDownloadTo;
        private MyLIB.Components.MyDataGridView dgvPreQueue;
        private System.Windows.Forms.BindingSource bsPreQueue;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbPreQueueStartAll;
        private System.Windows.Forms.TabPage tpAdd;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsbGetClipboard;
        private System.Windows.Forms.ToolStripButton tsbParse;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbStartSelected;
        private System.Windows.Forms.ToolStripButton tsbClearPreQueue;
        private System.Windows.Forms.ToolStripButton tsbDeleteFromPrequeue;
        private System.Windows.Forms.ToolStripButton tsbPrequeueCheck;
        private System.Windows.Forms.ToolStripButton tsbPreQueueSetFolder;
        private MyLIB.Components.MyDataGridView dgvQueue;
        private System.Windows.Forms.BindingSource bsQueue;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tsbQueueStart;
        private System.Windows.Forms.ToolStripButton tsbQueueStop;
        private System.Windows.Forms.ToolStripButton tsbQueueRemove;
        private System.Windows.Forms.ToolStripButton tsbPreQueueUp;
        private System.Windows.Forms.ToolStripButton tsbPreQueueDown;
        private System.Windows.Forms.ToolStripButton tsbQueueUp;
        private System.Windows.Forms.ToolStripButton tsbQueueDown;
        private System.Windows.Forms.ToolStripButton tsbQueueEnable;
        private System.Windows.Forms.ToolStripButton tsbQueueDisable;
        private System.Windows.Forms.ToolStripButton tsbReset;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stTotal;
        private System.Windows.Forms.ToolStripStatusLabel stLeft;
        private System.Windows.Forms.ToolStripStatusLabel stTime;
        private System.Windows.Forms.ToolStripStatusLabel stSpeed;
        private System.Windows.Forms.ToolStripProgressBar stProgress;
        private System.Windows.Forms.ContextMenuStrip menuDgvQueue;
        private System.Windows.Forms.ToolStripMenuItem miQueueReset;
        private System.Windows.Forms.ToolStripMenuItem miQueueRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miQueueEnable;
        private System.Windows.Forms.ToolStripMenuItem miQueueDisable;
        private System.Windows.Forms.CheckBox chShutdown;
        private MyLIB.Components.MyMcFlatComboBox cbFontSize;
        private System.Windows.Forms.Label label2;
        private Classes.SomeConfig someConfig1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcQueueFileName;
        private MyLib.Components.DataGridViewColorMarkColumn dgcQueueStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcQueueFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcQueueDone;
        private MyLIB.Components.DataGridViewProgressColumn dgcQueuePerc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcQueueSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcQueueETL;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcQueueFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPreQueueFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPreQueueFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPreQueueStatusText;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPewQueue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLogTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcLogMsg;
    }
}

