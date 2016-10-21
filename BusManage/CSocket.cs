using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace BusManage
{
    //定义委托
    public delegate void LoginEvevt(bool bln);
    public delegate void ConnectingEvevt();
    public delegate void GetDataEvent(int lineid, int busid, string drvnumber, int stationid, DateTime itime, string ssign, int direct, ref bool iscomp);

    class CSocket
    {
        //定义委托事件 
        public event LoginEvevt DccLogin;
        public event ConnectingEvevt DccConnecting;
        public event ConnectingEvevt DccBreak;
        public event GetDataEvent GetDccMsg;

        /// <summary>
        /// DCC连接关键字
        /// </summary>
        private string dccIpKey = "dccip";
        private string dccPortKey = "dccport";

        /// <summary>
        /// DCC地址与端口
        /// </summary>
        private string remoteEndIP = "60.29.214.33";
        private int remoteEndPort = 9002;

        private SocketClientManager sckClient;

        /// <summary>
        /// 信息分割字
        /// </summary>
        private char seperatorChar = (char)0x1F;
        private char endChar = (char)0x1E;

        /// <summary>
        /// 数据通信后台任务
        /// </summary>
        private BackgroundWorker sysBackworker = null;

        /// <summary>
        /// 连接探测定时器
        /// </summary>
        private System.Timers.Timer detectTimer;

        /// <summary>
        /// 信息处理定时器
        /// </summary>
        private System.Timers.Timer analysisTimer;

        /// <summary>
        /// 连接探测心跳信息事件间隔，以秒为单位
        /// </summary>
        private int detectInterval = 30;

        /// <summary>
        /// 第一次连接探测心跳信息事件间隔，以秒为单位
        /// </summary>
        private int detectIntervalFirst = 4;

        /// <summary>
        /// 信息处理时间间隔，以毫秒为单位
        /// </summary>
        private int analysisInterval = 100;

        /// <summary>
        /// 缓存接收到的数据
        /// </summary>
        Queue<string> msgList = new Queue<string>();

        public CSocket()
        {
            if (CVar.QueryMode) //预览模式不使用Dcc通信
            {
                return;
            }

            if (ConfigurationManager.AppSettings[dccIpKey] != null)
            {
                remoteEndIP = ConfigurationManager.AppSettings[dccIpKey];
            }

            if (ConfigurationManager.AppSettings[dccPortKey] != null)
            {
                remoteEndPort = Convert.ToInt16(ConfigurationManager.AppSettings[dccPortKey]);
            }

            sckClient = new SocketClientManager(remoteEndIP, remoteEndPort);
            sckClient.OnReceiveMsg += new SocketClientManager.OnReceiveMsgHandler(ProcessReceive);
            sckClient.OnConnected += new SocketClientManager.OnConnectedHandler(ProcessConnect);
            sckClient.OnFaildConnect += new SocketClientManager.OnConnectedHandler(ProcessConnectErr);
        }

        public void Start()
        {
            if (sckClient != null)
            {
                sckClient.Start();
            }
        }

        private void ProcessReceive()
        {
            string receivedInfo = sckClient.recMsg;
            PrintSck("rec:", receivedInfo, ConsoleColor.DarkMagenta);

            string[] infos = receivedInfo.Split(endChar);
            for (int i = 0; i < infos.Length; i++)
            {
                string info = infos[i];

                //登陆回执
                if (info.StartsWith("login_ack"))
                {
                    //登陆成功
                    string[] sRec = info.Split(seperatorChar);

                    if (sRec[1].ToLower() == "succ")
                    //login_ack   succ    用户ID
                    {
                        //运行后台任务
                        StartSysBackworker();

                        if (this.DccLogin != null) DccLogin(true);
                        continue;
                    }
                    else   
                    //'login_ack   fail    用户ID  线路个数    线路1ID ...  线路nID
                    {
                        string relines = "";

                        for (int j = 1; j <= int.Parse(sRec[3]); j++)
                        {
                            relines += "," + CFunc.IDValue("tb_lines", "lineid2", "linename", int.Parse(sRec[3 + j]));
                        }

                        MessageBox.Show("线路：" + relines.Substring(1) + Environment.NewLine + "已被其它发车系统占用，请重新选择管理线路");
                        if (this.DccLogin != null) DccLogin(false);
                        break;
                    }
                }
                //连接探测信息回执
                else if (info.StartsWith("detect_ack"))
                {
                    if (this.DccConnecting != null) DccConnecting();
                    continue;
                }
                //到离站信息
                else if (info.StartsWith("disp"))
                {
                    msgList.Enqueue(info);
                    continue;
                }
            }
        }

        private void ProcessConnect()
        {
            Console.WriteLine("已经连接DCC");

            string loginStr = "login" + seperatorChar + CVar.LoginID + seperatorChar + CVar.LineNum + seperatorChar + CVar.SelLines + endChar;

            PrintSck("snd:", loginStr, ConsoleColor.Green);
            sckClient.SendMsg(loginStr);
        }

        private void ProcessConnectErr()
        {
            Console.WriteLine("连接DCC失败，尝试重新连接");
            sckClient.ReStart();

            if (this.DccBreak != null) DccBreak();
        }

        /// <summary>
        /// 解析并处理接受的内容
        /// </summary>
        /// <param name="msg">单条信息</param>
        private void AnalysisMsg(string msg)
        {
            string[] recs = msg.Split(seperatorChar);

            //disp  线路ID  车号ID  驾驶员ID  站点ID  时间  进出站标记  上下行标记
            if (recs[0] == "disp")
            {
                PrintSck("ret:", msg, ConsoleColor.Blue);

                //发送回执
                //disp_ack  线路ID  车号ID  站点ID  进出站标记  上下行标记
                string ackStr = "disp_ack" + seperatorChar + recs[1] + seperatorChar + recs[2] + seperatorChar + recs[4] + seperatorChar + recs[6] + seperatorChar + recs[7] + endChar;

                PrintSck("snd:", ackStr, ConsoleColor.Green);
                sckClient.SendMsg(ackStr);

                if (CFunc.DateDiff(DateInterval.Day, DateTime.Parse(recs[5]), DateTime.Now) != 0)
                {
                    //非当天数据不处理
                    return;
                }

                //通过事件转到外部处理
                if (GetDccMsg != null)
                {
                    bool iscomp = false;
                    GetDccMsg(int.Parse(recs[1]), int.Parse(recs[2]), recs[3], int.Parse(recs[4]), DateTime.Parse(recs[5]), recs[6], int.Parse(recs[7]), ref iscomp);

                    while (!iscomp)
                    {
                        //等待，直到事件处理完成
                    }
                }
            }
        }

        /// <summary>
        /// 通过中心转发信息
        /// </summary>
        /// <param name="lineid">线路ID</param>
        /// <param name="busid">车辆ID</param>
        /// <param name="msg">发送内容</param>
        public void SendMsg(int lineid, int busid, string msg)
        {
            if (sckClient != null)
            {
                //disp_dcc  线路ID  车辆ID  文字信息
                string msgStr = "disp_dcc" + seperatorChar + lineid.ToString() + seperatorChar + busid.ToString() + seperatorChar + msg + endChar;

                PrintSck("snd:", msgStr, ConsoleColor.Green);
                sckClient.SendMsg(msgStr);
            }
        }

        /// <summary>
        /// 启动后台通信服务
        /// </summary>
        public void StartSysBackworker()
        {
            sysBackworker = new BackgroundWorker();
            sysBackworker.WorkerReportsProgress = true; // 设置可以通告进度
            sysBackworker.WorkerSupportsCancellation = true; // 设置可以取消
            sysBackworker.DoWork += new DoWorkEventHandler(monitorBackworker_DoWork);

            sysBackworker.RunWorkerAsync();
        }

        void monitorBackworker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (detectTimer != null)
            {
                detectTimer.Enabled = false;
                detectTimer = null;
            }

            detectTimer = new System.Timers.Timer(1000 * detectIntervalFirst);
            detectTimer.Elapsed += new System.Timers.ElapsedEventHandler(detectTimer_Elapsed);
            detectTimer.AutoReset = true;
            detectTimer.Enabled = true;

            if (analysisTimer != null)
            {
                analysisTimer.Enabled = false;
                analysisTimer = null;
            }

            analysisTimer = new System.Timers.Timer(analysisInterval);
            analysisTimer.Elapsed += new System.Timers.ElapsedEventHandler(analysisTimer_Elapsed);
            analysisTimer.AutoReset = true;
            analysisTimer.Enabled = true;
        }

        /// <summary>
        /// 探测连接定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void detectTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            detectTimer.Interval = 1000 * detectInterval;

            //发送探测信息
            if (sckClient != null)
            {
                string detectStr = "detect" + seperatorChar + CVar.LoginID + endChar;

                PrintSck("snd:", detectStr, ConsoleColor.Green);
                sckClient.SendMsg(detectStr);
            }
        }

        private static int inTimer = 0;

        /// <summary>
        /// 数据处理定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void analysisTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // 加锁检查更新锁
            if (Interlocked.Exchange(ref inTimer, 1) == 0)
            {
                try
                {
                    if (msgList.Count != 0)
                    {
                        //从消息队列里取出一条数据进行处理(直接从队列移除)
                        string str = msgList.Dequeue();

                        AnalysisMsg(str);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Interlocked.Exchange(ref inTimer, 0);
                }
            }
        }

        private readonly object obj = new object();

        public void PrintSck(string desc, string msg, ConsoleColor c)
        {
            string str = msg.Replace(seperatorChar.ToString(), "|").Replace(endChar.ToString(), Environment.NewLine + "\t\t");

            Console.Write(desc);
            Console.ForegroundColor = c;
            Console.WriteLine(str);
            Console.ResetColor();

            lock (obj)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                if (!string.IsNullOrEmpty(path))
                {
                    path = AppDomain.CurrentDomain.BaseDirectory + "log\\" + DateTime.Now.ToString("yyyyMMdd");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    path = path + "\\dcc.log";
                    if (!File.Exists(path))
                    {
                        FileStream fs = File.Create(path);
                        fs.Close();
                    }
                    if (File.Exists(path))
                    {
                        StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                        sw.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t" + str);
                        sw.Close();
                    }
                }
            }
        }
    }
}
