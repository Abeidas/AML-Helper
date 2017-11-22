namespace SplitTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateLink = new System.Windows.Forms.ToolStripMenuItem();
            this.setSplitPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeView_Pathes = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Source = new System.Windows.Forms.Label();
            this.lbl_FileRequiredMerging = new System.Windows.Forms.Label();
            this.lbl_TimeOthers = new System.Windows.Forms.Label();
            this.lbl_TimeForMerging = new System.Windows.Forms.Label();
            this.lbl_TimeForLoading = new System.Windows.Forms.Label();
            this.lbl_TimeForIDCheck = new System.Windows.Forms.Label();
            this.lbl_TimeCheckReferences = new System.Windows.Forms.Label();
            this.lbl_TimeOverall = new System.Windows.Forms.Label();
            this.lbl_TimeShowTree = new System.Windows.Forms.Label();
            this.lbl_numberOfAllObjects = new System.Windows.Forms.Label();
            this.lbl_IDErrorNumber = new System.Windows.Forms.Label();
            this.lbl_LinkNumber = new System.Windows.Forms.Label();
            this.lbl_SUCNumber = new System.Windows.Forms.Label();
            this.lbl_InterfaceClassNumber = new System.Windows.Forms.Label();
            this.lbl_ErrorNumber = new System.Windows.Forms.Label();
            this.lbl_RoleClassNumber = new System.Windows.Forms.Label();
            this.lbl_IENumber = new System.Windows.Forms.Label();
            this.lbl_AttributeNumber = new System.Windows.Forms.Label();
            this.lbl_InterfaceNumber = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMerge2 = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.lbl_Split3 = new System.Windows.Forms.Label();
            this.btnSetSplitPoint = new System.Windows.Forms.Button();
            this.btnSplit3ToContentView = new System.Windows.Forms.Button();
            this.treeView4 = new System.Windows.Forms.TreeView();
            this.btnMainToContentView = new System.Windows.Forms.Button();
            this.btnSplit2ToContentView = new System.Windows.Forms.Button();
            this.lbl_Split2 = new System.Windows.Forms.Label();
            this.btnSplit1ToContentView = new System.Windows.Forms.Button();
            this.treeView3 = new System.Windows.Forms.TreeView();
            this.lbl_split1 = new System.Windows.Forms.Label();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.lbl_Ori = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btn_CreateCAEXFile = new System.Windows.Forms.Button();
            this.btn_SplitCAEXFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_LoadCAEXFile = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtAMLContent = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBox_ShowWarnings = new System.Windows.Forms.CheckBox();
            this.MergeCommentsListBox = new System.Windows.Forms.ListBox();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_PathHashTable = new System.Windows.Forms.Label();
            this.btn_updateHashTables = new System.Windows.Forms.Button();
            this.listBox_PathHashTable = new System.Windows.Forms.ListBox();
            this.btn_StandardLibrary = new System.Windows.Forms.Button();
            this.btn_repairIDError = new System.Windows.Forms.Button();
            this.IDErrorListBox = new System.Windows.Forms.ListBox();
            this.ReferenceErrorListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.findAttributeToolStripMenuItem,
            this.mnuCreateLink,
            this.setSplitPointToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(218, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.removeToolStripMenuItem.Text = "Remove Selected Object";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // findAttributeToolStripMenuItem
            // 
            this.findAttributeToolStripMenuItem.Name = "findAttributeToolStripMenuItem";
            this.findAttributeToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.findAttributeToolStripMenuItem.Text = "Find attribute Durchmesser";
            this.findAttributeToolStripMenuItem.Click += new System.EventHandler(this.findAttributeToolStripMenuItem_Click);
            // 
            // mnuCreateLink
            // 
            this.mnuCreateLink.Name = "mnuCreateLink";
            this.mnuCreateLink.Size = new System.Drawing.Size(217, 22);
            this.mnuCreateLink.Text = "Create Link";
            this.mnuCreateLink.Click += new System.EventHandler(this.mnuCreateLink_Click);
            // 
            // setSplitPointToolStripMenuItem
            // 
            this.setSplitPointToolStripMenuItem.Name = "setSplitPointToolStripMenuItem";
            this.setSplitPointToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.setSplitPointToolStripMenuItem.Text = "SetSplitPoint";
            this.setSplitPointToolStripMenuItem.Click += new System.EventHandler(this.setSplitPointToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1238, 569);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.treeView_Pathes);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.btnMerge2);
            this.tabPage1.Controls.Add(this.btnMerge);
            this.tabPage1.Controls.Add(this.lbl_Split3);
            this.tabPage1.Controls.Add(this.btnSetSplitPoint);
            this.tabPage1.Controls.Add(this.btnSplit3ToContentView);
            this.tabPage1.Controls.Add(this.treeView4);
            this.tabPage1.Controls.Add(this.btnMainToContentView);
            this.tabPage1.Controls.Add(this.btnSplit2ToContentView);
            this.tabPage1.Controls.Add(this.lbl_Split2);
            this.tabPage1.Controls.Add(this.btnSplit1ToContentView);
            this.tabPage1.Controls.Add(this.treeView3);
            this.tabPage1.Controls.Add(this.lbl_split1);
            this.tabPage1.Controls.Add(this.treeView2);
            this.tabPage1.Controls.Add(this.lbl_Ori);
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Controls.Add(this.btn_CreateCAEXFile);
            this.tabPage1.Controls.Add(this.btn_SplitCAEXFile);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btn_LoadCAEXFile);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1230, 543);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Splitting of Files";
            // 
            // treeView_Pathes
            // 
            this.treeView_Pathes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView_Pathes.ImageIndex = 1;
            this.treeView_Pathes.ImageList = this.imageList;
            this.treeView_Pathes.Location = new System.Drawing.Point(6, 7);
            this.treeView_Pathes.Name = "treeView_Pathes";
            this.treeView_Pathes.SelectedImageKey = "new.ico";
            this.treeView_Pathes.ShowLines = false;
            this.treeView_Pathes.ShowPlusMinus = false;
            this.treeView_Pathes.ShowRootLines = false;
            this.treeView_Pathes.Size = new System.Drawing.Size(338, 471);
            this.treeView_Pathes.TabIndex = 53;
            this.treeView_Pathes.DoubleClick += new System.EventHandler(this.treeView_Pathes_DoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Folder.ico");
            this.imageList.Images.SetKeyName(1, "new.ico");
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbl_Source);
            this.panel2.Controls.Add(this.lbl_FileRequiredMerging);
            this.panel2.Controls.Add(this.lbl_TimeOthers);
            this.panel2.Controls.Add(this.lbl_TimeForMerging);
            this.panel2.Controls.Add(this.lbl_TimeForLoading);
            this.panel2.Controls.Add(this.lbl_TimeForIDCheck);
            this.panel2.Controls.Add(this.lbl_TimeCheckReferences);
            this.panel2.Controls.Add(this.lbl_TimeOverall);
            this.panel2.Controls.Add(this.lbl_TimeShowTree);
            this.panel2.Controls.Add(this.lbl_numberOfAllObjects);
            this.panel2.Controls.Add(this.lbl_IDErrorNumber);
            this.panel2.Controls.Add(this.lbl_LinkNumber);
            this.panel2.Controls.Add(this.lbl_SUCNumber);
            this.panel2.Controls.Add(this.lbl_InterfaceClassNumber);
            this.panel2.Controls.Add(this.lbl_ErrorNumber);
            this.panel2.Controls.Add(this.lbl_RoleClassNumber);
            this.panel2.Controls.Add(this.lbl_IENumber);
            this.panel2.Controls.Add(this.lbl_AttributeNumber);
            this.panel2.Controls.Add(this.lbl_InterfaceNumber);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1031, 222);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(190, 291);
            this.panel2.TabIndex = 52;
            // 
            // lbl_Source
            // 
            this.lbl_Source.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Source.AutoSize = true;
            this.lbl_Source.Location = new System.Drawing.Point(4, 10);
            this.lbl_Source.Name = "lbl_Source";
            this.lbl_Source.Size = new System.Drawing.Size(44, 13);
            this.lbl_Source.TabIndex = 67;
            this.lbl_Source.Text = "Source:";
            this.lbl_Source.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_FileRequiredMerging
            // 
            this.lbl_FileRequiredMerging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_FileRequiredMerging.AutoSize = true;
            this.lbl_FileRequiredMerging.Location = new System.Drawing.Point(3, 30);
            this.lbl_FileRequiredMerging.Name = "lbl_FileRequiredMerging";
            this.lbl_FileRequiredMerging.Size = new System.Drawing.Size(61, 13);
            this.lbl_FileRequiredMerging.TabIndex = 66;
            this.lbl_FileRequiredMerging.Text = "not Merged";
            this.lbl_FileRequiredMerging.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TimeOthers
            // 
            this.lbl_TimeOthers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_TimeOthers.AutoSize = true;
            this.lbl_TimeOthers.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimeOthers.Location = new System.Drawing.Point(115, 265);
            this.lbl_TimeOthers.Name = "lbl_TimeOthers";
            this.lbl_TimeOthers.Size = new System.Drawing.Size(41, 12);
            this.lbl_TimeOthers.TabIndex = 52;
            this.lbl_TimeOthers.Text = "00:00:00";
            this.lbl_TimeOthers.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TimeForMerging
            // 
            this.lbl_TimeForMerging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_TimeForMerging.AutoSize = true;
            this.lbl_TimeForMerging.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimeForMerging.Location = new System.Drawing.Point(115, 217);
            this.lbl_TimeForMerging.Name = "lbl_TimeForMerging";
            this.lbl_TimeForMerging.Size = new System.Drawing.Size(41, 12);
            this.lbl_TimeForMerging.TabIndex = 53;
            this.lbl_TimeForMerging.Text = "00:00:00";
            this.lbl_TimeForMerging.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TimeForLoading
            // 
            this.lbl_TimeForLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_TimeForLoading.AutoSize = true;
            this.lbl_TimeForLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimeForLoading.Location = new System.Drawing.Point(115, 205);
            this.lbl_TimeForLoading.Name = "lbl_TimeForLoading";
            this.lbl_TimeForLoading.Size = new System.Drawing.Size(41, 12);
            this.lbl_TimeForLoading.TabIndex = 53;
            this.lbl_TimeForLoading.Text = "00:00:00";
            this.lbl_TimeForLoading.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TimeForIDCheck
            // 
            this.lbl_TimeForIDCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_TimeForIDCheck.AutoSize = true;
            this.lbl_TimeForIDCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimeForIDCheck.Location = new System.Drawing.Point(115, 229);
            this.lbl_TimeForIDCheck.Name = "lbl_TimeForIDCheck";
            this.lbl_TimeForIDCheck.Size = new System.Drawing.Size(41, 12);
            this.lbl_TimeForIDCheck.TabIndex = 54;
            this.lbl_TimeForIDCheck.Text = "00:00:00";
            this.lbl_TimeForIDCheck.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TimeCheckReferences
            // 
            this.lbl_TimeCheckReferences.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_TimeCheckReferences.AutoSize = true;
            this.lbl_TimeCheckReferences.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimeCheckReferences.Location = new System.Drawing.Point(115, 241);
            this.lbl_TimeCheckReferences.Name = "lbl_TimeCheckReferences";
            this.lbl_TimeCheckReferences.Size = new System.Drawing.Size(41, 12);
            this.lbl_TimeCheckReferences.TabIndex = 55;
            this.lbl_TimeCheckReferences.Text = "00:00:00";
            this.lbl_TimeCheckReferences.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TimeOverall
            // 
            this.lbl_TimeOverall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_TimeOverall.AutoSize = true;
            this.lbl_TimeOverall.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimeOverall.Location = new System.Drawing.Point(115, 193);
            this.lbl_TimeOverall.Name = "lbl_TimeOverall";
            this.lbl_TimeOverall.Size = new System.Drawing.Size(41, 12);
            this.lbl_TimeOverall.TabIndex = 51;
            this.lbl_TimeOverall.Text = "00:00:00";
            this.lbl_TimeOverall.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TimeShowTree
            // 
            this.lbl_TimeShowTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_TimeShowTree.AutoSize = true;
            this.lbl_TimeShowTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimeShowTree.Location = new System.Drawing.Point(115, 253);
            this.lbl_TimeShowTree.Name = "lbl_TimeShowTree";
            this.lbl_TimeShowTree.Size = new System.Drawing.Size(41, 12);
            this.lbl_TimeShowTree.TabIndex = 50;
            this.lbl_TimeShowTree.Text = "00:00:00";
            this.lbl_TimeShowTree.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_numberOfAllObjects
            // 
            this.lbl_numberOfAllObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_numberOfAllObjects.AutoSize = true;
            this.lbl_numberOfAllObjects.Location = new System.Drawing.Point(3, 85);
            this.lbl_numberOfAllObjects.Name = "lbl_numberOfAllObjects";
            this.lbl_numberOfAllObjects.Size = new System.Drawing.Size(71, 13);
            this.lbl_numberOfAllObjects.TabIndex = 64;
            this.lbl_numberOfAllObjects.Text = "Object count:";
            this.lbl_numberOfAllObjects.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_IDErrorNumber
            // 
            this.lbl_IDErrorNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_IDErrorNumber.AutoSize = true;
            this.lbl_IDErrorNumber.Location = new System.Drawing.Point(3, 43);
            this.lbl_IDErrorNumber.Name = "lbl_IDErrorNumber";
            this.lbl_IDErrorNumber.Size = new System.Drawing.Size(50, 13);
            this.lbl_IDErrorNumber.TabIndex = 56;
            this.lbl_IDErrorNumber.Text = "ID errors:";
            this.lbl_IDErrorNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_LinkNumber
            // 
            this.lbl_LinkNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_LinkNumber.AutoSize = true;
            this.lbl_LinkNumber.Location = new System.Drawing.Point(3, 176);
            this.lbl_LinkNumber.Name = "lbl_LinkNumber";
            this.lbl_LinkNumber.Size = new System.Drawing.Size(35, 13);
            this.lbl_LinkNumber.TabIndex = 63;
            this.lbl_LinkNumber.Text = "Links:";
            this.lbl_LinkNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_SUCNumber
            // 
            this.lbl_SUCNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_SUCNumber.AutoSize = true;
            this.lbl_SUCNumber.Location = new System.Drawing.Point(3, 163);
            this.lbl_SUCNumber.Name = "lbl_SUCNumber";
            this.lbl_SUCNumber.Size = new System.Drawing.Size(96, 13);
            this.lbl_SUCNumber.TabIndex = 62;
            this.lbl_SUCNumber.Text = "SystemUnitClasses";
            this.lbl_SUCNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_InterfaceClassNumber
            // 
            this.lbl_InterfaceClassNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_InterfaceClassNumber.AutoSize = true;
            this.lbl_InterfaceClassNumber.Location = new System.Drawing.Point(3, 150);
            this.lbl_InterfaceClassNumber.Name = "lbl_InterfaceClassNumber";
            this.lbl_InterfaceClassNumber.Size = new System.Drawing.Size(88, 13);
            this.lbl_InterfaceClassNumber.TabIndex = 61;
            this.lbl_InterfaceClassNumber.Text = "InterfaceClasses:";
            this.lbl_InterfaceClassNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_ErrorNumber
            // 
            this.lbl_ErrorNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_ErrorNumber.AutoSize = true;
            this.lbl_ErrorNumber.Location = new System.Drawing.Point(3, 56);
            this.lbl_ErrorNumber.Name = "lbl_ErrorNumber";
            this.lbl_ErrorNumber.Size = new System.Drawing.Size(69, 13);
            this.lbl_ErrorNumber.TabIndex = 57;
            this.lbl_ErrorNumber.Text = "Error Number";
            this.lbl_ErrorNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_RoleClassNumber
            // 
            this.lbl_RoleClassNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_RoleClassNumber.AutoSize = true;
            this.lbl_RoleClassNumber.Location = new System.Drawing.Point(4, 137);
            this.lbl_RoleClassNumber.Name = "lbl_RoleClassNumber";
            this.lbl_RoleClassNumber.Size = new System.Drawing.Size(68, 13);
            this.lbl_RoleClassNumber.TabIndex = 60;
            this.lbl_RoleClassNumber.Text = "RoleClasses:";
            this.lbl_RoleClassNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_IENumber
            // 
            this.lbl_IENumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_IENumber.AutoSize = true;
            this.lbl_IENumber.Location = new System.Drawing.Point(3, 98);
            this.lbl_IENumber.Name = "lbl_IENumber";
            this.lbl_IENumber.Size = new System.Drawing.Size(88, 13);
            this.lbl_IENumber.TabIndex = 59;
            this.lbl_IENumber.Text = "InternalElements:";
            this.lbl_IENumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_AttributeNumber
            // 
            this.lbl_AttributeNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_AttributeNumber.AutoSize = true;
            this.lbl_AttributeNumber.Location = new System.Drawing.Point(4, 124);
            this.lbl_AttributeNumber.Name = "lbl_AttributeNumber";
            this.lbl_AttributeNumber.Size = new System.Drawing.Size(54, 13);
            this.lbl_AttributeNumber.TabIndex = 58;
            this.lbl_AttributeNumber.Text = "Attributes:";
            this.lbl_AttributeNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_InterfaceNumber
            // 
            this.lbl_InterfaceNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_InterfaceNumber.AutoSize = true;
            this.lbl_InterfaceNumber.Location = new System.Drawing.Point(3, 111);
            this.lbl_InterfaceNumber.Name = "lbl_InterfaceNumber";
            this.lbl_InterfaceNumber.Size = new System.Drawing.Size(101, 13);
            this.lbl_InterfaceNumber.TabIndex = 58;
            this.lbl_InterfaceNumber.Text = "Interface Instances:";
            this.lbl_InterfaceNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 52;
            this.label6.Text = "Time for Others:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 53;
            this.label10.Text = "Time for Merging:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 12);
            this.label5.TabIndex = 53;
            this.label5.Text = "Time for Loading:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 12);
            this.label4.TabIndex = 54;
            this.label4.Text = "Time for ID Check:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 12);
            this.label3.TabIndex = 55;
            this.label3.Text = "Time for Reference Check:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 12);
            this.label2.TabIndex = 51;
            this.label2.Text = "Overall Time:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 12);
            this.label1.TabIndex = 50;
            this.label1.Text = "Time for Tree Presentation:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnMerge2
            // 
            this.btnMerge2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMerge2.Location = new System.Drawing.Point(1031, 187);
            this.btnMerge2.Name = "btnMerge2";
            this.btnMerge2.Size = new System.Drawing.Size(190, 30);
            this.btnMerge2.TabIndex = 46;
            this.btnMerge2.Text = "Merge Variant 2";
            this.btnMerge2.UseVisualStyleBackColor = true;
            this.btnMerge2.Click += new System.EventHandler(this.btnMerge2_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMerge.Location = new System.Drawing.Point(1031, 151);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(190, 30);
            this.btnMerge.TabIndex = 45;
            this.btnMerge.Text = "Merge and Reload";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // lbl_Split3
            // 
            this.lbl_Split3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Split3.AutoSize = true;
            this.lbl_Split3.Location = new System.Drawing.Point(6, 526);
            this.lbl_Split3.Name = "lbl_Split3";
            this.lbl_Split3.Size = new System.Drawing.Size(33, 13);
            this.lbl_Split3.TabIndex = 35;
            this.lbl_Split3.Text = "Split3";
            // 
            // btnSetSplitPoint
            // 
            this.btnSetSplitPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetSplitPoint.Location = new System.Drawing.Point(1031, 79);
            this.btnSetSplitPoint.Name = "btnSetSplitPoint";
            this.btnSetSplitPoint.Size = new System.Drawing.Size(190, 30);
            this.btnSetSplitPoint.TabIndex = 34;
            this.btnSetSplitPoint.Text = "Set SplitPoint at Selection";
            this.btnSetSplitPoint.UseVisualStyleBackColor = true;
            this.btnSetSplitPoint.Click += new System.EventHandler(this.btnSetSplitPoint_Click);
            // 
            // btnSplit3ToContentView
            // 
            this.btnSplit3ToContentView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSplit3ToContentView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSplit3ToContentView.Location = new System.Drawing.Point(950, 455);
            this.btnSplit3ToContentView.Name = "btnSplit3ToContentView";
            this.btnSplit3ToContentView.Size = new System.Drawing.Size(75, 23);
            this.btnSplit3ToContentView.TabIndex = 33;
            this.btnSplit3ToContentView.Text = "showAML";
            this.btnSplit3ToContentView.UseVisualStyleBackColor = true;
            this.btnSplit3ToContentView.Click += new System.EventHandler(this.btnSplit3ToContentView_Click);
            // 
            // treeView4
            // 
            this.treeView4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView4.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView4.Location = new System.Drawing.Point(745, 221);
            this.treeView4.Name = "treeView4";
            this.treeView4.Size = new System.Drawing.Size(281, 257);
            this.treeView4.TabIndex = 32;
            // 
            // btnMainToContentView
            // 
            this.btnMainToContentView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMainToContentView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainToContentView.Location = new System.Drawing.Point(951, 193);
            this.btnMainToContentView.Name = "btnMainToContentView";
            this.btnMainToContentView.Size = new System.Drawing.Size(75, 23);
            this.btnMainToContentView.TabIndex = 29;
            this.btnMainToContentView.Text = "showAML";
            this.btnMainToContentView.UseVisualStyleBackColor = true;
            this.btnMainToContentView.Click += new System.EventHandler(this.btnMainToContentView_Click);
            // 
            // btnSplit2ToContentView
            // 
            this.btnSplit2ToContentView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSplit2ToContentView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSplit2ToContentView.Location = new System.Drawing.Point(664, 455);
            this.btnSplit2ToContentView.Name = "btnSplit2ToContentView";
            this.btnSplit2ToContentView.Size = new System.Drawing.Size(75, 23);
            this.btnSplit2ToContentView.TabIndex = 31;
            this.btnSplit2ToContentView.Text = "showAML";
            this.btnSplit2ToContentView.UseVisualStyleBackColor = true;
            this.btnSplit2ToContentView.Click += new System.EventHandler(this.btnSplit2ToContentView_Click);
            // 
            // lbl_Split2
            // 
            this.lbl_Split2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Split2.AutoSize = true;
            this.lbl_Split2.Location = new System.Drawing.Point(6, 513);
            this.lbl_Split2.Name = "lbl_Split2";
            this.lbl_Split2.Size = new System.Drawing.Size(33, 13);
            this.lbl_Split2.TabIndex = 27;
            this.lbl_Split2.Text = "Split2";
            // 
            // btnSplit1ToContentView
            // 
            this.btnSplit1ToContentView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSplit1ToContentView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSplit1ToContentView.Location = new System.Drawing.Point(472, 455);
            this.btnSplit1ToContentView.Name = "btnSplit1ToContentView";
            this.btnSplit1ToContentView.Size = new System.Drawing.Size(75, 23);
            this.btnSplit1ToContentView.TabIndex = 30;
            this.btnSplit1ToContentView.Text = "showAML";
            this.btnSplit1ToContentView.UseVisualStyleBackColor = true;
            this.btnSplit1ToContentView.Click += new System.EventHandler(this.btnSplit1ToContentView_Click);
            // 
            // treeView3
            // 
            this.treeView3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView3.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView3.Location = new System.Drawing.Point(553, 221);
            this.treeView3.Name = "treeView3";
            this.treeView3.Size = new System.Drawing.Size(186, 257);
            this.treeView3.TabIndex = 26;
            // 
            // lbl_split1
            // 
            this.lbl_split1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_split1.AutoSize = true;
            this.lbl_split1.Location = new System.Drawing.Point(6, 500);
            this.lbl_split1.Name = "lbl_split1";
            this.lbl_split1.Size = new System.Drawing.Size(33, 13);
            this.lbl_split1.TabIndex = 28;
            this.lbl_split1.Text = "Split1";
            // 
            // treeView2
            // 
            this.treeView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView2.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView2.Location = new System.Drawing.Point(350, 221);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(197, 256);
            this.treeView2.TabIndex = 25;
            // 
            // lbl_Ori
            // 
            this.lbl_Ori.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Ori.AutoSize = true;
            this.lbl_Ori.Location = new System.Drawing.Point(6, 487);
            this.lbl_Ori.Name = "lbl_Ori";
            this.lbl_Ori.Size = new System.Drawing.Size(51, 13);
            this.lbl_Ori.TabIndex = 24;
            this.lbl_Ori.Text = "FileName";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Location = new System.Drawing.Point(350, 6);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(676, 210);
            this.treeView1.TabIndex = 23;
            // 
            // btn_CreateCAEXFile
            // 
            this.btn_CreateCAEXFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CreateCAEXFile.Location = new System.Drawing.Point(1032, 43);
            this.btn_CreateCAEXFile.Name = "btn_CreateCAEXFile";
            this.btn_CreateCAEXFile.Size = new System.Drawing.Size(190, 30);
            this.btn_CreateCAEXFile.TabIndex = 20;
            this.btn_CreateCAEXFile.Text = "Create AML File";
            this.btn_CreateCAEXFile.UseVisualStyleBackColor = true;
            this.btn_CreateCAEXFile.Click += new System.EventHandler(this.btn_CreateCAEXFile_Click);
            // 
            // btn_SplitCAEXFile
            // 
            this.btn_SplitCAEXFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SplitCAEXFile.Location = new System.Drawing.Point(1031, 115);
            this.btn_SplitCAEXFile.Name = "btn_SplitCAEXFile";
            this.btn_SplitCAEXFile.Size = new System.Drawing.Size(190, 30);
            this.btn_SplitCAEXFile.TabIndex = 21;
            this.btn_SplitCAEXFile.Text = "Split AML File at SplitPoints";
            this.btn_SplitCAEXFile.UseVisualStyleBackColor = true;
            this.btn_SplitCAEXFile.Click += new System.EventHandler(this.btn_SplitCAEXFile_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1166, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 30);
            this.button1.TabIndex = 22;
            this.button1.Text = "Reload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // btn_LoadCAEXFile
            // 
            this.btn_LoadCAEXFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_LoadCAEXFile.Location = new System.Drawing.Point(1032, 7);
            this.btn_LoadCAEXFile.Name = "btn_LoadCAEXFile";
            this.btn_LoadCAEXFile.Size = new System.Drawing.Size(128, 30);
            this.btn_LoadCAEXFile.TabIndex = 22;
            this.btn_LoadCAEXFile.Text = "Load AML File";
            this.btn_LoadCAEXFile.UseVisualStyleBackColor = true;
            this.btn_LoadCAEXFile.Click += new System.EventHandler(this.btn_LoadCAEXFile_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtAMLContent);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1230, 543);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "XML View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtAMLContent
            // 
            this.txtAMLContent.AcceptsReturn = true;
            this.txtAMLContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAMLContent.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAMLContent.Location = new System.Drawing.Point(6, 6);
            this.txtAMLContent.Multiline = true;
            this.txtAMLContent.Name = "txtAMLContent";
            this.txtAMLContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAMLContent.Size = new System.Drawing.Size(997, 531);
            this.txtAMLContent.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBox_ShowWarnings);
            this.tabPage3.Controls.Add(this.MergeCommentsListBox);
            this.tabPage3.Controls.Add(this.btn_Reload);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.lbl_PathHashTable);
            this.tabPage3.Controls.Add(this.btn_updateHashTables);
            this.tabPage3.Controls.Add(this.listBox_PathHashTable);
            this.tabPage3.Controls.Add(this.btn_StandardLibrary);
            this.tabPage3.Controls.Add(this.btn_repairIDError);
            this.tabPage3.Controls.Add(this.IDErrorListBox);
            this.tabPage3.Controls.Add(this.ReferenceErrorListBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1230, 543);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Error List";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkBox_ShowWarnings
            // 
            this.checkBox_ShowWarnings.AutoSize = true;
            this.checkBox_ShowWarnings.Location = new System.Drawing.Point(570, 10);
            this.checkBox_ShowWarnings.Name = "checkBox_ShowWarnings";
            this.checkBox_ShowWarnings.Size = new System.Drawing.Size(101, 17);
            this.checkBox_ShowWarnings.TabIndex = 28;
            this.checkBox_ShowWarnings.Text = "Show Warnings";
            this.checkBox_ShowWarnings.UseVisualStyleBackColor = true;
            this.checkBox_ShowWarnings.CheckedChanged += new System.EventHandler(this.checkBox_ShowWarnings_CheckedChanged);
            // 
            // MergeCommentsListBox
            // 
            this.MergeCommentsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MergeCommentsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MergeCommentsListBox.FormattingEnabled = true;
            this.MergeCommentsListBox.ItemHeight = 12;
            this.MergeCommentsListBox.Location = new System.Drawing.Point(200, 204);
            this.MergeCommentsListBox.Name = "MergeCommentsListBox";
            this.MergeCommentsListBox.Size = new System.Drawing.Size(1021, 100);
            this.MergeCommentsListBox.TabIndex = 27;
            // 
            // btn_Reload
            // 
            this.btn_Reload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Reload.Enabled = false;
            this.btn_Reload.Location = new System.Drawing.Point(1116, 3);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(105, 28);
            this.btn_Reload.TabIndex = 26;
            this.btn_Reload.Text = "Reload File";
            this.btn_Reload.UseVisualStyleBackColor = true;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "List of Merge comments";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(197, 315);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "List of reference errors";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "List of ID errors";
            // 
            // lbl_PathHashTable
            // 
            this.lbl_PathHashTable.AutoSize = true;
            this.lbl_PathHashTable.Location = new System.Drawing.Point(6, 10);
            this.lbl_PathHashTable.Name = "lbl_PathHashTable";
            this.lbl_PathHashTable.Size = new System.Drawing.Size(81, 13);
            this.lbl_PathHashTable.TabIndex = 25;
            this.lbl_PathHashTable.Text = "PathHashTable";
            // 
            // btn_updateHashTables
            // 
            this.btn_updateHashTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_updateHashTables.Location = new System.Drawing.Point(136, 3);
            this.btn_updateHashTables.Name = "btn_updateHashTables";
            this.btn_updateHashTables.Size = new System.Drawing.Size(59, 26);
            this.btn_updateHashTables.TabIndex = 20;
            this.btn_updateHashTables.Text = "Update";
            this.btn_updateHashTables.UseVisualStyleBackColor = true;
            this.btn_updateHashTables.Click += new System.EventHandler(this.btn_updateHashTables_Click);
            // 
            // listBox_PathHashTable
            // 
            this.listBox_PathHashTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_PathHashTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_PathHashTable.FormattingEnabled = true;
            this.listBox_PathHashTable.Location = new System.Drawing.Point(9, 32);
            this.listBox_PathHashTable.Name = "listBox_PathHashTable";
            this.listBox_PathHashTable.Size = new System.Drawing.Size(186, 498);
            this.listBox_PathHashTable.TabIndex = 19;
            // 
            // btn_StandardLibrary
            // 
            this.btn_StandardLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_StandardLibrary.Location = new System.Drawing.Point(888, 3);
            this.btn_StandardLibrary.Name = "btn_StandardLibrary";
            this.btn_StandardLibrary.Size = new System.Drawing.Size(222, 28);
            this.btn_StandardLibrary.TabIndex = 16;
            this.btn_StandardLibrary.Text = "Label as AutomationML Standard Library";
            this.btn_StandardLibrary.UseVisualStyleBackColor = true;
            this.btn_StandardLibrary.Click += new System.EventHandler(this.btn_StandardLibrary_Click);
            // 
            // btn_repairIDError
            // 
            this.btn_repairIDError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_repairIDError.Enabled = false;
            this.btn_repairIDError.Location = new System.Drawing.Point(723, 3);
            this.btn_repairIDError.Name = "btn_repairIDError";
            this.btn_repairIDError.Size = new System.Drawing.Size(159, 28);
            this.btn_repairIDError.TabIndex = 16;
            this.btn_repairIDError.Text = "Repair and save AML file";
            this.btn_repairIDError.UseVisualStyleBackColor = true;
            this.btn_repairIDError.Click += new System.EventHandler(this.btn_repairIDError_Click);
            // 
            // IDErrorListBox
            // 
            this.IDErrorListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IDErrorListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDErrorListBox.FormattingEnabled = true;
            this.IDErrorListBox.ItemHeight = 12;
            this.IDErrorListBox.Location = new System.Drawing.Point(201, 33);
            this.IDErrorListBox.Name = "IDErrorListBox";
            this.IDErrorListBox.Size = new System.Drawing.Size(1022, 136);
            this.IDErrorListBox.TabIndex = 15;
            // 
            // ReferenceErrorListBox
            // 
            this.ReferenceErrorListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReferenceErrorListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReferenceErrorListBox.FormattingEnabled = true;
            this.ReferenceErrorListBox.ItemHeight = 12;
            this.ReferenceErrorListBox.Location = new System.Drawing.Point(200, 331);
            this.ReferenceErrorListBox.Name = "ReferenceErrorListBox";
            this.ReferenceErrorListBox.Size = new System.Drawing.Size(1021, 196);
            this.ReferenceErrorListBox.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 582);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "AutomationML Validation Tool";
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findAttributeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuCreateLink;
        private System.Windows.Forms.ToolStripMenuItem setSplitPointToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lbl_Split3;
        private System.Windows.Forms.Button btnSetSplitPoint;
        private System.Windows.Forms.Button btnSplit3ToContentView;
        private System.Windows.Forms.TreeView treeView4;
        private System.Windows.Forms.Button btnMainToContentView;
        private System.Windows.Forms.Button btnSplit2ToContentView;
        private System.Windows.Forms.Label lbl_Split2;
        private System.Windows.Forms.Button btnSplit1ToContentView;
        private System.Windows.Forms.TreeView treeView3;
        private System.Windows.Forms.Label lbl_split1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Label lbl_Ori;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btn_CreateCAEXFile;
        private System.Windows.Forms.Button btn_SplitCAEXFile;
        private System.Windows.Forms.Button btn_LoadCAEXFile;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtAMLContent;
        private System.Windows.Forms.Button btnMerge2;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox ReferenceErrorListBox;
        private System.Windows.Forms.ListBox IDErrorListBox;
        private System.Windows.Forms.Button btn_repairIDError;
        private System.Windows.Forms.Button btn_updateHashTables;
        private System.Windows.Forms.ListBox listBox_PathHashTable;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_PathHashTable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_TimeOthers;
        private System.Windows.Forms.Label lbl_TimeForLoading;
        private System.Windows.Forms.Label lbl_TimeForIDCheck;
        private System.Windows.Forms.Label lbl_TimeCheckReferences;
        private System.Windows.Forms.Label lbl_TimeOverall;
        private System.Windows.Forms.Label lbl_TimeShowTree;
        private System.Windows.Forms.Label lbl_numberOfAllObjects;
        private System.Windows.Forms.Label lbl_IDErrorNumber;
        private System.Windows.Forms.Label lbl_LinkNumber;
        private System.Windows.Forms.Label lbl_SUCNumber;
        private System.Windows.Forms.Label lbl_InterfaceClassNumber;
        private System.Windows.Forms.Label lbl_ErrorNumber;
        private System.Windows.Forms.Label lbl_RoleClassNumber;
        private System.Windows.Forms.Label lbl_IENumber;
        private System.Windows.Forms.Label lbl_InterfaceNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_TimeForMerging;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_AttributeNumber;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TreeView treeView_Pathes;
        private System.Windows.Forms.Label lbl_FileRequiredMerging;
        private System.Windows.Forms.ListBox MergeCommentsListBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_StandardLibrary;
        private System.Windows.Forms.Label lbl_Source;
        private System.Windows.Forms.CheckBox checkBox_ShowWarnings;
    }
}

