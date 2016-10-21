using Com.Database;
using Com.SubClass;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmSchEdit : Form
    {
        public event DataChangedEvevt DataChanged;

        private CDatabase db = Program.db;

        private EditMode editType;
        private string recID;
        private int _lineID2;
        private int _direct;

        public frmSchEdit(int lineid2, int direct)
        {
            InitializeComponent();

            _lineID2 = lineid2;
            _direct = direct;

            editType = EditMode.NewMode;
            InitUcl();
        }

        public frmSchEdit(int lineid2, int direct, string recid)
        {
            InitializeComponent();

            _lineID2 = lineid2;
            _direct = direct;

            editType = EditMode.ModifyMode;
            recID = recid;
            InitUcl();
            FillData();
        }

        private void InitUcl()
        {
            this.Text = string.Format("计划发车点({0})" , _direct == 0 ? "上行" : "下行");
            dtpPStartTime.EditValue = DateTime.Now;

            InitCbo_Case(_lineID2);
            InitCbo_Bus(_lineID2);
            InitCbo_Drv(_lineID2);
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

        private void FillData()
        {
            SchInfo sch = CVar.SngSch(recID);

            if (sch != null)
            {
                CSubClass.FindInCbo(cboBus, sch.Busid2.ToString());
                CSubClass.FindInCbo(cboDrv, sch.Drvnumber.ToString());
                CSubClass.FindInCbo(cboCase, sch.Caseid.ToString());

                dtpPStartTime.EditValue = sch.Plan_starttime;
                txtTime.Text = CFunc.DateDiff(DateInterval.Minute, sch.Plan_starttime, sch.Plan_arrivetime).ToString();
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
            if (CFunc.DateDiff(DateInterval.Minute, DateTime.Now, DateTime.Parse(dtpPStartTime.EditValue.ToString())) < 0)
            {
                MessageBox.Show("发车时间必须大于当前时间。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!CFunc.TxtCheck(txtTime, "行驶时长"))
            {
                return false;
            }
            if (int.Parse(txtTime.Text) <= 0)
            {
                MessageBox.Show("行驶时长必须大于0。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void SaveData()
        {
            string sql;

            //a.RECID , a.LINEID2, c.BUSID2, a.caseid, a.drvnumber, c.BUSNUMBER, a.RUNNUMBER, d.DRVNAME, e.CASENAME,
            //a.PLAN_STARTTIME, a.PLAN_ARRIVETIME, a.STARTTIME, a.ARRIVETIME, a.DIRECT, a.RUNSTATUS"

            SchInfo sch;

            if (editType == EditMode.NewMode)
            {
                sch = new SchInfo();

                sch.Recid = CFunc.DBID();
                sch.Lineid2 = _lineID2;
                sch.Direct = _direct;
            }
            else
            {
                sch = CVar.SngSch(recID);
            }
            
            sch.Busid2 = int.Parse(((ExComboBox)cboBus.SelectedItem).Key);
            sch.Busnumber = ((ExComboBox)cboBus.SelectedItem).Value;
            sch.Drvnumber = ((ExComboBox)cboDrv.SelectedItem).Key;
            sch.Drvname = ((ExComboBox)cboDrv.SelectedItem).Value;
            sch.Caseid = ((ExComboBox)cboCase.SelectedItem).Key;
            sch.Casename = ((ExComboBox)cboCase.SelectedItem).Value;
            sch.Runnumber = CVar.GetRunNumber(_lineID2, sch.Busid2);
            sch.Plan_starttime = CVar.TimeValue(dtpPStartTime.Text);
            sch.Plan_arrivetime = sch.Plan_starttime.AddMinutes(int.Parse(txtTime.Text));
            sch.Starttime = null;
            sch.Arrivetime = null;
            sch.Direct = _direct;
            sch.Status = 0;

            if (editType == EditMode.NewMode)
            {
                sql = "INSERT INTO TB_DRIVING_RECORDS ( "
                    + "    RECID, LINEID, LINEID2, CASEID, BUSID, BUSID2, DRVID, DRVNUMBER, "
                    + "    STARTTIME, ARRIVETIME, PLAN_STARTTIME, PLAN_ARRIVETIME, CHKDATE, "
                    + "    RUNSTATUS, DIRECT, RUN_TIME, FASTORSLOW, PLAN_OPR_MILEAGE, OPR_MILEAGE, "
                    + "    RUNNUMBER, CON_BUSTIMES, SUMMARY, SRCTYPE, EDITSIGN, CRDATE, "
                    + "    MAKER, MAKEDATE, AUDSIGN, AUDOR, AUDDATE "
                    + ") "
                    + "SELECT '{0}', a.LINEID, a.LINEID2, E.CASEID, F.BUSID, F.BUSID2, '{6}', '{5}', "
                    + "    NULL, NULL, {8}, {9}, SYSDATE, "
                    + "    0, {10}, NULL, NULL, DECODE({10},0,E.LINELENGTH,E.LINELENGTH2), 0, "
                    + "    {7}, NULL, NULL, 0, 1, SYSDATE, "
                    + "    NULL, SYSDATE, 0, NULL, NULL "
                    + "FROM TB_LINES A "
                    + "INNER JOIN TB_LINE_CASES E ON E.LINEID = A.LINEID AND E.CASEID = '{4}' "
                    + "INNER JOIN TB_BUSES F ON F.BUSID2 = '{2}' "
                    + "WHERE a.lineid2 = {1} ";
            }
            else
            {
                sql = "UPDATE TB_DRIVING_RECORDS SET "
                  + "    CASEID = '{4}', RUNNUMBER = {7}, "
                  + "    BUSID = '{3}', BUSID2 = {2}, DRVID = '{6}', DRVNUMBER = '{5}', "
                  + "    PLAN_STARTTIME = {8}, PLAN_ARRIVETIME = {9} "
                  + "WHERE RECID = '{0}' ";
            }

            sql = string.Format(sql, sch.Recid, sch.Lineid2.ToString(), sch.Busid2.ToString(), CVar.BusID2ToID(sch.Lineid2, sch.Busid2),
                                    sch.Caseid, sch.Drvnumber, CVar.DrvNumberToID(sch.Lineid2, sch.Drvnumber), sch.Runnumber,
                                    CVar.TransTime(sch.Plan_starttime), CVar.TransTime(sch.Plan_arrivetime), sch.Direct.ToString());

            db.Execute(sql);

            if (editType == EditMode.NewMode)
            {
                CVar.Sch.Add(sch);
                recID = sch.Recid;
            }
            else
            {
                QueueInfo queue = CVar.SngQueue(sch.Recid);

                if (queue != null)
                {
                    sql = "UPDATE TB_LOCAL_QUEUE SET "
                        + "    BUSID2 = " + sch.Busid2 + ", DRVNUMBER = '" + sch.Drvnumber + "', CASEID = '" + sch.Caseid + "', "
                        + "    STARTTIME = '" + CVar.TransTime(sch.Plan_starttime) + "', RUNNUMBER = " + sch.Runnumber + " "
                        + "WHERE RECID = '" + sch.Recid + "' ";
                    db.Execute(sql);
                }
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

        private void frmSchEdit_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dtpPStartTime.EditValue = CVar.TimeValue(dtpPStartTime.Text).AddMinutes(1);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            dtpPStartTime.EditValue = CVar.TimeValue(dtpPStartTime.Text).AddMinutes(-1);
        }

        private void cboBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int busid2 = int.Parse(((ExComboBox)cboBus.SelectedItem).Key);
            string busid = CVar.BusID2ToID(_lineID2, busid2);
            string lineid = CVar.LineID2ToID(_lineID2);

            string drvid = CFunc.IDValue("TB_BUS_DRIVERS", "BUSID", "DRV1ID", busid, "LINEID = '" + lineid + "'", "");
            if (drvid != "")
            {
                CSubClass.FindInCbo(cboDrv, drvid);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                txtTime.Text = (int.Parse(txtTime.Text) + 1).ToString();
            }
            catch
            { }
        }

        private void btnSub2_Click(object sender, EventArgs e)
        {
            try
            {
                txtTime.Text = (int.Parse(txtTime.Text) - 1).ToString();
            }
            catch
            { }
        }
    }
}
