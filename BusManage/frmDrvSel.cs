using Com.Database;
using Com.SubClass;
using DevExpress.XtraGrid.Columns;
using System;
using System.Data;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmDrvSel : Form
    {
        private CDatabase db = Program.db;

        private DrvInfo driver = null;

        private GridColumn colID;
        private GridColumn colCode;
        private GridColumn colName;
        private GridColumn colLine;

        public frmDrvSel()
        {
            InitializeComponent();

            CSubClass.SetXtraGridStyle(dgvDetail);
            InitGrid();
        }

        public DrvInfo ShowMe()
        {
            this.ShowDialog();

            return driver;
        }

        private void InitGrid()
        {
            colID = CSubClass.CreateColumn("DRVID", "系统ID", 0, 0);
            colCode = CSubClass.CreateColumn("DRVNUMBER", "工号", 1, 100);
            colName = CSubClass.CreateColumn("DRVNAME", "姓名", 2, 100);
            colLine = CSubClass.CreateColumn("LINENAME", "所属线路", 3, 100);

            dgvDetail.Columns.AddRange(new GridColumn[] {
                colID, colCode, colName, colLine
            });

            colID.Visible = false;

            //dgvDetail.OptionsBehavior.Editable = true;
            //foreach (GridColumn c in dgvDetail.Columns)
            //{
            //    c.OptionsColumn.AllowEdit = c.ColumnEdit is RepositoryItemButtonEdit;
            //    c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            //    c.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
            //    c.AppearanceCell.TextOptions.HAlignment = c.AppearanceCell.HAlignment;
            //}
        }

        private void FillGrid()
        {
            string sql = "SELECT a.drvid, a.drvnumber, a.drvname, c.linename FROM tb_Drivers a " + Environment.NewLine
                        + "LEFT JOIN TB_LINE_DRIVERS b ON b.drvid = a.drvid LEFT JOIN TB_LINES c ON c.lineid = b.lineid " + Environment.NewLine
                        + "WHERE drvnumber Like '%" + txtFind.Text + "%' OR drvname Like '%" + txtFind.Text + "%'";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                gridList.DataSource = dt;
                gridList.RefreshDataSource();
            }
            else
            {
                CSubClass.ClearRows(dgvDetail);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFind.Text == "")
            {
                MessageBox.Show("请输入查询内容(可模糊匹配)。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FillGrid();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int RowIndex = dgvDetail.FocusedRowHandle;      //获取当前行的index
            DataRow row = dgvDetail.GetDataRow(RowIndex);   //获取当前行   

            driver = new DrvInfo();
            driver.Drvid = row["DRVID"].ToString();
            driver.Drvnumber = row["DRVNUMBER"].ToString();
            driver.Drvname = row["DRVNAME"].ToString();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            driver = null;
            this.Close();
        }
    }
}
