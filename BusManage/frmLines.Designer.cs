namespace BusManage
{
    partial class frmLines
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLines));
            this.lvwLines = new System.Windows.Forms.ListView();
            this.imlIco = new System.Windows.Forms.ImageList(this.components);
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lvwLines
            // 
            this.lvwLines.CheckBoxes = true;
            this.lvwLines.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwLines.Location = new System.Drawing.Point(8, 8);
            this.lvwLines.MultiSelect = false;
            this.lvwLines.Name = "lvwLines";
            this.lvwLines.Size = new System.Drawing.Size(448, 150);
            this.lvwLines.TabIndex = 0;
            this.lvwLines.UseCompatibleStateImageBehavior = false;
            this.lvwLines.View = System.Windows.Forms.View.List;
            // 
            // imlIco
            // 
            this.imlIco.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIco.ImageStream")));
            this.imlIco.TransparentColor = System.Drawing.Color.Transparent;
            this.imlIco.Images.SetKeyName(0, "Arrow.png");
            // 
            // btnOk
            // 
            this.btnOk.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOk.Location = new System.Drawing.Point(362, 164);
            this.btnOk.LookAndFeel.SkinName = "Office 2013";
            this.btnOk.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 26);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "  确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 201);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lvwLines);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLines";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "线路选择";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwLines;
        private System.Windows.Forms.ImageList imlIco;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}