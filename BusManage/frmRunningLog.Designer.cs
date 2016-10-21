namespace BusManage
{
    partial class frmRunningLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRunningLog));
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.lblLine = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dtpDate = new DevExpress.XtraEditors.DateEdit();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.cboLine = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnlNr = new System.Windows.Forms.Panel();
            this.lblNr = new DevExpress.XtraEditors.LabelControl();
            this.gridNr = new DevExpress.XtraGrid.GridControl();
            this.dgvNr = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlFk = new System.Windows.Forms.Panel();
            this.lblFk = new DevExpress.XtraEditors.LabelControl();
            this.gridFk = new DevExpress.XtraGrid.GridControl();
            this.dgvFk = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlKq = new System.Windows.Forms.Panel();
            this.lblKq = new DevExpress.XtraEditors.LabelControl();
            this.gridKq = new DevExpress.XtraGrid.GridControl();
            this.dgvKq = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.pnlNr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNr)).BeginInit();
            this.pnlFk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFk)).BeginInit();
            this.pnlKq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKq)).BeginInit();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuery.Appearance.Options.UseFont = true;
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnQuery.Location = new System.Drawing.Point(304, 36);
            this.btnQuery.LookAndFeel.SkinName = "Office 2013";
            this.btnQuery.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 24);
            this.btnQuery.TabIndex = 4;
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
            this.groupControl1.Controls.Add(this.dtpDate);
            this.groupControl1.Controls.Add(this.lblDate);
            this.groupControl1.Controls.Add(this.cboLine);
            this.groupControl1.Controls.Add(this.btnQuery);
            this.groupControl1.Controls.Add(this.lblLine);
            this.groupControl1.Location = new System.Drawing.Point(7, 7);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(930, 72);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "查询条件";
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
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.pnlNr);
            this.panelControl1.Controls.Add(this.pnlFk);
            this.panelControl1.Controls.Add(this.pnlKq);
            this.panelControl1.Controls.Add(this.btnNew);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(944, 561);
            this.panelControl1.TabIndex = 0;
            // 
            // pnlNr
            // 
            this.pnlNr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(193)))), ((int)(((byte)(224)))));
            this.pnlNr.Controls.Add(this.lblNr);
            this.pnlNr.Controls.Add(this.gridNr);
            this.pnlNr.Location = new System.Drawing.Point(313, 251);
            this.pnlNr.Name = "pnlNr";
            this.pnlNr.Size = new System.Drawing.Size(624, 303);
            this.pnlNr.TabIndex = 3;
            this.pnlNr.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlNr_Paint);
            // 
            // lblNr
            // 
            this.lblNr.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNr.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblNr.Location = new System.Drawing.Point(12, 7);
            this.lblNr.Name = "lblNr";
            this.lblNr.Size = new System.Drawing.Size(60, 17);
            this.lblNr.TabIndex = 0;
            this.lblNr.Text = "未出车登记";
            // 
            // gridNr
            // 
            this.gridNr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridNr.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridNr.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridNr.Location = new System.Drawing.Point(0, 30);
            this.gridNr.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridNr.MainView = this.dgvNr;
            this.gridNr.Name = "gridNr";
            this.gridNr.ShowOnlyPredefinedDetails = true;
            this.gridNr.Size = new System.Drawing.Size(624, 273);
            this.gridNr.TabIndex = 1;
            this.gridNr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvNr});
            // 
            // dgvNr
            // 
            this.dgvNr.Appearance.GroupPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNr.Appearance.GroupPanel.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dgvNr.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Crimson;
            this.dgvNr.Appearance.GroupPanel.Options.UseFont = true;
            this.dgvNr.Appearance.GroupPanel.Options.UseForeColor = true;
            this.dgvNr.GridControl = this.gridNr;
            this.dgvNr.Name = "dgvNr";
            this.dgvNr.OptionsView.ShowGroupPanel = false;
            this.dgvNr.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.dgvNr_CustomDrawRowIndicator);
            this.dgvNr.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.dgvNr_CustomDrawEmptyForeground);
            // 
            // pnlFk
            // 
            this.pnlFk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(183)))), ((int)(((byte)(175)))));
            this.pnlFk.Controls.Add(this.lblFk);
            this.pnlFk.Controls.Add(this.gridFk);
            this.pnlFk.Location = new System.Drawing.Point(313, 85);
            this.pnlFk.Name = "pnlFk";
            this.pnlFk.Size = new System.Drawing.Size(624, 160);
            this.pnlFk.TabIndex = 2;
            this.pnlFk.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFk_Paint);
            // 
            // lblFk
            // 
            this.lblFk.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFk.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblFk.Location = new System.Drawing.Point(12, 7);
            this.lblFk.Name = "lblFk";
            this.lblFk.Size = new System.Drawing.Size(48, 17);
            this.lblFk.TabIndex = 0;
            this.lblFk.Text = "快速反馈";
            // 
            // gridFk
            // 
            this.gridFk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFk.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridFk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridFk.Location = new System.Drawing.Point(0, 30);
            this.gridFk.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridFk.MainView = this.dgvFk;
            this.gridFk.Name = "gridFk";
            this.gridFk.ShowOnlyPredefinedDetails = true;
            this.gridFk.Size = new System.Drawing.Size(624, 130);
            this.gridFk.TabIndex = 1;
            this.gridFk.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvFk});
            // 
            // dgvFk
            // 
            this.dgvFk.Appearance.GroupPanel.BackColor = System.Drawing.Color.White;
            this.dgvFk.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.DarkTurquoise;
            this.dgvFk.Appearance.GroupPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFk.Appearance.GroupPanel.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dgvFk.Appearance.GroupPanel.ForeColor = System.Drawing.Color.DarkCyan;
            this.dgvFk.Appearance.GroupPanel.Options.UseBackColor = true;
            this.dgvFk.Appearance.GroupPanel.Options.UseFont = true;
            this.dgvFk.Appearance.GroupPanel.Options.UseForeColor = true;
            this.dgvFk.GridControl = this.gridFk;
            this.dgvFk.Name = "dgvFk";
            this.dgvFk.OptionsView.ShowGroupPanel = false;
            this.dgvFk.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.dgvFk_CustomDrawRowIndicator);
            this.dgvFk.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.dgvFk_CustomDrawEmptyForeground);
            // 
            // pnlKq
            // 
            this.pnlKq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlKq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.pnlKq.Controls.Add(this.lblKq);
            this.pnlKq.Controls.Add(this.gridKq);
            this.pnlKq.Location = new System.Drawing.Point(7, 85);
            this.pnlKq.Name = "pnlKq";
            this.pnlKq.Size = new System.Drawing.Size(300, 469);
            this.pnlKq.TabIndex = 1;
            this.pnlKq.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlKq_Paint);
            // 
            // lblKq
            // 
            this.lblKq.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKq.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblKq.Location = new System.Drawing.Point(12, 7);
            this.lblKq.Name = "lblKq";
            this.lblKq.Size = new System.Drawing.Size(60, 17);
            this.lblKq.TabIndex = 0;
            this.lblKq.Text = "驾驶员出勤";
            // 
            // gridKq
            // 
            this.gridKq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridKq.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridKq.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridKq.Location = new System.Drawing.Point(0, 30);
            this.gridKq.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridKq.MainView = this.dgvKq;
            this.gridKq.Name = "gridKq";
            this.gridKq.ShowOnlyPredefinedDetails = true;
            this.gridKq.Size = new System.Drawing.Size(300, 439);
            this.gridKq.TabIndex = 1;
            this.gridKq.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvKq});
            // 
            // dgvKq
            // 
            this.dgvKq.Appearance.GroupPanel.BackColor = System.Drawing.Color.White;
            this.dgvKq.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvKq.Appearance.GroupPanel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvKq.Appearance.GroupPanel.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dgvKq.Appearance.GroupPanel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.dgvKq.Appearance.GroupPanel.Options.UseBackColor = true;
            this.dgvKq.Appearance.GroupPanel.Options.UseFont = true;
            this.dgvKq.Appearance.GroupPanel.Options.UseForeColor = true;
            this.dgvKq.GridControl = this.gridKq;
            this.dgvKq.Name = "dgvKq";
            this.dgvKq.OptionsView.ShowGroupPanel = false;
            this.dgvKq.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.dgvKq_CustomDrawRowIndicator);
            this.dgvKq.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.dgvKq_CustomDrawEmptyForeground);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnNew.Location = new System.Drawing.Point(864, 258);
            this.btnNew.LookAndFeel.SkinName = "Office 2013";
            this.btnNew.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(64, 24);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = " 新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraScrollableControl1.Appearance.Options.UseFont = true;
            this.xtraScrollableControl1.Controls.Add(this.panelControl1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(944, 561);
            this.xtraScrollableControl1.TabIndex = 3;
            // 
            // frmRunningLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 561);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRunningLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "行车日报";
            this.Load += new System.EventHandler(this.frmRunningLog_Load);
            this.SizeChanged += new System.EventHandler(this.frmRunningLog_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.pnlNr.ResumeLayout(false);
            this.pnlNr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNr)).EndInit();
            this.pnlFk.ResumeLayout(false);
            this.pnlFk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFk)).EndInit();
            this.pnlKq.ResumeLayout(false);
            this.pnlKq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKq)).EndInit();
            this.xtraScrollableControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.LabelControl lblLine;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit dtpDate;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.ComboBoxEdit cboLine;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraGrid.GridControl gridKq;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvKq;
        private DevExpress.XtraGrid.GridControl gridNr;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvNr;
        private DevExpress.XtraGrid.GridControl gridFk;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvFk;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private System.Windows.Forms.Panel pnlKq;
        private System.Windows.Forms.Panel pnlNr;
        private System.Windows.Forms.Panel pnlFk;
        private DevExpress.XtraEditors.LabelControl lblKq;
        private DevExpress.XtraEditors.LabelControl lblFk;
        private DevExpress.XtraEditors.LabelControl lblNr;
    }
}