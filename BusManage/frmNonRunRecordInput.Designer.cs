namespace BusManage
{
    partial class frmNonRunRecordInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNonRunRecordInput));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.tabInfo = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.dtpArriveTime = new DevExpress.XtraEditors.TimeEdit();
            this.dtpStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.btnDrv = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemarks = new DevExpress.XtraEditors.SimpleButton();
            this.btnCount = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSp1 = new DevExpress.XtraEditors.LabelControl();
            this.txtKm = new DevExpress.XtraEditors.TextEdit();
            this.txtPKm = new DevExpress.XtraEditors.TextEdit();
            this.txtRemarks = new DevExpress.XtraEditors.TextEdit();
            this.lblRemarks = new DevExpress.XtraEditors.LabelControl();
            this.lblKm = new DevExpress.XtraEditors.LabelControl();
            this.lblPKm = new DevExpress.XtraEditors.LabelControl();
            this.lblPlanTime = new DevExpress.XtraEditors.LabelControl();
            this.cboNonOpr = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblNonOpr = new DevExpress.XtraEditors.LabelControl();
            this.cboDrv = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblDrv = new DevExpress.XtraEditors.LabelControl();
            this.cboBus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblBus = new DevExpress.XtraEditors.LabelControl();
            this.dtpDate = new DevExpress.XtraEditors.DateEdit();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.cboLine = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblLine = new DevExpress.XtraEditors.LabelControl();
            this.mnuSys = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).BeginInit();
            this.tabInfo.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpArriveTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPKm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNonOpr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDrv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOK.Location = new System.Drawing.Point(386, 273);
            this.btnOK.LookAndFeel.SkinName = "Office 2013";
            this.btnOK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 26);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "  确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancel.Location = new System.Drawing.Point(482, 273);
            this.btnCancel.LookAndFeel.SkinName = "Office 2013";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "  取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabInfo
            // 
            this.tabInfo.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInfo.Appearance.Options.UseFont = true;
            this.tabInfo.AppearancePage.Header.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabInfo.AppearancePage.Header.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tabInfo.AppearancePage.Header.Options.UseFont = true;
            this.tabInfo.AppearancePage.Header.Options.UseForeColor = true;
            this.tabInfo.Location = new System.Drawing.Point(7, 7);
            this.tabInfo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.SelectedTabPage = this.xtraTabPage1;
            this.tabInfo.Size = new System.Drawing.Size(570, 260);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.DimGray;
            this.xtraTabPage1.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.dtpArriveTime);
            this.xtraTabPage1.Controls.Add(this.dtpStartTime);
            this.xtraTabPage1.Controls.Add(this.btnDrv);
            this.xtraTabPage1.Controls.Add(this.btnRemarks);
            this.xtraTabPage1.Controls.Add(this.btnCount);
            this.xtraTabPage1.Controls.Add(this.panel1);
            this.xtraTabPage1.Controls.Add(this.lblSp1);
            this.xtraTabPage1.Controls.Add(this.txtKm);
            this.xtraTabPage1.Controls.Add(this.txtPKm);
            this.xtraTabPage1.Controls.Add(this.txtRemarks);
            this.xtraTabPage1.Controls.Add(this.lblRemarks);
            this.xtraTabPage1.Controls.Add(this.lblKm);
            this.xtraTabPage1.Controls.Add(this.lblPKm);
            this.xtraTabPage1.Controls.Add(this.lblPlanTime);
            this.xtraTabPage1.Controls.Add(this.cboNonOpr);
            this.xtraTabPage1.Controls.Add(this.lblNonOpr);
            this.xtraTabPage1.Controls.Add(this.cboDrv);
            this.xtraTabPage1.Controls.Add(this.lblDrv);
            this.xtraTabPage1.Controls.Add(this.cboBus);
            this.xtraTabPage1.Controls.Add(this.lblBus);
            this.xtraTabPage1.Controls.Add(this.dtpDate);
            this.xtraTabPage1.Controls.Add(this.lblDate);
            this.xtraTabPage1.Controls.Add(this.cboLine);
            this.xtraTabPage1.Controls.Add(this.lblLine);
            this.xtraTabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(564, 228);
            this.xtraTabPage1.Text = "非营运路单信息";
            // 
            // dtpArriveTime
            // 
            this.dtpArriveTime.EditValue = new System.DateTime(2016, 6, 28, 0, 0, 0, 0);
            this.dtpArriveTime.Location = new System.Drawing.Point(369, 111);
            this.dtpArriveTime.Name = "dtpArriveTime";
            this.dtpArriveTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpArriveTime.Properties.Appearance.Options.UseFont = true;
            this.dtpArriveTime.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpArriveTime.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpArriveTime.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpArriveTime.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpArriveTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpArriveTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.dtpArriveTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpArriveTime.Properties.EditFormat.FormatString = "HH:mm";
            this.dtpArriveTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpArriveTime.Properties.LookAndFeel.SkinName = "Office 2013";
            this.dtpArriveTime.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpArriveTime.Properties.Mask.EditMask = "HH:mm";
            this.dtpArriveTime.Size = new System.Drawing.Size(58, 24);
            this.dtpArriveTime.TabIndex = 15;
            this.dtpArriveTime.EditValueChanged += new System.EventHandler(this.dtpArriveTime_EditValueChanged);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.EditValue = new System.DateTime(2016, 6, 28, 0, 0, 0, 0);
            this.dtpStartTime.Location = new System.Drawing.Point(288, 111);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Properties.Appearance.Options.UseFont = true;
            this.dtpStartTime.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpStartTime.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStartTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.dtpStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpStartTime.Properties.EditFormat.FormatString = "HH:mm";
            this.dtpStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpStartTime.Properties.LookAndFeel.SkinName = "Office 2013";
            this.dtpStartTime.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpStartTime.Properties.Mask.EditMask = "HH:mm";
            this.dtpStartTime.Size = new System.Drawing.Size(58, 24);
            this.dtpStartTime.TabIndex = 13;
            this.dtpStartTime.EditValueChanged += new System.EventHandler(this.dtpStartTime_EditValueChanged);
            // 
            // btnDrv
            // 
            this.btnDrv.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrv.Appearance.Options.UseFont = true;
            this.btnDrv.Image = ((System.Drawing.Image)(resources.GetObject("btnDrv.Image")));
            this.btnDrv.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDrv.Location = new System.Drawing.Point(384, 55);
            this.btnDrv.LookAndFeel.SkinName = "Office 2013";
            this.btnDrv.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDrv.Name = "btnDrv";
            this.btnDrv.Size = new System.Drawing.Size(34, 24);
            this.btnDrv.TabIndex = 8;
            this.btnDrv.Click += new System.EventHandler(this.btnDrv_Click);
            // 
            // btnRemarks
            // 
            this.btnRemarks.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemarks.Appearance.Options.UseFont = true;
            this.btnRemarks.Location = new System.Drawing.Point(490, 187);
            this.btnRemarks.LookAndFeel.SkinName = "Office 2013";
            this.btnRemarks.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRemarks.Name = "btnRemarks";
            this.btnRemarks.Size = new System.Drawing.Size(34, 24);
            this.btnRemarks.TabIndex = 23;
            this.btnRemarks.Text = "…";
            this.btnRemarks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRemarks_MouseDown);
            // 
            // btnCount
            // 
            this.btnCount.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCount.Appearance.Options.UseFont = true;
            this.btnCount.Image = ((System.Drawing.Image)(resources.GetObject("btnCount.Image")));
            this.btnCount.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCount.Location = new System.Drawing.Point(369, 149);
            this.btnCount.LookAndFeel.SkinName = "Office 2013";
            this.btnCount.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(34, 24);
            this.btnCount.TabIndex = 20;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(20, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 1);
            this.panel1.TabIndex = 9;
            // 
            // lblSp1
            // 
            this.lblSp1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSp1.Location = new System.Drawing.Point(351, 114);
            this.lblSp1.Name = "lblSp1";
            this.lblSp1.Size = new System.Drawing.Size(12, 17);
            this.lblSp1.TabIndex = 14;
            this.lblSp1.Text = "至";
            // 
            // txtKm
            // 
            this.txtKm.Location = new System.Drawing.Point(288, 149);
            this.txtKm.Name = "txtKm";
            this.txtKm.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKm.Properties.Appearance.Options.UseFont = true;
            this.txtKm.Properties.LookAndFeel.SkinName = "Office 2013";
            this.txtKm.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtKm.Size = new System.Drawing.Size(75, 24);
            this.txtKm.TabIndex = 19;
            // 
            // txtPKm
            // 
            this.txtPKm.Location = new System.Drawing.Point(86, 149);
            this.txtPKm.Name = "txtPKm";
            this.txtPKm.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPKm.Properties.Appearance.Options.UseFont = true;
            this.txtPKm.Properties.LookAndFeel.SkinName = "Office 2013";
            this.txtPKm.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPKm.Size = new System.Drawing.Size(75, 24);
            this.txtPKm.TabIndex = 17;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(62, 187);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Properties.Appearance.Options.UseFont = true;
            this.txtRemarks.Properties.LookAndFeel.SkinName = "Office 2013";
            this.txtRemarks.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtRemarks.Size = new System.Drawing.Size(422, 24);
            this.txtRemarks.TabIndex = 22;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(20, 190);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(36, 17);
            this.lblRemarks.TabIndex = 21;
            this.lblRemarks.Text = "备注：";
            // 
            // lblKm
            // 
            this.lblKm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKm.Location = new System.Drawing.Point(222, 152);
            this.lblKm.Name = "lblKm";
            this.lblKm.Size = new System.Drawing.Size(60, 17);
            this.lblKm.TabIndex = 18;
            this.lblKm.Text = "实际里程：";
            // 
            // lblPKm
            // 
            this.lblPKm.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPKm.Location = new System.Drawing.Point(20, 152);
            this.lblPKm.Name = "lblPKm";
            this.lblPKm.Size = new System.Drawing.Size(60, 17);
            this.lblPKm.TabIndex = 16;
            this.lblPKm.Text = "计划里程：";
            // 
            // lblPlanTime
            // 
            this.lblPlanTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanTime.Location = new System.Drawing.Point(222, 114);
            this.lblPlanTime.Name = "lblPlanTime";
            this.lblPlanTime.Size = new System.Drawing.Size(60, 17);
            this.lblPlanTime.TabIndex = 12;
            this.lblPlanTime.Text = "行驶时间：";
            // 
            // cboNonOpr
            // 
            this.cboNonOpr.Location = new System.Drawing.Point(62, 111);
            this.cboNonOpr.Name = "cboNonOpr";
            this.cboNonOpr.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNonOpr.Properties.Appearance.Options.UseFont = true;
            this.cboNonOpr.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNonOpr.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboNonOpr.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNonOpr.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboNonOpr.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNonOpr.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboNonOpr.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNonOpr.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboNonOpr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNonOpr.Properties.LookAndFeel.SkinName = "Office 2013";
            this.cboNonOpr.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboNonOpr.Size = new System.Drawing.Size(90, 24);
            this.cboNonOpr.TabIndex = 11;
            // 
            // lblNonOpr
            // 
            this.lblNonOpr.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNonOpr.Location = new System.Drawing.Point(20, 114);
            this.lblNonOpr.Name = "lblNonOpr";
            this.lblNonOpr.Size = new System.Drawing.Size(36, 17);
            this.lblNonOpr.TabIndex = 10;
            this.lblNonOpr.Text = "类型：";
            // 
            // cboDrv
            // 
            this.cboDrv.Location = new System.Drawing.Point(288, 55);
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
            this.cboDrv.Size = new System.Drawing.Size(90, 24);
            this.cboDrv.TabIndex = 7;
            // 
            // lblDrv
            // 
            this.lblDrv.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrv.Location = new System.Drawing.Point(222, 58);
            this.lblDrv.Name = "lblDrv";
            this.lblDrv.Size = new System.Drawing.Size(48, 17);
            this.lblDrv.TabIndex = 6;
            this.lblDrv.Text = "驾驶员：";
            // 
            // cboBus
            // 
            this.cboBus.Location = new System.Drawing.Point(62, 55);
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
            this.lblBus.Location = new System.Drawing.Point(20, 58);
            this.lblBus.Name = "lblBus";
            this.lblBus.Size = new System.Drawing.Size(36, 17);
            this.lblBus.TabIndex = 4;
            this.lblBus.Text = "车辆：";
            // 
            // dtpDate
            // 
            this.dtpDate.EditValue = new System.DateTime(2016, 6, 23, 14, 18, 57, 0);
            this.dtpDate.Location = new System.Drawing.Point(62, 17);
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
            this.dtpDate.EditValueChanged += new System.EventHandler(this.dtpDate_EditValueChanged);
            // 
            // lblDate
            // 
            this.lblDate.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(20, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 17);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "日期：";
            // 
            // cboLine
            // 
            this.cboLine.Location = new System.Drawing.Point(288, 17);
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
            // lblLine
            // 
            this.lblLine.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.Location = new System.Drawing.Point(222, 20);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(36, 17);
            this.lblLine.TabIndex = 2;
            this.lblLine.Text = "线路：";
            // 
            // mnuSys
            // 
            this.mnuSys.Name = "mnuSys";
            this.mnuSys.Size = new System.Drawing.Size(61, 4);
            // 
            // frmNonRunRecordInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.tabInfo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNonRunRecordInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "路单编辑";
            this.Load += new System.EventHandler(this.frmNonRunRecordInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).EndInit();
            this.tabInfo.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpArriveTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPKm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNonOpr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDrv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraTab.XtraTabControl tabInfo;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl lblSp1;
        private DevExpress.XtraEditors.TextEdit txtKm;
        private DevExpress.XtraEditors.TextEdit txtPKm;
        private DevExpress.XtraEditors.TextEdit txtRemarks;
        private DevExpress.XtraEditors.LabelControl lblRemarks;
        private DevExpress.XtraEditors.LabelControl lblKm;
        private DevExpress.XtraEditors.LabelControl lblPKm;
        private DevExpress.XtraEditors.LabelControl lblPlanTime;
        private DevExpress.XtraEditors.ComboBoxEdit cboNonOpr;
        private DevExpress.XtraEditors.LabelControl lblNonOpr;
        private DevExpress.XtraEditors.ComboBoxEdit cboDrv;
        private DevExpress.XtraEditors.LabelControl lblDrv;
        private DevExpress.XtraEditors.ComboBoxEdit cboBus;
        private DevExpress.XtraEditors.LabelControl lblBus;
        private DevExpress.XtraEditors.DateEdit dtpDate;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.ComboBoxEdit cboLine;
        private DevExpress.XtraEditors.LabelControl lblLine;
        private DevExpress.XtraEditors.SimpleButton btnCount;
        private DevExpress.XtraEditors.SimpleButton btnRemarks;
        private System.Windows.Forms.ContextMenuStrip mnuSys;
        private DevExpress.XtraEditors.SimpleButton btnDrv;
        private DevExpress.XtraEditors.TimeEdit dtpArriveTime;
        private DevExpress.XtraEditors.TimeEdit dtpStartTime;
    }
}