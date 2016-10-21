using Com.Database;
using Com.SubClass;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmDrvingRecordInput : Form
    {
        //定义委托事件 
        public event DataChangedEvevt DataChanged;

        private CDatabase db = Program.db;

        private EditMode editType;
        private string recID;

        public frmDrvingRecordInput()
        {
            InitializeComponent();

            editType = EditMode.NewMode;
            InitUcl();
        }

        public frmDrvingRecordInput(string recid)
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

            CFunc.SetCtrlsSta(false, txtStartTime, txtArriveTime, txtPKm, txtKm);
        }

        private void InitRemarks()
        {
            string sql = "SELECT remarksName FROM TB_REMARKS";
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
                InitCbo_Case(lineid);
                InitCbo_Bus(lineid);
                InitCbo_Drv(lineid);
            }

            InitCbo_Direct();
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

        private void InitCbo_Case(int lineid)
        {
            ComboBoxItemCollection coll = cboCase.Properties.Items;
            coll.BeginUpdate();
            coll.Clear();

            try
            {
                List<CaseInfo> cases = CVar.Line_Cases(lineid);
                if (cases.Count > 0)
                {
                    for (int i = 0; i < cases.Count; i++)
                    {
                        coll.Add(new ExComboBox(i, cases[i].Caseid.ToString(), cases[i].Casename));
                    }
                }
            }
            finally
            {
                coll.EndUpdate();
            }

            cboCase.SelectedIndex = -1;
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

        private void InitCbo_Direct()
        {
            ComboBoxItemCollection coll = cboDirect.Properties.Items;
            coll.BeginUpdate();
            coll.Clear();
            try
            {
                coll.Add(new ExComboBox(0, "0", "上行"));
                coll.Add(new ExComboBox(1, "1", "下行"));
            }
            finally
            {
                coll.EndUpdate();
            }

            cboDirect.SelectedIndex = -1;
        }

        private void FillPKm()
        {
            if (cboCase.SelectedItem != null && cboDirect.SelectedItem != null)
            {
                int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
                string caseid = ((ExComboBox)cboCase.SelectedItem).Key;
                int direct = int.Parse(((ExComboBox)cboDirect.SelectedItem).Key);

                CaseInfo ci = CVar.Line_case(lineid2, caseid);
                double km = direct == 0 ? ci.Uplength : ci.Downlength;

                txtPKm.Text = km.ToString();
            }
            else
            {
                txtPKm.Text = "";
            }
        }

        private void FillKm()
        {
            if (cboBus.SelectedItem != null && txtStartTime.Text != "" && txtArriveTime.Text != "")
            {
                int busid2 = int.Parse(((ExComboBox)cboBus.SelectedItem).Key);
                txtKm.Text = CVar.GetRealMileage(busid2, CVar.DateValue(dtpDate.Text), DateTime.Parse(txtStartTime.Text), DateTime.Parse(txtArriveTime.Text)).ToString();
            }
            else
            {
                txtKm.Text = "";
            }
        }

        private void FillData()
        {
            string querySql = "SELECT CHKDATE, LINEID2, BUSID2, RUNNUMBER, DRVNUMBER, CASEID, DIRECT, " + Environment.NewLine
                            + "    PLAN_STARTTIME, PLAN_ARRIVETIME, to_char(STARTTIME,'hh24:mi') AS STARTTIME, to_char(ARRIVETIME,'hh24:mi') AS ARRIVETIME, " + Environment.NewLine
                            + "    PLAN_OPR_MILEAGE, OPR_MILEAGE, REMARKS " + Environment.NewLine
                            + "FROM TB_DRIVING_RECORDS " + Environment.NewLine
                            + "WHERE RECID = '" + recID + "' ";
            DataTable ds = db.GetRs(querySql);

            if (ds.Rows.Count > 0)
            {
                DataRow dr = ds.Rows[0];

                dtpDate.EditValue = DateTime.Parse(dr["CHKDATE"].ToString());
                CSubClass.FindInCbo(cboLine, dr["LINEID2"].ToString());
                CSubClass.FindInCbo(cboBus, dr["BUSID2"].ToString());
                CSubClass.FindInCbo(cboDrv, dr["DRVNUMBER"].ToString());
                CSubClass.FindInCbo(cboCase, dr["CASEID"].ToString());
                CSubClass.FindInCbo(cboDirect, dr["DIRECT"].ToString());

                dtpPStartTime.EditValue = DateTime.Parse(dr["PLAN_STARTTIME"].ToString());
                dtpPArriveTime.EditValue = DateTime.Parse(dr["PLAN_ARRIVETIME"].ToString());
                if (dr["STARTTIME"] == null)
                {
                    txtStartTime.Text = dr["STARTTIME"].ToString();
                }
                if (dr["ARRIVETIME"] == null)
                {
                    txtArriveTime.Text = dr["ARRIVETIME"].ToString();
                }
                txtPKm.Text = dr["PLAN_OPR_MILEAGE"].ToString();
                txtKm.Text = dr["OPR_MILEAGE"].ToString();

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
            if (!CFunc.CboCheck(cboCase, "区间"))
            {
                return false;
            }
            if (!CFunc.CboCheck(cboDirect, "方向"))
            {
                return false;
            }
            if (CFunc.DateDiff(DateInterval.Minute, DateTime.Parse(dtpPStartTime.EditValue.ToString()),DateTime.Parse(dtpPArriveTime.EditValue.ToString())) < 0)
            {
                MessageBox.Show("计划到达时间必须大于计划发车时间。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtPKm.Text == "") { txtPKm.Text = "0"; }
            if (txtKm.Text == "") { txtKm.Text = "0"; }

            return true;
        }

        private void SaveData()
        {
            string sql;

            int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
            string lineid = CVar.LineID2ToID(lineid2);
            string caseid = ((ExComboBox)cboCase.SelectedItem).Key;
            int busid2 = int.Parse(((ExComboBox)cboBus.SelectedItem).Key);
            string busid = CVar.BusID2ToID(lineid2, busid2);
            string drvnumber = ((ExComboBox)cboDrv.SelectedItem).Key;
            string drvid = CVar.DrvNumberToID(lineid2, drvnumber);
            int direct = int.Parse(((ExComboBox)cboDirect.SelectedItem).Key);

            string starttime = "", arrivetime = "";
            if (txtStartTime.Text != "")
            {
                starttime = CVar.TransTime(CVar.TimeValue(txtStartTime.Text), CVar.DateValue(dtpDate.Text));
            }
            if (txtArriveTime.Text != "")
            {
                arrivetime = CVar.TransTime(CVar.TimeValue(txtStartTime.Text), CVar.DateValue(dtpDate.Text));
            }

            int runtime;
            string fastorslow;
            if (txtStartTime.Text == "" || txtArriveTime.Text == "")
            {
                runtime = 0;
                fastorslow = "NULL";
            }
            else
            {
                runtime = CVar.TimeDiff(DateTime.Parse(txtStartTime.Text), DateTime.Parse(txtArriveTime.Text));
                fastorslow = (runtime - CVar.TimeDiff(CVar.TimeValue(dtpPStartTime.Text), CVar.TimeValue(dtpPArriveTime.Text))).ToString();
            }

            int runnumer = CVar.GetRunNumber(lineid2, busid2, CVar.DateValue(dtpDate.Text));

            CaseInfo ci = CVar.Line_case(lineid2, caseid);
            double con_busTimes = ci.Countway == 2 ? 0.5 : 1;

            int stationnum = direct == 0 ? ci.Up_stationnum : ci.Dn_stationnum;

            int audsign = 0;
            string summary = "";
          
              //实驶准点、自动审核
            if (starttime != "" && arrivetime != "")
            {
                if (Math.Abs(CVar.TimeDiff(CVar.TimeValue(dtpPStartTime.Text), DateTime.Parse(starttime))) > 7)
                {
                    audsign = 0;
                    summary = "实际发车与计划发车偏差过大；";
                }
                else
                {
                    int num = CVar.GetNotPassStations(lineid2, caseid, direct, busid2, DateTime.Now, DateTime.Parse(starttime), DateTime.Parse(arrivetime));
                  
                    if (num / stationnum < (1 - 0.75)) 
                    {
                        audsign = 1;
                        summary = "站点通过率达标；";
                    }
                    else
                    {
                        audsign = 0;
                        summary = "站点通过率未达标(" + num.ToString() + "站未获取进出站)；";
                    }
                  
                    if (audsign == 0)
                    {
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
                    }
                }
            }
            else
            {
                audsign = 0;
            }

            if (starttime == "") { starttime = "NULL"; }
            if (arrivetime == "") { arrivetime = "NULL"; }

            if (editType == EditMode.NewMode)
            {
                recID = CFunc.DBID();

                sql = "INSERT INTO TB_DRIVING_RECORDS ( "
                    + "    RECID, CHKDATE, LINEID, LINEID2, CASEID, BUSID, BUSID2, DRVID, DRVNUMBER, "
                    + "    PLAN_STARTTIME, PLAN_ARRIVETIME, STARTTIME, ARRIVETIME, "
                    + "    RUNSTATUS, DIRECT, RUN_TIME, FASTORSLOW, PLAN_OPR_MILEAGE, OPR_MILEAGE, "
                    + "    RUNNUMBER, CON_BUSTIMES, REMARKS, SUMMARY, SRCTYPE, EDITSIGN, CRDATE, "
                    + "    MAKER, MAKEDATE, AUDSIGN, AUDOR, AUDDATE "
                    + ") VALUES ( "
                    + "    '{0}', {1}, '{2}', {3}, '{4}', '{5}', {6}, '{7}', {8}, "
                    + "    {9}, {10}, {11}, {12}, "
                    + "    {13}, {14}, {15}, {16}, {17}, {18}, "
                    + "    {19}, {20}, '{21}', '{22}', 1, 0, SYSDATE, "
                    + "    '" + CVar.LoginID + "', SYSDATE, {23}, NULL, NULL "
                    + ") ";
            }
            else
            {
                sql = "UPDATE TB_DRIVING_RECORDS SET "
                    + "    CASEID = '{4}', DRVID= '{7}', DRVNUMBER = '{8}', "
                    + "    PLAN_STARTTIME = {9}, PLAN_ARRIVETIME = {10}, STARTTIME = {11}, ARRIVETIME = {12}, "
                    + "    RUNSTATUS = {13}, DIRECT = {14}, RUN_TIME = {15}, FASTORSLOW = {16}, PLAN_OPR_MILEAGE = {17}, OPR_MILEAGE = {18}, "
                    + "    RUNNUMBER = {19}, CON_BUSTIMES = {20}, REMARKS = '{21}', SUMMARY = '{22}', EDITSIGN = 1, "
                    + "    MAKER = '" + CVar.LoginID + "', MAKEDATE = SYSDATE, AUDSIGN = {23}, AUDOR = NULL, AUDDATE = NULL "
                    + "WHERE RECID = '{0}' ";
            }
            sql = string.Format(sql,
                                recID, CVar.TransTime(DateTime.Parse("00:00:00"), CVar.DateValue(dtpDate.Text)), lineid, lineid2.ToString(), caseid, busid, busid2.ToString(), drvid, drvnumber,
                                CVar.TransTime(DateTime.Parse(dtpPStartTime.EditValue.ToString()), CVar.DateValue(dtpDate.Text)), CVar.TransTime(DateTime.Parse(dtpPArriveTime.EditValue.ToString()), CVar.DateValue(dtpDate.Text)), starttime, arrivetime,
                                2, direct.ToString(), runtime.ToString(), fastorslow, txtPKm.Text, txtKm.Text,
                                runnumer.ToString(), con_busTimes.ToString(), txtRemarks.Text, summary, audsign.ToString()
                                );

            db.Execute(sql);
        }

        private void frmDrvingRecordInput_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
            CFunc.SetMaxLength("TB_DRIVING_RECORDS", txtRemarks, "REMARKS");
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            if (txtStartTime.Text == "" || txtArriveTime.Text == "")
            {
                MessageBox.Show("时间信息不完整，无法计算里程。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

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
                InitCbo_Case(lineid);
                InitCbo_Bus(lineid);
                InitCbo_Drv(lineid);
            }
            else
            {
                cboCase.Properties.Items.Clear();
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

        private void cboCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPKm();
        }

        private void cboDirect_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPKm();
        }

        private void cboBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKm.Text = "";
        }

        private void dtpDate_EditValueChanged(object sender, EventArgs e)
        {
            txtKm.Text = "";
        }

        private void dtpPStartTime_EditValueChanged(object sender, EventArgs e)
        {
            txtKm.Text = "";
        }

        private void dtpPArriveTime_EditValueChanged(object sender, EventArgs e)
        {
            txtKm.Text = "";
        }
    }
}
