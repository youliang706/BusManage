using Com.Database;
using Com.SubClass;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmRunningLog_Nr : Form
    {
        //定义委托事件 
        public event DataChangedEvevt DataChanged;

        private CDatabase db = Program.db;

        private EditMode editType;
        private string sysID;

        private int _lineid2;
        private DateTime _dte;

        public frmRunningLog_Nr(int lineid2, DateTime dte)
        {
            InitializeComponent();

            editType = EditMode.NewMode;
            _lineid2 = lineid2;
            _dte = dte;
            InitUcl();
        }

        public frmRunningLog_Nr(string sysid)
        {
            InitializeComponent();

            editType = EditMode.ModifyMode;
            sysID = sysid;
            _lineid2 = int.Parse(CFunc.IDValue("TB_NOTRUN_LOG", "SYSID", "LINEID2", sysID));
            InitUcl();
            FillData();

            CFunc.SetCtrlsSta(false, cboBus);
        }

        private void InitUcl()
        {
            InitCbo_Bus();
            InitCbo_Type();
        }

        private void InitCbo_Type()
        {
            ComboBoxItemCollection coll = cboRsn.Properties.Items;
            coll.BeginUpdate();
            coll.Clear();

            try
            {
                string sql = "SELECT NRUNRSNID, NRUNRSNNAME FROM TB_NOTRUNRSN WHERE STOPSIGN = 0";
                DataTable dt = db.GetRs(sql);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    coll.Add(new ExComboBox(i, dt.Rows[i]["NRUNRSNID"].ToString(), dt.Rows[i]["NRUNRSNNAME"].ToString()));
                }
            }
            finally
            {
                coll.EndUpdate();
            }

            cboRsn.SelectedIndex = -1;
        }

        private void InitCbo_Bus()
        {
            ComboBoxItemCollection coll = cboBus.Properties.Items;
            coll.BeginUpdate();
            coll.Clear();

            try
            {
                List<BusInfo> buses = CVar.Line_Buses(_lineid2);
                if (buses.Count > 0)
                {
                    for (int i = 0; i < buses.Count; i++)
                    {
                        coll.Add(new ExComboBox(i, buses[i].Busid2.ToString(), buses[i].Busnumber));
                    }
                }
            }
            finally
            {
                coll.EndUpdate();
            }

            cboBus.SelectedIndex = -1;
        }

        private void FillData()
        {
            string querySql = "SELECT RELATEDATE, LINEID2, BUSID2, STARTTIME, ENDTIME, RSNID, SUMMARY " + Environment.NewLine
                            + "FROM TB_NOTRUN_LOG " + Environment.NewLine
                            + "WHERE SYSID = '" + sysID + "' ";
            DataTable ds = db.GetRs(querySql);

            if (ds.Rows.Count > 0)
            {
                DataRow dr = ds.Rows[0];

                CSubClass.FindInCbo(cboBus, dr["BUSID2"].ToString());
                dtpStartTime.EditValue = DateTime.Parse(dr["STARTTIME"].ToString());
                dtpEndTime.EditValue = DateTime.Parse(dr["ENDTIME"].ToString());
                CSubClass.FindInCbo(cboRsn, dr["RSNID"].ToString());
                txtSummary.Text = ds.Rows[0]["SUMMARY"].ToString();
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
            if (!CFunc.CboCheck(cboBus, "车辆"))
            {
                return false;
            }
            if (!CFunc.CboCheck(cboRsn, "未发车原因"))
            {
                return false;
            }
            if (CFunc.DateDiff(DateInterval.Minute, DateTime.Parse(dtpStartTime.EditValue.ToString()), DateTime.Parse(dtpEndTime.EditValue.ToString())) < 0)
            {
                MessageBox.Show("截止时间必须大于开始时间。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void SaveData()
        {
            string sql;

            string lineid = CVar.LineID2ToID(_lineid2);
            string rsnid = ((ExComboBox)cboRsn.SelectedItem).Key;
            int busid2 = int.Parse(((ExComboBox)cboBus.SelectedItem).Key);
            string busid = CVar.BusID2ToID(_lineid2, busid2);

            if (editType == EditMode.NewMode)
            {
                sysID = CFunc.DBID();

                sql = "INSERT INTO TB_NOTRUN_LOG ( " 
                    + "    SYSID, LINEID, LINEID2, BUSID, BUSID2, STARTTIME, ENDTIME, RELATEDATE, RSNID, SUMMARY, MAKER, MAKEDATE " 
                    + ") VALUES ( " 
                    + "    '{0}', '{1}', {2}, '{3}', {4}, {5}, {6}, {7}, '{8}', '{9}', '" + CVar.LoginID + "', SYSDATE " 
                    + ") ";
            }
            else
            {
                sql = "UPDATE TB_NOTRUN_LOG SET " 
                    + "    STARTTIME = {5}, ENDTIME = {6}, RSNID = '{8}', SUMMARY = '{9}', MAKER = '" + CVar.LoginID + "', MAKEDATE = SYSDATE "
                    + "WHERE SYSID = '{0}' ";
            }
            sql = string.Format(sql,
                                sysID, lineid, _lineid2.ToString(), busid, busid2.ToString(),
                                CVar.TransTime(DateTime.Parse(dtpStartTime.EditValue.ToString()), _dte), CVar.TransTime(DateTime.Parse(dtpEndTime.EditValue.ToString()), _dte), CVar.TransTime(DateTime.Parse("00:00:00"), _dte),
                                rsnid, txtSummary.Text
                                );

            db.Execute(sql);
        }

        private void frmRunningLog_Nr_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
            CFunc.SetMaxLength("TB_NOTRUN_LOG", txtSummary, "SUMMARY");
        }
    }
}
