using Com.Database;
using Com.SubClass;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmRepairLogInput : Form
    {
        //定义委托事件 
        public event DataChangedEvevt DataChanged;

        private CDatabase db = Program.db;

        private EditMode editType;
        private string sysID;

        public frmRepairLogInput()
        {
            InitializeComponent();

            editType = EditMode.NewMode;
            InitUcl();
        }

        public frmRepairLogInput(string sysid)
        {
            InitializeComponent();

            editType = EditMode.ModifyMode;
            sysID = sysid;
            InitUcl();
            FillData();

            CFunc.SetCtrlsSta(false, dtpDate, cboLine, cboBus);
        }

        private void InitUcl()
        {
            CSubClass.SetXtraDtpStyle(dtpDate, DtType.LongDate);
            dtpDate.EditValue = DateTime.Now;

            InitCbo();
        }

        private void InitCbo()
        {
            InitCbo_Line();

            if (cboLine.SelectedIndex >= 0)
            {
                int lineid = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
                InitCbo_Bus(lineid);
            }

            InitCbo_Type();
        }

        private void InitCbo_Line()
        {
            ComboBoxItemCollection coll = cboLine.Properties.Items;
            coll.BeginUpdate();
            coll.Clear();

            try
            {
                Dictionary<string, LineInfo> lines = CVar.Lines;
                if (lines.Count > 0)
                {
                    int i = 0;
                    foreach (KeyValuePair<string, LineInfo> li in lines)
                    {
                        coll.Add(new ExComboBox(i++, li.Value.Lineid2.ToString(), li.Value.Linename));
                    }
                }
            }
            finally
            {
                coll.EndUpdate();
            }

            cboLine.SelectedIndex = -1;
        }

        private void InitCbo_Type()
        {
            ComboBoxItemCollection coll = cboFalut.Properties.Items;
            coll.BeginUpdate();
            coll.Clear();

            try
            {
                string sql = "SELECT FALUTID, FALUTNAME FROM TB_FALUTTYPE WHERE STOPSIGN = 0";
                DataTable dt = db.GetRs(sql);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    coll.Add(new ExComboBox(i, dt.Rows[i]["FALUTID"].ToString(), dt.Rows[i]["FALUTNAME"].ToString()));
                }
            }
            finally
            {
                coll.EndUpdate();
            }

            cboFalut.SelectedIndex = -1;
        }

        private void InitCbo_Bus(int lineid)
        {
            ComboBoxItemCollection coll = cboBus.Properties.Items;
            coll.BeginUpdate();
            coll.Clear();

            try
            {
                List<BusInfo> buses = CVar.Line_Buses(lineid);
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
            string querySql = "SELECT RELATEDATE, LINEID2, BUSID2, to_char(REGTIME,'hh24:mi') AS REGTIME, FALUTID, SUMMARY " + Environment.NewLine
                            + "FROM TB_REPAIR_LOG " + Environment.NewLine
                            + "WHERE SYSID = '" + sysID + "' ";
            DataTable ds = db.GetRs(querySql);

            if (ds.Rows.Count > 0)
            {
                DataRow dr = ds.Rows[0];

                dtpDate.EditValue = DateTime.Parse(dr["RELATEDATE"].ToString());
                CSubClass.FindInCbo(cboLine, dr["LINEID2"].ToString());
                CSubClass.FindInCbo(cboBus, dr["BUSID2"].ToString());

                dtpRegTime.EditValue = DateTime.Parse(dr["REGTIME"].ToString());
                CSubClass.FindInCbo(cboFalut, dr["FALUTID"].ToString());
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
            if (!CFunc.CboCheck(cboLine, "线路"))
            {
                return false;
            }
            if (!CFunc.CboCheck(cboBus, "车辆"))
            {
                return false;
            }
            if (!CFunc.CboCheck(cboFalut, "故障类型"))
            {
                return false;
            }

            int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
            int busid2 = int.Parse(((ExComboBox)cboBus.SelectedItem).Key);

            if (CFunc.ChkExists("TB_REPAIR_LOG", "BUSID2", busid2, "LINEID2 = " + lineid2 + " AND STATUS = 0" + (editType == EditMode.NewMode ? "" : " AND SYSID <> '" + sysID + "'")))
            {
                MessageBox.Show("车辆已有报修且未处理完成的记录。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void SaveData()
        {
            string sql;

            int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
            string lineid = CVar.LineID2ToID(lineid2);
            string faluttype = ((ExComboBox)cboFalut.SelectedItem).Key;
            int busid2 = int.Parse(((ExComboBox)cboBus.SelectedItem).Key);
            string busid = CVar.BusID2ToID(lineid2, busid2);

            if (editType == EditMode.NewMode)
            {
                sysID = CFunc.DBID();

                sql = "INSERT INTO TB_REPAIR_LOG ( " 
                    + "    SYSID, LINEID, LINEID2, BUSID, BUSID2, REGTIME, RELATEDATE, FALUTID, SUMMARY, MAKER, MAKEDATE " 
                    + ") VALUES ( "
                    + "    '{0}', '{1}', {2}, '{3}', {4}, {5}, {6}, '{7}', '{8}', '" + CVar.LoginID + "', SYSDATE "
                    + ") ";
            }
            else
            {
                sql = "UPDATE TB_REPAIR_LOG SET " 
                    + "    REGTIME = {5}, " 
                    + "    FALUTID = '{7}', SUMMARY = '{8}', "
                    + "    MAKER = '" + CVar.LoginID + "', MAKEDATE = SYSDATE "
                    + "WHERE SYSID = '{0}' ";
            }
            sql = string.Format(sql,
                                sysID, lineid, lineid2.ToString(), busid, busid2.ToString(),
                                CVar.TransTime(CVar.TimeValue(dtpRegTime.Text), CVar.DateValue(dtpDate.Text)), CVar.TransTime(DateTime.Parse("00:00:00"), CVar.DateValue(dtpDate.Text)),
                                faluttype, txtSummary.Text
                                );

            db.Execute(sql);
        }

        private void frmRepairLogInput_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
            CFunc.SetMaxLength("TB_REPAIR_LOG", txtSummary, "SUMMARY");
        }

        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLine.SelectedIndex >= 0)
            {
                int lineid = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
                InitCbo_Bus(lineid);
            }
            else
            {
                cboBus.Properties.Items.Clear();
            }
        }
    }
}
