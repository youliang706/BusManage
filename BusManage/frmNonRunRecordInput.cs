using Com.Database;
using Com.SubClass;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmNonRunRecordInput : Form
    {
        //定义委托事件 
        public event DataChangedEvevt DataChanged;

        private CDatabase db = Program.db;

        private EditMode editType;
        private string recID;

        public frmNonRunRecordInput()
        {
            InitializeComponent();

            editType = EditMode.NewMode;
            InitUcl();
        }

        public frmNonRunRecordInput(string recid)
        {
            InitializeComponent();

            editType = EditMode.ModifyMode;
            recID = recid;
            InitUcl();
            FillData();

            CFunc.SetCtrlsSta(false, dtpDate, cboLine, cboBus);
        }

        private void InitUcl()
        {
            CSubClass.SetXtraDtpStyle(dtpDate, DtType.LongDate);
            dtpDate.EditValue = DateTime.Now;

            InitCbo();
            InitRemarks();
        }

        private void InitRemarks()
        {
            string sql = "SELECT REMARKSNAME FROM TB_REMARKS";
            DataTable dt = db.GetRs(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CFunc.AddContextMenu(dt.Rows[i][0].ToString(), mnuSys.Items, new EventHandler(mnuClick));
            }

            //btnRemarks.ContextMenuStrip = mnuSys;
        }

        private void InitCbo()
        {
            InitCbo_Line();

            if (cboLine.SelectedIndex >= 0)
            {
                int lineid = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
                InitCbo_Bus(lineid);
                InitCbo_Drv(lineid);
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
            ComboBoxItemCollection coll = cboNonOpr.Properties.Items;
            coll.BeginUpdate();
            coll.Clear();

            try
            {
                string sql = "SELECT NONOPRID, NONOPRNAME FROM TB_NONOPRTYPE WHERE STOPSIGN = 0";
                DataTable dt = db.GetRs(sql);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    coll.Add(new ExComboBox(i, dt.Rows[i]["NONOPRID"].ToString(), dt.Rows[i]["NONOPRNAME"].ToString()));
                }
            }
            finally
            {
                coll.EndUpdate();
            }

            cboNonOpr.SelectedIndex = -1;
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

        private void InitCbo_Drv(int lineid)
        {
            ComboBoxItemCollection coll = cboDrv.Properties.Items;
            coll.BeginUpdate();
            coll.Clear();

            try
            {
                List<DrvInfo> drivers = CVar.Line_Drivers(lineid);
                if (drivers.Count > 0)
                {
                    for (int i = 0; i < drivers.Count; i++)
                    {
                        coll.Add(new ExComboBox(i, drivers[i].Drvnumber.ToString(), drivers[i].Drvname));
                    }
                }

            }
            finally
            {
                coll.EndUpdate();
            }

            cboDrv.SelectedIndex = -1;
        }

        private void FillKm()
        {
            if (cboBus.SelectedItem != null)
            {
                int busid2 = int.Parse(((ExComboBox)cboBus.SelectedItem).Key);
                txtKm.Text = CVar.GetRealMileage(busid2, CVar.DateValue(dtpDate.Text), CVar.TimeValue(dtpStartTime.Text), CVar.TimeValue(dtpArriveTime.Text)).ToString();
            }
            else
            {
                txtKm.Text = "";
            }
        }

        private void FillData()
        {
            string querySql = "SELECT CHKDATE, LINEID2, BUSID2, DRVNUMBER, " + Environment.NewLine
                            + "    STARTTIME, ARRIVETIME, PLAN_NON_OPR_MILEAGE, NON_OPR_MILEAGE, NON_OPR_TYPE, REMARKS " + Environment.NewLine
                            + "FROM TB_NONRUN_RECORDS " + Environment.NewLine
                            + "WHERE RECID = '" + recID + "' ";
            DataTable ds = db.GetRs(querySql);

            if (ds.Rows.Count > 0)
            {
                DataRow dr = ds.Rows[0];

                dtpDate.EditValue = DateTime.Parse(dr["CHKDATE"].ToString());
                CSubClass.FindInCbo(cboLine, dr["LINEID2"].ToString());
                CSubClass.FindInCbo(cboBus, dr["BUSID2"].ToString());
                CSubClass.FindInCbo(cboDrv, dr["DRVNUMBER"].ToString());
                CSubClass.FindInCbo(cboNonOpr, dr["NON_OPR_TYPE"].ToString());

                dtpStartTime.EditValue = DateTime.Parse(dr["STARTTIME"].ToString());
                dtpArriveTime.EditValue = DateTime.Parse(dr["ARRIVETIME"].ToString());
                txtPKm.Text = dr["PLAN_NON_OPR_MILEAGE"].ToString();
                txtKm.Text = dr["NON_OPR_MILEAGE"].ToString();

                txtRemarks.Text = ds.Rows[0]["REMARKS"].ToString();
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

            DataChanged(editType, recID);
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
            if (!CFunc.CboCheck(cboDrv, "驾驶员"))
            {
                return false;
            }
            if (!CFunc.CboCheck(cboNonOpr, "非运营类型"))
            {
                return false;
            }
            if (CFunc.DateDiff(DateInterval.Minute, CVar.TimeValue(dtpStartTime.Text), CVar.TimeValue(dtpArriveTime.Text)) < 0)
            {
                MessageBox.Show("到达时间必须大于发车时间。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!CFunc.TxtCheck(txtPKm, "计划里程"))
            {
                return false;
            }
            if (!CFunc.TxtCheck(txtKm, "实际里程"))
            {
                return false;
            }

            return true;
        }

        private void SaveData()
        {
            string sql;

            int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
            string lineid = CVar.LineID2ToID(lineid2);
            string non_opr_type = ((ExComboBox)cboNonOpr.SelectedItem).Key;
            int busid2 = int.Parse(((ExComboBox)cboBus.SelectedItem).Key);
            string busid = CVar.BusID2ToID(lineid2, busid2);
            string drvnumber = ((ExComboBox)cboDrv.SelectedItem).Key;
            string drvid = CVar.DrvNumberToID(lineid2, drvnumber);

            int runtime = CVar.TimeDiff(CVar.TimeValue(dtpStartTime.Text), CVar.TimeValue(dtpArriveTime.Text));
            int runnumer = CVar.GetRunNumber(lineid2, busid2, CVar.DateValue(dtpDate.Text));

            int audsign = 0;
            string summary = "";
          
            //自动审核
            if (double.Parse(txtPKm.Text) != 0)
            {
                audsign = Math.Abs(double.Parse(txtKm.Text) - double.Parse(txtPKm.Text)) / double.Parse(txtKm.Text) < (1 - 0.75) ? 1 : 0;
                          
                if (audsign == 1)
                {
                    summary += "里程达标；";
                }
                else
                {
                    summary += "里程未达标；";
                }
            }

            if (editType == EditMode.NewMode)
            {
                recID = CFunc.DBID();

                sql = "INSERT INTO TB_NONRUN_RECORDS ( "
                    + "    RECID, CHKDATE, LINEID, LINEID2, BUSID, BUSID2, DRVID, DRVNUMBER, "
                    + "    STARTTIME, ARRIVETIME, "
                    + "    RUN_TIME, PLAN_NON_OPR_MILEAGE, NON_OPR_MILEAGE, NON_OPR_TYPE, "
                    + "    RUNNUMBER, REMARKS, SUMMARY, "
                    + "    MAKER, MAKEDATE, AUDSIGN, AUDOR, AUDDATE "
                    + ") VALUES ( "
                    + "    '{0}', {1}, '{2}', {3}, '{4}', {5}, '{6}', {7}, "
                    + "    {8}, {9}, "
                    + "    {10}, {11}, {12}, '{13}', "
                    + "    {14}, '{15}', '{16}', "
                    + "    '" + CVar.LoginID + "', SYSDATE, {17}, NULL, NULL "
                    + ") ";
            }
            else
            {
                sql = "UPDATE TB_NONRUN_RECORDS SET "
                    + "    DRVID= '{6}', DRVNUMBER = '{7}', "
                    + "    STARTTIME = {8}, ARRIVETIME = {9}, "
                    + "    RUN_TIME = {10}, PLAN_NON_OPR_MILEAGE = {11}, NON_OPR_MILEAGE = {12}, NON_OPR_TYPE = '{13}', "
                    + "    RUNNUMBER = {14}, REMARKS = '{15}', SUMMARY = '{16}', "
                    + "    MAKER = '" + CVar.LoginID + "', MAKEDATE = SYSDATE, AUDSIGN = {17}, AUDOR = NULL, AUDDATE = NULL "
                    + "WHERE RECID = '{0}' ";
            }
            sql = string.Format(sql,
                                recID, CVar.TransTime(DateTime.Parse("00:00:00"), CVar.DateValue(dtpDate.Text)), lineid, lineid2.ToString(), busid, busid2.ToString(), drvid, drvnumber,
                                CVar.TransTime(CVar.TimeValue(dtpStartTime.Text), CVar.DateValue(dtpDate.Text)), CVar.TransTime(CVar.TimeValue(dtpArriveTime.Text), CVar.DateValue(dtpDate.Text)),
                                runtime.ToString(), txtPKm.Text, txtKm.Text, non_opr_type, 
                                runnumer.ToString(), txtRemarks.Text, summary, audsign.ToString()
                                );

            db.Execute(sql);
        }

        private void frmNonRunRecordInput_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
            CFunc.SetMaxLength("TB_NONRUN_RECORDS", txtRemarks, "REMARKS");
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            FillKm();
        }

        private void mnuClick(object sender, EventArgs e)
        {
            txtRemarks.Text = (sender as ToolStripMenuItem).Text;
        }

        private void btnRemarks_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mnuSys.Show(btnRemarks, e.Location);
            }
        }

        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLine.SelectedIndex >= 0)
            {
                int lineid = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
                InitCbo_Bus(lineid);
                InitCbo_Drv(lineid);
            }
            else
            {
                cboBus.Properties.Items.Clear();
                cboDrv.Properties.Items.Clear();
            }
        }

        private void btnDrv_Click(object sender, EventArgs e)
        {
            frmDrvSel frm = new frmDrvSel();
            DrvInfo di = frm.ShowMe();

            if (di != null)
            {
                ComboBoxItemCollection coll = cboDrv.Properties.Items;
                coll.BeginUpdate();
                try
                {
                    coll.Add(new ExComboBox(coll.Count, di.Drvnumber.ToString(), di.Drvname));
                }
                finally
                {
                    coll.EndUpdate();
                }

                cboDrv.SelectedIndex = coll.Count - 1;
            }
        }

        private void cboBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKm.Text = "";
        }

        private void dtpDate_EditValueChanged(object sender, EventArgs e)
        {
            txtKm.Text = "";
        }

        private void dtpStartTime_EditValueChanged(object sender, EventArgs e)
        {
            txtKm.Text = "";
        }

        private void dtpArriveTime_EditValueChanged(object sender, EventArgs e)
        {
            txtKm.Text = "";
        }
    }
}
