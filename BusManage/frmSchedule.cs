using Com.Database;
using Com.SubClass;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmSchedule : Form
    {
        private GridColumn colBusID;
        private GridColumn colDrvID;
        private GridColumn colRunNumber;
        private GridColumn colRunTimes;
        private GridColumn colBusNumber;
        private GridColumn colDrvNumber;
        private GridColumn colDrvName;
        private GridColumn colOpr;

        RepositoryItemLookUpEdit cboBus = new RepositoryItemLookUpEdit();
        RepositoryItemLookUpEdit cboDrv = new RepositoryItemLookUpEdit();

        private CDatabase db = Program.db;
        IList<RowData> RowList = new BindingList<RowData>();

        public frmSchedule(Form ParentForm)
        {
            InitializeComponent();

            CSubClass.SetXtraGridStyle(dgvDetail);
            InitGrid();

            CSubClass.SetXtraDtpStyle(dtpDate, DtType.LongDate);
            dtpDate.EditValue = DateTime.Now;

            InitCbo();

            this.Size = ParentForm.Size;
            //this.Location = ParentForm.Location;
        }

        private void InitCbo()
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

        private void InitCbo_Sch(int lineid2)
        {
            ComboBoxItemCollection coll = cboSch.Properties.Items;
            coll.BeginUpdate();
            coll.Clear();

            try
            {
                string lineid = CVar.LineID2ToID(lineid2);

                string sql = "SELECT SCHID,SCHNAME FROM TB_SCHEDULE WHERE LINEID = '" + lineid + "' AND STOPSIGN = 0";
                DataTable dt = db.GetRs(sql);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        coll.Add(new ExComboBox(i, dt.Rows[i]["SCHID"].ToString(), dt.Rows[i]["SCHNAME"].ToString()));
                    }
                }
            }
            finally
            {
                coll.EndUpdate();
            }

            cboSch.SelectedIndex = cboSch.Properties.Items.Count > 0 ? 0 : -1;
        }

        private void InitGrid()
        {
            colBusID = CSubClass.CreateColumn("BUSID", "车辆ID", 0, 0);
            colDrvID = CSubClass.CreateColumn("DRVID", "驾驶员ID", 0, 0);
            colRunNumber = CSubClass.CreateColumn("RUNNUMBER", "班次", 1, 50, HorzAlignment.Center);
            colRunTimes = CSubClass.CreateColumn("RUNTIMES", "计划趟次", 2, 50, HorzAlignment.Center);
            colBusNumber = CSubClass.CreateColumn("BUSNUMBER", "车号", 3, 100);
            colDrvNumber = CSubClass.CreateColumn("DRVNUMBER", "工号", 3, 100);
            colDrvName = CSubClass.CreateColumn("DRVNAME", "驾驶员", 4, 100);

            CreateButtonColumn();

            //列绑定ComboBox
            InitCbo_Bus();
            gridList.RepositoryItems.Add(cboBus);
            colBusNumber.ColumnEdit = cboBus;
            colBusNumber.OptionsColumn.AllowEdit = true;

            InitCbo_Drv();
            gridList.RepositoryItems.Add(cboDrv);
            colDrvNumber.ColumnEdit = cboDrv;
            colDrvNumber.OptionsColumn.AllowEdit = true;

            dgvDetail.Columns.AddRange(new GridColumn[] {
                colBusID, colDrvID, colRunNumber, colRunTimes, colBusNumber, colDrvNumber, colDrvName, colOpr
            });

            dgvDetail.OptionsBehavior.Editable = true;
            foreach (GridColumn c in dgvDetail.Columns)
            {
                c.OptionsColumn.AllowEdit = c.ColumnEdit != null;
                c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                c.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                c.AppearanceCell.TextOptions.HAlignment = c.AppearanceCell.HAlignment;
            }

            colBusID.Visible = false;
            colDrvID.Visible = false;

            colBusNumber.AppearanceHeader.ForeColor = Color.RoyalBlue;
            colDrvNumber.AppearanceHeader.ForeColor = Color.RoyalBlue;

            gridList.DataSource = RowList;
            gridList.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            gridList.RefreshDataSource();
        }

        private void CreateButtonColumn()
        {
            RepositoryItemButtonEdit riButtonEdit = CSubClass.CreateOprColumn(new ExColumn[] {
                new ExColumn("clear","", Properties.Resources.Cancel)
            });
            riButtonEdit.Buttons[0].ImageLocation = ImageLocation.MiddleCenter;
            riButtonEdit.ButtonClick += new ButtonPressedEventHandler(riButtonEdit_ButtonClick);

            colOpr = new GridColumn();
            colOpr.Caption = "操作";
            colOpr.FieldName = "operate";
            colOpr.Width = 40;
            colOpr.Visible = true;
            colOpr.Fixed = FixedStyle.Right;
            colOpr.UnboundType = DevExpress.Data.UnboundColumnType.String;
            colOpr.ColumnEdit = riButtonEdit;
            dgvDetail.GridControl.RepositoryItems.Add(riButtonEdit);
        }

        private void riButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "clear")
            {
                dgvDetail.SetFocusedRowCellValue("BUSID", "");
                dgvDetail.SetFocusedRowCellValue("DRVID", "");
                dgvDetail.SetFocusedRowCellValue("BUSNUMBER", "");
                dgvDetail.SetFocusedRowCellValue("DRVNUMBER", "");
                dgvDetail.SetFocusedRowCellValue("DRVNAME", "");
            }
        }

        private void InitCbo_Bus()
        {
            cboBus.Appearance.Font = new System.Drawing.Font("微软雅黑", 9);
            cboBus.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9);
            cboBus.AppearanceDropDownHeader.Font = new System.Drawing.Font("微软雅黑", 9);
            cboBus.BestFitMode = BestFitMode.BestFitResizePopup;
            cboBus.NullText = null;
            cboBus.ParseEditValue += new ConvertEditValueEventHandler(riCombo_ParseEditValue);
            cboBus.EditValueChanged += new EventHandler(riCombo_EditValueChanged);

            List<BusInfo> buses = new List<BusInfo> { new BusInfo() };

            cboBus.DisplayMember = "Busnumber";
            cboBus.ValueMember = "Busnumber";
            cboBus.DataSource = buses;
            cboBus.PopulateColumns();
            cboBus.Columns["Lineid2"].Visible = false;
            cboBus.Columns["Busid"].Visible = false;
            cboBus.Columns["Busid2"].Visible = false;
            cboBus.Columns["Busnumber"].Caption = "车号";
            cboBus.Columns["Platenumber"].Caption = "牌号";
        }

        private void InitCbo_Drv()
        {
            cboDrv.Appearance.Font = new System.Drawing.Font("微软雅黑", 9);
            cboDrv.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9);
            cboDrv.AppearanceDropDownHeader.Font = new System.Drawing.Font("微软雅黑", 9);
            cboDrv.BestFitMode = BestFitMode.BestFitResizePopup;
            cboDrv.NullText = null;
            cboDrv.ParseEditValue += new ConvertEditValueEventHandler(riCombo_ParseEditValue);
            cboDrv.EditValueChanged += new EventHandler(riCombo_EditValueChanged);

            List<DrvInfo> drvs = new List<DrvInfo> { new DrvInfo() };

            cboDrv.DisplayMember = "Drvnumber";
            cboDrv.ValueMember = "Drvnumber";
            cboDrv.DataSource = drvs;
            cboDrv.PopulateColumns();
            cboDrv.Columns["Lineid2"].Visible = false;
            cboDrv.Columns["Drvid"].Visible = false;
            cboDrv.Columns["Drvnumber"].Caption = "工号";
            cboDrv.Columns["Drvname"].Caption = "驾驶员";
        }

        private void riCombo_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (e.Value != null)
            {
                e.Value = e.Value.ToString();
                e.Handled = true;
            }
        }

        private void riCombo_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.BaseEdit edit = dgvDetail.ActiveEditor;
            int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);

            switch (dgvDetail.FocusedColumn.FieldName)
            {
                case "BUSNUMBER":
                    string busnumber = edit.EditValue.ToString();
                    int busid2 = CVar.BusNumberToID2(lineid2, busnumber);

                    BusInfo bus = CVar.Line_bus(lineid2, busid2);
                    if (bus != null)
                    {
                        int idx = dgvDetail.GetFocusedDataSourceRowIndex();

                        //RowList[idx].DRVNAME = drv.Drvname;
                        //相关其列通过直接改界面值来修改绑定的记录集
                        dgvDetail.SetFocusedRowCellValue("BUSID", bus.Busid);
                        dgvDetail.SetFocusedRowCellValue("BUSNUMBER", bus.Busnumber);

                        string lineid = CVar.LineID2ToID(lineid2);
                        string drvid = CFunc.IDValue("TB_BUS_DRIVERS", "BUSID", "DRV1ID", bus.Busid, "LINEID = '" + lineid + "'", "");
                        if (drvid != "")
                        {
                            string drvno = CVar.DrvIDToNumber(lineid2, drvid);
                            DrvInfo di = CVar.Line_driver(lineid2, drvno);
                            if (di != null)
                            {
                                //RowList[idx].DRVNAME = drv.Drvname;
                                //相关其列通过直接改界面值来修改绑定的记录集
                                dgvDetail.SetFocusedRowCellValue("DRVID", di.Drvid);
                                dgvDetail.SetFocusedRowCellValue("DRVNUMBER", di.Drvnumber);
                                dgvDetail.SetFocusedRowCellValue("DRVNAME", di.Drvname);
                            }
                        }
                    }
                    break;

                case "DRVNUMBER":
                    string drvnumber = edit.EditValue.ToString();

                    DrvInfo drv = CVar.Line_driver(lineid2, drvnumber);
                    if (drv != null)
                    {
                        int idx = dgvDetail.GetFocusedDataSourceRowIndex();

                        //RowList[idx].DRVNAME = drv.Drvname;
                        //相关其列通过直接改界面值来修改绑定的记录集
                        dgvDetail.SetFocusedRowCellValue("DRVID", drv.Drvid);
                        dgvDetail.SetFocusedRowCellValue("DRVNUMBER", drv.Drvnumber);
                        dgvDetail.SetFocusedRowCellValue("DRVNAME", drv.Drvname);
                    }

                    break;
            }
        }

        private void ClearCtrls()
        {
            CSubClass.ClearRows(dgvDetail);
            btnSave.Enabled = false;
            btnReset.Enabled = false;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void FillData()
        {
            RowList.Clear();

            int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
            string lineid = CVar.LineID2ToID(lineid2);
            string schid = ((ExComboBox)cboSch.SelectedItem).Key;
            string oriid = CFunc.IDValue("TB_ORIGINALATTEMPER", "SCHID", "ORIID", schid, "LINEID = '" + lineid + "' AND to_char(ORIDATE, 'yyyy-mm-dd') = '" + CVar.DateValue(dtpDate.Text).ToString("yyyy-MM-dd") + "'", "");

            string sql;
            if (oriid == "")
            {
                sql = "SELECT a.RUNNUMBER, a.RUNTIMES, '' AS BUSID, '' AS BUSNUMBER, '' AS DRVID, '' AS DRVNUMBER, '' AS DRVNAME " + Environment.NewLine
                    + "FROM( " + Environment.NewLine
                    + "    SELECT RUNNUMBER, count(*) AS RUNTIMES FROM TB_SCHEDULE_T " + Environment.NewLine
                    + "    WHERE SCHID = '" + schid + "' " + Environment.NewLine
                    + "    GROUP BY RUNNUMBER " + Environment.NewLine
                    + ") a " + Environment.NewLine
                    + "ORDER BY a.RUNNUMBER ";
            }
            else
            {
                sql = "SELECT a.RUNNUMBER, a.RUNTIMES, c.BUSID, d.BUSNUMBER, c.DRV1ID AS DRVID, e.DRVNUMBER, e.DRVNAME " + Environment.NewLine
                    + "FROM( " + Environment.NewLine
                    + "    SELECT RUNNUMBER, count(*) AS RUNTIMES FROM TB_SCHEDULE_T " + Environment.NewLine
                    + "    WHERE SCHID = '" + schid + "' " + Environment.NewLine
                    + "    GROUP BY RUNNUMBER " + Environment.NewLine
                    + ") a " + Environment.NewLine
                    + "LEFT JOIN TB_ORIGINALATTEMPER b ON b.ORIID = '" + oriid + "' " + Environment.NewLine
                    + "LEFT JOIN TB_ORIGINALATTEMPER_D c ON c.ORIID = b.ORIID AND c.RUNNUMBER = a.RUNNUMBER " + Environment.NewLine
                    + "LEFT JOIN TB_BUSES d ON d.BUSID = c.BUSID " + Environment.NewLine
                    + "LEFT JOIN TB_DRIVERS e ON e.DRVID = c.DRV1ID " + Environment.NewLine
                    + "ORDER BY a.RUNNUMBER ";
            }
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                //gridList.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    RowData r = new RowData()
                    {
                        BUSID = dr["BUSID"].ToString(),
                        DRVID = dr["DRVID"].ToString(),
                        RUNNUMBER = dr["RUNNUMBER"].ToString(),
                        RUNTIMES = dr["RUNTIMES"].ToString(),
                        BUSNUMBER = dr["BUSNUMBER"].ToString(),
                        DRVNUMBER = dr["DRVNUMBER"].ToString(),
                        DRVNAME = dr["DRVNAME"].ToString(),
                    };

                    RowList.Add(r);
                }

                gridList.RefreshDataSource();

                btnSave.Enabled = true;
                btnReset.Enabled = oriid == "" ? false : true;
            }
            else
            {
                CSubClass.ClearRows(dgvDetail);
            }
        }

        private bool ChkData()
        {
            for (int i = 0; i < RowList.Count; i++)
            {
                if (RowList[i].BUSID == null || RowList[i].BUSID == "")
                {
                    MessageBox.Show("班次[" + RowList[i].RUNNUMBER + "]未设置车辆。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false; 
                }
                if (RowList[i].DRVID == null || RowList[i].DRVID == "")
                {
                    MessageBox.Show("班次[" + RowList[i].RUNNUMBER + "]未设置驾驶员。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            for (int i = 0; i < RowList.Count; i++)
            {
                for (int j = i + 1; j < RowList.Count; j++)
                {
                    if (RowList[i].BUSID == RowList[j].BUSID)
                    {
                        MessageBox.Show("车辆[" + RowList[i].BUSNUMBER + "]设置到了多个班次。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }

            return true;
        }

        private void SaveData()
        {
            string sql;
            List<string> sqls = new List<string>();

            int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
            string lineid = CVar.LineID2ToID(lineid2);
            string schid = ((ExComboBox)cboSch.SelectedItem).Key;
            string oriid = CFunc.IDValue("TB_ORIGINALATTEMPER", "SCHID", "ORIID", schid, "LINEID = '" + lineid + "' AND to_char(ORIDATE, 'yyyy-mm-dd') = '" + CVar.DateValue(dtpDate.Text).ToString("yyyy-MM-dd") + "'", "");
            string dte = CVar.TransTime(DateTime.Parse("00:00:00"), CVar.DateValue(dtpDate.Text));

            if (oriid != "")
            {
                sql = "UPDATE TB_ORIGINALATTEMPER SET MAKER = '" + CVar.LoginID + "', MAKEDATE = SYSDATE "
                    + "WHERE ORIID = '" + oriid + "'";
                sqls.Add(sql);

                for (int i = 0; i < RowList.Count; i++)
                {
                    sql = "UPDATE TB_ORIGINALATTEMPER_D SET BUSID = '" + RowList[i].BUSID + "', DRV1ID = '" + RowList[i].DRVID + "' "
                        + "WHERE ORIID = '" + oriid + "' AND RUNNUMBER = " + RowList[i].RUNNUMBER + " ";
                    sqls.Add(sql);
                }

                sql = "UPDATE TB_SCHEDULE_USEDATE SET SCHAUDOR = '" + CVar.LoginID + "', SCHAUDDATE = SYSDATE "
                    + "WHERE SCHID = '" + schid + "'";
                sqls.Add(sql);
            }
            else
            {
                oriid = CFunc.DBID();

                sql = "INSERT INTO TB_ORIGINALATTEMPER (ORIID, LINEID, ORIDATE, SCHID, MAKER, MAKEDATE, SUMMARY) "
                    + "VALUES ('" + oriid + "', '" + lineid + "', " + dte + ", '" + schid + "', '" + CVar.LoginID + "', SYSDATE, '') ";
                sqls.Add(sql);

                for (int i = 0; i < RowList.Count; i++)
                {
                    sql = "INSERT INTO TB_ORIGINALATTEMPER_D (ORIID, LINEID, RUNNUMBER, BUSID, DRV1ID, SUMMARY) "
                        + "VALUES ('" + oriid + "', '" + lineid + "', " + RowList[i].RUNNUMBER + ", '" + RowList[i].BUSID + "', '" + RowList[i].DRVID + "', '')";
                    sqls.Add(sql);
                }

                sql = "INSERT INTO TB_SCHEDULE_USEDATE (SCHID, LINEID, SCHDATE, SCHSTATUS, SCHAUDOR, SCHAUDDATE, SUMMARY) "
                    + "VALUES ('" + schid + "', '" + lineid + "', " + dte + ", 1, '" + CVar.LoginID + "', SYSDATE, '') ";
                sqls.Add(sql);
            }

            try
            {
                db.Execute(sqls);

                MessageBox.Show("保存成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private void ResetData()
        {
            string sql;
            List<string> sqls = new List<string>();

            int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
            string lineid = CVar.LineID2ToID(lineid2);
            string schid = ((ExComboBox)cboSch.SelectedItem).Key;
            string oriid = CFunc.IDValue("TB_ORIGINALATTEMPER", "SCHID", "ORIID", schid, "LINEID = '" + lineid + "' AND to_char(ORIDATE, 'yyyy-mm-dd') = '" + CVar.DateValue(dtpDate.Text).ToString("yyyy-MM-dd") + "'", "");
            if (oriid != "")
            {
                sql = "DELETE FROM TB_ORIGINALATTEMPER WHERE ORIID = '" + oriid + "'";
                sqls.Add(sql);

                sql = "DELETE FROM TB_ORIGINALATTEMPER_D WHERE ORIID = '" + oriid + "'";
                sqls.Add(sql);

                sql = "DELETE FROM TB_SCHEDULE_USEDATE WHERE SCHID = '" + schid + "' AND LINEID = '" + lineid + "' AND to_char(SCHDATE, 'yyyy-mm-dd') = '" + CVar.DateValue(dtpDate.Text).ToString("yyyy-MM-dd") + "'";
                sqls.Add(sql);

                try
                {
                    db.Execute(sqls);

                    MessageBox.Show("撤销成功，请重新选择计划进行排班。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    throw (e);
                }
            }
            else
            {
                MessageBox.Show("当日未设置排班信息，无需进行撤销操作。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

        private void frmSchedule_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }

        private void frmSchedule_SizeChanged(object sender, EventArgs e)
        {
            if (this.ClientSize.Width > 900)
            {
                panelControl1.Width = this.ClientSize.Width;
            }
            else
            {
                panelControl1.Width = 900;
            }
            if (this.ClientSize.Height > 540)
            {
                panelControl1.Height = this.ClientSize.Height;
            }
            else
            {
                panelControl1.Height = 540;
            }
        }

        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearCtrls();

            if (cboLine.SelectedIndex >= 0)
            {
                int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
                List<BusInfo> buses = CVar.Line_Buses(lineid2);
                cboBus.DataSource = buses;
                List<DrvInfo> drvs = CVar.Line_Drivers(lineid2);
                cboDrv.DataSource = drvs;

                InitCbo_Sch(lineid2);
            }
            else
            {
                cboSch.Properties.Items.Clear();
            }
        }

        private class RowData
        {
            public string BUSID { get; set; }
            public string DRVID { get; set; }
            public string RUNNUMBER { get; set; }
            public string RUNTIMES { get; set; }
            public string BUSNUMBER { get; set; }
            public string DRVNUMBER { get; set; }
            public string DRVNAME { get; set; }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定清除当前排班内容？","提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                ResetData();
            }
        }

        private void dtpDate_EditValueChanged(object sender, EventArgs e)
        {
            ClearCtrls();
        }

        private void cboLine_EditValueChanged(object sender, EventArgs e)
        {
            ClearCtrls();
        }

        private void cboSch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearCtrls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ChkData())
            {
                SaveData();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (cboLine.SelectedItem == null)
            {
                MessageBox.Show("请选择线路。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboSch.SelectedItem == null)
            {
                MessageBox.Show("请选择行车计划。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
            string lineid = CVar.LineID2ToID(lineid2);
            string schid = ((ExComboBox)cboSch.SelectedItem).Key;

            string curschid = CFunc.IDValue("TB_SCHEDULE_USEDATE", "LINEID", "SCHID", lineid, "to_char(SCHDATE, 'yyyy-mm-dd') = '" + CVar.DateValue(dtpDate.Text).ToString("yyyy-MM-dd") + "'", "");

            if (curschid == "")
            {
                FillData();
            }
            else
            {
                if (schid == curschid)
                {
                    FillData();
                }
                else
                {
                    MessageBox.Show("当日已做过其它计划的排班，如需修改计划请先选择\"撤销。\"", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
