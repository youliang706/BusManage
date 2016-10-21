using Com.Database;
using Com.SubClass;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmDrvingRecord : Form
    {
        private GridColumn colID;
        private GridColumn colSrc;
        private GridColumn colEdSign;
        private GridColumn colLkSign;
        private GridColumn colConTimes;
        private GridColumn colBusNumber;
        private GridColumn colRunNumber;
        private GridColumn colDrvName;
        private GridColumn colCaseName;
        private GridColumn colDirect;
        private GridColumn colPSTime;
        private GridColumn colPATime;
        private GridColumn colSTime;
        private GridColumn colATime;
        private GridColumn colFOS;
        private GridColumn colPKm;
        private GridColumn colKm;
        private GridColumn colAud;
        private GridColumn colRemark;
        private GridColumn colSummary;
        private GridColumn colOpr;

        private CDatabase db = Program.db;

        public frmDrvingRecord(Form ParentForm)
        {
            InitializeComponent();

            InitCbo();

            CSubClass.SetXtraGridStyle(dgvDetail);
            InitGrid();

            CSubClass.SetXtraDtpStyle(dtpDate, DtType.LongDate);
            dtpDate.EditValue = DateTime.Now;

            this.Size = ParentForm.Size;
            //this.Location = ParentForm.Location;
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

            cboLine.SelectedIndex = cboLine.Properties.Items.Count > 0 ? 0 : -1;
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

        private void InitGrid()
        {
            colID = CSubClass.CreateColumn("RECID", "系统ID", 0, 0);
            colSrc = CSubClass.CreateColumn("SRCTYPE", "来源标记", 0, 0);
            colEdSign = CSubClass.CreateColumn("EDITSIGN", "编辑标记", 0, 0);
            colLkSign = CSubClass.CreateColumn("LOCKSIGN", "锁定标记", 0, 0);
            colConTimes = CSubClass.CreateColumn("CON_BUSTIMES", "折算趟次", 0, 0);
            colBusNumber = CSubClass.CreateColumn("BUSNUMBER", "车号", 1, 60);
            colRunNumber = CSubClass.CreateColumn("RUNNUMBER", "班次", 2, 40);
            colDrvName = CSubClass.CreateColumn("DRVNAME", "驾驶员", 3, 60);
            colCaseName = CSubClass.CreateColumn("CASENAME", "区间", 4, 60);
            colDirect = CSubClass.CreateColumn("DIRECT", "方向", 5, 60);
            colPSTime = CSubClass.CreateColumn("PLAN_STARTTIME", "计划发车", 6, 60, HorzAlignment.Center, FormatType.DateTime, "HH:mm");
            colPATime = CSubClass.CreateColumn("PLAN_ARRIVETIME", "计划到达", 7, 60, HorzAlignment.Center, FormatType.DateTime, "HH:mm");
            colSTime = CSubClass.CreateColumn("STARTTIME", "实际发车", 8, 60, HorzAlignment.Center, FormatType.DateTime, "HH:mm");
            colATime = CSubClass.CreateColumn("ARRIVETIME", "实际到达", 9, 60, HorzAlignment.Center, FormatType.DateTime, "HH:mm");
            colFOS = CSubClass.CreateColumn("FASTORSLOW", "快慢点", 10, 60);
            colPKm = CSubClass.CreateColumn("PLAN_OPR_MILEAGE", "计划里程", 11, 60);
            colKm = CSubClass.CreateColumn("OPR_MILEAGE", "实际里程", 12, 60);
            colAud = CSubClass.CreateColumn("AUDSIGN", "审核", 13, 40);
            colRemark = CSubClass.CreateColumn("REMARKS", "备注", 14, 200);
            colSummary = CSubClass.CreateColumn("SUMMARY", "说明", 15, 200);

            CreateButtonColumn();

            dgvDetail.Columns.AddRange(new GridColumn[] {
                colID, colSrc, colEdSign, colLkSign, colConTimes, colBusNumber, colRunNumber, colDrvName, colCaseName, colDirect,
                colPSTime, colPATime, colSTime, colATime, colFOS, colPKm, colKm, colAud, colRemark, colSummary, colOpr
            });

            colID.Visible = false;
            colSrc.Visible = false;
            colEdSign.Visible = false;
            colLkSign.Visible = false;
            colConTimes.Visible = false;

            dgvDetail.OptionsBehavior.Editable = true;
            foreach (GridColumn c in dgvDetail.Columns)
            {
                c.OptionsColumn.AllowEdit = c.ColumnEdit is RepositoryItemButtonEdit;
                c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                c.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                c.AppearanceCell.TextOptions.HAlignment = c.AppearanceCell.HAlignment;
            }
        }

        private void CreateButtonColumn()
        {
            RepositoryItemButtonEdit riButtonEdit = CSubClass.CreateOprColumn(new ExColumn[] { 
                new ExColumn("edit","", Properties.Resources.Edit),
                new ExColumn("delete","", Properties.Resources.Delete)
            });
            riButtonEdit.Buttons[0].ImageLocation = ImageLocation.MiddleCenter;
            riButtonEdit.ButtonClick += new ButtonPressedEventHandler(riButtonEdit_ButtonClick);

            colOpr = new GridColumn();
            colOpr.Caption = "操作";
            colOpr.FieldName = "operate";
            colOpr.Width = 75;
            colOpr.Visible = true;
            colOpr.Fixed = FixedStyle.Right;
            colOpr.UnboundType = DevExpress.Data.UnboundColumnType.String;
            colOpr.ColumnEdit = riButtonEdit;
            dgvDetail.GridControl.RepositoryItems.Add(riButtonEdit);
        }

        private void riButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int RowIndex = dgvDetail.FocusedRowHandle;      //获取当前行的index
            DataRow row = dgvDetail.GetDataRow(RowIndex);   //获取当前行   

            if (e.Button.Tag.ToString() == "edit")
            {
                DataEdit(row["RECID"].ToString());
            }
            else if (e.Button.Tag.ToString() == "delete")
            {
                DataDelete(row["RECID"].ToString());
            }
        }

        private void ClearCtrls()
        {
            CSubClass.ClearRows(dgvDetail);

            tssRunTimes.Text = "0";
            tssKm.Text = "0/0Km";
            tssRate.Text = "0%";
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void FillData()
        {
            List<string> sqlCon = new List<string>();
            string conStr = "";

            if (dtpDate.EditValue != null)
            {
                sqlCon.Add("TRUNC(CHKDATE) = TRUNC(to_date('" + CVar.DateValue(dtpDate.Text).ToString("yyyy-MM-dd") + "', 'yyyy-mm-dd')) ");
            }
            if (cboLine.SelectedIndex >= 0)
            {
                string lineid = ((ExComboBox)cboLine.SelectedItem).Key;
                sqlCon.Add("a.LINEID2 = " + lineid);
            }
            if (cboBus.SelectedIndex >= 0)
            {
                string busid = ((ExComboBox)cboBus.SelectedItem).Key;
                sqlCon.Add("a.BUSID2 = " + busid);
            }
            if (cboDrv.SelectedIndex >= 0)
            {
                string drvno = ((ExComboBox)cboDrv.SelectedItem).Key;
                sqlCon.Add("a.DRVNUMBER = '" + drvno + "'");
            }
            if (cboDirect.SelectedIndex >= 0)
            {
                string direct = ((ExComboBox)cboDirect.SelectedItem).Key;
                sqlCon.Add("a.DIRECT = " + direct);
            }

            if (sqlCon.Count > 0)
            {
                conStr = "AND (" + string.Join("AND ", sqlCon) + ") ";
            }

            string sql = "SELECT a.RECID, a.SRCTYPE, a.EDITSIGN, a.LOCKSIGN, b.BUSNUMBER, a.RUNNUMBER, d.DRVNAME, e.CASENAME, CASE a.DIRECT WHEN 0 THEN '上行' ELSE '下行' END AS DIRECT, " + Environment.NewLine
                        + "    a.PLAN_STARTTIME, a.PLAN_ARRIVETIME, a.STARTTIME, a.ARRIVETIME, " + Environment.NewLine
                        + "    a.FASTORSLOW, a.CON_BUSTIMES, a.PLAN_OPR_MILEAGE, a.OPR_MILEAGE, a.AUDSIGN, a.REMARKS, a.SUMMARY " + Environment.NewLine
                        + "FROM TB_DRIVING_RECORDS a " + Environment.NewLine
                        + "LEFT JOIN TB_BUSES b ON b.BUSID2 = a.BUSID2 " + Environment.NewLine
                        + "LEFT JOIN TB_DRIVERS d ON d.DRVNUMBER = a.DRVNUMBER " + Environment.NewLine
                        + "LEFT JOIN TB_LINE_CASES e ON e.LINEID = a.LINEID AND e.CASEID = a.CASEID " + Environment.NewLine
                        + "WHERE RUNSTATUS IN (2,7) AND EDITSIGN <> 2 " + Environment.NewLine
                        + conStr + Environment.NewLine
                        + "ORDER BY PLAN_STARTTIME ";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                gridList.DataSource = dt;
                gridList.RefreshDataSource();

                //填写合计值
                double con_bustimes = 0;
                double sum_pkm = 0;
                double sum_km = 0;
                int audnum = 0;
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["CON_BUSTIMES"].ToString() != "")
                    {
                        con_bustimes += double.Parse(dt.Rows[i]["CON_BUSTIMES"].ToString());
                    }
                    if (dt.Rows[i]["PLAN_OPR_MILEAGE"].ToString() != "")
                    {
                        sum_pkm += double.Parse(dt.Rows[i]["PLAN_OPR_MILEAGE"].ToString());
                    }
                    if (dt.Rows[i]["OPR_MILEAGE"].ToString() != "")
                    {
                        sum_km += double.Parse(dt.Rows[i]["OPR_MILEAGE"].ToString());
                    }

                    if (int.Parse(dt.Rows[i]["AUDSIGN"].ToString()) == 1)
                    {
                        audnum++;
                    }
                }

                tssRunTimes.Text = con_bustimes.ToString();
                tssKm.Text = sum_pkm.ToString() + "/" + sum_km.ToString() + "Km";
                tssRate.Text = ((double)audnum / (double)dt.Rows.Count).ToString("P");
            }
            else
            {
                CSubClass.ClearRows(dgvDetail);
            }
        }

        private void DataChanged(EditMode editType, object id)
        {
            FillData();
            dgvDetail.FocusedRowHandle = dgvDetail.LocateByValue(0, dgvDetail.Columns["RECID"], id.ToString());
        }

        private void DataNew()
        {
            frmDrvingRecordInput frm = new frmDrvingRecordInput();
            frm.DataChanged += new DataChangedEvevt(DataChanged);
            frm.ShowDialog();
        }

        private void DataEdit(string recid)
        {
            frmDrvingRecordInput frm = new frmDrvingRecordInput(recid);
            frm.DataChanged += new DataChangedEvevt(DataChanged);
            frm.ShowDialog();
        }

        private void DataDelete(string recid)
        {
            if (CFunc.IDValue("TB_DRIVING_RECORDS", "RECID", "LOCKSIGN", recid) != "0")
            {
                MessageBox.Show("锁定的数据禁止删除。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("是否删除选择的路单？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            string sql = "UPDATE TB_DRIVING_RECORDS SET EDITSIGN = 2 WHERE RECID = '" + recid +"'";
            db.Execute(sql);

            //删除表格行
            dgvDetail.DeleteRow(dgvDetail.FocusedRowHandle);
        }

        private void SetSubmitSta()
        {
            if (cboLine.SelectedIndex >= 0)
            {
                int lineid = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);

                if (CFunc.ChkExists("TB_RECSUBMIT", "LINEID2", lineid, "TRUNC(RELATEDATE) = TRUNC(to_date('" + CVar.DateValue(dtpDate.Text).ToString("yyyy-MM-dd") + "', 'yyyy-mm-dd'))"))
                {
                    tssSubmit.Text = "当日路单已上报";
                    tssSubmit.ForeColor = Color.MediumBlue;
                    tssSubmit.Enabled = false;
                }
                else
                {
                    tssSubmit.Text = "当日路单未上报";
                    tssSubmit.ForeColor = Color.MediumVioletRed;
                    tssSubmit.Enabled = true;
                }
            }
            else
            {
                tssSubmit.Text = "未选择线路";
                tssSubmit.ForeColor = Color.Gray;
                tssSubmit.Enabled = true;
            }
        }

        private void SubmitData()
        {
            if (MessageBox.Show("确定上报当日路单？", "提示", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            int lineid = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);

            if (!CFunc.ChkExists("TB_RECSUBMIT", "LINEID2", lineid, "TRUNC(RELATEDATE) = TRUNC(to_date('" + CVar.DateValue(dtpDate.Text).ToString("yyyy-MM-dd") + "', 'yyyy-mm-dd'))"))
            {
                if (!CFunc.ChkExists("TB_DRIVING_RECORDS", "LINEID2", lineid, "TRUNC(CHKDATE) = TRUNC(to_date('" + CVar.DateValue(dtpDate.Text).ToString("yyyy-MM-dd") + "', 'yyyy-mm-dd')) AND RUNSTATUS IN (2,7) AND EDITSIGN <> 2 AND NVL(AUDSIGN,0) = 0 AND REMARKS IS NULL"))
                {
                    MessageBox.Show("存在没有录入备注的未通过路单，请先修改路单再上报。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string sql = "INSERT INTO TB_RECSUBMIT(lineid2, relatedate, maker, makedate) "
                            + "VALUES (" + lineid.ToString() + ", " + CVar.TransTime(DateTime.Parse("00:00:00"), CVar.DateValue(dtpDate.Text)) + ", '" + CVar.LoginID + "', SYSDATE)";
                db.Execute(sql);
            }

            MessageBox.Show("路单上报成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetSubmitSta();
        }

        private void dgvDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void dgvDetail_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            CSubClass.SetEmptyForeground(this.dgvDetail, e);
        }

        private void frmDrvingRecord_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataNew();
        }

        private void tssSubmit_Click(object sender, EventArgs e)
        {
            SubmitData();
        }

        private void frmDrvingRecord_SizeChanged(object sender, EventArgs e)
        {
            if (this.ClientSize.Width > 960)
            {
                panelControl1.Width = this.ClientSize.Width;
            }
            else
            {
                panelControl1.Width = 960;
            }
            if (this.ClientSize.Height > 540)
            {
                panelControl1.Height = this.ClientSize.Height - statusStrip1.Height;
            }
            else
            {
                panelControl1.Height = 540 - statusStrip1.Height;
            }
        }

        private void dtpDate_TextChanged(object sender, EventArgs e)
        {
            ClearCtrls();
            SetSubmitSta();
        }

        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearCtrls();

            if (cboLine.SelectedIndex >= 0)
            {
                int lineid = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
                InitCbo_Bus(lineid);
                InitCbo_Drv(lineid);
            }

            SetSubmitSta();
        }

        private void cboBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearCtrls();
        }

        private void cboDrv_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearCtrls();
        }

        private void cboDirect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearCtrls();
        }

        private void dgvDetail_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow row = dgvDetail.GetDataRow(e.RowHandle);

                if (row != null)
                {
                    if (int.Parse(row["EDITSIGN"].ToString()) == 1) //修改
                    {
                        e.Appearance.ForeColor = Color.MediumBlue;
                    }
                    else if (int.Parse(row["SRCTYPE"].ToString()) == 1) //手工新增
                    {
                        e.Appearance.ForeColor = Color.MediumSeaGreen;
                    }

                    if (int.Parse(row["AUDSIGN"].ToString()) == 0)  //审核未通过
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void dgvDetail_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "AUDSIGN")
            {
                switch (e.DisplayText)
                {
                    case "0":
                        e.DisplayText = "";
                        break;
                    case "1":
                        e.DisplayText = "√";
                        break;
                }
            }
        }
    }
}
