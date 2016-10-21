using System;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmTmrChange : Form
    {
        private bool _ret;
        private int _interval;

        public frmTmrChange()
        {
            InitializeComponent();
        }

        public bool ShowMe(ref int interval)
        {
            this.ShowDialog();

            interval = _interval;
            return _ret;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtInterval.Text != "")
            {
                txtInterval.Text = (int.Parse(txtInterval.Text) + 1).ToString();
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (txtInterval.Text != "")
            {
                txtInterval.Text = (int.Parse(txtInterval.Text) - 1).ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CFunc.TxtCheck(txtInterval, "调整分钟数")) return;

            _interval = int.Parse(txtInterval.Text);
            _ret = true;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _ret = false;

            this.Close();
        }
    }
}
