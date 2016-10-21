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
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmRepairLog : Form
    {
        private GridColumn colID;
        private GridColumn colStatus;
        private GridColumn colBusNumber;
        private GridColumn colRegTime;
        private GridColumn colFalut;
        private GridColumn colSummary;
        private GridColumn colAccepter;
        private GridColumn colAcceptDate;
        private GridColumn colOpr;

        private CDatabase db = Program.db;

        public frmRepairLog(Form ParentForm)
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
            colID = CSubClass.CreateColumn("SYSID", "系统ID", 0, 0);
            colStatus = CSubClass.CreateColumn("STATUS", "状态标记", 0, 0);
            colBusNumber = CSubClass.CreateColumn("BUSNUMBER", "车号", 1, 60);
            colRegTime = CSubClass.CreateColumn("REGTIME", "登记时间", 2, 60, HorzAlignment.Center, FormatType.DateTime, "HH:mm");
            colFalut = CSubClass.CreateColumn("FALUTNAME", "故障类型", 3, 200);
            colSummary = CSubClass.CreateColumn("SUMMARY", "备注", 4, 200);
            colAccepter = CSubClass.CreateColumn("ACCEPTER", "维修人", 5, 60);
            colAcceptDate = CSubClass.CreateColumn("ACCEPTDATE", "维修完成时间", 6, 100, HorzAlignment.Center, FormatType.DateTime, "yyyy-MM-dd");

            CreateButtonColumn();

            dgvDetail.Columns.AddRange(new GridColumn[] {
                colID, colStatus, colBusNumber, colRegTime, colFalut, colSummary, colAccepter, colAcceptDate, colOpr
            });

            colID.Visible = false;
            colStatus.Visible = false;

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

            if (row["STATUS"].ToString() != "0")
            {
                MessageBox.Show("当前记录禁止操作。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (e.Button.Tag.ToString() == "edit")
            {
                DataEdit(row["SYSID"].ToString());
            }
            else if (e.Button.Tag.ToString() == "delete")
            {
                DataDelete(row["SYSID"].ToString());
            }
        }

        private void ClearCtrls()
        {
            CSubClass.ClearRows(dgvDetail);

            tssSum.Text = "0";
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
                sqlCon.Add("TRUNC(RELATEDATE) = TRUNC(to_date('" + CVar.DateValue(dtpDate.Text).ToString("yyyy-MM-dd") + "', 'yyyy-mm-dd')) ");
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

            string sql = "SELECT a.SYSID, nvl(a.STATUS,0) AS STATUS, b.BUSNUMBER, to_char(a.REGTIME,'hh24:mi') AS REGTIME, " + Environment.NewLine
                        + "    c.FALUTNAME, a.SUMMARY, d.USERNAME AS ACCEPTER, a.ACCEPTEDATE " + Environment.NewLine
                        + "FROM TB_REPAIR_LOG a " + Environment.NewLine
                        + "LEFT JOIN TB_BUSES b ON b.BUSID2 = a.BUSID2 " + Environment.NewLine
                        + "LEFT JOIN TB_FALUTTYPE c ON c.FALUTID = a.FALUTID " + Environment.NewLine
                        + "LEFT JOIN TB_UPC_USER d ON d.USERCODE = a.ACCEPTER " + Environment.NewLine
                        + conStr + Environment.NewLine
                        + "ORDER BY REGTIME ";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                gridList.DataSource = dt;
                gridList.RefreshDataSource();

                //填写合计值
                tssSum.Text = dt.Rows.Count.ToString();
            }
            else
            {
                CSubClass.ClearRows(dgvDetail);
            }
        }

        private void DataChanged(EditMode editType, object id)
        {
            FillData();
            dgvDetail.FocusedRowHandle = dgvDetail.LocateByValue(0, dgvDetail.Columns["SYSID"], id.ToString());
        }

        private void DataNew()
        {
            frmRepairLogInput frm = new frmRepairLogInput();
            frm.DataChanged += new DataChangedEvevt(DataChanged);
            frm.ShowDialog();
        }

        private void DataEdit(string sysid)
        {
            frmRepairLogInput frm = new frmRepairLogInput(sysid);
            frm.DataChanged += new DataChangedEvevt(DataChanged);
            frm.ShowDialog();
        }

        private void DataDelete(string recid)
        {
            if (MessageBox.Show("是否删除选择的记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            string sql = "DELETE TB_REPAIR_LOG WHERE SYSID = '" + recid + "'";
            db.Execute(sql);

            //删除表格行
            dgvDetail.DeleteRow(dgvDetail.FocusedRowHandle);
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

        private void frmRepairLog_Load(object sender, EventArgs e)
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

        private void frmRepairLog_SizeChanged(object sender, EventArgs e)
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
        }

        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearCtrls();
        }
    }
}
