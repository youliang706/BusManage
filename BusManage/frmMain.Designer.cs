namespace BusManage
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            DevExpress.XtraEditors.TileItemElement tileItemElement24 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement25 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement26 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement27 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement28 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement29 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement21 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement23 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement22 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement30 = new DevExpress.XtraEditors.TileItemElement();
            this.mnuQueue = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuQueueIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQueueOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrQueue = new System.Windows.Forms.Timer(this.components);
            this.mnuSch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSchAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSchModify = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSchDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuChangeBus = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTmrChange = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTmrEqual = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSchSwap = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrLsnr = new System.Windows.Forms.Timer(this.components);
            this.colUp_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.sStrip = new System.Windows.Forms.StatusStrip();
            this.tssLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspRate = new System.Windows.Forms.ToolStripProgressBar();
            this.tssRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSpin = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssStsatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlCase = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.tabList = new DevExpress.XtraTab.XtraTabControl();
            this.tabPg_Up = new DevExpress.XtraTab.XtraTabPage();
            this.gridUp_Sch = new DevExpress.XtraGrid.GridControl();
            this.dgvUp_Sch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPg_Dn = new DevExpress.XtraTab.XtraTabPage();
            this.gridDn_Sch = new DevExpress.XtraGrid.GridControl();
            this.dgvDn_Sch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblLine = new System.Windows.Forms.Label();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.pnlQueue = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlUp = new System.Windows.Forms.Panel();
            this.lblUpQueue = new DevExpress.XtraEditors.LabelControl();
            this.gridUp = new DevExpress.XtraGrid.GridControl();
            this.dgvUp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlDn = new System.Windows.Forms.Panel();
            this.gridDn = new DevExpress.XtraGrid.GridControl();
            this.dgvDn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblDnQueue = new DevExpress.XtraEditors.LabelControl();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.navCategorySys = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.tniRepair = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tniReport = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tniOprRecord = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tniUnOprRecord = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tniSchedule = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tniBusDrivers = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.navCategoryExe = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.tniMapMonitor = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tniPlayBack = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tniLineGraph = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tileNavSubItem1 = new DevExpress.XtraBars.Navigation.TileNavSubItem();
            this.mnuQueue.SuspendLayout();
            this.mnuSch.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            this.sStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCase)).BeginInit();
            this.pnlCase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabList)).BeginInit();
            this.tabList.SuspendLayout();
            this.tabPg_Up.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUp_Sch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUp_Sch)).BeginInit();
            this.tabPg_Dn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDn_Sch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDn_Sch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlQueue)).BeginInit();
            this.pnlQueue.SuspendLayout();
            this.pnlUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUp)).BeginInit();
            this.pnlDn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDn)).BeginInit();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuQueue
            // 
            this.mnuQueue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQueueIn,
            this.mnuQueueOut});
            this.mnuQueue.Name = "contextMenuStrip1";
            this.mnuQueue.Size = new System.Drawing.Size(125, 48);
            this.mnuQueue.Opening += new System.ComponentModel.CancelEventHandler(this.mnuQueue_Opening);
            this.mnuQueue.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuQueue_ItemClicked);
            // 
            // mnuQueueIn
            // 
            this.mnuQueueIn.Name = "mnuQueueIn";
            this.mnuQueueIn.Size = new System.Drawing.Size(124, 22);
            this.mnuQueueIn.Text = "添加进站";
            // 
            // mnuQueueOut
            // 
            this.mnuQueueOut.Name = "mnuQueueOut";
            this.mnuQueueOut.Size = new System.Drawing.Size(124, 22);
            this.mnuQueueOut.Text = "发出车辆";
            // 
            // tmrQueue
            // 
            this.tmrQueue.Tick += new System.EventHandler(this.tmrQueue_Tick);
            // 
            // mnuSch
            // 
            this.mnuSch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSchAdd,
            this.mnuSchModify,
            this.mnuSchDelete,
            this.toolStripSeparator1,
            this.mnuChangeBus,
            this.mnuTmrChange,
            this.mnuTmrEqual,
            this.mnuSchSwap});
            this.mnuSch.Name = "mnuSch";
            this.mnuSch.Size = new System.Drawing.Size(125, 164);
            this.mnuSch.Opening += new System.ComponentModel.CancelEventHandler(this.mnuSch_Opening);
            this.mnuSch.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuSch_ItemClicked);
            // 
            // mnuSchAdd
            // 
            this.mnuSchAdd.Name = "mnuSchAdd";
            this.mnuSchAdd.Size = new System.Drawing.Size(124, 22);
            this.mnuSchAdd.Text = "添加";
            // 
            // mnuSchModify
            // 
            this.mnuSchModify.Name = "mnuSchModify";
            this.mnuSchModify.Size = new System.Drawing.Size(124, 22);
            this.mnuSchModify.Text = "修改";
            // 
            // mnuSchDelete
            // 
            this.mnuSchDelete.Name = "mnuSchDelete";
            this.mnuSchDelete.Size = new System.Drawing.Size(124, 22);
            this.mnuSchDelete.Text = "删除";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // mnuChangeBus
            // 
            this.mnuChangeBus.Name = "mnuChangeBus";
            this.mnuChangeBus.Size = new System.Drawing.Size(124, 22);
            this.mnuChangeBus.Text = "换车";
            // 
            // mnuTmrChange
            // 
            this.mnuTmrChange.Name = "mnuTmrChange";
            this.mnuTmrChange.Size = new System.Drawing.Size(124, 22);
            this.mnuTmrChange.Text = "批量调整";
            // 
            // mnuTmrEqual
            // 
            this.mnuTmrEqual.Name = "mnuTmrEqual";
            this.mnuTmrEqual.Size = new System.Drawing.Size(124, 22);
            this.mnuTmrEqual.Text = "重新分配";
            // 
            // mnuSchSwap
            // 
            this.mnuSchSwap.Name = "mnuSchSwap";
            this.mnuSchSwap.Size = new System.Drawing.Size(124, 22);
            this.mnuSchSwap.Text = "上下对调";
            // 
            // tmrLsnr
            // 
            this.tmrLsnr.Tick += new System.EventHandler(this.tmrLsnr_Tick);
            // 
            // colUp_No
            // 
            this.colUp_No.Caption = "车次";
            this.colUp_No.Name = "colUp_No";
            this.colUp_No.Visible = true;
            this.colUp_No.VisibleIndex = 0;
            this.colUp_No.Width = 284;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.sStrip);
            this.xtraScrollableControl1.Controls.Add(this.pnlCase);
            this.xtraScrollableControl1.Controls.Add(this.pnlTitle);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(944, 561);
            this.xtraScrollableControl1.TabIndex = 9;
            // 
            // sStrip
            // 
            this.sStrip.AutoSize = false;
            this.sStrip.BackColor = System.Drawing.Color.White;
            this.sStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLeft,
            this.tspRate,
            this.tssRate,
            this.tssSpin,
            this.tssStsatus,
            this.tssRight});
            this.sStrip.Location = new System.Drawing.Point(0, 531);
            this.sStrip.Name = "sStrip";
            this.sStrip.Size = new System.Drawing.Size(944, 30);
            this.sStrip.TabIndex = 1;
            // 
            // tssLeft
            // 
            this.tssLeft.Name = "tssLeft";
            this.tssLeft.Size = new System.Drawing.Size(16, 25);
            this.tssLeft.Text = "  ";
            // 
            // tspRate
            // 
            this.tspRate.AutoSize = false;
            this.tspRate.Margin = new System.Windows.Forms.Padding(1, 6, 1, 6);
            this.tspRate.Name = "tspRate";
            this.tspRate.Size = new System.Drawing.Size(200, 18);
            this.tspRate.Value = 50;
            // 
            // tssRate
            // 
            this.tssRate.AutoSize = false;
            this.tssRate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssRate.Name = "tssRate";
            this.tssRate.Size = new System.Drawing.Size(120, 25);
            this.tssRate.Text = "趟次完成率：0%";
            this.tssRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tssSpin
            // 
            this.tssSpin.Name = "tssSpin";
            this.tssSpin.Size = new System.Drawing.Size(479, 25);
            this.tssSpin.Spring = true;
            // 
            // tssStsatus
            // 
            this.tssStsatus.Image = ((System.Drawing.Image)(resources.GetObject("tssStsatus.Image")));
            this.tssStsatus.Name = "tssStsatus";
            this.tssStsatus.Size = new System.Drawing.Size(96, 25);
            this.tssStsatus.Text = "中心连接正常";
            // 
            // tssRight
            // 
            this.tssRight.Name = "tssRight";
            this.tssRight.Size = new System.Drawing.Size(16, 25);
            this.tssRight.Text = "  ";
            // 
            // pnlCase
            // 
            this.pnlCase.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlCase.Appearance.Options.UseBackColor = true;
            this.pnlCase.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.pnlCase.Location = new System.Drawing.Point(0, 54);
            this.pnlCase.Name = "pnlCase";
            this.pnlCase.Panel1.Controls.Add(this.btnAdd);
            this.pnlCase.Panel1.Controls.Add(this.tabList);
            this.pnlCase.Panel1.Controls.Add(this.lblLine);
            this.pnlCase.Panel1.Controls.Add(this.cboLine);
            this.pnlCase.Panel1.Text = "Panel1";
            this.pnlCase.Panel2.Controls.Add(this.pnlQueue);
            this.pnlCase.Panel2.Text = "Panel2";
            this.pnlCase.Size = new System.Drawing.Size(944, 475);
            this.pnlCase.SplitterPosition = 404;
            this.pnlCase.TabIndex = 0;
            this.pnlCase.Text = "splitContainerControl1";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(478, 40);
            this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 22);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabList
            // 
            this.tabList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabList.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabList.Appearance.Options.UseFont = true;
            this.tabList.Location = new System.Drawing.Point(6, 40);
            this.tabList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabList.Name = "tabList";
            this.tabList.SelectedTabPage = this.tabPg_Up;
            this.tabList.Size = new System.Drawing.Size(531, 433);
            this.tabList.TabIndex = 2;
            this.tabList.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPg_Up,
            this.tabPg_Dn});
            this.tabList.TabPageWidth = 50;
            this.tabList.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabList_SelectedPageChanged);
            // 
            // tabPg_Up
            // 
            this.tabPg_Up.Appearance.Header.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPg_Up.Appearance.Header.Options.UseFont = true;
            this.tabPg_Up.Appearance.HeaderActive.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPg_Up.Appearance.HeaderActive.Options.UseFont = true;
            this.tabPg_Up.Appearance.HeaderDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPg_Up.Appearance.HeaderDisabled.Options.UseFont = true;
            this.tabPg_Up.Appearance.HeaderHotTracked.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPg_Up.Appearance.HeaderHotTracked.Options.UseFont = true;
            this.tabPg_Up.Controls.Add(this.gridUp_Sch);
            this.tabPg_Up.Image = ((System.Drawing.Image)(resources.GetObject("tabPg_Up.Image")));
            this.tabPg_Up.Name = "tabPg_Up";
            this.tabPg_Up.Size = new System.Drawing.Size(525, 401);
            this.tabPg_Up.Text = "上行";
            // 
            // gridUp_Sch
            // 
            this.gridUp_Sch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUp_Sch.ContextMenuStrip = this.mnuSch;
            this.gridUp_Sch.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridUp_Sch.Location = new System.Drawing.Point(6, 7);
            this.gridUp_Sch.MainView = this.dgvUp_Sch;
            this.gridUp_Sch.Name = "gridUp_Sch";
            this.gridUp_Sch.Size = new System.Drawing.Size(513, 388);
            this.gridUp_Sch.TabIndex = 0;
            this.gridUp_Sch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvUp_Sch});
            // 
            // dgvUp_Sch
            // 
            this.dgvUp_Sch.GridControl = this.gridUp_Sch;
            this.dgvUp_Sch.IndicatorWidth = 32;
            this.dgvUp_Sch.Name = "dgvUp_Sch";
            this.dgvUp_Sch.OptionsView.ShowIndicator = false;
            this.dgvUp_Sch.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.dgvUp_Sch_CustomDrawCell);
            this.dgvUp_Sch.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.dgvUp_Sch_RowCellStyle);
            this.dgvUp_Sch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvUp_Sch_MouseDown);
            this.dgvUp_Sch.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvUp_Sch_MouseMove);
            // 
            // tabPg_Dn
            // 
            this.tabPg_Dn.Appearance.Header.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPg_Dn.Appearance.Header.Options.UseFont = true;
            this.tabPg_Dn.Appearance.HeaderActive.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPg_Dn.Appearance.HeaderActive.Options.UseFont = true;
            this.tabPg_Dn.Appearance.HeaderDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPg_Dn.Appearance.HeaderDisabled.Options.UseFont = true;
            this.tabPg_Dn.Appearance.HeaderHotTracked.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPg_Dn.Appearance.HeaderHotTracked.Options.UseFont = true;
            this.tabPg_Dn.Controls.Add(this.gridDn_Sch);
            this.tabPg_Dn.Image = ((System.Drawing.Image)(resources.GetObject("tabPg_Dn.Image")));
            this.tabPg_Dn.Name = "tabPg_Dn";
            this.tabPg_Dn.Size = new System.Drawing.Size(525, 401);
            this.tabPg_Dn.Text = "下行";
            // 
            // gridDn_Sch
            // 
            this.gridDn_Sch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDn_Sch.ContextMenuStrip = this.mnuSch;
            this.gridDn_Sch.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridDn_Sch.Location = new System.Drawing.Point(6, 7);
            this.gridDn_Sch.MainView = this.dgvDn_Sch;
            this.gridDn_Sch.Name = "gridDn_Sch";
            this.gridDn_Sch.Size = new System.Drawing.Size(513, 388);
            this.gridDn_Sch.TabIndex = 13;
            this.gridDn_Sch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDn_Sch});
            // 
            // dgvDn_Sch
            // 
            this.dgvDn_Sch.GridControl = this.gridDn_Sch;
            this.dgvDn_Sch.IndicatorWidth = 32;
            this.dgvDn_Sch.Name = "dgvDn_Sch";
            this.dgvDn_Sch.OptionsView.ShowIndicator = false;
            this.dgvDn_Sch.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.dgvDn_Sch_CustomDrawCell);
            this.dgvDn_Sch.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.dgvDn_Sch_RowCellStyle);
            this.dgvDn_Sch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDn_Sch_MouseDown);
            this.dgvDn_Sch.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvDn_Sch_MouseMove);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.BackColor = System.Drawing.Color.Transparent;
            this.lblLine.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLine.Location = new System.Drawing.Point(12, 12);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(44, 17);
            this.lblLine.TabIndex = 0;
            this.lblLine.Text = "线路：";
            // 
            // cboLine
            // 
            this.cboLine.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Location = new System.Drawing.Point(62, 9);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(167, 25);
            this.cboLine.TabIndex = 1;
            this.cboLine.SelectedIndexChanged += new System.EventHandler(this.cboLine_SelectedIndexChanged);
            // 
            // pnlQueue
            // 
            this.pnlQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQueue.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.pnlQueue.Horizontal = false;
            this.pnlQueue.Location = new System.Drawing.Point(0, 0);
            this.pnlQueue.Name = "pnlQueue";
            this.pnlQueue.Panel1.Controls.Add(this.pnlUp);
            this.pnlQueue.Panel1.Text = "Panel1";
            this.pnlQueue.Panel2.Controls.Add(this.pnlDn);
            this.pnlQueue.Panel2.Text = "Panel2";
            this.pnlQueue.Size = new System.Drawing.Size(404, 475);
            this.pnlQueue.SplitterPosition = 254;
            this.pnlQueue.TabIndex = 6;
            this.pnlQueue.Text = "splitContainerControl2";
            // 
            // pnlUp
            // 
            this.pnlUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(203)))), ((int)(((byte)(156)))));
            this.pnlUp.Controls.Add(this.lblUpQueue);
            this.pnlUp.Controls.Add(this.gridUp);
            this.pnlUp.Location = new System.Drawing.Point(0, 9);
            this.pnlUp.Name = "pnlUp";
            this.pnlUp.Size = new System.Drawing.Size(398, 244);
            this.pnlUp.TabIndex = 0;
            this.pnlUp.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlUp_Paint);
            // 
            // lblUpQueue
            // 
            this.lblUpQueue.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpQueue.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblUpQueue.Location = new System.Drawing.Point(9, 9);
            this.lblUpQueue.Name = "lblUpQueue";
            this.lblUpQueue.Size = new System.Drawing.Size(48, 17);
            this.lblUpQueue.TabIndex = 0;
            this.lblUpQueue.Text = "上行队列";
            // 
            // gridUp
            // 
            this.gridUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUp.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridUp.Location = new System.Drawing.Point(0, 32);
            this.gridUp.MainView = this.dgvUp;
            this.gridUp.Name = "gridUp";
            this.gridUp.Size = new System.Drawing.Size(398, 212);
            this.gridUp.TabIndex = 1;
            this.gridUp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvUp});
            // 
            // dgvUp
            // 
            this.dgvUp.GridControl = this.gridUp;
            this.dgvUp.Name = "dgvUp";
            this.dgvUp.OptionsView.ShowColumnHeaders = false;
            this.dgvUp.OptionsView.ShowGroupPanel = false;
            this.dgvUp.OptionsView.ShowIndicator = false;
            this.dgvUp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvUp_MouseMove);
            // 
            // pnlDn
            // 
            this.pnlDn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(149)))), ((int)(((byte)(226)))));
            this.pnlDn.Controls.Add(this.gridDn);
            this.pnlDn.Controls.Add(this.lblDnQueue);
            this.pnlDn.Location = new System.Drawing.Point(0, 1);
            this.pnlDn.Name = "pnlDn";
            this.pnlDn.Size = new System.Drawing.Size(398, 209);
            this.pnlDn.TabIndex = 0;
            this.pnlDn.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDn_Paint);
            // 
            // gridDn
            // 
            this.gridDn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDn.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridDn.Location = new System.Drawing.Point(0, 32);
            this.gridDn.MainView = this.dgvDn;
            this.gridDn.Name = "gridDn";
            this.gridDn.Size = new System.Drawing.Size(398, 177);
            this.gridDn.TabIndex = 1;
            this.gridDn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDn});
            // 
            // dgvDn
            // 
            this.dgvDn.GridControl = this.gridDn;
            this.dgvDn.Name = "dgvDn";
            this.dgvDn.OptionsView.ShowColumnHeaders = false;
            this.dgvDn.OptionsView.ShowGroupPanel = false;
            this.dgvDn.OptionsView.ShowIndicator = false;
            this.dgvDn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvDn_MouseMove);
            // 
            // lblDnQueue
            // 
            this.lblDnQueue.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDnQueue.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblDnQueue.Location = new System.Drawing.Point(9, 9);
            this.lblDnQueue.Name = "lblDnQueue";
            this.lblDnQueue.Size = new System.Drawing.Size(48, 17);
            this.lblDnQueue.TabIndex = 0;
            this.lblDnQueue.Text = "下行队列";
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(58)))));
            this.pnlTitle.Controls.Add(this.picTitle);
            this.pnlTitle.Controls.Add(this.tileNavPane1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(944, 54);
            this.pnlTitle.TabIndex = 3;
            // 
            // picTitle
            // 
            this.picTitle.BackColor = System.Drawing.Color.Transparent;
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(16, 16);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(180, 25);
            this.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTitle.TabIndex = 0;
            this.picTitle.TabStop = false;
            // 
            // tileNavPane1
            // 
            this.tileNavPane1.AllowGlyphSkinning = true;
            this.tileNavPane1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.tileNavPane1.Appearance.Options.UseBackColor = true;
            this.tileNavPane1.BackColor = System.Drawing.Color.Transparent;
            this.tileNavPane1.ButtonPadding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.tileNavPane1.Buttons.Add(this.navCategoryExe);
            this.tileNavPane1.Buttons.Add(this.navCategorySys);
            // 
            // tileNavCategory1
            // 
            this.tileNavPane1.DefaultCategory.Name = "tileNavCategory1";
            this.tileNavPane1.DefaultCategory.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.DefaultCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.tileNavPane1.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane1.DefaultCategory.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileNavPane1.Location = new System.Drawing.Point(0, 0);
            this.tileNavPane1.Name = "tileNavPane1";
            this.tileNavPane1.OptionsPrimaryDropDown.AppearanceItem.Hovered.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tileNavPane1.OptionsPrimaryDropDown.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileNavPane1.OptionsPrimaryDropDown.AppearanceItem.Normal.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tileNavPane1.OptionsPrimaryDropDown.AppearanceItem.Normal.Options.UseFont = true;
            this.tileNavPane1.OptionsPrimaryDropDown.AppearanceItem.Pressed.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tileNavPane1.OptionsPrimaryDropDown.AppearanceItem.Pressed.Options.UseFont = true;
            this.tileNavPane1.OptionsPrimaryDropDown.AppearanceItem.Selected.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tileNavPane1.OptionsPrimaryDropDown.AppearanceItem.Selected.Options.UseFont = true;
            this.tileNavPane1.OptionsPrimaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.OptionsPrimaryDropDown.ShowItemShadow = DevExpress.Utils.DefaultBoolean.True;
            this.tileNavPane1.OptionsSecondaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.Size = new System.Drawing.Size(944, 54);
            this.tileNavPane1.TabIndex = 0;
            this.tileNavPane1.Text = "tileNavPane1";
            // 
            // navCategorySys
            // 
            this.navCategorySys.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navCategorySys.Caption = "";
            this.navCategorySys.Glyph = ((System.Drawing.Image)(resources.GetObject("navCategorySys.Glyph")));
            // 
            // tniRepair
            // 
            this.tniRepair.Caption = "tniRepair";
            this.tniRepair.Name = "tniRepair";
            this.tniRepair.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tniRepair.OwnerCollection = this.navCategorySys.Items;
            // 
            // 
            // 
            this.tniRepair.Tile.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(62)))), ((int)(((byte)(191)))));
            this.tniRepair.Tile.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tniRepair.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement24.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement24.Image")));
            tileItemElement24.Text = "维修登记";
            tileItemElement24.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            this.tniRepair.Tile.Elements.Add(tileItemElement24);
            this.tniRepair.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tniRepair.Tile.Name = "tniRepair";
            this.navCategorySys.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.tniRepair,
            this.tniReport,
            this.tniOprRecord,
            this.tniUnOprRecord,
            this.tniSchedule,
            this.tniBusDrivers});
            this.navCategorySys.Name = "navCategorySys";
            this.navCategorySys.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.navCategorySys.OwnerCollection = null;
            // 
            // 
            // 
            this.navCategorySys.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.navCategorySys.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            // 
            // tniReport
            // 
            this.tniReport.Caption = "tniReport";
            this.tniReport.Name = "tniReport";
            this.tniReport.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tniReport.OwnerCollection = this.navCategorySys.Items;
            // 
            // 
            // 
            this.tniReport.Tile.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(193)))), ((int)(((byte)(59)))));
            this.tniReport.Tile.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tniReport.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement25.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement25.Image")));
            tileItemElement25.Text = "行车日报";
            tileItemElement25.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            this.tniReport.Tile.Elements.Add(tileItemElement25);
            this.tniReport.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tniReport.Tile.Name = "tniReport";
            // 
            // tniOprRecord
            // 
            this.tniOprRecord.Caption = "tniOprRecord";
            this.tniOprRecord.Name = "tniOprRecord";
            this.tniOprRecord.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tniOprRecord.OwnerCollection = this.navCategorySys.Items;
            // 
            // 
            // 
            this.tniOprRecord.Tile.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(140)))), ((int)(((byte)(239)))));
            this.tniOprRecord.Tile.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tniOprRecord.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement26.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement26.Image")));
            tileItemElement26.Text = "营运路单";
            tileItemElement26.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            this.tniOprRecord.Tile.Elements.Add(tileItemElement26);
            this.tniOprRecord.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tniOprRecord.Tile.Name = "tniOprRecord";
            // 
            // tniUnOprRecord
            // 
            this.tniUnOprRecord.Caption = "tniUnOprRecord";
            this.tniUnOprRecord.Name = "tniUnOprRecord";
            this.tniUnOprRecord.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tniUnOprRecord.OwnerCollection = this.navCategorySys.Items;
            // 
            // 
            // 
            this.tniUnOprRecord.Tile.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.tniUnOprRecord.Tile.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tniUnOprRecord.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement27.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement27.Image")));
            tileItemElement27.Text = "非营运路单";
            tileItemElement27.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            this.tniUnOprRecord.Tile.Elements.Add(tileItemElement27);
            this.tniUnOprRecord.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tniUnOprRecord.Tile.Name = "tniUnOprRecord";
            // 
            // tniSchedule
            // 
            this.tniSchedule.Caption = "tniSchedule";
            this.tniSchedule.Name = "tniSchedule";
            this.tniSchedule.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tniSchedule.OwnerCollection = this.navCategorySys.Items;
            // 
            // 
            // 
            this.tniSchedule.Tile.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(29)))), ((int)(((byte)(71)))));
            this.tniSchedule.Tile.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tniSchedule.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement28.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement28.Image")));
            tileItemElement28.Text = "线路排班";
            tileItemElement28.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            this.tniSchedule.Tile.Elements.Add(tileItemElement28);
            this.tniSchedule.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tniSchedule.Tile.Name = "tniSchedule";
            // 
            // tniBusDrivers
            // 
            this.tniBusDrivers.Caption = "tniBusDrivers";
            this.tniBusDrivers.Name = "tniBusDrivers";
            this.tniBusDrivers.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tniBusDrivers.OwnerCollection = this.navCategorySys.Items;
            // 
            // 
            // 
            this.tniBusDrivers.Tile.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(75)))));
            this.tniBusDrivers.Tile.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tniBusDrivers.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement29.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement29.Image")));
            tileItemElement29.Text = "车辆人员配置";
            tileItemElement29.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            this.tniBusDrivers.Tile.Elements.Add(tileItemElement29);
            this.tniBusDrivers.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tniBusDrivers.Tile.Name = "tniBusDrivers";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            // 
            // navCategoryExe
            // 
            this.navCategoryExe.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.navCategoryExe.Caption = "";
            this.navCategoryExe.Glyph = ((System.Drawing.Image)(resources.GetObject("navCategoryExe.Glyph")));
            // 
            // tniMapMonitor
            // 
            this.tniMapMonitor.Caption = "tniMapMonitor";
            this.tniMapMonitor.Name = "tniMapMonitor";
            this.tniMapMonitor.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tniMapMonitor.OwnerCollection = this.navCategoryExe.Items;
            // 
            // 
            // 
            this.tniMapMonitor.Tile.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(202)))), ((int)(((byte)(5)))));
            this.tniMapMonitor.Tile.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tniMapMonitor.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement21.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement21.Image")));
            tileItemElement21.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tileItemElement21.Text = "地图监控";
            this.tniMapMonitor.Tile.Elements.Add(tileItemElement21);
            this.tniMapMonitor.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tniMapMonitor.Tile.Name = "tniMapMonitor";
            // 
            // tniPlayBack
            // 
            this.tniPlayBack.Caption = "tniPlayBack";
            this.tniPlayBack.Name = "tniPlayBack";
            this.tniPlayBack.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tniPlayBack.OwnerCollection = this.navCategoryExe.Items;
            // 
            // 
            // 
            this.tniPlayBack.Tile.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(193)))), ((int)(((byte)(224)))));
            this.tniPlayBack.Tile.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tniPlayBack.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement23.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement23.Image")));
            tileItemElement23.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tileItemElement23.Text = "轨迹回放";
            this.tniPlayBack.Tile.Elements.Add(tileItemElement23);
            this.tniPlayBack.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tniPlayBack.Tile.Name = "tniPlayBack";
            this.navCategoryExe.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.tniMapMonitor,
            this.tniLineGraph,
            this.tniPlayBack});
            this.navCategoryExe.Name = "navCategoryExe";
            this.navCategoryExe.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.navCategoryExe.OwnerCollection = null;
            // 
            // 
            // 
            this.navCategoryExe.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.navCategoryExe.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            // 
            // tniLineGraph
            // 
            this.tniLineGraph.Caption = "tniLineGraph";
            this.tniLineGraph.Name = "tniLineGraph";
            this.tniLineGraph.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tniLineGraph.OwnerCollection = this.navCategoryExe.Items;
            // 
            // 
            // 
            this.tniLineGraph.Tile.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(183)))), ((int)(((byte)(175)))));
            this.tniLineGraph.Tile.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tniLineGraph.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement22.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement22.Image")));
            tileItemElement22.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tileItemElement22.Text = "直观图";
            this.tniLineGraph.Tile.Elements.Add(tileItemElement22);
            this.tniLineGraph.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tniLineGraph.Tile.Name = "tniLineGraph";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 561);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智能公交发车系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.mnuQueue.ResumeLayout(false);
            this.mnuSch.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.sStrip.ResumeLayout(false);
            this.sStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCase)).EndInit();
            this.pnlCase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabList)).EndInit();
            this.tabList.ResumeLayout(false);
            this.tabPg_Up.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUp_Sch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUp_Sch)).EndInit();
            this.tabPg_Dn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDn_Sch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDn_Sch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlQueue)).EndInit();
            this.pnlQueue.ResumeLayout(false);
            this.pnlUp.ResumeLayout(false);
            this.pnlUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUp)).EndInit();
            this.pnlDn.ResumeLayout(false);
            this.pnlDn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDn)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuQueue;
        private System.Windows.Forms.ToolStripMenuItem mnuQueueIn;
        private System.Windows.Forms.ToolStripMenuItem mnuQueueOut;
        private System.Windows.Forms.Timer tmrQueue;
        private System.Windows.Forms.ContextMenuStrip mnuSch;
        private System.Windows.Forms.ToolStripMenuItem mnuSchAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuSchModify;
        private System.Windows.Forms.ToolStripMenuItem mnuSchDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeBus;
        private System.Windows.Forms.ToolStripMenuItem mnuTmrChange;
        private System.Windows.Forms.ToolStripMenuItem mnuTmrEqual;
        private System.Windows.Forms.ToolStripMenuItem mnuSchSwap;
        private System.Windows.Forms.Timer tmrLsnr;
        private DevExpress.XtraGrid.Columns.GridColumn colUp_No;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.SplitContainerControl pnlCase;
        private DevExpress.XtraTab.XtraTabControl tabList;
        private DevExpress.XtraTab.XtraTabPage tabPg_Dn;
        private DevExpress.XtraTab.XtraTabPage tabPg_Up;
        private DevExpress.XtraGrid.GridControl gridUp_Sch;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvUp_Sch;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox picTitle;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SplitContainerControl pnlQueue;
        private DevExpress.XtraGrid.GridControl gridDn_Sch;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDn_Sch;
        private System.Windows.Forms.StatusStrip sStrip;
        private System.Windows.Forms.ToolStripStatusLabel tssLeft;
        private System.Windows.Forms.ToolStripStatusLabel tssSpin;
        private System.Windows.Forms.ToolStripStatusLabel tssStsatus;
        private System.Windows.Forms.ToolStripStatusLabel tssRight;
        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraBars.Navigation.TileNavCategory navCategorySys;
        private DevExpress.XtraBars.Navigation.TileNavItem tniReport;
        private System.Windows.Forms.ToolStripProgressBar tspRate;
        private System.Windows.Forms.ToolStripStatusLabel tssRate;
        private DevExpress.XtraBars.Navigation.TileNavItem tniBusDrivers;
        private System.Windows.Forms.Panel pnlUp;
        private DevExpress.XtraEditors.LabelControl lblUpQueue;
        private DevExpress.XtraGrid.GridControl gridUp;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvUp;
        private System.Windows.Forms.Panel pnlDn;
        private DevExpress.XtraGrid.GridControl gridDn;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDn;
        private DevExpress.XtraEditors.LabelControl lblDnQueue;
        private DevExpress.Utils.ToolTipController toolTipController;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraBars.Navigation.TileNavItem tniOprRecord;
        private DevExpress.XtraBars.Navigation.TileNavItem tniSchedule;
        private DevExpress.XtraBars.Navigation.TileNavItem tniUnOprRecord;
        private DevExpress.XtraBars.Navigation.TileNavCategory navCategoryExe;
        private DevExpress.XtraBars.Navigation.TileNavItem tniLineGraph;
        private DevExpress.XtraBars.Navigation.TileNavItem tniMapMonitor;
        private DevExpress.XtraBars.Navigation.TileNavItem tniRepair;
        private DevExpress.XtraBars.Navigation.TileNavSubItem tileNavSubItem1;
        private DevExpress.XtraBars.Navigation.TileNavItem tniPlayBack;
    }
}

