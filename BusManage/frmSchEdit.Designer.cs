namespace BusManage
{
    partial class frmSchEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSchEdit));
            this.tabInfo = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnSub2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSub = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.txtTime = new DevExpress.XtraEditors.TextEdit();
            this.lblTime = new DevExpress.XtraEditors.LabelControl();
            this.dtpPStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.lblPStartTime = new DevExpress.XtraEditors.LabelControl();
            this.cboCase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblCase = new DevExpress.XtraEditors.LabelControl();
            this.btnDrv = new DevExpress.XtraEditors.SimpleButton();
            this.cboDrv = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblDrv = new DevExpress.XtraEditors.LabelControl();
            this.cboBus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblBus = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).BeginInit();
            this.tabInfo.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDrv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBus.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.tabInfo.Size = new System.Drawing.Size(450, 198);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.DimGray;
            this.xtraTabPage1.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.btnSub2);
            this.xtraTabPage1.Controls.Add(this.btnAdd2);
            this.xtraTabPage1.Controls.Add(this.btnSub);
            this.xtraTabPage1.Controls.Add(this.btnAdd);
            this.xtraTabPage1.Controls.Add(this.txtTime);
            this.xtraTabPage1.Controls.Add(this.lblTime);
            this.xtraTabPage1.Controls.Add(this.dtpPStartTime);
            this.xtraTabPage1.Controls.Add(this.lblPStartTime);
            this.xtraTabPage1.Controls.Add(this.cboCase);
            this.xtraTabPage1.Controls.Add(this.lblCase);
            this.xtraTabPage1.Controls.Add(this.btnDrv);
            this.xtraTabPage1.Controls.Add(this.cboDrv);
            this.xtraTabPage1.Controls.Add(this.lblDrv);
            this.xtraTabPage1.Controls.Add(this.cboBus);
            this.xtraTabPage1.Controls.Add(this.lblBus);
            this.xtraTabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(444, 166);
            this.xtraTabPage1.Text = "时刻点";
            // 
            // btnSub2
            // 
            this.btnSub2.Image = ((System.Drawing.Image)(resources.GetObject("btnSub2.Image")));
            this.btnSub2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSub2.Location = new System.Drawing.Point(198, 122);
            this.btnSub2.LookAndFeel.SkinName = "Office 2013";
            this.btnSub2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSub2.Name = "btnSub2";
            this.btnSub2.Size = new System.Drawing.Size(34, 24);
            this.btnSub2.TabIndex = 14;
            this.btnSub2.Click += new System.EventHandler(this.btnSub2_Click);
            // 
            // btnAdd2
            // 
            this.btnAdd2.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd2.Image")));
            this.btnAdd2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAdd2.Location = new System.Drawing.Point(158, 122);
            this.btnAdd2.LookAndFeel.SkinName = "Office 2013";
            this.btnAdd2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(34, 24);
            this.btnAdd2.TabIndex = 13;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // btnSub
            // 
            this.btnSub.Image = ((System.Drawing.Image)(resources.GetObject("btnSub.Image")));
            this.btnSub.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSub.Location = new System.Drawing.Point(198, 87);
            this.btnSub.LookAndFeel.SkinName = "Office 2013";
            this.btnSub.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(34, 24);
            this.btnSub.TabIndex = 10;
            this.btnSub.Click += new System.EventHandler(this.btnSub_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(158, 87);
            this.btnAdd.LookAndFeel.SkinName = "Office 2013";
            this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 24);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTime
            // 
            this.txtTime.EditValue = "0";
            this.txtTime.Location = new System.Drawing.Point(86, 122);
            this.txtTime.Name = "txtTime";
            this.txtTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Properties.Appearance.Options.UseFont = true;
            this.txtTime.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtTime.Properties.LookAndFeel.SkinName = "Office 2013";
            this.txtTime.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTime.Size = new System.Drawing.Size(66, 24);
            this.txtTime.TabIndex = 12;
            // 
            // lblTime
            // 
            this.lblTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(20, 125);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(60, 17);
            this.lblTime.TabIndex = 11;
            this.lblTime.Text = "行驶时间：";
            // 
            // dtpPStartTime
            // 
            this.dtpPStartTime.EditValue = new System.DateTime(2016, 6, 28, 0, 0, 0, 0);
            this.dtpPStartTime.Location = new System.Drawing.Point(86, 87);
            this.dtpPStartTime.Name = "dtpPStartTime";
            this.dtpPStartTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPStartTime.Properties.Appearance.Options.UseFont = true;
            this.dtpPStartTime.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPStartTime.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpPStartTime.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPStartTime.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpPStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpPStartTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.dtpPStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpPStartTime.Properties.EditFormat.FormatString = "HH:mm";
            this.dtpPStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpPStartTime.Properties.LookAndFeel.SkinName = "Office 2013";
            this.dtpPStartTime.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpPStartTime.Properties.Mask.EditMask = "HH:mm";
            this.dtpPStartTime.Size = new System.Drawing.Size(66, 24);
            this.dtpPStartTime.TabIndex = 8;
            // 
            // lblPStartTime
            // 
            this.lblPStartTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPStartTime.Location = new System.Drawing.Point(20, 90);
            this.lblPStartTime.Name = "lblPStartTime";
            this.lblPStartTime.Size = new System.Drawing.Size(60, 17);
            this.lblPStartTime.TabIndex = 7;
            this.lblPStartTime.Text = "发车时间：";
            // 
            // cboCase
            // 
            this.cboCase.Location = new System.Drawing.Point(62, 52);
            this.cboCase.Name = "cboCase";
            this.cboCase.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCase.Properties.Appearance.Options.UseFont = true;
            this.cboCase.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCase.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboCase.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCase.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboCase.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCase.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboCase.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCase.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboCase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCase.Properties.LookAndFeel.SkinName = "Office 2013";
            this.cboCase.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboCase.Size = new System.Drawing.Size(90, 24);
            this.cboCase.TabIndex = 6;
            // 
            // lblCase
            // 
            this.lblCase.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCase.Location = new System.Drawing.Point(20, 55);
            this.lblCase.Name = "lblCase";
            this.lblCase.Size = new System.Drawing.Size(36, 17);
            this.lblCase.TabIndex = 5;
            this.lblCase.Text = "区间：";
            // 
            // btnDrv
            // 
            this.btnDrv.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrv.Appearance.Options.UseFont = true;
            this.btnDrv.Image = ((System.Drawing.Image)(resources.GetObject("btnDrv.Image")));
            this.btnDrv.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDrv.Location = new System.Drawing.Point(354, 17);
            this.btnDrv.LookAndFeel.SkinName = "Office 2013";
            this.btnDrv.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDrv.Name = "btnDrv";
            this.btnDrv.Size = new System.Drawing.Size(34, 24);
            this.btnDrv.TabIndex = 4;
            this.btnDrv.Click += new System.EventHandler(this.btnDrv_Click);
            // 
            // cboDrv
            // 
            this.cboDrv.Location = new System.Drawing.Point(258, 17);
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
            this.cboDrv.TabIndex = 3;
            // 
            // lblDrv
            // 
            this.lblDrv.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrv.Location = new System.Drawing.Point(204, 20);
            this.lblDrv.Name = "lblDrv";
            this.lblDrv.Size = new System.Drawing.Size(48, 17);
            this.lblDrv.TabIndex = 2;
            this.lblDrv.Text = "驾驶员：";
            // 
            // cboBus
            // 
            this.cboBus.Location = new System.Drawing.Point(62, 17);
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
            this.cboBus.SelectedIndexChanged += new System.EventHandler(this.cboBus_SelectedIndexChanged);
            // 
            // lblBus
            // 
            this.lblBus.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBus.Location = new System.Drawing.Point(20, 20);
            this.lblBus.Name = "lblBus";
            this.lblBus.Size = new System.Drawing.Size(36, 17);
            this.lblBus.TabIndex = 0;
            this.lblBus.Text = "车辆：";
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
            // frmSchEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 249);
            this.Controls.Add(this.tabInfo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSchEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "计划时刻点";
            this.Load += new System.EventHandler(this.frmSchEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).EndInit();
            this.tabInfo.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDrv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabInfo;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnDrv;
        private DevExpress.XtraEditors.ComboBoxEdit cboDrv;
        private DevExpress.XtraEditors.LabelControl lblDrv;
        private DevExpress.XtraEditors.ComboBoxEdit cboBus;
        private DevExpress.XtraEditors.LabelControl lblBus;
        private DevExpress.XtraEditors.ComboBoxEdit cboCase;
        private DevExpress.XtraEditors.LabelControl lblCase;
        private DevExpress.XtraEditors.TimeEdit dtpPStartTime;
        private DevExpress.XtraEditors.LabelControl lblPStartTime;
        private DevExpress.XtraEditors.LabelControl lblTime;
        private DevExpress.XtraEditors.TextEdit txtTime;
        private DevExpress.XtraEditors.SimpleButton btnSub;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnSub2;
        private DevExpress.XtraEditors.SimpleButton btnAdd2;
    }
}