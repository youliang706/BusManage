using Com.Database;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BusManage
{
    public enum DateInterval
    {
        Second, Minute, Hour, Day, Week, Month, Quarter, Year
    }

    public sealed class CFunc
    {
        static CDatabase db = Program.db;
        /// <summary>
        /// 获取公网IP
        /// </summary>
        /// <returns></returns>
        public static string GetOuterIP()
        {
            string tempip = "127.0.0.1";
            try
            {
                //WebRequest wr = WebRequest.Create("http://www.ip138.com/ips138.asp");
                //Stream s = wr.GetResponse().GetResponseStream();
                //StreamReader sr = new StreamReader(s, Encoding.Default);
                //string wburl = sr.ReadToEnd(); 

                //if (wburl.IndexOf("无法找到该页") == -1)
                //{
                //    int start = wburl.IndexOf("[") + 1;
                //    int end = wburl.IndexOf("]", start);
                //    tempip = wburl.Substring(start, end - start);
                //    sr.Close();
                //    s.Close();
                //    return tempip;
                //}

                WebRequest wr = WebRequest.Create("http://www.net.cn/static/customercare/yourIP.asp");
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string wburl = sr.ReadToEnd(); 

                if (wburl.IndexOf("无法找到该页") == -1)
                {
                    int start = wburl.IndexOf("<h2>") + 4;
                    int end = wburl.IndexOf("</h2>", start);
                    tempip = wburl.Substring(start, end - start);
                    if (tempip.IndexOf(",") > 0)
                    {
                        tempip = tempip.Substring(0, tempip.IndexOf(",") - 1);
                    }

                    sr.Close();
                    s.Close();
                }
            }
            catch
            {
            }
            return tempip;
        }

        /// <summary>
        /// 设置控件状态
        /// </summary>
        /// <param name="bln"></param>
        /// <param name="ctls"></param>
        public static void SetCtrlsSta(bool bln, params object[] ctls)
        {
            foreach (object ctl in ctls)
            {
                try
                {
                    (ctl as Control).Enabled = bln;
                    (ctl as Control).BackColor = bln ? Color.FromKnownColor(System.Drawing.KnownColor.Window) : Color.FromArgb(220, 220, 220);
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 判断文本框为空，提示"请输入..."
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="tipText"></param>
        public static void TxtCheck(TextBox txt, string tipText)
        {
            if (txt.Enabled && txt.Text == "")
            {
                MessageBox.Show("请输入" + tipText + "。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt.Focus();
            }
        }

        public static bool TxtCheck(TextEdit txt, string tipText)
        {
            if (txt.Enabled && txt.Text.Trim() == "")
            {
                MessageBox.Show("请输入" + tipText + "。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判断组合框为空，提示"请选择..."
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="tipText"></param>
        public static void CboCheck(System.Windows.Forms.ComboBox cbo, string tipText)
        {
            if (cbo.Enabled && cbo.SelectedIndex == -1)
            {
                MessageBox.Show("请选择" + tipText + "。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo.Focus();
            }
        }

        public static bool CboCheck(ComboBoxEdit cbo, string tipText)
        {
            if (cbo.Enabled && cbo.SelectedIndex == -1)
            {
                MessageBox.Show("请选择" + tipText + "。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 清除窗体控件内容
        /// </summary>
        /// <param name="ctls"></param>
        public static void ClearCtrls(params object[] ctls)
        {
            foreach (object ctl in ctls)
            {
                try
                {
                    if (ctl is TextBox)
                    {
                        (ctl as TextBox).Text = "";
                    }
                    else if (ctl is System.Windows.Forms.ComboBox)
                    {
                        (ctl as System.Windows.Forms.ComboBox).SelectedIndex = -1;
                    }
                    else if (ctl is DateTimePicker)
                    {
                        (ctl as DateTimePicker).Value = DateTime.Now;
                    }
                    else if (ctl is CheckBox)
                    {
                        (ctl as CheckBox).Checked = false;
                    }
                    else if (ctl is TextEdit)
                    {
                        (ctl as TextEdit).Text = "";
                    }
                    else if (ctl is DevExpress.XtraEditors.ComboBoxEdit)
                    {
                        (ctl as DevExpress.XtraEditors.ComboBoxEdit).SelectedIndex = -1;
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 取服务器的日期时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDate()
        {
            DataTable dt = db.GetRs("SELECT SYSDATE FROM DUAL");
            return DateTime.Parse(dt.Rows[0][0].ToString());
        }

        /// <summary>
        /// 根据一字段及内容查找另一字段内容
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="srcField"></param>
        /// <param name="destField"></param>
        /// <param name="value"></param>
        /// <param name="condition"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static string IDValue(string tableName, string srcField, string destField, string value, string condition = "", string defValue = "")
        {
            string sql = "SELECT " + destField + " FROM " + tableName + " WHERE " + srcField + " = '" + value + "'";
            if (!condition.Equals(""))
            {
                sql += " AND (" + condition + ")";
            }

            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0][destField].ToString();
            }
            else
            {
                return defValue;
            }
        }

        public static string IDValue(string tableName, string srcField, string destField, int value, string condition = "", string defValue = "")
        {
            string sql = "SELECT " + destField + " FROM " + tableName + " WHERE " + srcField + " = " + value.ToString() + "";
            if (!condition.Equals(""))
            {
                sql += " AND (" + condition + ")";
            }

            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0][destField].ToString();
            }
            else
            {
                return defValue;
            }
        }

        public static string IDValue(string tableName, string srcField, string destField, DateTime value, string condition = "", string defValue = "")
        {
            string sql = "SELECT " + destField + " FROM " + tableName + " WHERE TRUNC(" + srcField + ") = TRUNC(" + value.ToString() + ")";
            if (!condition.Equals(""))
            {
                sql += " AND (" + condition + ")";
            }

            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0][destField].ToString();
            }
            else
            {
                return defValue;
            }
        }

        /// <summary>
        /// 检查记录是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static bool ChkExists(string tableName, string fieldName, string value, string condition = "")
        {
            string sql = "SELECT NVL(COUNT(" + fieldName + "),0) AS dest FROM " + tableName + " WHERE " + fieldName + " = '" + value.ToString() + "'";
            if (!condition.Equals(""))
            {
                sql += " AND (" + condition + ")";
            }

            DataTable dt = db.GetRs(sql);

            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ChkExists(string tableName, string fieldName, int value, string condition = "")
        {
            string sql = "SELECT NVL(COUNT(" + fieldName + "),0) AS dest FROM " + tableName + " WHERE " + fieldName + " = " + value.ToString() + "";
            if (!condition.Equals(""))
            {
                sql += " AND (" + condition + ")";
            }

            DataTable dt = db.GetRs(sql);

            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ChkExists(string tableName, string fieldName, DateTime value, string condition = "")
        {
            string sql = "SELECT NVL(COUNT(" + fieldName + "),0) AS dest FROM " + tableName + " WHERE TRUNC(" + fieldName + ") = TRUNC(" + value.ToString() + ")";
            if (!condition.Equals(""))
            {
                sql += " AND (" + condition + ")";
            }

            DataTable dt = db.GetRs(sql);

            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 设置文本最大输入字符数
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="ctls"></param>
        public static void SetMaxLength(string tableName, params object[] ctls)
        {
            string sql = "SELECT * FROM " + tableName + " WHERE rownum = 0";
            DataTable dt = db.GetRs(sql);

            for (int i = 0; i < ctls.Count() - 1; i+=2)
            {
                try
                {
                    if (ctls[i] is TextBox)
                    {
                        (ctls[i] as TextBox).MaxLength = dt.Columns[(ctls[i + 1] as string)].MaxLength;
                    }
                    else if (ctls[i] is TextEdit)
                    {
                        (ctls[i] as TextEdit).Properties.MaxLength = dt.Columns[(ctls[i + 1] as string)].MaxLength;
                    }
                }
                catch
                { }
            }
        }

        public static string DBID()
        {
            try
            {
                string sql = "SELECT fn_get_uuid AS sysid FROM DUAL";
                DataTable dt = db.GetRs(sql);

                return dt.Rows[0]["sysid"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing functions DBID", ex);
            }
        }

        /// <summary>
        /// 计算两个时间类型的差值
        /// </summary>
        /// <param name="Interval"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static long DateDiff(DateInterval Interval, System.DateTime StartDate, System.DateTime EndDate)
        {
            long lngDateDiffValue = 0;
            System.TimeSpan TS = new System.TimeSpan(EndDate.Ticks - StartDate.Ticks);
            switch (Interval)
            {
                case DateInterval.Second:
                    lngDateDiffValue = (long)TS.TotalSeconds;
                    break;
                case DateInterval.Minute:
                    lngDateDiffValue = (long)TS.TotalMinutes;
                    break;
                case DateInterval.Hour:
                    lngDateDiffValue = (long)TS.TotalHours;
                    break;
                case DateInterval.Day:
                    lngDateDiffValue = (long)TS.Days;
                    break;
                case DateInterval.Week:
                    lngDateDiffValue = (long)(TS.Days / 7);
                    break;
                case DateInterval.Month:
                    lngDateDiffValue = (long)(TS.Days / 30);
                    break;
                case DateInterval.Quarter:
                    lngDateDiffValue = (long)((TS.Days / 30) / 3);
                    break;
                case DateInterval.Year:
                    lngDateDiffValue = (long)(TS.Days / 365);
                    break;
            }
            return (lngDateDiffValue);
        }

        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="text">要显示的文字，如果为 - 则显示为分割线</param>
        /// <param name="cms">要添加到的子菜单集合</param>
        /// <param name="callback">点击时触发的事件</param>
        /// <returns>生成的子菜单，如果为分隔条则返回null</returns>
        public static ToolStripMenuItem AddContextMenu(string text, ToolStripItemCollection cms, EventHandler callback)
        {
            if (text == "-")
            {
                ToolStripSeparator tsp = new ToolStripSeparator();
                cms.Add(tsp);
                return null;
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(text);
                if (callback != null) tsmi.Click += callback;
                cms.Add(tsmi);
                return tsmi;
            }
            return null;
        }
    }

    public partial class NativeMethods
    {
        /// <summary>
        /// 启动控制台
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        /// <summary>
        /// 释放控制台
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
    }
}
