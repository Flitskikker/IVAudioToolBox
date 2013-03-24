namespace IVAUDToolBox
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pictureBoxHeader = new System.Windows.Forms.PictureBox();
            this.pictureBoxHeaderLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxHeaderWaveForm = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSingle = new System.Windows.Forms.TabPage();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSampleRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOffset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelSample = new System.Windows.Forms.Label();
            this.listViewSampleProperties = new System.Windows.Forms.ListView();
            this.columnHeaderSampleProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSampleValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.listViewFileProperties = new System.Windows.Forms.ListView();
            this.columnHeaderFileProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFileValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSeparator = new System.Windows.Forms.GroupBox();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonPlay = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPlayLooped = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPause = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButtonExport = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItemExportWAV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExportWAVMulti = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExportAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonType = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReplace = new System.Windows.Forms.ToolStripButton();
            this.tabPageMulti = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.openFileDialogOpenIVAUD = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialogExport = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogReplace = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSaveAs = new System.Windows.Forms.SaveFileDialog();
            this.mainMenuMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemReplace = new System.Windows.Forms.MenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeaderLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeaderWaveForm)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageSingle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStripMenu.SuspendLayout();
            this.tabPageMulti.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxHeader
            // 
            this.pictureBoxHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxHeader.BackgroundImage")));
            this.pictureBoxHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxHeader.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxHeader.Name = "pictureBoxHeader";
            this.pictureBoxHeader.Size = new System.Drawing.Size(799, 67);
            this.pictureBoxHeader.TabIndex = 0;
            this.pictureBoxHeader.TabStop = false;
            // 
            // pictureBoxHeaderLogo
            // 
            this.pictureBoxHeaderLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxHeaderLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxHeaderLogo.Image")));
            this.pictureBoxHeaderLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxHeaderLogo.Name = "pictureBoxHeaderLogo";
            this.pictureBoxHeaderLogo.Size = new System.Drawing.Size(299, 67);
            this.pictureBoxHeaderLogo.TabIndex = 1;
            this.pictureBoxHeaderLogo.TabStop = false;
            // 
            // pictureBoxHeaderWaveForm
            // 
            this.pictureBoxHeaderWaveForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxHeaderWaveForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxHeaderWaveForm.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxHeaderWaveForm.Image")));
            this.pictureBoxHeaderWaveForm.Location = new System.Drawing.Point(689, 0);
            this.pictureBoxHeaderWaveForm.Name = "pictureBoxHeaderWaveForm";
            this.pictureBoxHeaderWaveForm.Size = new System.Drawing.Size(110, 67);
            this.pictureBoxHeaderWaveForm.TabIndex = 2;
            this.pictureBoxHeaderWaveForm.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageSingle);
            this.tabControl.Controls.Add(this.tabPageMulti);
            this.tabControl.Location = new System.Drawing.Point(12, 73);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(778, 515);
            this.tabControl.TabIndex = 3;
            // 
            // tabPageSingle
            // 
            this.tabPageSingle.BackColor = System.Drawing.Color.White;
            this.tabPageSingle.Controls.Add(this.listView);
            this.tabPageSingle.Controls.Add(this.groupBox1);
            this.tabPageSingle.Controls.Add(this.toolStripMenu);
            this.tabPageSingle.Location = new System.Drawing.Point(4, 22);
            this.tabPageSingle.Name = "tabPageSingle";
            this.tabPageSingle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSingle.Size = new System.Drawing.Size(770, 489);
            this.tabPageSingle.TabIndex = 0;
            this.tabPageSingle.Text = "Single File";
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderName,
            this.columnHeaderDuration,
            this.columnHeaderSampleRate,
            this.columnHeaderOffset,
            this.columnHeaderSize});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(6, 37);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(756, 230);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "#";
            this.columnHeaderID.Width = 50;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 275;
            // 
            // columnHeaderDuration
            // 
            this.columnHeaderDuration.Text = "Duration";
            this.columnHeaderDuration.Width = 100;
            // 
            // columnHeaderSampleRate
            // 
            this.columnHeaderSampleRate.Text = "Sample Rate";
            this.columnHeaderSampleRate.Width = 100;
            // 
            // columnHeaderOffset
            // 
            this.columnHeaderOffset.Text = "Offset";
            this.columnHeaderOffset.Width = 100;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "Size";
            this.columnHeaderSize.Width = 100;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Empty.png");
            this.imageList.Images.SetKeyName(1, "Play.png");
            this.imageList.Images.SetKeyName(2, "PlayLooped.png");
            this.imageList.Images.SetKeyName(3, "Pause.png");
            this.imageList.Images.SetKeyName(4, "Stop.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelSample);
            this.groupBox1.Controls.Add(this.listViewSampleProperties);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelFile);
            this.groupBox1.Controls.Add(this.listViewFileProperties);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBoxSeparator);
            this.groupBox1.Location = new System.Drawing.Point(6, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 210);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // labelSample
            // 
            this.labelSample.AutoEllipsis = true;
            this.labelSample.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSample.Location = new System.Drawing.Point(444, 22);
            this.labelSample.Name = "labelSample";
            this.labelSample.Size = new System.Drawing.Size(302, 27);
            this.labelSample.TabIndex = 23;
            this.labelSample.Text = "< No sample selected >";
            this.labelSample.UseMnemonic = false;
            // 
            // listViewSampleProperties
            // 
            this.listViewSampleProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewSampleProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSampleProperty,
            this.columnHeaderSampleValue});
            this.listViewSampleProperties.FullRowSelect = true;
            this.listViewSampleProperties.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewSampleProperties.Location = new System.Drawing.Point(389, 52);
            this.listViewSampleProperties.Name = "listViewSampleProperties";
            this.listViewSampleProperties.Size = new System.Drawing.Size(357, 147);
            this.listViewSampleProperties.TabIndex = 22;
            this.listViewSampleProperties.UseCompatibleStateImageBehavior = false;
            this.listViewSampleProperties.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSampleProperty
            // 
            this.columnHeaderSampleProperty.Text = "Property";
            this.columnHeaderSampleProperty.Width = 150;
            // 
            // columnHeaderSampleValue
            // 
            this.columnHeaderSampleValue.Text = "Value";
            this.columnHeaderSampleValue.Width = 175;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(387, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Sample:";
            // 
            // labelFile
            // 
            this.labelFile.AutoEllipsis = true;
            this.labelFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFile.Location = new System.Drawing.Point(65, 22);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(303, 27);
            this.labelFile.TabIndex = 20;
            this.labelFile.Text = "< No file opened >";
            this.labelFile.UseMnemonic = false;
            // 
            // listViewFileProperties
            // 
            this.listViewFileProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewFileProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFileProperty,
            this.columnHeaderFileValue});
            this.listViewFileProperties.FullRowSelect = true;
            this.listViewFileProperties.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewFileProperties.Location = new System.Drawing.Point(10, 52);
            this.listViewFileProperties.Name = "listViewFileProperties";
            this.listViewFileProperties.Size = new System.Drawing.Size(358, 147);
            this.listViewFileProperties.TabIndex = 19;
            this.listViewFileProperties.UseCompatibleStateImageBehavior = false;
            this.listViewFileProperties.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderFileProperty
            // 
            this.columnHeaderFileProperty.Text = "Property";
            this.columnHeaderFileProperty.Width = 150;
            // 
            // columnHeaderFileValue
            // 
            this.columnHeaderFileValue.Text = "Value";
            this.columnHeaderFileValue.Width = 175;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "File:";
            // 
            // groupBoxSeparator
            // 
            this.groupBoxSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxSeparator.Location = new System.Drawing.Point(378, 10);
            this.groupBoxSeparator.Name = "groupBoxSeparator";
            this.groupBoxSeparator.Size = new System.Drawing.Size(2, 190);
            this.groupBoxSeparator.TabIndex = 0;
            this.groupBoxSeparator.TabStop = false;
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripMenu.AutoSize = false;
            this.toolStripMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonSave,
            this.toolStripButtonSaveAs,
            this.toolStripSeparator1,
            this.toolStripButtonPlay,
            this.toolStripButtonPlayLooped,
            this.toolStripButtonPause,
            this.toolStripButtonStop,
            this.toolStripSeparator2,
            this.toolStripSplitButtonExport,
            this.toolStripComboBoxType,
            this.toolStripButtonType,
            this.toolStripButtonReplace});
            this.toolStripMenu.Location = new System.Drawing.Point(2, 4);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(765, 26);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 23);
            this.toolStripButtonOpen.Text = "Open...";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 23);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonSaveAs
            // 
            this.toolStripButtonSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveAs.Image")));
            this.toolStripButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveAs.Name = "toolStripButtonSaveAs";
            this.toolStripButtonSaveAs.Size = new System.Drawing.Size(23, 23);
            this.toolStripButtonSaveAs.Text = "Save As...";
            this.toolStripButtonSaveAs.Click += new System.EventHandler(this.toolStripButtonSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripButtonPlay
            // 
            this.toolStripButtonPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPlay.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPlay.Image")));
            this.toolStripButtonPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPlay.Name = "toolStripButtonPlay";
            this.toolStripButtonPlay.Size = new System.Drawing.Size(23, 23);
            this.toolStripButtonPlay.Text = "Play";
            this.toolStripButtonPlay.Click += new System.EventHandler(this.toolStripButtonPlay_Click);
            // 
            // toolStripButtonPlayLooped
            // 
            this.toolStripButtonPlayLooped.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPlayLooped.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPlayLooped.Image")));
            this.toolStripButtonPlayLooped.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPlayLooped.Name = "toolStripButtonPlayLooped";
            this.toolStripButtonPlayLooped.Size = new System.Drawing.Size(23, 23);
            this.toolStripButtonPlayLooped.Text = "Play Looped";
            this.toolStripButtonPlayLooped.Click += new System.EventHandler(this.toolStripButtonPlayLooped_Click);
            // 
            // toolStripButtonPause
            // 
            this.toolStripButtonPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPause.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPause.Image")));
            this.toolStripButtonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPause.Name = "toolStripButtonPause";
            this.toolStripButtonPause.Size = new System.Drawing.Size(23, 23);
            this.toolStripButtonPause.Text = "Pause";
            this.toolStripButtonPause.Visible = false;
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(23, 23);
            this.toolStripButtonStop.Text = "Stop";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripSplitButtonExport
            // 
            this.toolStripSplitButtonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButtonExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemExportWAV,
            this.toolStripMenuItemExportWAVMulti,
            this.toolStripMenuItemExportAll});
            this.toolStripSplitButtonExport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButtonExport.Image")));
            this.toolStripSplitButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonExport.Name = "toolStripSplitButtonExport";
            this.toolStripSplitButtonExport.Size = new System.Drawing.Size(32, 23);
            this.toolStripSplitButtonExport.Text = "Export selected as WAV...";
            this.toolStripSplitButtonExport.ButtonClick += new System.EventHandler(this.toolStripMenuItemExportWAV_Click);
            // 
            // toolStripMenuItemExportWAV
            // 
            this.toolStripMenuItemExportWAV.Name = "toolStripMenuItemExportWAV";
            this.toolStripMenuItemExportWAV.Size = new System.Drawing.Size(283, 22);
            this.toolStripMenuItemExportWAV.Text = "Export selected as WAV...";
            this.toolStripMenuItemExportWAV.Click += new System.EventHandler(this.toolStripMenuItemExportWAV_Click);
            // 
            // toolStripMenuItemExportWAVMulti
            // 
            this.toolStripMenuItemExportWAVMulti.Name = "toolStripMenuItemExportWAVMulti";
            this.toolStripMenuItemExportWAVMulti.Size = new System.Drawing.Size(283, 22);
            this.toolStripMenuItemExportWAVMulti.Text = "Export selected as Multi Channel WAV...";
            this.toolStripMenuItemExportWAVMulti.Click += new System.EventHandler(this.toolStripMenuItemExportWAVMulti_Click);
            // 
            // toolStripMenuItemExportAll
            // 
            this.toolStripMenuItemExportAll.Name = "toolStripMenuItemExportAll";
            this.toolStripMenuItemExportAll.Size = new System.Drawing.Size(283, 22);
            this.toolStripMenuItemExportAll.Text = "Export all as WAV...";
            this.toolStripMenuItemExportAll.Click += new System.EventHandler(this.toolStripMenuItemExportAll_Click);
            // 
            // toolStripComboBoxType
            // 
            this.toolStripComboBoxType.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBoxType.Name = "toolStripComboBoxType";
            this.toolStripComboBoxType.Size = new System.Drawing.Size(121, 26);
            this.toolStripComboBoxType.Visible = false;
            // 
            // toolStripButtonType
            // 
            this.toolStripButtonType.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonType.Enabled = false;
            this.toolStripButtonType.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonType.Image")));
            this.toolStripButtonType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonType.Name = "toolStripButtonType";
            this.toolStripButtonType.Size = new System.Drawing.Size(23, 23);
            this.toolStripButtonType.Text = "toolStripButton10";
            this.toolStripButtonType.Visible = false;
            // 
            // toolStripButtonReplace
            // 
            this.toolStripButtonReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReplace.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReplace.Image")));
            this.toolStripButtonReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReplace.Name = "toolStripButtonReplace";
            this.toolStripButtonReplace.Size = new System.Drawing.Size(23, 23);
            this.toolStripButtonReplace.Text = "Replace...";
            this.toolStripButtonReplace.Click += new System.EventHandler(this.toolStripButtonReplace_Click);
            // 
            // tabPageMulti
            // 
            this.tabPageMulti.BackColor = System.Drawing.Color.White;
            this.tabPageMulti.Controls.Add(this.label18);
            this.tabPageMulti.Location = new System.Drawing.Point(4, 22);
            this.tabPageMulti.Name = "tabPageMulti";
            this.tabPageMulti.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMulti.Size = new System.Drawing.Size(770, 489);
            this.tabPageMulti.TabIndex = 1;
            this.tabPageMulti.Text = "Multiple Files";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.Location = new System.Drawing.Point(6, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(758, 483);
            this.label18.TabIndex = 0;
            this.label18.Text = "Not available.";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonQuit.Location = new System.Drawing.Point(704, 593);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(85, 25);
            this.buttonQuit.TabIndex = 4;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAbout.Location = new System.Drawing.Point(615, 593);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(85, 25);
            this.buttonAbout.TabIndex = 5;
            this.buttonAbout.Text = "About...";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // labelCopyright
            // 
            this.labelCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Enabled = false;
            this.labelCopyright.Location = new System.Drawing.Point(8, 600);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(235, 13);
            this.labelCopyright.TabIndex = 6;
            this.labelCopyright.Text = "© 2012 FlitskikkerSoftware. All rights reserved.";
            // 
            // openFileDialogOpenIVAUD
            // 
            this.openFileDialogOpenIVAUD.Filter = "IV Audio Files|*.ivaud;*.wac;*.*";
            this.openFileDialogOpenIVAUD.Title = "Open file...";
            // 
            // saveFileDialogExport
            // 
            this.saveFileDialogExport.Filter = "Wave files|*.wav";
            this.saveFileDialogExport.Title = "Export...";
            // 
            // folderBrowserDialogExport
            // 
            this.folderBrowserDialogExport.Description = "Please select a destination folder:";
            // 
            // openFileDialogReplace
            // 
            this.openFileDialogReplace.Filter = "Wave files|*.wav";
            this.openFileDialogReplace.Title = "Open replacement file...";
            // 
            // saveFileDialogSaveAs
            // 
            this.saveFileDialogSaveAs.Filter = "IV Audio Files|*.ivaud;*.wac;*.*";
            this.saveFileDialogSaveAs.Title = "Save As...";
            // 
            // mainMenuMenu
            // 
            this.mainMenuMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemReplace});
            // 
            // menuItemReplace
            // 
            this.menuItemReplace.Index = 0;
            this.menuItemReplace.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.menuItemReplace.Text = "Replace";
            this.menuItemReplace.Visible = false;
            this.menuItemReplace.Click += new System.EventHandler(this.toolStripButtonReplace_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 629);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pictureBoxHeaderWaveForm);
            this.Controls.Add(this.pictureBoxHeaderLogo);
            this.Controls.Add(this.pictureBoxHeader);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu = this.mainMenuMenu;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IV Audio ToolBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeaderLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeaderWaveForm)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageSingle.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.tabPageMulti.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxHeader;
        private System.Windows.Forms.PictureBox pictureBoxHeaderLogo;
        private System.Windows.Forms.PictureBox pictureBoxHeaderWaveForm;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSingle;
        private System.Windows.Forms.TabPage tabPageMulti;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.GroupBox groupBoxSeparator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderDuration;
        private System.Windows.Forms.ColumnHeader columnHeaderSampleRate;
        private System.Windows.Forms.ColumnHeader columnHeaderOffset;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlay;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlayLooped;
        private System.Windows.Forms.ToolStripButton toolStripButtonPause;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonReplace;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxType;
        private System.Windows.Forms.ToolStripButton toolStripButtonType;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonExport;
        private System.Windows.Forms.OpenFileDialog openFileDialogOpenIVAUD;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExportWAV;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExportWAVMulti;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.ListView listViewFileProperties;
        private System.Windows.Forms.ColumnHeader columnHeaderFileProperty;
        private System.Windows.Forms.ColumnHeader columnHeaderFileValue;
        private System.Windows.Forms.Label labelSample;
        private System.Windows.Forms.ListView listViewSampleProperties;
        private System.Windows.Forms.ColumnHeader columnHeaderSampleProperty;
        private System.Windows.Forms.ColumnHeader columnHeaderSampleValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExportAll;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogExport;
        private System.Windows.Forms.OpenFileDialog openFileDialogReplace;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSaveAs;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.MainMenu mainMenuMenu;
        private System.Windows.Forms.MenuItem menuItemReplace;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

