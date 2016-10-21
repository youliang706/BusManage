using Com.Database;
using Com.Register;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace BusManage
{
    public enum EditMode
    {
        NewMode = 1,
        ModifyMode = 2
    }
    //定义委托
    public delegate void DataChangedEvevt(EditMode editType, object obj);

    public delegate void DataCheckEvent(EditMode editType, object obj, ref bool bln);
    public delegate void DataSaveEvent(EditMode editType, object obj, ref bool bln);

    static class Program
    {

        //全局数据库处理对象
        public static CDatabase db = new CDatabase();

        //注册表处理
        public static CReg reg = new CReg();

        //Socket类
        public static CSocket sck = null;

        //登录成功标记(0-未登录、1-成功、2-失败)
        private static int loginSign = 0;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args == null)
            {
                args = new string[0];
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            //判断只能运行一个实例 
            bool createNew;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew);

            if (!createNew)
            {
                MessageBox.Show("程序实例已经运行");
                return;
            }

            //建立数据库连接
            string sConn = ConfigurationManager.ConnectionStrings["dbconfig"].ConnectionString;
            db.CreateConn(sConn);

            if (!VerifyVer())
            {
                try
                {
                    Process.Start(System.Windows.Forms.Application.StartupPath + "\\LiveUpdate.exe");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Application.Exit();
                return;
            }

            CVar.CenterIP = ConfigurationManager.AppSettings["dccip"];
            CVar.CenterPort = ConfigurationManager.AppSettings["dccport"];
            CVar.ChartExe = ConfigurationManager.AppSettings["chartexe"];
            CVar.MonitorExe = ConfigurationManager.AppSettings["monitorexe"];
            CVar.PlaybackExe = ConfigurationManager.AppSettings["playbackexe"];
            CVar.QueryMode = ConfigurationManager.AppSettings["querymode"] == "true" ? true : false;
            CVar.DebugMode = ConfigurationManager.AppSettings["debugmode"] == "true" ? true : false;

            //启动控制台
            if (CVar.DebugMode)
            {
                NativeMethods.AllocConsole();
            }

            sck = new CSocket();
            bool bln = false;

            if (args.Length != 0)
            {
                bln = ChkPass(args[0], args[1]);
            }
            else
            {
                //注册登录窗体的事件     
                frmLogin LoginForm = new frmLogin();
                LoginForm.ChkLogin += new ChkLoginEvevt(ChkLogin);

                bln = LoginForm.ShowMe();
            }

            if (bln)
            {
                frmLines LinesForm = new frmLines();

                if (LinesForm.ShowMe())
                {
                    if (CVar.QueryMode)
                    {
                        Application.Run(new frmMain());
                    }
                    else
                    {
                        sck.DccLogin += new LoginEvevt(DccLogin);
                        sck.Start();

                        while (loginSign == 0)
                        { }

                        if (loginSign == 1)
                        { 
                            Application.Run(new frmMain()); 
                        }
                    }
                }
            }
        }

        static bool VerifyVer()
        {
            bool bln = false;

            try
            {
                if (File.Exists(Application.StartupPath + @"\update.xml"))
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(Application.StartupPath + @"\update.xml");

                    XmlNode x = xml.SelectSingleNode("//updatelist/version");
                    string ver = x.InnerText;

                    string sql = "SELECT objectVersion FROM TB_ObjVer WHERE LOWER(objectName) = 'update.xml'";
                    DataTable dt = db.GetRs(sql);

                    if (dt.Rows.Count != 0)
                    {
                        if (String.Compare(ver, dt.Rows[0][0].ToString(), true) == 0)
                        {
                            bln = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bln;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            Log.WriteLogs(e.ExceptionObject as Exception);
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            Log.WriteLogs(e.Exception);
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 生成自定义异常消息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>
        /// <returns>异常字符串文本</returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
                sb.AppendLine("【异常方法】：" + ex.TargetSite);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }

        private static void DccLogin(bool bln)
        {
            loginSign = bln ? 1: 2;
        }

        static void ChkLogin(string sUser, string sPwd, ref bool bln)
        {
            bln = false;

            string sql = string.Format("SELECT password FROM TB_UPC_USER WHERE UPPER(usercode) = UPPER('{0}')", sUser);
            DataTable ds = db.GetRs(sql);

            if (ds.Rows.Count == 0)
            {
                MessageBox.Show("用户名不存在。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (ds.Rows[0]["password"].ToString().ToLower() != System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sPwd, "MD5").ToLower())
                {
                    MessageBox.Show("密码不正确。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    CVar.LoginID = sUser;
                    CVar.LoginPwd = ds.Rows[0]["password"].ToString().ToLower();

                    bln = true;
                }
            }
        }

        static bool ChkPass(string sUser, string sMd5)
        {
            bool bln = false;

            string sql = string.Format("SELECT password FROM TB_UPC_USER WHERE UPPER(usercode) = UPPER('{0}')", sUser);
            DataTable ds = db.GetRs(sql);

            if (ds.Rows.Count == 0)
            {
                MessageBox.Show("用户名不存在。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (ds.Rows[0]["password"].ToString().ToLower() != sMd5.ToLower())
                {
                    MessageBox.Show("密码不正确。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    CVar.LoginID = sUser;
                    CVar.LoginPwd = ds.Rows[0]["password"].ToString().ToLower();

                    bln = true;
                }
            }

            return bln;
        }
    }

    public class Log
    {
        private static readonly object obj = new object();

        public static void WriteLogs(string content)
        {
            lock (obj)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                if (!string.IsNullOrEmpty(path))
                {
                    path = AppDomain.CurrentDomain.BaseDirectory + "log";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    path = path + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".Info.log";
                    if (!File.Exists(path))
                    {
                        FileStream fs = File.Create(path);
                        fs.Close();
                    }
                    if (File.Exists(path))
                    {
                        StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                        sw.WriteLine(DateTime.Now.ToString("HH:mm:ss") + ": " + content);
                        sw.Close();
                    }
                }
            }
        }

        public static void WriteLogs(Exception ex)
        {
            lock (obj)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                if (!string.IsNullOrEmpty(path))
                {
                    path = AppDomain.CurrentDomain.BaseDirectory + "log";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    path = path + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".Error.log";
                    if (!File.Exists(path))
                    {
                        FileStream fs = File.Create(path);
                        fs.Close();
                    }
                    if (File.Exists(path))
                    {
                        StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                        sw.WriteLine("------------------------------------------------------------");
                        sw.WriteLine("错误发生于：" + DateTime.Now.ToString());
                        sw.WriteLine("错误描述：" + ex.Message);
                        sw.WriteLine("错误位置：" + ex.StackTrace);
                        sw.WriteLine("------------------------------------------------------------");
                        sw.Close();
                    }
                }
            }
        }
    }
}
