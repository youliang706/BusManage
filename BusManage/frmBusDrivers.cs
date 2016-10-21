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
    public partial class frmBusDrivers : Form
    {
        private GridColumn colBusID;
        private GridColumn colDrvID;
        private GridColumn colBusNumber;
        private GridColumn colPlateNumber;
        private GridColumn colDrvNumber;
        private GridColumn colDrvName;
        private GridColumn colSummary;
        private GridColumn colOpr;

        RepositoryItemLookUpEdit cboDrv = new RepositoryItemLookUpEdit();
        RepositoryItemTextEdit txtSummary = new RepositoryItemTextEdit();

        private CDatabase db = Program.db;
        IList<RowData> RowList = new BindingList<RowData>();

        public frmBusDrivers(Form ParentForm)
        {
            InitializeComponent();

            CSubClass.SetXtraGridStyle(dgvDetail);
            InitGrid();

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

        private void InitGrid()
        {
            colBusID = CSubClass.CreateColumn("BUSID", "车辆ID", 0, 0);
            colDrvID = CSubClass.CreateColumn("DRVID", "驾驶员ID", 0, 0);
            colBusNumber = CSubClass.CreateColumn("BUSNUMBER", "车号", 1, 100);
            colPlateNumber = CSubClass.CreateColumn("PLATENUMBER", "牌号", 2, 100);
            colDrvNumber = CSubClass.CreateColumn("DRVNUMBER", "工号", 3, 100);
            colDrvName = CSubClass.CreateColumn("DRVNAME", "驾驶员", 4, 100);
            colSummary = CSubClass.CreateColumn("SUMMARY", "备注", 5, 200);

            CreateButtonColumn();

            //列绑定ComboBox
            InitCbo_Drv();
            gridList.RepositoryItems.Add(cboDrv);
            colDrvNumber.ColumnEdit = cboDrv;
            colDrvNumber.OptionsColumn.AllowEdit = true;

            gridList.RepositoryItems.Add(txtSummary);
            colSummary.ColumnEdit = txtSummary;
            colSummary.OptionsColumn.AllowEdit = true;
            
            dgvDetail.Columns.AddRange(new GridColumn[] {
                colBusID, colDrvID, colBusNumber, colPlateNumber, colDrvNumber, colDrvName, colSummary, colOpr
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

            colDrvNumber.AppearanceHeader.ForeColor = Color.RoyalBlue;
            colSummary.AppearanceHeader.ForeColor = Color.RoyalBlue;

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
                dgvDetail.SetFocusedRowCellValue("DRVID", "");
                dgvDetail.SetFocusedRowCellValue("DRVNUMBER", "");
                dgvDetail.SetFocusedRowCellValue("DRVNAME", "");
                dgvDetail.SetFocusedRowCellValue("SUMMARY", "");
            }
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

            //riLookUpEdit
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
            string drvnumber = edit.EditValue.ToString();

            int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);

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
        }

        private void ClearCtrls()
        {
            CSubClass.ClearRows(dgvDetail);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void FillData()
        {
            RowList.Clear();

            List<string> sqlCon = new List<string>();
            string conStr = "";

            int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
            string lineid = CVar.LineID2ToID(lineid2);
            sqlCon.Add("a.LINEID = '" + lineid + "'");

            if (sqlCon.Count > 0)
            {
                conStr = "WHERE (" + string.Join("AND ", sqlCon) + ") ";
            }

            string sql = "SELECT b.BUSID, d.DRVID, b.BUSNUMBER, b.PLATENUMBER, d.DRVNUMBER, d.DRVNAME, c.SUMMARY " + Environment.NewLine
                        + "FROM TB_LINE_BUSES a " + Environment.NewLine
                        + "INNER JOIN TB_BUSES b ON b.BUSID = a.BUSID " + Environment.NewLine
                        + "LEFT JOIN TB_BUS_DRIVERS c ON c.LINEID = a.LINEID AND c.BUSID = a.BUSID " + Environment.NewLine
                        + "LEFT JOIN TB_DRIVERS d ON d.DRVID = c.DRV1ID " + Environment.NewLine
                        + conStr + Environment.NewLine
                        + "ORDER BY BUSNUMBER ";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                //gridList.DataSource = dt;
                for (int i=0; i<dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    RowData r = new RowData() {
                        BUSID = dr["BUSID"].ToString(),
                        DRVID = dr["DRVID"].ToString(),
                        BUSNUMBER = dr["BUSNUMBER"].ToString(),
                        PLATENUMBER = dr["PLATENUMBER"].ToString(),
                        DRVNUMBER = dr["DRVNUMBER"].ToString(),
                        DRVNAME = dr["DRVNAME"].ToString(),
                        SUMMARY = dr["SUMMARY"].ToString()
                    };

                    RowList.Add(r);
                }

                gridList.RefreshDataSource();
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
                if (RowList[i].DRVID != null && RowList[i].DRVID != "")
                {
                    for (int j = i + 1; j < RowList.Count; j++)
                    {
                        if (RowList[i].DRVID == RowList[j].DRVID)
                        {
                            if (MessageBox.Show("驾驶员[" + RowList[i].DRVNAME + "]配置给不止一辆车，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return false;
                            }
                        }
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

            sql = "DELETE FROM TB_BUS_DRIVERS WHERE LINEID = '" + lineid + "'";
            sqls.Add(sql);

            for (int i = 0; i < RowList.Count; i++)
            {
                if ((RowList[i].DRVID != null && RowList[i].DRVID != "") || (RowList[i].SUMMARY != null && RowList[i].SUMMARY != ""))
                {
                    sql = "INSERT INTO TB_BUS_DRIVERS (LINEID, BUSID, BUSSTATE, DRV1ID, DRV1_REST, DRV2ID, DRV2_REST, SUMMARY) "
                        + "VALUES ('{0}', '{1}', 0, '{2}', -1, NULL, -1, '{3}')";
                    sql = string.Format(sql, lineid, RowList[i].BUSID, RowList[i].DRVID, RowList[i].SUMMARY);

                    sqls.Add(sql);
                }
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

        private void frmBusDrivers_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }

        private void frmBusDrivers_SizeChanged(object sender, EventArgs e)
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
            if (cboLine.SelectedIndex >= 0)
            {
                int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
                List<DrvInfo> drvs = CVar.Line_Drivers(lineid2);
                cboDrv.DataSource = drvs;

                FillData();
            }
            else
            {
                ClearCtrls();
            }
        }

        private class RowData
        {
            public string BUSID { get; set; }
            public string DRVID { get; set; }
            public string BUSNUMBER { get; set; }
            public string PLATENUMBER { get; set; }
            public string DRVNUMBER { get; set; }

            public string DRVNAME { get; set; }
            public string SUMMARY { get; set; }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ChkData())
            {
                SaveData();
            }
        }
    }
}
