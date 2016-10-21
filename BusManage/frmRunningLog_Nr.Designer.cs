namespace BusManage
{
    partial class frmRunningLog_Nr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRunningLog_Nr));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.tabInfo = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.lblSp = new DevExpress.XtraEditors.LabelControl();
            this.dtpEndTime = new DevExpress.XtraEditors.TimeEdit();
            this.dtpStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.txtSummary = new DevExpress.XtraEditors.TextEdit();
            this.lblSummary = new DevExpress.XtraEditors.LabelControl();
            this.lblTime = new DevExpress.XtraEditors.LabelControl();
            this.cboRsn = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblRsn = new DevExpress.XtraEditors.LabelControl();
            this.cboBus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblBus = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).BeginInit();
            this.tabInfo.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSummary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRsn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOK.Location = new System.Drawing.Point(266, 211);
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
            this.btnCancel.Location = new System.Drawing.Point(362, 211);
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
            this.tabInfo.Size = new System.Drawing.Size(450, 200);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.DimGray;
            this.xtraTabPage1.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.lblSp);
            this.xtraTabPage1.Controls.Add(this.dtpEndTime);
            this.xtraTabPage1.Controls.Add(this.dtpStartTime);
            this.xtraTabPage1.Controls.Add(this.txtSummary);
            this.xtraTabPage1.Controls.Add(this.lblSummary);
            this.xtraTabPage1.Controls.Add(this.lblTime);
            this.xtraTabPage1.Controls.Add(this.cboRsn);
            this.xtraTabPage1.Controls.Add(this.lblRsn);
            this.xtraTabPage1.Controls.Add(this.cboBus);
            this.xtraTabPage1.Controls.Add(this.lblBus);
            this.xtraTabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(444, 168);
            this.xtraTabPage1.Text = "未发车原因";
            // 
            // lblSp
            // 
            this.lblSp.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSp.Location = new System.Drawing.Point(136, 54);
            this.lblSp.Name = "lblSp";
            this.lblSp.Size = new System.Drawing.Size(12, 17);
            this.lblSp.TabIndex = 4;
            this.lblSp.Text = "至";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.EditValue = new System.DateTime(2016, 6, 28, 0, 0, 0, 0);
            this.dtpEndTime.Location = new System.Drawing.Point(154, 52);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Properties.Appearance.Options.UseFont = true;
            this.dtpEndTime.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpEndTime.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEndTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.dtpEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpEndTime.Properties.EditFormat.FormatString = "HH:mm";
            this.dtpEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpEndTime.Properties.LookAndFeel.SkinName = "Office 2013";
            this.dtpEndTime.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpEndTime.Properties.Mask.EditMask = "HH:mm";
            this.dtpEndTime.Size = new System.Drawing.Size(68, 24);
            this.dtpEndTime.TabIndex = 5;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.EditValue = new System.DateTime(2016, 6, 28, 0, 0, 0, 0);
            this.dtpStartTime.Location = new System.Drawing.Point(62, 52);
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
            this.dtpStartTime.Size = new System.Drawing.Size(68, 24);
            this.dtpStartTime.TabIndex = 3;
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(62, 124);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSummary.Properties.Appearance.Options.UseFont = true;
            this.txtSummary.Properties.LookAndFeel.SkinName = "Office 2013";
            this.txtSummary.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSummary.Size = new System.Drawing.Size(350, 24);
            this.txtSummary.TabIndex = 9;
            // 
            // lblSummary
            // 
            this.lblSummary.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.Location = new System.Drawing.Point(20, 127);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(36, 17);
            this.lblSummary.TabIndex = 8;
            this.lblSummary.Text = "备注：";
            // 
            // lblTime
            // 
            this.lblTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(20, 54);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(36, 17);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "时间：";
            // 
            // cboRsn
            // 
            this.cboRsn.Location = new System.Drawing.Point(62, 88);
            this.cboRsn.Name = "cboRsn";
            this.cboRsn.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRsn.Properties.Appearance.Options.UseFont = true;
            this.cboRsn.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRsn.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboRsn.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRsn.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboRsn.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRsn.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboRsn.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRsn.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboRsn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRsn.Properties.LookAndFeel.SkinName = "Office 2013";
            this.cboRsn.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboRsn.Size = new System.Drawing.Size(130, 24);
            this.cboRsn.TabIndex = 7;
            // 
            // lblRsn
            // 
            this.lblRsn.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRsn.Location = new System.Drawing.Point(20, 91);
            this.lblRsn.Name = "lblRsn";
            this.lblRsn.Size = new System.Drawing.Size(36, 17);
            this.lblRsn.TabIndex = 6;
            this.lblRsn.Text = "原因：";
            // 
            // cboBus
            // 
            this.cboBus.Location = new System.Drawing.Point(62, 16);
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
            this.cboBus.TabIndex = 1;
            // 
            // lblBus
            // 
            this.lblBus.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBus.Location = new System.Drawing.Point(20, 19);
            this.lblBus.Name = "lblBus";
            this.lblBus.Size = new System.Drawing.Size(36, 17);
            this.lblBus.TabIndex = 0;
            this.lblBus.Text = "车辆：";
            // 
            // frmRunningLog_Nr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(464, 249);
            this.Controls.Add(this.tabInfo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRunningLog_Nr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "未发车登记";
            this.Load += new System.EventHandler(this.frmRunningLog_Nr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).EndInit();
            this.tabInfo.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSummary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRsn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraTab.XtraTabControl tabInfo;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.TextEdit txtSummary;
        private DevExpress.XtraEditors.LabelControl lblSummary;
        private DevExpress.XtraEditors.LabelControl lblTime;
        private DevExpress.XtraEditors.ComboBoxEdit cboRsn;
        private DevExpress.XtraEditors.LabelControl lblRsn;
        private DevExpress.XtraEditors.ComboBoxEdit cboBus;
        private DevExpress.XtraEditors.LabelControl lblBus;
        private DevExpress.XtraEditors.TimeEdit dtpStartTime;
        private DevExpress.XtraEditors.LabelControl lblSp;
        private DevExpress.XtraEditors.TimeEdit dtpEndTime;
    }
}