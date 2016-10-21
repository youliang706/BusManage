using Com.Database;
using Com.SubClass;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmBusChange : Form
    {
        public event DataChangedEvevt DataChanged;

        private CDatabase db = Program.db;

        private int _lineID2;
        private int _busID2;

        private GridColumn colID;
        private GridColumn colDirect;
        private GridColumn colDrv;
        private GridColumn colCase;
        private GridColumn colStartTime;
        private GridColumn colArriveTime;

        List<RowData> rowList = new List<RowData>();

        public frmBusChange(int lineid2, int busid2)
        {
            InitializeComponent();

            _lineID2 = lineid2;
            _busID2 = busid2;
            InitUcl();
            FillTxt();
        }

        private void InitFlx()
        {
            CSubClass.SetXtraGridStyle(dgvDetail);

            colID = CSubClass.CreateColumn("RECID", "系统ID", 0, 0);
            colDirect = CSubClass.CreateColumn("DIRECT", "方向", 0, 60, HorzAlignment.Center);
            colDrv = CSubClass.CreateColumn("DRVNAME", "驾驶员", 3, 100);
            colCase = CSubClass.CreateColumn("CASENAME", "区间", 4, 150);
            colStartTime = CSubClass.CreateColumn("PLAN_STARTTIME", "发车时间", 5, 100, HorzAlignment.Center, FormatType.DateTime, "HH:mm");
            colArriveTime = CSubClass.CreateColumn("PLAN_ARRIVETIME", "到达时间", 6, 100, HorzAlignment.Center, FormatType.DateTime, "HH:mm");

            dgvDetail.Columns.AddRange(new GridColumn[] {
                colID, colDirect, colDrv, colCase, colStartTime, colArriveTime
            });

            colID.Visible = false;

            dgvDetail.OptionsBehavior.Editable = true;
            foreach (GridColumn c in dgvDetail.Columns)
            {
                //c.OptionsColumn.AllowEdit = c.ColumnEdit is RepositoryItemButtonEdit;
                c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                c.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                c.AppearanceCell.TextOptions.HAlignment = c.AppearanceCell.HAlignment;
            }

            dgvDetail.OptionsSelection.MultiSelect = true;
            dgvDetail.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            dgvDetail.OptionsSelection.InvertSelection = false;
            dgvDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        private void InitUcl()
        {
            InitFlx();

            InitCbo_Bus(_lineID2, cboBus);
            InitCbo_Bus(_lineID2, cboBus2);
            InitCbo_Drv(_lineID2);

            CFunc.SetCtrlsSta(false, cboBus);
            CFunc.SetCtrlsSta(false, cboDrv2);
            chkDrv.Checked = false;
        }

        private void InitCbo_Bus(int lineid, ComboBoxEdit cbo)
        {
            ComboBoxItemCollection coll = cbo.Properties.Items;
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

            cbo.SelectedIndex = -1;
        }

        private void InitCbo_Drv(int lineid)
        {
            ComboBoxItemCollection coll = cboDrv2.Properties.Items;
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

            cboDrv2.SelectedIndex = -1;
        }

        private void FillTxt()
        {
            //队列中的发车点
            List<QueueInfo> queues = CVar.Queue.Where(q => q.Lineid2 == _lineID2).Where(q => q.Busid2 == _busID2).ToList();

            if (queues.Count > 0)
            {
                SchInfo sch = CVar.SngSch(queues[0].Recid);

                RowData rd = new RowData()
                {
                    RECID = sch.Recid,
                    CASENAME = sch.Casename,
                    DIRECT = sch.Direct == 0 ? "上行" : "下行",
                    DRVNAME = sch.Drvname,
                    PLAN_STARTTIME = sch.Plan_starttime.ToString(),
                    PLAN_ARRIVETIME = sch.Plan_arrivetime.ToString()
                };
                rowList.Add(rd);
            }

            //未发车的发车点
            //List<SchInfo> schs = CVar.Sch.FindAll(delegate (SchInfo s) { return s.Lineid2 == _lineID2 && s.Busid2 == busid2; });
            List<SchInfo> schs = CVar.Sch.Where(s => s.Lineid2 == _lineID2).Where(s => s.Busid2 == _busID2).Where(s => s.Status == 0).ToList();

            for (int i=0; i<schs.Count; i++)
            {
                RowData rd = new RowData() {
                                            RECID = schs[i].Recid,
                                            CASENAME = schs[i].Casename,
                                            DIRECT = schs[i].Direct == 0 ? "上行" : "下行",
                                            DRVNAME = schs[i].Drvname,
                                            PLAN_STARTTIME = schs[i].Plan_starttime.ToString(),
                                            PLAN_ARRIVETIME = schs[i].Plan_arrivetime.ToString()
                                            };
                rowList.Add(rd);
            }

            dgvDetail.GridControl.DataSource = rowList;
            dgvDetail.GridControl.RefreshDataSource();

            CSubClass.FindInCbo(cboBus, _busID2.ToString());
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
            DataChanged(EditMode.ModifyMode, _busID2);

            this.Close();
        }

        private bool CheckData()
        {
            if (!CFunc.CboCheck(cboBus2, "车辆"))
            {
                return false;
            }
            if (chkDrv.Checked)
            {
                if (!CFunc.CboCheck(cboDrv2, "驾驶员"))
                {
                    return false;
                }
            }

            if (dgvDetail.SelectedRowsCount == 0)
            {
                MessageBox.Show("没有选择换车的时刻点。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void SaveData()
        {
            string sql;
            List<string> sqls = new List<string>();

            int busid2 = int.Parse(((ExComboBox)cboBus2.SelectedItem).Key);
            string busid = CVar.BusID2ToID(_lineID2, busid2);
            string busnumber = ((ExComboBox)cboBus2.SelectedItem).Value;
            string drvnumber = "";
            string drvid = "";
            string drvname = "";

            List<string> recs = new List<string>();

            int[] rowHandles = dgvDetail.GetSelectedRows();
            for (int i = 0; i < rowHandles.Length; i++)
            {
                string recid = dgvDetail.GetRowCellValue(rowHandles[i], "RECID").ToString();
                recs.Add(recid);
            }

            if (chkDrv.Checked)
            {
                drvnumber = ((ExComboBox)cboDrv2.SelectedItem).Key;
                drvid = CVar.DrvNumberToID(_lineID2, drvnumber);
                drvname = ((ExComboBox)cboDrv2.SelectedItem).Value;

                for (int i = 0; i < recs.Count; i++)
                {
                    sql = "UPDATE TB_DRIVING_RECORDS SET BUSID = '" + busid + "', BUSID2 = " + busid2.ToString() + ", DRVID = '" + drvid + "', drvnumber = '" + drvnumber + "' "
                        + "WHERE RECID = '" + recs[i] + "' ";
                    sqls.Add(sql);
                }
            }
            else
            {
                for (int i = 0; i < recs.Count; i++)
                {
                    sql = "UPDATE TB_DRIVING_RECORDS SET BUSID = '" + busid + "', BUSID2 = " + busid2.ToString() + " "
                        + "WHERE RECID = '" + recs[i] + "' ";
                    sqls.Add(sql);
                }
            }

            db.Execute(sqls);

            //维护记录集
            for (int i = 0; i < recs.Count; i++)
            {
                //未发车的发车点
                SchInfo sch = CVar.SngSch(recs[i]);

                if (sch != null)
                {
                    sch.Busid2 = busid2;
                    sch.Busnumber = busnumber;
                    if (chkDrv.Checked)
                    {
                        sch.Drvnumber = drvnumber;
                        sch.Drvname = drvname;
                    }
                }

                //队列中的发车点
                QueueInfo queue = CVar.SngQueue(recs[i]);

                if (queue != null)
                {
                    queue.Busid2 = busid2;
                    queue.Busnumber = busnumber;
                    if (chkDrv.Checked)
                    {
                        queue.Drvnumber = drvnumber;
                        queue.Drvname = drvname;
                    }

                    sql = "UPDATE TB_LOCAL_QUEUE SET "
                        + "    BUSID2 = " + sch.Busid2 + ", DRVNUMBER = '" + sch.Drvnumber + "' "
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
                ComboBoxItemCollection coll = cboDrv2.Properties.Items;
                coll.BeginUpdate();
                try
                {
                    coll.Add(new ExComboBox(coll.Count, di.Drvnumber.ToString(), di.Drvname));
                }
                finally
                {
                    coll.EndUpdate();
                }

                cboDrv2.SelectedIndex = coll.Count - 1;
            }
        }

        private void frmBusChange_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }

        private class RowData
        {
            public string RECID { get; set; }
            public string DIRECT { get; set; }
            public string DRVNAME { get; set; }
            public string CASENAME { get; set; }
            public string PLAN_STARTTIME { get; set; }
            public string PLAN_ARRIVETIME { get; set; }
        }

        private void chkDrv_CheckedChanged(object sender, EventArgs e)
        {
            CFunc.SetCtrlsSta(chkDrv.Checked, cboDrv2);
        }
    }
}
