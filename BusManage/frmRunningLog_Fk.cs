using Com.Database;
using Com.SubClass;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmRunningLog_Fk : Form
    {
        //定义委托事件 
        public event DataChangedEvevt DataChanged;

        private CDatabase db = Program.db;

        private EditMode editType;
        private string sysID;

        private int _lineid2;
        private DateTime _dte;
        private int _period;

        public frmRunningLog_Fk(int lineid2, DateTime dte, int period)
        {
            InitializeComponent();

            editType = EditMode.NewMode;
            _lineid2 = lineid2;
            _dte = dte;
            _period = period;
            InitUcl();
        }

        public frmRunningLog_Fk(string sysid)
        {
            InitializeComponent();

            editType = EditMode.ModifyMode;
            sysID = sysid;
            _lineid2 = int.Parse(CFunc.IDValue("TB_FEEDBACK", "SYSID", "LINEID2", sysID));
            InitUcl();
            FillData();
        }

        private void InitUcl()
        {
            InitCbo();
            InitRemarks();
        }

        private void InitRemarks()
        {
            string sql = "SELECT PHRASENAME FROM TB_FEEDPHRASE";
            DataTable dt = db.GetRs(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CFunc.AddContextMenu(dt.Rows[i][0].ToString(), mnuSys.Items, new EventHandler(mnuClick));
            }

            //btnContent.ContextMenuStrip = mnuSys;
        }

        private void InitCbo()
        {
            ComboBoxItemCollection coll = cboType.Properties.Items;
            coll.BeginUpdate();
            coll.Clear();

            try
            {
                coll.Add(new ExComboBox(0, "0", "未执行"));
                coll.Add(new ExComboBox(1, "1", "执行"));
            }
            finally
            {
                coll.EndUpdate();
            }

            cboType.SelectedIndex = -1;
        }

        private void FillData()
        {
            string querySql = "SELECT FEEDTYPE, CONTENT " + Environment.NewLine
                            + "FROM TB_FEEDBACK " + Environment.NewLine
                            + "WHERE SYSID = '" + sysID + "' ";
            DataTable ds = db.GetRs(querySql);

            if (ds.Rows.Count > 0)
            {
                DataRow dr = ds.Rows[0];

                CSubClass.FindInCbo(cboType, dr["FEEDTYPE"].ToString());
                txtContent.Text = ds.Rows[0]["CONTENT"].ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckData())
            {
                return;
            }

            SaveData();

            DataChanged(editType, sysID);
            this.Close();
        }

        private bool CheckData()
        {
            if (!CFunc.CboCheck(cboType, "反馈类型"))
            {
                return false;
            }
            if (!CFunc.TxtCheck(txtContent, "反馈内容"))
            {
                return false;
            }

            return true;
        }

        private void SaveData()
        {
            string sql;

            string feedtype = ((ExComboBox)cboType.SelectedItem).Key;
            string lineid = CVar.LineID2ToID(_lineid2);

            if (editType == EditMode.NewMode)
            {
                sysID = CFunc.DBID();

                sql = "INSERT INTO TB_FEEDBACK ( "
                    + "    SYSID, LINEID, LINEID2, RELATEDATE, PERIOD, FEEDTYPE, CONTENT, MAKER, MAKEDATE " 
                    + ") VALUES ( " 
                    + "    '{0}', '{1}', {2}, {3}, {4}, '{5}', '{6}', '" + CVar.LoginID + "', SYSDATE " 
                    + ") ";
            }
            else
            {
                sql = "UPDATE TB_FEEDBACK SET " 
                    + "    FEEDTYPE = '{5}', CONTENT = '{6}', MAKER = '" + CVar.LoginID + "', MAKEDATE = SYSDATE "
                    + "WHERE SYSID = '{0}' ";
            }
            sql = string.Format(sql,
                                sysID, lineid, _lineid2.ToString(), CVar.TransTime(DateTime.Parse("00:00:00"), _dte), _period.ToString(),
                                feedtype, txtContent.Text
                                );

            db.Execute(sql);
        }

        private void frmRunningLog_Fk_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
            CFunc.SetMaxLength("TB_FEEDBACK", txtContent, "CONTENT");
        }

        private void mnuClick(object sender, EventArgs e)
        {
            txtContent.Text = (sender as ToolStripMenuItem).Text;
        }

        private void btnContent_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mnuSys.Show(btnContent, e.Location);
            }
        }
    }
}
