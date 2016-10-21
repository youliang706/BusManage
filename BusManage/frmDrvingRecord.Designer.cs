namespace BusManage
{
    partial class frmDrvingRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDrvingRecord));
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.lblLine = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboDirect = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblDirect = new DevExpress.XtraEditors.LabelControl();
            this.cboDrv = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblDrv = new DevExpress.XtraEditors.LabelControl();
            this.cboBus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblBus = new DevExpress.XtraEditors.LabelControl();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.dtpDate = new DevExpress.XtraEditors.DateEdit();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.cboLine = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridList = new DevExpress.XtraGrid.GridControl();
            this.dgvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblRunTimes = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRunTimes = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblKm = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssKm = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSubmit = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDirect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDrv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuery.Appearance.Options.UseFont = true;
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnQuery.Location = new System.Drawing.Point(719, 36);
            this.btnQuery.LookAndFeel.SkinName = "Office 2013";
            this.btnQuery.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 24);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "  查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lblLine
            // 
            this.lblLine.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.Location = new System.Drawing.Point(160, 39);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(36, 17);
            this.lblLine.TabIndex = 2;
            this.lblLine.Text = "线路：";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cboDirect);
            this.groupControl1.Controls.Add(this.lblDirect);
            this.groupControl1.Controls.Add(this.cboDrv);
            this.groupControl1.Controls.Add(this.lblDrv);
            this.groupControl1.Controls.Add(this.cboBus);
            this.groupControl1.Controls.Add(this.lblBus);
            this.groupControl1.Controls.Add(this.btnNew);
            this.groupControl1.Controls.Add(this.dtpDate);
            this.groupControl1.Controls.Add(this.lblDate);
            this.groupControl1.Controls.Add(this.cboLine);
            this.groupControl1.Controls.Add(this.btnQuery);
            this.groupControl1.Controls.Add(this.lblLine);
            this.groupControl1.Location = new System.Drawing.Point(7, 7);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(930, 72);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "查询条件";
            // 
            // cboDirect
            // 
            this.cboDirect.Location = new System.Drawing.Point(641, 36);
            this.cboDirect.Name = "cboDirect";
            this.cboDirect.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDirect.Properties.Appearance.Options.UseFont = true;
            this.cboDirect.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDirect.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboDirect.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDirect.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboDirect.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDirect.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboDirect.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDirect.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboDirect.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDirect.Properties.LookAndFeel.SkinName = "Office 2013";
            this.cboDirect.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboDirect.Size = new System.Drawing.Size(60, 24);
            this.cboDirect.TabIndex = 9;
            this.cboDirect.SelectedIndexChanged += new System.EventHandler(this.cboDirect_SelectedIndexChanged);
            // 
            // lblDirect
            // 
            this.lblDirect.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirect.Location = new System.Drawing.Point(601, 39);
            this.lblDirect.Name = "lblDirect";
            this.lblDirect.Size = new System.Drawing.Size(36, 17);
            this.lblDirect.TabIndex = 8;
            this.lblDirect.Text = "方向：";
            // 
            // cboDrv
            // 
            this.cboDrv.Location = new System.Drawing.Point(508, 36);
            this.cboDrv.Name = "cboDrv";
            this.cboDrv.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDrv.Properties.Appearance.Options.UseFont = true;
            this.cboDrv.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDrv.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboDrv.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDrv.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboDrv.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDrv.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboDrv.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDrv.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboDrv.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDrv.Properties.LookAndFeel.SkinName = "Office 2013";
            this.cboDrv.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboDrv.Size = new System.Drawing.Size(75, 24);
            this.cboDrv.TabIndex = 7;
            this.cboDrv.SelectedIndexChanged += new System.EventHandler(this.cboDrv_SelectedIndexChanged);
            // 
            // lblDrv
            // 
            this.lblDrv.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrv.Location = new System.Drawing.Point(456, 39);
            this.lblDrv.Name = "lblDrv";
            this.lblDrv.Size = new System.Drawing.Size(48, 17);
            this.lblDrv.TabIndex = 6;
            this.lblDrv.Text = "驾驶员：";
            // 
            // cboBus
            // 
            this.cboBus.Location = new System.Drawing.Point(348, 36);
            this.cboBus.Name = "cboBus";
            this.cboBus.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBus.Properties.Appearance.Options.UseFont = true;
            this.cboBus.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBus.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboBus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboBus.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBus.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboBus.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBus.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboBus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBus.Properties.LookAndFeel.SkinName = "Office 2013";
            this.cboBus.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboBus.Size = new System.Drawing.Size(90, 24);
            this.cboBus.TabIndex = 5;
            this.cboBus.SelectedIndexChanged += new System.EventHandler(this.cboBus_SelectedIndexChanged);
            // 
            // lblBus
            // 
            this.lblBus.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBus.Location = new System.Drawing.Point(308, 39);
            this.lblBus.Name = "lblBus";
            this.lblBus.Size = new System.Drawing.Size(36, 17);
            this.lblBus.TabIndex = 4;
            this.lblBus.Text = "车辆：";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnNew.Location = new System.Drawing.Point(843, 36);
            this.btnNew.LookAndFeel.SkinName = "Office 2013";
            this.btnNew.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 24);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "  新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.EditValue = new System.DateTime(2016, 6, 23, 14, 18, 57, 0);
            this.dtpDate.Location = new System.Drawing.Point(52, 36);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.Appearance.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceCalendar.DayCellHighlighted.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceCalendar.DayCellHighlighted.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceCalendar.Header.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceCalendar.Header.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceCalendar.HeaderHighlighted.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceCalendar.HeaderHighlighted.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceCalendar.WeekNumber.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceCalendar.WeekNumber.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtpDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Properties.LookAndFeel.SkinName = "Office 2013";
            this.dtpDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpDate.Size = new System.Drawing.Size(90, 24);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.TextChanged += new System.EventHandler(this.dtpDate_TextChanged);
            // 
            // lblDate
            // 
            this.lblDate.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(12, 39);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 17);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "日期：";
            // 
            // cboLine
            // 
            this.cboLine.Location = new System.Drawing.Point(200, 36);
            this.cboLine.Name = "cboLine";
            this.cboLine.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLine.Properties.Appearance.Options.UseFont = true;
            this.cboLine.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLine.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboLine.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLine.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboLine.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLine.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboLine.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLine.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLine.Properties.LookAndFeel.SkinName = "Office 2013";
            this.cboLine.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLine.Size = new System.Drawing.Size(90, 24);
            this.cboLine.TabIndex = 3;
            this.cboLine.SelectedIndexChanged += new System.EventHandler(this.cboLine_SelectedIndexChanged);
            // 
            // gridList
            // 
            this.gridList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridList.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridList.Location = new System.Drawing.Point(7, 85);
            this.gridList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridList.MainView = this.dgvDetail;
            this.gridList.Name = "gridList";
            this.gridList.ShowOnlyPredefinedDetails = true;
            this.gridList.Size = new System.Drawing.Size(930, 447);
            this.gridList.TabIndex = 0;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetail});
            // 
            // dgvDetail
            // 
            this.dgvDetail.GridControl = this.gridList;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.dgvDetail_CustomDrawRowIndicator);
            this.dgvDetail.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.dgvDetail_RowStyle);
            this.dgvDetail.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.dgvDetail_CustomDrawEmptyForeground);
            this.dgvDetail.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvDetail_CustomColumnDisplayText);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gridList);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(944, 539);
            this.panelControl1.TabIndex = 0;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraScrollableControl1.Appearance.Options.UseFont = true;
            this.xtraScrollableControl1.Controls.Add(this.statusStrip1);
            this.xtraScrollableControl1.Controls.Add(this.panelControl1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(944, 561);
            this.xtraScrollableControl1.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblRunTimes,
            this.tssRunTimes,
            this.toolStripStatusLabel7,
            this.tlblKm,
            this.tssKm,
            this.toolStripStatusLabel8,
            this.tlblRate,
            this.tssRate,
            this.toolStripStatusLabel10,
            this.tssSubmit});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(944, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlblRunTimes
            // 
            this.tlblRunTimes.Name = "tlblRunTimes";
            this.tlblRunTimes.Size = new System.Drawing.Size(68, 17);
            this.tlblRunTimes.Text = "趟次合计：";
            // 
            // tssRunTimes
            // 
            this.tssRunTimes.ForeColor = System.Drawing.Color.MediumBlue;
            this.tssRunTimes.Name = "tssRunTimes";
            this.tssRunTimes.Size = new System.Drawing.Size(15, 17);
            this.tssRunTimes.Text = "0";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(4, 17);
            // 
            // tlblKm
            // 
            this.tlblKm.Name = "tlblKm";
            this.tlblKm.Size = new System.Drawing.Size(145, 17);
            this.tlblKm.Text = "里程合计（计划/实际）：";
            // 
            // tssKm
            // 
            this.tssKm.ForeColor = System.Drawing.Color.MediumBlue;
            this.tssKm.Name = "tssKm";
            this.tssKm.Size = new System.Drawing.Size(33, 17);
            this.tssKm.Text = "0km";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(4, 17);
            // 
            // tlblRate
            // 
            this.tlblRate.Name = "tlblRate";
            this.tlblRate.Size = new System.Drawing.Size(80, 17);
            this.tlblRate.Text = "审核通过率：";
            // 
            // tssRate
            // 
            this.tssRate.ForeColor = System.Drawing.Color.MediumBlue;
            this.tssRate.Name = "tssRate";
            this.tssRate.Size = new System.Drawing.Size(26, 17);
            this.tssRate.Text = "0%";
            // 
            // toolStripStatusLabel10
            // 
            this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
            this.toolStripStatusLabel10.Size = new System.Drawing.Size(462, 17);
            this.toolStripStatusLabel10.Spring = true;
            // 
            // tssSubmit
            // 
            this.tssSubmit.IsLink = true;
            this.tssSubmit.Name = "tssSubmit";
            this.tssSubmit.Size = new System.Drawing.Size(92, 17);
            this.tssSubmit.Text = "本日路单未上报";
            this.tssSubmit.Click += new System.EventHandler(this.tssSubmit_Click);
            // 
            // frmDrvingRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 561);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDrvingRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "营运路单";
            this.Load += new System.EventHandler(this.frmDrvingRecord_Load);
            this.SizeChanged += new System.EventHandler(this.frmDrvingRecord_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDirect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDrv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.xtraScrollableControl1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.LabelControl lblLine;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.DateEdit dtpDate;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.ComboBoxEdit cboLine;
        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboDrv;
        private DevExpress.XtraEditors.LabelControl lblDrv;
        private DevExpress.XtraEditors.ComboBoxEdit cboBus;
        private DevExpress.XtraEditors.LabelControl lblBus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblRunTimes;
        private System.Windows.Forms.ToolStripStatusLabel tssRunTimes;
        private System.Windows.Forms.ToolStripStatusLabel tlblKm;
        private System.Windows.Forms.ToolStripStatusLabel tssKm;
        private System.Windows.Forms.ToolStripStatusLabel tlblRate;
        private System.Windows.Forms.ToolStripStatusLabel tssRate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel10;
        private System.Windows.Forms.ToolStripStatusLabel tssSubmit;
        private DevExpress.XtraEditors.ComboBoxEdit cboDirect;
        private DevExpress.XtraEditors.LabelControl lblDirect;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetail;


    }
}