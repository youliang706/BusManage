namespace BusManage
{
    partial class frmBusChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusChange));
            this.tabInfo = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.chkDrv = new DevExpress.XtraEditors.CheckEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.cboBus2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblBus2 = new DevExpress.XtraEditors.LabelControl();
            this.gridList = new DevExpress.XtraGrid.GridControl();
            this.dgvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnDrv = new DevExpress.XtraEditors.SimpleButton();
            this.cboDrv2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboBus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblBus = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).BeginInit();
            this.tabInfo.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDrv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBus2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDrv2.Properties)).BeginInit();
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
            this.tabInfo.Size = new System.Drawing.Size(422, 360);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.DimGray;
            this.xtraTabPage1.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.chkDrv);
            this.xtraTabPage1.Controls.Add(this.pictureEdit1);
            this.xtraTabPage1.Controls.Add(this.cboBus2);
            this.xtraTabPage1.Controls.Add(this.lblBus2);
            this.xtraTabPage1.Controls.Add(this.gridList);
            this.xtraTabPage1.Controls.Add(this.btnDrv);
            this.xtraTabPage1.Controls.Add(this.cboDrv2);
            this.xtraTabPage1.Controls.Add(this.cboBus);
            this.xtraTabPage1.Controls.Add(this.lblBus);
            this.xtraTabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(416, 328);
            this.xtraTabPage1.Text = "更换车辆";
            // 
            // chkDrv
            // 
            this.chkDrv.Location = new System.Drawing.Point(204, 55);
            this.chkDrv.Name = "chkDrv";
            this.chkDrv.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDrv.Properties.Appearance.Options.UseFont = true;
            this.chkDrv.Properties.Caption = "驾驶员：";
            this.chkDrv.Properties.LookAndFeel.SkinName = "Office 2013";
            this.chkDrv.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkDrv.Size = new System.Drawing.Size(66, 21);
            this.chkDrv.TabIndex = 5;
            this.chkDrv.CheckedChanged += new System.EventHandler(this.chkDrv_CheckedChanged);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(169, 30);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit1.Size = new System.Drawing.Size(29, 36);
            this.pictureEdit1.TabIndex = 2;
            // 
            // cboBus2
            // 
            this.cboBus2.Location = new System.Drawing.Point(276, 17);
            this.cboBus2.Name = "cboBus2";
            this.cboBus2.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBus2.Properties.Appearance.Options.UseFont = true;
            this.cboBus2.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBus2.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboBus2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBus2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboBus2.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBus2.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboBus2.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBus2.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboBus2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBus2.Properties.LookAndFeel.SkinName = "Office 2013";
            this.cboBus2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboBus2.Size = new System.Drawing.Size(90, 24);
            this.cboBus2.TabIndex = 4;
            // 
            // lblBus2
            // 
            this.lblBus2.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBus2.Location = new System.Drawing.Point(234, 20);
            this.lblBus2.Name = "lblBus2";
            this.lblBus2.Size = new System.Drawing.Size(36, 17);
            this.lblBus2.TabIndex = 3;
            this.lblBus2.Text = "车辆：";
            // 
            // gridList
            // 
            this.gridList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridList.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridList.Location = new System.Drawing.Point(10, 94);
            this.gridList.MainView = this.dgvDetail;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(397, 226);
            this.gridList.TabIndex = 8;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetail});
            // 
            // dgvDetail
            // 
            this.dgvDetail.GridControl = this.gridList;
            this.dgvDetail.IndicatorWidth = 32;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.OptionsView.ShowIndicator = false;
            // 
            // btnDrv
            // 
            this.btnDrv.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrv.Appearance.Options.UseFont = true;
            this.btnDrv.Image = ((System.Drawing.Image)(resources.GetObject("btnDrv.Image")));
            this.btnDrv.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDrv.Location = new System.Drawing.Point(372, 54);
            this.btnDrv.LookAndFeel.SkinName = "Office 2013";
            this.btnDrv.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDrv.Name = "btnDrv";
            this.btnDrv.Size = new System.Drawing.Size(34, 24);
            this.btnDrv.TabIndex = 7;
            this.btnDrv.Click += new System.EventHandler(this.btnDrv_Click);
            // 
            // cboDrv2
            // 
            this.cboDrv2.Location = new System.Drawing.Point(276, 54);
            this.cboDrv2.Name = "cboDrv2";
            this.cboDrv2.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDrv2.Properties.Appearance.Options.UseFont = true;
            this.cboDrv2.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDrv2.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboDrv2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDrv2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboDrv2.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDrv2.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboDrv2.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDrv2.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboDrv2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDrv2.Properties.LookAndFeel.SkinName = "Office 2013";
            this.cboDrv2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboDrv2.Size = new System.Drawing.Size(90, 24);
            this.cboDrv2.TabIndex = 6;
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
            this.btnOK.Location = new System.Drawing.Point(236, 373);
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
            this.btnCancel.Location = new System.Drawing.Point(332, 373);
            this.btnCancel.LookAndFeel.SkinName = "Office 2013";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "  取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmBusChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.tabInfo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBusChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "更换车辆";
            this.Load += new System.EventHandler(this.frmBusChange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabInfo)).EndInit();
            this.tabInfo.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDrv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBus2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDrv2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabInfo;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnDrv;
        private DevExpress.XtraEditors.ComboBoxEdit cboDrv2;
        private DevExpress.XtraEditors.ComboBoxEdit cboBus;
        private DevExpress.XtraEditors.LabelControl lblBus;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit cboBus2;
        private DevExpress.XtraEditors.LabelControl lblBus2;
        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetail;
        private DevExpress.XtraEditors.CheckEdit chkDrv;
    }
}