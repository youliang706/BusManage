namespace BusManage
{
    partial class frmRunningLog_Fk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRunningLog_Fk));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.tabInfo = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtContent = new DevExpress.XtraEditors.MemoEdit();
            this.btnContent = new DevExpress.XtraEditors.SimpleButton();
            this.lblContent = new DevExpress.XtraEditors.LabelControl();
            this.cboType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.mnuSys = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).BeginInit();
            this.tabInfo.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOK.Location = new System.Drawing.Point(266, 213);
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
            this.btnCancel.Location = new System.Drawing.Point(362, 213);
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
            this.xtraTabPage1.Controls.Add(this.txtContent);
            this.xtraTabPage1.Controls.Add(this.btnContent);
            this.xtraTabPage1.Controls.Add(this.lblContent);
            this.xtraTabPage1.Controls.Add(this.cboType);
            this.xtraTabPage1.Controls.Add(this.lblType);
            this.xtraTabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(444, 168);
            this.xtraTabPage1.Text = "快速反馈";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(86, 60);
            this.txtContent.Name = "txtContent";
            this.txtContent.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.Properties.Appearance.Options.UseFont = true;
            this.txtContent.Size = new System.Drawing.Size(288, 87);
            this.txtContent.TabIndex = 3;
            // 
            // btnContent
            // 
            this.btnContent.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContent.Appearance.Options.UseFont = true;
            this.btnContent.Image = ((System.Drawing.Image)(resources.GetObject("btnContent.Image")));
            this.btnContent.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnContent.Location = new System.Drawing.Point(380, 60);
            this.btnContent.LookAndFeel.SkinName = "Office 2013";
            this.btnContent.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnContent.Name = "btnContent";
            this.btnContent.Size = new System.Drawing.Size(40, 24);
            this.btnContent.TabIndex = 4;
            this.btnContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnContent_MouseDown);
            // 
            // lblContent
            // 
            this.lblContent.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent.Location = new System.Drawing.Point(20, 63);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(60, 17);
            this.lblContent.TabIndex = 2;
            this.lblContent.Text = "反馈内容：";
            // 
            // cboType
            // 
            this.cboType.Location = new System.Drawing.Point(86, 20);
            this.cboType.Name = "cboType";
            this.cboType.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboType.Properties.Appearance.Options.UseFont = true;
            this.cboType.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboType.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboType.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboType.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboType.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboType.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboType.Properties.LookAndFeel.SkinName = "Office 2013";
            this.cboType.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboType.Size = new System.Drawing.Size(130, 24);
            this.cboType.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(20, 23);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(60, 17);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "反馈类型：";
            // 
            // mnuSys
            // 
            this.mnuSys.Name = "mnuSys";
            this.mnuSys.Size = new System.Drawing.Size(61, 4);
            // 
            // frmRunningLog_Fk
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
            this.Name = "frmRunningLog_Fk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "反馈信息";
            this.Load += new System.EventHandler(this.frmRunningLog_Fk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).EndInit();
            this.tabInfo.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraTab.XtraTabControl tabInfo;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LabelControl lblContent;
        private DevExpress.XtraEditors.ComboBoxEdit cboType;
        private DevExpress.XtraEditors.LabelControl lblType;
        private DevExpress.XtraEditors.SimpleButton btnContent;
        private DevExpress.XtraEditors.MemoEdit txtContent;
        private System.Windows.Forms.ContextMenuStrip mnuSys;
    }
}