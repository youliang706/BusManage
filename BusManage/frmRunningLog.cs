using Com.Database;
using Com.SubClass;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace BusManage
{
    public partial class frmRunningLog : Form
    {
        private GridColumn colKq_DrvName;
        private GridColumn colKq_BusNumber;

        private GridColumn colFk_ID;
        private GridColumn colFk_PeriodID;
        private GridColumn colFk_PeriodName;
        private GridColumn colFk_Type;
        private GridColumn colFk_Content;
        private GridColumn colFk_Opr;

        private GridColumn colID;
        private GridColumn colBusNumber;
        private GridColumn colStartTime;
        private GridColumn colEndTime;
        private GridColumn colRsn;
        private GridColumn colSummary;
        private GridColumn colOpr;

        private CDatabase db = Program.db;

        public frmRunningLog(Form ParentForm)
        {
            InitializeComponent();

            InitCbo();

            CSubClass.SetXtraGridStyle(dgvKq);
            CSubClass.SetXtraGridStyle(dgvFk);
            CSubClass.SetXtraGridStyle(dgvNr);
            InitGrid();

            CSubClass.SetXtraDtpStyle(dtpDate, DtType.LongDate);
            dtpDate.EditValue = DateTime.Now;

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
            InitGrid_Kq();
            InitGrid_Fk();
            InitGrid_Nr();
        }

        private void InitGrid_Kq()
        {
            colKq_DrvName = CSubClass.CreateColumn("DRVNAME", "驾驶员", 1, 60);
            colKq_BusNumber = CSubClass.CreateColumn("BUSNUMBER", "车号", 2, 60);

            dgvKq.Columns.AddRange(new GridColumn[] {
                colKq_DrvName, colKq_BusNumber
            });
        }

        private void InitGrid_Fk()
        {
            colFk_ID = CSubClass.CreateColumn("SYSID", "系统ID", 0, 0);
            colFk_PeriodID = CSubClass.CreateColumn("PERIOD", "峰段标记", 0, 0);
            colFk_PeriodName = CSubClass.CreateColumn("PERIODNAME", "峰段", 1, 100);
            colFk_Type = CSubClass.CreateColumn("TYPENAME", "类型", 2, 100);
            colFk_Content = CSubClass.CreateColumn("CONTENT", "内容", 3, 285);

            CreateButtonColumn_Fk();

            dgvFk.Columns.AddRange(new GridColumn[] {
                colFk_ID, colFk_PeriodID, colFk_PeriodName, colFk_Type, colFk_Content, colFk_Opr
            });

            colFk_ID.Visible = false;
            colFk_PeriodID.Visible = false;

            dgvFk.OptionsBehavior.Editable = true;
            foreach (GridColumn c in dgvFk.Columns)
            {
                c.OptionsColumn.AllowEdit = c.ColumnEdit is RepositoryItemButtonEdit;
                c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                c.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                c.AppearanceCell.TextOptions.HAlignment = c.AppearanceCell.HAlignment;
            }
        }

        private void CreateButtonColumn_Fk()
        {
            RepositoryItemButtonEdit riButtonEdit = CSubClass.CreateOprColumn(new ExColumn[] { 
                new ExColumn("edit", "编辑", Properties.Resources.Edit)
            });
            riButtonEdit.ButtonClick += new ButtonPressedEventHandler(riButtonEdit2_ButtonClick);

            colFk_Opr = new GridColumn();
            colFk_Opr.Caption = "操作";
            colFk_Opr.FieldName = "operate";
            colFk_Opr.Width = 75;
            colFk_Opr.Visible = true;
            colFk_Opr.Fixed = FixedStyle.Right;
            colFk_Opr.UnboundType = DevExpress.Data.UnboundColumnType.String;
            colFk_Opr.ColumnEdit = riButtonEdit;
            dgvFk.GridControl.RepositoryItems.Add(riButtonEdit);
        }

        private void riButtonEdit2_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int RowIndex = dgvFk.FocusedRowHandle;      //获取当前行的index
            DataRow row = dgvFk.GetDataRow(RowIndex);   //获取当前行 

            if (e.Button.Tag.ToString() == "edit")
            {
                if (row["SYSID"].ToString() == "")
                {
                    int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);
                    DateTime dte = CVar.DateValue(dtpDate.Text);

                    DataNew_Fk(lineid2, dte, int.Parse(row["PERIOD"].ToString()));
                }
                else
                {
                    DataEdit_Fk(row["SYSID"].ToString());
                }
            }
        }

        private void InitGrid_Nr()
        {
            colID = CSubClass.CreateColumn("SYSID", "系统ID", 0, 0);
            colBusNumber = CSubClass.CreateColumn("BUSNUMBER", "车号", 1, 60);
            colStartTime = CSubClass.CreateColumn("STARTTIME", "开始时间", 2, 100, HorzAlignment.Center, FormatType.DateTime, "HH:mm");
            colEndTime = CSubClass.CreateColumn("ENDTIME", "截止时间", 2, 100, HorzAlignment.Center, FormatType.DateTime, "HH:mm");
            colRsn = CSubClass.CreateColumn("NRUNRSNNAME", "原因", 3, 100);
            colSummary = CSubClass.CreateColumn("SUMMARY", "备注", 4, 200);

            CreateButtonColumn();

            dgvNr.Columns.AddRange(new GridColumn[] {
                colID, colBusNumber, colStartTime, colEndTime, colRsn, colSummary, colOpr
            });

            colID.Visible = false;

            dgvNr.OptionsBehavior.Editable = true;
            foreach (GridColumn c in dgvNr.Columns)
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
                new ExColumn("edit","编辑", Properties.Resources.Edit),
                new ExColumn("delete","删除", Properties.Resources.Delete)
            });
            riButtonEdit.ButtonClick += new ButtonPressedEventHandler(riButtonEdit_ButtonClick);

            colOpr = new GridColumn();
            colOpr.Caption = "操作";
            colOpr.FieldName = "operate";
            colOpr.Width = 150;
            colOpr.Visible = true;
            colOpr.Fixed = FixedStyle.Right;
            colOpr.UnboundType = DevExpress.Data.UnboundColumnType.String;
            colOpr.ColumnEdit = riButtonEdit;
            dgvNr.GridControl.RepositoryItems.Add(riButtonEdit);
        }

        private void riButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int RowIndex = dgvNr.FocusedRowHandle;      //获取当前行的index
            DataRow row = dgvNr.GetDataRow(RowIndex);   //获取当前行 

            if (e.Button.Tag.ToString() == "edit")
            {
                DataEdit_Nr(row["SYSID"].ToString());
            }
            else if (e.Button.Tag.ToString() == "delete")
            {
                DataDelete_Nr(row["SYSID"].ToString());
            }
        }

        private void ClearCtrls()
        {
            CSubClass.ClearRows(dgvKq);
            CSubClass.ClearRows(dgvFk);
            CSubClass.ClearRows(dgvNr);

            btnNew.Enabled = false;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void FillData()
        {
            FillData_Kq();
            FillData_Fk();
            FillData_Nr();

            btnNew.Enabled = true;
        }

        private void FillData_Kq()
        {
            List<string> sqlCon = new List<string>();
            string conStr = "";

            if (dtpDate.EditValue != null)
            {
                sqlCon.Add("TRUNC(a.CHKDATE) = TRUNC(to_date('" + CVar.DateValue(dtpDate.Text).ToString("yyyy-MM-dd") + "', 'yyyy-mm-dd')) ");
            }
            if (cboLine.SelectedIndex >= 0)
            {
                string lineid = ((ExComboBox)cboLine.SelectedItem).Key;
                sqlCon.Add("a.LINEID2 = " + lineid);
            }

            if (sqlCon.Count > 0)
            {
                conStr = "WHERE (" + string.Join("AND ", sqlCon) + ") ";
            }

            string sql = "SELECT c.DRVNAME, b.BUSNUMBER " + Environment.NewLine
                        + "FROM TB_DRIVING_RECORDS a " + Environment.NewLine
                        + "LEFT JOIN TB_BUSES b ON b.BUSID2 = a.BUSID2 " + Environment.NewLine
                        + "LEFT JOIN TB_DRIVERS c ON c.DRVNUMBER = a.DRVNUMBER " + Environment.NewLine
                        + conStr + Environment.NewLine
                        + "GROUP BY c.DRVNAME, b.BUSNUMBER " + Environment.NewLine
                        + "ORDER BY c.DRVNAME, b.BUSNUMBER ";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                gridKq.DataSource = dt;
                gridKq.RefreshDataSource();
            }
            else
            {
                CSubClass.ClearRows(dgvKq);
            }
        }

        private void FillData_Fk()
        {
            List<string> sqlCon = new List<string>();
            string conStr = "";

            if (dtpDate.EditValue != null)
            {
                sqlCon.Add("TRUNC(a.RELATEDATE) = TRUNC(to_date('" + CVar.DateValue(dtpDate.Text).ToString("yyyy-MM-dd") + "', 'yyyy-mm-dd')) ");
            }
            if (cboLine.SelectedIndex >= 0)
            {
                string lineid = ((ExComboBox)cboLine.SelectedItem).Key;
                sqlCon.Add("a.LINEID2 = " + lineid);
            }

            if (sqlCon.Count > 0)
            {
                conStr = "AND (" + string.Join("AND ", sqlCon) + ") ";
            }

            string sql = "SELECT a.SYSID, x.PERIOD, x.PERIODNAME, DECODE(a.FEEDTYPE, 1, '执行', '未执行') AS TYPENAME, a.CONTENT " + Environment.NewLine
                        + "FROM ( " + Environment.NewLine
                        + "    SELECT 1 AS PERIOD, '早高峰' AS PERIODNAME FROM DUAL UNION SELECT 2, '平峰' FROM DUAL UNION SELECT 3, '晚高峰' FROM DUAL " + Environment.NewLine
                        + ") x " + Environment.NewLine
                        + "LEFT JOIN TB_FEEDBACK a ON a.PERIOD = x.PERIOD " + conStr;
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                gridFk.DataSource = dt;
                gridFk.RefreshDataSource();
            }
            else
            {
                CSubClass.ClearRows(dgvFk);
            }
        }

        private void FillData_Nr()
        {
            List<string> sqlCon = new List<string>();
            string conStr = "";

            if (dtpDate.EditValue != null)
            {
                sqlCon.Add("TRUNC(a.RELATEDATE) = TRUNC(to_date('" + CVar.DateValue(dtpDate.Text).ToString("yyyy-MM-dd") + "', 'yyyy-mm-dd')) ");
            }
            if (cboLine.SelectedIndex >= 0)
            {
                string lineid = ((ExComboBox)cboLine.SelectedItem).Key;
                sqlCon.Add("a.LINEID2 = " + lineid);
            }

            if (sqlCon.Count > 0)
            {
                conStr = "WHERE (" + string.Join("AND ", sqlCon) + ") ";
            }

            string sql = "SELECT a.SYSID, b.BUSNUMBER, a.STARTTIME, a.ENDTIME, c.NRUNRSNNAME, a.SUMMARY " + Environment.NewLine
                        + "FROM TB_NOTRUN_LOG a " + Environment.NewLine
                        + "LEFT JOIN TB_BUSES b ON b.BUSID2 = a.BUSID2 " + Environment.NewLine
                        + "LEFT JOIN TB_NotRunRsn c ON c.NRUNRSNID = a.RSNID " + Environment.NewLine
                        + conStr;
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                gridNr.DataSource = dt;
                gridNr.RefreshDataSource();
            }
            else
            {
                CSubClass.ClearRows(dgvNr);
            }
        }

        private void DataChanged_Fk(EditMode editType, object id)
        {
            FillData_Fk();
            dgvFk.FocusedRowHandle = dgvKq.LocateByValue(0, dgvFk.Columns["SYSID"], id.ToString());
        }

        private void DataChanged_Nr(EditMode editType, object id)
        {
            FillData_Nr();
            dgvNr.FocusedRowHandle = dgvKq.LocateByValue(0, dgvNr.Columns["SYSID"], id.ToString());
        }

        private void DataNew_Fk(int lineid2, DateTime dte, int period)
        {
            frmRunningLog_Fk frm = new frmRunningLog_Fk(lineid2, dte, period);
            frm.DataChanged += new DataChangedEvevt(DataChanged_Fk);
            frm.ShowDialog();
        }

        private void DataEdit_Fk(string sysid)
        {
            frmRunningLog_Fk frm = new frmRunningLog_Fk(sysid);
            frm.DataChanged += new DataChangedEvevt(DataChanged_Fk);
            frm.ShowDialog();
        }

        private void DataNew_Nr(int lineid2, DateTime dte)
        {
            frmRunningLog_Nr frm = new frmRunningLog_Nr(lineid2, dte);
            frm.DataChanged += new DataChangedEvevt(DataChanged_Nr);
            frm.ShowDialog();
        }

        private void DataEdit_Nr(string sysid)
        {
            frmRunningLog_Nr frm = new frmRunningLog_Nr(sysid);
            frm.DataChanged += new DataChangedEvevt(DataChanged_Nr);
            frm.ShowDialog();
        }

        private void DataDelete_Nr(string recid)
        {
            if (MessageBox.Show("是否删除选择的记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            string sql = "DELETE TB_REPAIR_LOG WHERE SYSID = '" + recid + "'";
            db.Execute(sql);

            //删除表格行
            dgvNr.DeleteRow(dgvKq.FocusedRowHandle);
        }

        private void frmRunningLog_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void frmRunningLog_SizeChanged(object sender, EventArgs e)
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

        private void dtpDate_TextChanged(object sender, EventArgs e)
        {
            ClearCtrls();
        }

        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearCtrls();
        }

        private void dgvKq_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void dgvFk_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void dgvNr_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void dgvKq_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            CSubClass.SetEmptyForeground(this.dgvKq, e);
        }

        private void dgvFk_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            CSubClass.SetEmptyForeground(this.dgvFk, e);
        }

        private void dgvNr_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            CSubClass.SetEmptyForeground(this.dgvNr, e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            int lineid2 = int.Parse(((ExComboBox)cboLine.SelectedItem).Key);

            DataNew_Nr(lineid2, CVar.DateValue(dtpDate.Text));
        }

        private void pnlKq_Paint(object sender, PaintEventArgs e)
        {
            panel_Paint(pnlKq, e);
        }

        private void pnlFk_Paint(object sender, PaintEventArgs e)
        {
            panel_Paint(pnlFk, e);
        }

        private void pnlNr_Paint(object sender, PaintEventArgs e)
        {
            panel_Paint(pnlNr, e);
        }

        private void panel_Paint(Panel pnl, PaintEventArgs e)
        {
            Color c = Color.FromArgb(157, 160, 170);

            ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle,
                                c, 1, ButtonBorderStyle.Solid,
                                c, 1, ButtonBorderStyle.Solid,
                                c, 1, ButtonBorderStyle.Solid,
                                c, 1, ButtonBorderStyle.Solid);
        }
    }
}
