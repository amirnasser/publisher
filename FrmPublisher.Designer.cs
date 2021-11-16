namespace Publisher
{
    partial class FrmPublisher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPublisher));
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.cmnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopyFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCopyFileLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyFolderLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.fbd1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.drpSites = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.btnDeploy = new System.Windows.Forms.ToolStripButton();
            this.btnSaveZip = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFindChanged = new System.Windows.Forms.ToolStripButton();
            this.btnFindTodayFiles = new System.Windows.Forms.ToolStripButton();
            this.btnCompare = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.img1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.img2 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pgbar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.bg1 = new System.ComponentModel.BackgroundWorker();
            this.bg2 = new System.ComponentModel.BackgroundWorker();
            this.cmnu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFiles
            // 
            this.lstFiles.AllowDrop = true;
            this.lstFiles.BackColor = System.Drawing.Color.White;
            this.lstFiles.ContextMenuStrip = this.cmnu;
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(5, 18);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFiles.Size = new System.Drawing.Size(1273, 253);
            this.lstFiles.TabIndex = 6;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.lstFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.lstFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            this.lstFiles.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            this.lstFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            this.lstFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
            // 
            // cmnu
            // 
            this.cmnu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyFile,
            this.toolStripMenuItem1,
            this.menuCopyFileLocation,
            this.mnuCopyFolderLocation,
            this.toolStripMenuItem2,
            this.mnuOpenFolder,
            this.toolStripMenuItem3,
            this.mnuPaste,
            this.toolStripMenuItem4,
            this.selectAllToolStripMenuItem});
            this.cmnu.Name = "cmnu";
            this.cmnu.Size = new System.Drawing.Size(247, 160);
            // 
            // mnuCopyFile
            // 
            this.mnuCopyFile.Name = "mnuCopyFile";
            this.mnuCopyFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopyFile.Size = new System.Drawing.Size(246, 22);
            this.mnuCopyFile.Text = "Copy File";
            this.mnuCopyFile.Click += new System.EventHandler(this.mnuCopyFile_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(243, 6);
            // 
            // menuCopyFileLocation
            // 
            this.menuCopyFileLocation.Name = "menuCopyFileLocation";
            this.menuCopyFileLocation.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.menuCopyFileLocation.Size = new System.Drawing.Size(246, 22);
            this.menuCopyFileLocation.Text = "Copy File Location";
            this.menuCopyFileLocation.Click += new System.EventHandler(this.menuCopyFileLocation_Click);
            // 
            // mnuCopyFolderLocation
            // 
            this.mnuCopyFolderLocation.Name = "mnuCopyFolderLocation";
            this.mnuCopyFolderLocation.Size = new System.Drawing.Size(246, 22);
            this.mnuCopyFolderLocation.Text = "Copy Folder Location";
            this.mnuCopyFolderLocation.Click += new System.EventHandler(this.mnuCopyFolderLocation_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(243, 6);
            // 
            // mnuOpenFolder
            // 
            this.mnuOpenFolder.Name = "mnuOpenFolder";
            this.mnuOpenFolder.Size = new System.Drawing.Size(246, 22);
            this.mnuOpenFolder.Text = "Open Folder Location";
            this.mnuOpenFolder.Click += new System.EventHandler(this.mnuOpenFolder_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(243, 6);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuPaste.Size = new System.Drawing.Size(246, 22);
            this.mnuPaste.Text = "Paste File(s)";
            this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(243, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.selectAllToolStripMenuItem.Text = "&Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Please Drag and Drop Files you want to add to deploy.";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drpSites,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.btnDelete,
            this.btnDeleteAll,
            this.toolStripButton4,
            this.btnDeploy,
            this.btnSaveZip,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.txtSearch,
            this.toolStripSeparator3,
            this.btnFindChanged,
            this.btnFindTodayFiles,
            this.btnCompare});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1283, 31);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // drpSites
            // 
            this.drpSites.Name = "drpSites";
            this.drpSites.Size = new System.Drawing.Size(200, 31);
            this.drpSites.SelectedIndexChanged += new System.EventHandler(this.drpSites_SelectedIndexChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Publisher.Properties.Resources.folder_3;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "Open";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Publisher.Properties.Resources.media_flash_2;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton2.Text = "Save";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Publisher.Properties.Resources.archive_insert_2;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton3.Text = "Copy Structure";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::Publisher.Properties.Resources.archive_remove;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(28, 28);
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteAll.Image = global::Publisher.Properties.Resources.application_exit_4;
            this.btnDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(28, 28);
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::Publisher.Properties.Resources.Tree;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton4.Text = "Show Folder Structure";
            this.toolStripButton4.Visible = false;
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // btnDeploy
            // 
            this.btnDeploy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeploy.Image = global::Publisher.Properties.Resources.db_comit_2;
            this.btnDeploy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(28, 28);
            this.btnDeploy.Text = "Deploy";
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            // 
            // btnSaveZip
            // 
            this.btnSaveZip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveZip.Image = global::Publisher.Properties.Resources.application_x_deb;
            this.btnSaveZip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveZip.Name = "btnSaveZip";
            this.btnSaveZip.Size = new System.Drawing.Size(28, 28);
            this.btnSaveZip.Text = "Save Zip";
            this.btnSaveZip.Click += new System.EventHandler(this.btnSaveZip_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.Visible = false;
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 28);
            this.toolStripLabel1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 31);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // btnFindChanged
            // 
            this.btnFindChanged.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFindChanged.Image = global::Publisher.Properties.Resources.system_search_3;
            this.btnFindChanged.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFindChanged.Name = "btnFindChanged";
            this.btnFindChanged.Size = new System.Drawing.Size(28, 28);
            this.btnFindChanged.Text = "Find Change files";
            this.btnFindChanged.Click += new System.EventHandler(this.btnFindChanged_Click);
            // 
            // btnFindTodayFiles
            // 
            this.btnFindTodayFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFindTodayFiles.Image = global::Publisher.Properties.Resources.Search;
            this.btnFindTodayFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFindTodayFiles.Name = "btnFindTodayFiles";
            this.btnFindTodayFiles.Size = new System.Drawing.Size(28, 28);
            this.btnFindTodayFiles.Text = "Search";
            this.btnFindTodayFiles.Visible = false;
            this.btnFindTodayFiles.Click += new System.EventHandler(this.btnFindTodayFiles_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCompare.Image = global::Publisher.Properties.Resources.compare;
            this.btnCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(28, 28);
            this.btnCompare.Text = "toolStripButton6";
            this.btnCompare.Visible = false;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstFiles);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1283, 276);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.propertyGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 313);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(1283, 119);
            this.panel2.TabIndex = 12;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(5, 5);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(1273, 109);
            this.propertyGrid1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listView1);
            this.panel3.Controls.Add(this.splitter3);
            this.panel3.Controls.Add(this.treeView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 438);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(1283, 585);
            this.panel3.TabIndex = 14;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(322, 5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(956, 575);
            this.listView1.SmallImageList = this.img1;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Filename";
            this.columnHeader1.Width = 350;
            // 
            // img1
            // 
            this.img1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img1.ImageStream")));
            this.img1.TransparentColor = System.Drawing.Color.Transparent;
            this.img1.Images.SetKeyName(0, "check.png");
            this.img1.Images.SetKeyName(1, "delete-icon.png");
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(312, 5);
            this.splitter3.Margin = new System.Windows.Forms.Padding(5);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(10, 575);
            this.splitter3.TabIndex = 1;
            this.splitter3.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.img2;
            this.treeView1.Location = new System.Drawing.Point(5, 5);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(307, 575);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // img2
            // 
            this.img2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img2.ImageStream")));
            this.img2.TransparentColor = System.Drawing.Color.Transparent;
            this.img2.Images.SetKeyName(0, "asp.png");
            this.img2.Images.SetKeyName(1, "open.png");
            this.img2.Images.SetKeyName(2, "Drive.png");
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 307);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1283, 6);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 432);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1283, 6);
            this.splitter2.TabIndex = 16;
            this.splitter2.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.pgbar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1023);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1283, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1166, 17);
            this.lblStatus.Spring = true;
            // 
            // pgbar1
            // 
            this.pgbar1.Name = "pgbar1";
            this.pgbar1.Size = new System.Drawing.Size(100, 16);
            // 
            // bg1
            // 
            this.bg1.WorkerReportsProgress = true;
            this.bg1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg1_DoWork);
            this.bg1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg1_ProgressChanged);
            this.bg1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg1_RunWorkerCompleted);
            // 
            // bg2
            // 
            this.bg2.WorkerReportsProgress = true;
            this.bg2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg2_DoWork);
            this.bg2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg2_ProgressChanged);
            this.bg2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg2_RunWorkerCompleted);
            // 
            // FrmPublisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 1045);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPublisher";
            this.Text = "File Publisher";
            this.Load += new System.EventHandler(this.FrmPublisher_Load);
            this.cmnu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fbd1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.ComponentModel.BackgroundWorker bg1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList img1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar pgbar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnDeleteAll;
        private System.Windows.Forms.ImageList img2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ContextMenuStrip cmnu;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyFolderLocation;
        private System.Windows.Forms.ToolStripMenuItem menuCopyFileLocation;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenFolder;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        public System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnFindChanged;
        private System.Windows.Forms.ToolStripButton btnFindTodayFiles;
        private System.Windows.Forms.ToolStripButton btnCompare;
        private System.ComponentModel.BackgroundWorker bg2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripButton btnDeploy;
        private System.Windows.Forms.ToolStripButton btnSaveZip;
        private System.Windows.Forms.ToolStripComboBox drpSites;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    }
}