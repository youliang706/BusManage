namespace BusManage
{
    partial class frmRepairLogInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepairLogInput));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.tabInfo = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.dtpRegTime = new DevExpress.XtraEditors.TimeEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSummary = new DevExpress.XtraEditors.TextEdit();
            this.lblSummary = new DevExpress.XtraEditors.LabelControl();
            this.lblRegTime = new DevExpress.XtraEditors.LabelControl();
            this.cboFalut = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblFalut = new DevExpress.XtraEditors.LabelControl();
            this.cboBus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblBus = new DevExpress.XtraEditors.LabelControl();
            this.dtpDate = new DevExpress.XtraEditors.DateEdit();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.cboLine = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblLine = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).BeginInit();
            this.tabInfo.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpRegTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSummary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFalut.Properties)).BeginInit();
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
            this.xtraTabPage1.Controls.Add(this.dtpRegTime);
            this.xtraTabPage1.Controls.Add(this.panel1);
            this.xtraTabPage1.Controls.Add(this.txtSummary);
            this.xtraTabPage1.Controls.Add(this.lblSummary);
            this.xtraTabPage1.Controls.Add(this.lblRegTime);
            this.xtraTabPage1.Controls.Add(this.cboFalut);
            this.xtraTabPage1.Controls.Add(this.lblFalut);
            this.xtraTabPage1.Controls.Add(this.cboBus);
            this.xtraTabPage1.Controls.Add(this.lblBus);
            this.xtraTabPage1.Controls.Add(this.dtpDate);
            this.xtraTabPage1.Controls.Add(this.lblDate);
            this.xtraTabPage1.Controls.Add(this.cboLine);
            this.xtraTabPage1.Controls.Add(this.lblLine);
            this.xtraTabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(564, 228);
            this.xtraTabPage1.Text = "维修登记信息";
            // 
            // dtpRegTime
            // 
            this.dtpRegTime.EditValue = new System.DateTime(2016, 6, 28, 0, 0, 0, 0);
            this.dtpRegTime.Location = new System.Drawing.Point(86, 111);
            this.dtpRegTime.Name = "dtpRegTime";
            this.dtpRegTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRegTime.Properties.Appearance.Options.UseFont = true;
            this.dtpRegTime.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRegTime.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpRegTime.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRegTime.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpRegTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpRegTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.dtpRegTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpRegTime.Properties.EditFormat.FormatString = "HH:mm";
            this.dtpRegTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpRegTime.Properties.LookAndFeel.SkinName = "Office 2013";
            this.dtpRegTime.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpRegTime.Properties.Mask.EditMask = "HH:mm";
            this.dtpRegTime.Size = new System.Drawing.Size(65, 24);
            this.dtpRegTime.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(20, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 1);
            this.panel1.TabIndex = 6;
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(86, 187);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSummary.Properties.Appearance.Options.UseFont = true;
            this.txtSummary.Properties.LookAndFeel.SkinName = "Office 2013";
            this.txtSummary.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSummary.Size = new System.Drawing.Size(398, 24);
            this.txtSummary.TabIndex = 12;
            // 
            // lblSummary
            // 
            this.lblSummary.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.Location = new System.Drawing.Point(20, 190);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(60, 17);
            this.lblSummary.TabIndex = 11;
            this.lblSummary.Text = "备注信息：";
            // 
            // lblRegTime
            // 
            this.lblRegTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegTime.Location = new System.Drawing.Point(20, 114);
            this.lblRegTime.Name = "lblRegTime";
            this.lblRegTime.Size = new System.Drawing.Size(60, 17);
            this.lblRegTime.TabIndex = 7;
            this.lblRegTime.Text = "登记时间：";
            // 
            // cboFalut
            // 
            this.cboFalut.Location = new System.Drawing.Point(86, 149);
            this.cboFalut.Name = "cboFalut";
            this.cboFalut.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFalut.Properties.Appearance.Options.UseFont = true;
            this.cboFalut.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFalut.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboFalut.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFalut.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboFalut.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFalut.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboFalut.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFalut.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboFalut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFalut.Properties.LookAndFeel.SkinName = "Office 2013";
            this.cboFalut.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboFalut.Size = new System.Drawing.Size(130, 24);
            this.cboFalut.TabIndex = 10;
            // 
            // lblFalut
            // 
            this.lblFalut.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFalut.Location = new System.Drawing.Point(20, 152);
            this.lblFalut.Name = "lblFalut";
            this.lblFalut.Size = new System.Drawing.Size(60, 17);
            this.lblFalut.TabIndex = 9;
            this.lblFalut.Text = "故障类型：";
            // 
            // cboBus
            // 
            this.cboBus.Location = new System.Drawing.Point(222, 55);
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
            // 
            // lblBus
            // 
            this.lblBus.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBus.Location = new System.Drawing.Point(180, 58);
            this.lblBus.Name = "lblBus";
            this.lblBus.Size = new System.Drawing.Size(36, 17);
            this.lblBus.TabIndex = 4;
            this.lblBus.Text = "车辆：";
            // 
            // dtpDate
            // 
            this.dtpDate.EditValue = new System.DateTime(2016, 6, 23, 14, 18, 57, 0);
            this.dtpDate.Location = new System.Drawing.Point(61, 17);
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
            this.cboLine.Location = new System.Drawing.Point(61, 55);
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
            this.lblLine.Location = new System.Drawing.Point(20, 58);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(36, 17);
            this.lblLine.TabIndex = 2;
            this.lblLine.Text = "线路：";
            // 
            // frmRepairLogInput
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
            this.Name = "frmRepairLogInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "维修登记";
            this.Load += new System.EventHandler(this.frmRepairLogInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).EndInit();
            this.tabInfo.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpRegTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSummary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFalut.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtSummary;
        private DevExpress.XtraEditors.LabelControl lblSummary;
        private DevExpress.XtraEditors.LabelControl lblRegTime;
        private DevExpress.XtraEditors.ComboBoxEdit cboFalut;
        private DevExpress.XtraEditors.LabelControl lblFalut;
        private DevExpress.XtraEditors.ComboBoxEdit cboBus;
        private DevExpress.XtraEditors.LabelControl lblBus;
        private DevExpress.XtraEditors.DateEdit dtpDate;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.ComboBoxEdit cboLine;
        private DevExpress.XtraEditors.LabelControl lblLine;
        private DevExpress.XtraEditors.TimeEdit dtpRegTime;
    }
}