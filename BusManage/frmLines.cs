using Com.Database;
using System;
using System.Data;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmLines : Form
    {
        private CDatabase db = Program.db;
        private bool blnRet;
        public frmLines()
        {
            InitializeComponent();
        }

        public bool ShowMe()
        {
            InitLvw();

            if (lvwLines.Items.Count == 1)
            {
                btnOk_Click(this.btnOk, new EventArgs());
            }
            else
            {
                this.ShowDialog();
            }
            return blnRet;
        }

        /// <summary>
        /// 填写管理线路
        /// </summary>
        private void InitLvw()
        {
            lvwLines.SmallImageList = imlIco;

            string sql = string.Format("SELECT b.lineid2, b.linename FROM tb_user_lines a INNER JOIN tb_lines b ON b.lineid = a.lineid " + Environment.NewLine
                                     + "WHERE UPPER(a.usercode) = '{0}' AND b.stopsign = 0", CVar.LoginID);
            DataTable dt = db.GetRs(sql);

            DataView dv = dt.DefaultView;
            dv.Sort = "linename";
            dt = dv.ToTable();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvwLines.Items.Add(dt.Rows[i]["lineid2"].ToString(), dt.Rows[i]["linename"].ToString(),0);
                lvwLines.Items[i].Tag = dt.Rows[i]["lineid2"].ToString();
                lvwLines.Items[i].Checked = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string slines = "";

            for (int i = 0; i < lvwLines.Items.Count; i++)
            {
                if (lvwLines.Items[i].Checked)
                {
                    slines += "," + lvwLines.Items[i].Tag;
                }
            }

            if (slines != "")
            {
                this.Hide();

                bool blnExit;
                if (CVar.ChkLines(slines.Substring(1), out blnExit))
                {
                    blnRet = true;
                    this.Close();
                }
                else if (blnExit)
                {
                    this.Close();
                }
                else
                {
                    this.ShowDialog();
                }
            }
            else
            { 
                MessageBox.Show("请选择线路。","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning); 
            }
        }
    }
}
