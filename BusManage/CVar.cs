using Com.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace BusManage
{
    internal class CVar
    {
        #region 字段
        private static string _centerip = "";
        private static string _centerport = "";
        private static string _chartexe = "";
        private static string _monitorexe = "";
        private static string _playbackexe = "";
        private static bool _querymode = false;
        private static bool _debugmode = false;
        private static string _loginid = "";
        private static string _loginpwd = "";
        private static bool _initsign = false;

        private static string _sellines = "";
        private static Dictionary<string, LineInfo> _lines = null;
        private static List<SchInfo> _sch = null;
        private static List<QueueInfo> _queue = null;

        private static DateTime dteDccSend;

        private static CDatabase db = Program.db;

        private static ZipHelper zip = new ZipHelper();
        private static FtpHelper ftp = new FtpHelper();
        #endregion

        static CVar()
        {
            //中心DCCIP
            _centerip = "";
            //中心DCC端口
            _centerport = "";
            //直观图路径
            _chartexe = "";
            //地图监控路径
            _monitorexe = "";
            //轨迹回放路径
            _playbackexe = "";
            //预览模式
            _querymode = false;
            //Debug模式
            _debugmode = false;
            //登录名
            _loginid = "";
            //登录密码
            _loginpwd = "";
            //初始化标记
            _initsign = false;

            //管理线路ID子串
            _sellines = "";
            //线路属性
            _lines = null;
            //本地时刻表
            _sch = null;
            //本地发车队列
            _queue = null;
        }

        #region 属性
        /// <summary>
        /// 中心DCCIP
        /// </summary>
        public static string CenterIP
        {
            get { return _centerip; }
            set { _centerip = value; }
        }

        /// <summary>
        /// 中心DCC端口
        /// </summary>
        public static string CenterPort
        {
            get { return _centerport; }
            set { _centerport = value; }
        }

        /// <summary>
        /// 直观图路径
        /// </summary>
        public static string ChartExe
        {
            get { return _chartexe; }
            set { _chartexe = value; }
        }

        /// <summary>
        /// 地图监控路径
        /// </summary>
        public static string MonitorExe
        {
            get { return _monitorexe; }
            set { _monitorexe = value; }
        }

        /// <summary>
        /// 地图监控路径
        /// </summary>
        public static string PlaybackExe
        {
            get { return _playbackexe; }
            set { _playbackexe = value; }
        }

        /// <summary>
        /// 预览模式
        /// </summary>
        public static bool QueryMode
        {
            get { return _querymode; }
            set { _querymode = value; }
        }

        /// <summary>
        /// Debug模式
        /// </summary>
        public static bool DebugMode
        {
            get { return _debugmode; }
            set { _debugmode = value; }
        }

        /// <summary>
        /// 登录名
        /// </summary>
        public static string LoginID
        {
            get { return _loginid; }
            set { _loginid = value; }
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        public static string LoginPwd
        {
            get { return _loginpwd; }
            set { _loginpwd = value; }
        }

        /// <summary>
        /// 初始化标记
        /// </summary>
        public static bool InitSign
        {
            get { return _initsign; }
            set { _initsign = value; }
        }

        /// <summary>
        /// 管理线路ID子串
        /// </summary>
        public static string SelLines
        {
            get { return _sellines; }
        }

        /// <summary>
        /// 管理线路数量
        /// </summary>
        public static int LineNum
        {
            get 
            {
                return _sellines.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Length; 
            }
        }

        /// <summary>
        /// 线路属性
        /// </summary>
        public static Dictionary<string, LineInfo> Lines
        {
            get { return _lines; }
            set { _lines = value; }
        }

        public static LineInfo SngLine(int lineid2)
        {
            if (_lines.ContainsKey(lineid2.ToString()))
            {
                return _lines[lineid2.ToString()];
            }
            else
            {
                throw new Exception("获取线路失败（未能匹配线路ID）");
            }            
        }

        /// <summary>
        /// 本地时刻表
        /// </summary>
        public static List<SchInfo> Sch
        {
            get { return _sch; }
            set { _sch = value; }
        }

        /// <summary>
        /// 线路时刻表
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="direct"></param>
        /// <returns></returns>
        public static List<SchInfo> Line_Sch(int lineid2, int direct)
        {
            List<SchInfo> s = Sch.Where(info => info.Lineid2 == lineid2).Where(info => info.Direct == direct).ToList();
            s.Sort(SortSch_PlanStarttimeAsc);
            return s;
        }

        /// <summary>
        /// 单个发车点
        /// </summary>
        /// <param name="recid"></param>
        /// <returns></returns>
        public static SchInfo SngSch(string recid)
        {
            List<SchInfo> s = Sch.Where(info => info.Recid == recid).ToList();
            if (s.Count != 0)
            {
                return s[0];
            }
            else
            {
                throw new Exception("获取时刻点失败（ID未能匹配）");
            }
        }

        /// <summary>
        /// 本地发车队列
        /// </summary>
        public static List<QueueInfo> Queue
        {
            get { return _queue; }
            set { _queue = value; }
        }

        /// <summary>
        /// 上下行队列
        /// </summary>
        /// <param name="direct"></param>
        /// <returns></returns>
        public static List<QueueInfo> Line_Queue(int direct)
        {
            List<QueueInfo> q = Queue.Where(info => info.Direct == direct).ToList();
            q.Sort(SortQueue);
            return q;
        }

        /// <summary>
        /// 单个排队队列
        /// </summary>
        /// <param name="recid"></param>
        /// <returns></returns>
        public static QueueInfo SngQueue(string recid)
        {
            List<QueueInfo> q = Queue.Where(info => info.Recid == recid).ToList();
            if (q.Count != 0)
            {
                return q[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 线路车辆
        /// </summary>
        public static List<BusInfo> Line_Buses(int lineid2)
        {
            if (_lines.ContainsKey(lineid2.ToString()))
            {
                List<BusInfo> b = new List<BusInfo>();

                foreach(var bi in _lines[lineid2.ToString()].Buses)
                {
                    b.Add((BusInfo)bi.Value);
                }

                return b;
            }
            else
            {
                throw new Exception("获取车辆失败（未能匹配线路ID）");
            }
        }

        public static BusInfo Line_bus(int lineid2, int busid2)
        {
            if (_lines.ContainsKey(lineid2.ToString()))
            {
                if (_lines[lineid2.ToString()].Buses.ContainsKey(busid2.ToString()))
                {
                    return _lines[lineid2.ToString()].Buses[busid2.ToString()];
                }
            }

            throw new Exception("获取车辆失败");
        }

        /// <summary>
        /// 线路驾驶员
        /// </summary>
        public static List<DrvInfo> Line_Drivers(int lineid2)
        {
            if (_lines.ContainsKey(lineid2.ToString()))
            {
                List<DrvInfo> d = new List<DrvInfo>();

                foreach (var di in _lines[lineid2.ToString()].Drivers)
                {
                    d.Add((DrvInfo)di.Value);
                }

                return d;
            }
            else
            {
                throw new Exception("获取驾驶员失败（未能匹配线路ID）");
            }
        }

        public static DrvInfo Line_driver(int lineid2, string drvnumber)
        {
            if (_lines.ContainsKey(lineid2.ToString()))
            {
                if (_lines[lineid2.ToString()].Drivers.ContainsKey(drvnumber))
                {
                    return _lines[lineid2.ToString()].Drivers[drvnumber];
                }
            }

            return null;
            //throw new Exception("获取驾驶员失败");
        }

        /// <summary>
        /// 线路区间属性
        /// </summary>
        public static List<CaseInfo> Line_Cases(int lineid2)
        {
            if (_lines.ContainsKey(lineid2.ToString()))
            {
                List<CaseInfo> c = new List<CaseInfo>();

                foreach (var ci in _lines[lineid2.ToString()].Cases)
                {
                    c.Add((CaseInfo)ci.Value);
                }

                return c;
            }
            else
            {
                throw new Exception("获取区间失败（未能匹配线路ID）");
            }
        }

        public static CaseInfo Line_case(int lineid2, string caseid)
        {
            if (_lines.ContainsKey(lineid2.ToString()))
            {
                if (_lines[lineid2.ToString()].Cases.ContainsKey(caseid))
                {
                    return _lines[lineid2.ToString()].Cases[caseid];
                }
            }

            throw new Exception("获取区间失败");
        }

        public static CaseInfo Line_Defcase(int lineid2)
        {
            List<CaseInfo> l = Line_Cases(lineid2).Where(info => info.Isdefault == 1).ToList();
            if (l.Count != 0)
            {
                return l[0]; 
            }

            throw new Exception("获取默认区间失败");
        }

        /// <summary>
        /// 发车通过率判断时间差
        /// </summary>
        public static int PassInterval
        {
            get { return 7; }
        }

        /// <summary>
        /// 过站达标率
        /// </summary>
        public static double PassStationRate
        {
            get { return 0.75; }
        }

        /// <summary>
        /// 里程达标率
        /// </summary>
        public static double PassMileRate
        {
            get { return 0.75; }
        }

        /// <summary>
        /// 实际发车与计划偏差允许值
        /// </summary>
        public static int SaveInterval
        {
            get { return 15; }
        }

        public static DateTime DccSend
        {
            get { return dteDccSend; }
            set { dteDccSend = value; }
        }
        #endregion

        #region 函数
        /// <summary>
        /// 显示当天行车计划
        /// </summary>
        /// <param name="lineStr"></param>
        /// <returns></returns>
        public static bool ShowSchOnFst(string lineStr)
        {
            string sql = "SELECT D.LINENAME, B.SCHNAME " + Environment.NewLine
                        + "FROM TB_ORIGINALATTEMPER A " + Environment.NewLine
                        + "INNER JOIN TB_SCHEDULE B ON B.SCHID = A.SCHID AND B.STOPSIGN = 0 " + Environment.NewLine
                        + "INNER JOIN TB_LINES D ON D.LINEID = A.LINEID " + Environment.NewLine
                        + "WHERE D.LINEID2 IN (" + lineStr + ") AND TRUNC(A.ORIDATE) = TRUNC(SYSDATE) " + Environment.NewLine
                        + "AND NOT EXISTS ( " + Environment.NewLine
                        + "    SELECT * FROM TB_DRIVING_RECORDS WHERE LINEID = A.LINEID AND TRUNC(CHKDATE) = TRUNC(SYSDATE) " + Environment.NewLine
                        + ")";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                string lineSch = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lineSch += Environment.NewLine + dt.Rows[i]["LINENAME"].ToString() + " -> " + dt.Rows[i]["SCHNAME"].ToString();
                }

                if (MessageBox.Show("请确认本日使用的行车计划，如有误请点击\"取消\"退出发车系统，在后台重新排班后再登录。" + Environment.NewLine + "注意：进入发车系统后将无法修改当日计划。" + Environment.NewLine + lineSch.ToString() ,"重要提醒", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 初始化管理线路
        /// </summary>
        /// <returns></returns>
        public static bool ChkLines(string lineStr, out bool blnExit)
        {
            blnExit = false;
            string sql;
            DataTable dt;

            sql = "SELECT B.LINENAME FROM TB_LINES B " + Environment.NewLine
                + "LEFT JOIN TB_ORIGINALATTEMPER A ON A.LINEID = B.LINEID AND TRUNC(A.ORIDATE) = TRUNC(SYSDATE) " + Environment.NewLine
                + "WHERE B.LINEID2 IN (" + lineStr + ") AND A.ORIID IS NULL ";
            dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                string lines = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lines += Environment.NewLine + dt.Rows[i]["LINENAME"].ToString();
                }

                MessageBox.Show("以下线路缺少排班当日的排班信息。" + lines, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            sql = "SELECT a.ORIID, c.SCHID, b.LINEID, b.LINENAME, c.SCHNAME FROM TB_LINES b " + Environment.NewLine
                + "INNER JOIN TB_ORIGINALATTEMPER a ON a.LINEID = b.LINEID INNER JOIN TB_SCHEDULE c ON c.SCHID = a.SCHID " + Environment.NewLine
                + "WHERE b.lineid2 IN (" + lineStr + ") AND TRUNC(a.oridate) = TRUNC(SYSDATE) AND c.STOPSIGN = 1";
            dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                string lines = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql1 = "DELETE FROM TB_ORIGINALATTEMPER_D WHERE ORIID = '" + dt.Rows[i]["ORIID"].ToString() + "'";
                    string sql2 = "DELETE FROM TB_ORIGINALATTEMPER WHERE ORIID = '" + dt.Rows[i]["ORIID"].ToString() + "'";
                    string sql3 = "DELETE FROM TB_SCHEDULE_USEDATE WHERE LINEID = '" + dt.Rows[i]["LINEID"].ToString() + "' AND TRUNC(a.schdate) = TRUNC(SYSDATE)";

                    db.Execute(sql1, sql2, sql3);

                    lines += Environment.NewLine + dt.Rows[i]["LINENAME"].ToString() + " >> " + dt.Rows[i]["SCHNAME"].ToString();
                }

                MessageBox.Show("以下线路使用的行车计划已经作废，请重新设置排班。" + lines, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            sql = "SELECT B.LINENAME, E.SCHID FROM TB_LINES B " + Environment.NewLine
                + "INNER JOIN TB_SCHEDULE_USEDATE C ON C.LINEID = B.LINEID AND TRUNC(C.SCHDATE) = TRUNC(SYSDATE) INNER JOIN TB_SCHEDULE_T D ON D.SCHID = C.SCHID " + Environment.NewLine
                + "INNER JOIN TB_SCHEDULE E ON E.SCHID = C.SCHID AND E.STOPSIGN = 0 LEFT JOIN TB_LINE_CASES A ON A.LINEID = C.LINEID AND A.CASEID = D.CASEID " + Environment.NewLine
                + "WHERE B.LINEID2 IN (" + lineStr + ") AND A.CASEID IS NULL ";
            dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                string lines = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lines += Environment.NewLine + dt.Rows[i]["LINENAME"].ToString() + " >> " + dt.Rows[i]["SCHNAME"].ToString();
                }

                MessageBox.Show("以下线路行车计划中出现不能识别的区间。" + lines, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            sql = "SELECT A.LINENAME, B.CASENAME FROM TB_LINES A " + Environment.NewLine
                + "INNER JOIN TB_LINE_CASES B ON B.LINEID = A.LINEID " + Environment.NewLine
                + "INNER JOIN TB_SCHEDULE_USEDATE D ON D.LINEID = A.LINEID AND TRUNC(D.SCHDATE) = TRUNC(SYSDATE) " + Environment.NewLine
                + "INNER JOIN TB_SCHEDULE T ON t.SCHID = D.SCHID AND T.STOPSIGN = 0 " + Environment.NewLine
                + "INNER JOIN TB_SCHEDULE_T E ON E.SCHID = D.SCHID AND E.CASEID = B.CASEID " + Environment.NewLine
                + "LEFT JOIN TB_LINE_STATIONS C ON C.LINEID = B.LINEID AND E.CASEID = B.CASEID " + Environment.NewLine
                + "WHERE A.LINEID2 IN (" + lineStr + ") AND B.STOPSIGN = 0 AND C.STATIONID IS NULL " + Environment.NewLine
                + "GROUP BY A.LINENAME, B.CASENAME ";
            dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                string lines = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lines += Environment.NewLine + dt.Rows[i]["LINENAME"].ToString() + " >> " + dt.Rows[i]["casename"].ToString();
                }

                MessageBox.Show("以下线路区间没有设置站点。" + lines, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //提示当日计划
            if (!ShowSchOnFst(lineStr))
            {
                blnExit = true;
                return false;
            }

            _sellines = lineStr;

            frmLoading frm = new frmLoading();
            return frm.ShowMe();
        }

        /// <summary>
        /// 获取车辆当日班次
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="busid2"></param>
        /// <returns></returns>
        public static int GetRunNumber(int lineid2, int busid2)
        {
            for (int i=0;i<_sch.Count; i++)
            {
                SchInfo si = Sch[i];

                if (si.Lineid2 == lineid2 && si.Busid2 == busid2)
                {
                    return si.Runnumber;
                }
            }

            return 0;
        }

        /// <summary>
        /// 获取车辆当日班次(用于路单编辑)
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="busid2"></param>
        /// <returns></returns>
        public static int GetRunNumber(int lineid2, int busid2, DateTime dte)
        {
            string sql = "SELECT b.runNumber FROM TB_OriginalAttemper a INNER JOIN TB_OriginalAttemper_D b ON b.oriID = a.oriID " + Environment.NewLine
                        + "INNER JOIN TB_LINES c ON c.lineID = a.lineID INNER JOIN TB_BUSES d ON d.busID = b.busID " + Environment.NewLine
                        + "WHERE to_char(a.oriDate,'yyyy-mm-dd') = '" + dte.ToString("yyyy-MM-dd") + "' " + Environment.NewLine
                        + "AND c.lineID2 = " + lineid2.ToString() + " AND d.busID2 = " + busid2.ToString() + " ";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                return int.Parse(dt.Rows[0]["runNumber"].ToString());
            }

            return 0;
        }

        /// <summary>
        /// 时间比较，返回差值
        /// </summary>
        /// <param name="dte1"></param>
        /// <param name="dte2"></param>
        /// <returns></returns>
        public static int TimeDiff(DateTime dte1, DateTime dte2)
        {
            TimeSpan t = dte2 - dte1;
            return (int)t.TotalMinutes;
        }

        /// <summary>
        /// 时间计算，分钟加减
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="dte"></param>
        /// <returns></returns>
        public static DateTime TimeAdd(int interval, DateTime dte)
        {
            return dte.AddMinutes(interval);
        }

        /// <summary>
        /// 将时间转换成数据库保存的格式
        /// </summary>
        /// <param name="itime"></param>
        /// <param name="dte"></param>
        /// <returns></returns>
        public static string TransTime(DateTime itime, DateTime dte)
        {
            return string.Format("to_date('{0} {1}', 'yyyy-mm-dd hh24:mi:ss')", dte.ToString("yyyy-MM-dd") , itime.ToString("HH:mm:ss"));
        }

        public static string TransTime(DateTime itime)
        {
            return string.Format("to_date('{0} {1}', 'yyyy-mm-dd hh24:mi:ss')", DateTime.Now.ToString("yyyy-MM-dd"), itime.ToString("HH:mm:ss"));
        }

        public static DateTime DateValue(string dte)
        {
            return DateTime.Parse(dte);
        }

        public static DateTime TimeValue(string tmr)
        {
            return DateTime.ParseExact(tmr, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 获得指定区间的起点站
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="caseid"></param>
        /// <param name="direct"></param>
        /// <returns></returns>
        public static int GetOutStationID(int lineid2, string caseid, int direct)
        {
            CaseInfo ci = Line_case(lineid2, caseid);

            if (ci != null)
            {
                return direct == 0 ? ci.Up_s_stationid : ci.Dn_s_stationid;
            }
            else
            {
                throw new Exception("获取起点站错误");
            }
        }

        /// <summary>
        /// 获得指定区间的终点站
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="caseid"></param>
        /// <param name="direct"></param>
        /// <returns></returns>
        public static int GetInStationID(int lineid2, string caseid, int direct)
        {
            CaseInfo ci = Line_case(lineid2, caseid);

            if (ci != null)
            {
                return direct == 0 ? ci.Up_e_stationid : ci.Dn_e_stationid;
            }
            else
            {
                throw new Exception("获取终点站错误");
            }
        }

        /// <summary>
        /// 获取车辆指定时间段的gps里程
        /// </summary>
        /// <param name="busid2"></param>
        /// <param name="dte"></param>
        /// <param name="btime"></param>
        /// <param name="etime"></param>
        /// <returns></returns>
        public static double GetRealMileage(int busid2, DateTime dte, DateTime btime, DateTime etime)
        {
            string sql = "SELECT FN_GET_MILEAGE(" + busid2.ToString() + ",to_date('" + dte.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'),to_date('" + btime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'),to_date('" + etime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')) AS km FROM DUAL";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                return double.Parse(dt.Rows[0]["km"].ToString());
            }

            return 0;
        }

        /// <summary>
        /// 获取车辆经过沿途各站点的数量
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="caseid"></param>
        /// <param name="direct"></param>
        /// <param name="busid2"></param>
        /// <param name="dte"></param>
        /// <param name="btime"></param>
        /// <param name="etime"></param>
        /// <returns></returns>
        public static int GetNotPassStations(int lineid2, string caseid, int direct, int busid2, DateTime dte, DateTime btime, DateTime etime)
        {
            string sql = "SELECT FN_GET_NOTPASSSTATION(" + lineid2.ToString() + ",'" + caseid + "'," + direct.ToString() + "," + busid2.ToString() + ",to_date('" + dte.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'),to_date('" + btime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'),to_date('" + etime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')) AS num FROM DUAL";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                return int.Parse(dt.Rows[0]["num"].ToString());
            }

            return 0;
        }

        /// <summary>
        /// 判断站点是否是首末站
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="busid2"></param>
        /// <param name="direct"></param>
        /// <param name="stationid2"></param>
        /// <param name="bln"></param>
        /// <returns></returns>
        public static bool ChkOrigin_TerminalStation(int lineid2, int busid2, int direct, int stationid2, bool bln)
        {
            string caseid;
            //找最后一个发车点对应的区间
            List<SchInfo> s = Sch.Where(info => info.Lineid2 == lineid2).Where(info => info.Busid2 == busid2).Where(info => info.Direct == direct).Where(info => info.Status != 0).ToList();

            if (s.Count != 0)
            {
                SchInfo si = new SchInfo();
                Reverser<SchInfo> reverser = new Reverser<SchInfo>(si.GetType(), "Plan_starttime", ReverserInfo.Direction.DESC);
                s.Sort(reverser);

                caseid = s[0].Caseid;
            }
            else
            {
                s = Sch.Where(info => info.Lineid2 == lineid2).Where(info => info.Busid2 == busid2).Where(info => info.Direct == direct).ToList();

                if (s.Count != 0)
                {   //首班车
                    SchInfo si = new SchInfo();
                    Reverser<SchInfo> reverser = new Reverser<SchInfo>(si.GetType(), "Plan_starttime", ReverserInfo.Direction.ASC);
                    s.Sort(reverser);

                    caseid = s[0].Caseid;
                }   //当日无发车点，取默认区间
                else
                {
                    caseid = "";
                }
            }

            CaseInfo ci;
            if (caseid != "")
            {   //指定区间
                ci = Line_case(lineid2, caseid);
            }
            else
            {   //默认区间
                ci = Line_Defcase(lineid2);
            }

            if (bln)
            {
                if (direct == 0)
                {
                    return ci.Up_s_stationid == stationid2 ? true : false;
                }
                else
                {
                    return ci.Dn_s_stationid == stationid2 ? true : false;
                }
            }
            else
            {
                if (direct == 0)
                {
                    return ci.Up_e_stationid == stationid2 ? true : false;
                }
                else
                {
                    return ci.Dn_e_stationid == stationid2 ? true : false;
                }
            }
        }

        /// <summary>
        /// 判断所有可能的终点站出站
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="direct"></param>
        /// <param name="stationid2"></param>
        /// <returns></returns>
        public static bool ChkEndStation(int lineid2, int direct, int stationid2)
        {
            List<CaseInfo> l = new List<CaseInfo>();

            if (direct == 0)
            {
                l = Line_Cases(lineid2).Where(info => info.Up_e_stationid == stationid2).ToList();
            }
            else
            {
                l = Line_Cases(lineid2).Where(info => info.Dn_e_stationid == stationid2).ToList();
            }

            return l.Count > 0 ? true : false;
        }

        /// <summary>
        /// 获取指定时间点之前最接近的进站时间点
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="busid2"></param>
        /// <param name="direct"></param>
        /// <param name="stationid2"></param>
        /// <param name="itime"></param>
        /// <returns></returns>
        public static DateTime GetNearInTime(int lineid2, int busid2, int direct, int stationid2, DateTime itime)
        {
            string sql = "SELECT Max(itime) AS itime FROM TB_A" + DateTime.Now.ToString("yyyyMMdd") + " " + Environment.NewLine
                        + "WHERE busid2 = " + busid2.ToString() + " AND direct = " + direct.ToString() + " AND to_char(itime,'hh24:mi:ss') < '" + itime.ToString("HH:mm:ss") + "'";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows[0]["itime"] != null)
            {
                DateTime dte = DateTime.Parse(dt.Rows[0]["itime"].ToString());

                List<SchInfo> s = Sch.Where(info => info.Lineid2 == lineid2).Where(info => info.Busid2 == busid2).Where(info => info.Direct == direct).ToList();
                SchInfo si = new SchInfo();
                Reverser<SchInfo> reverser = new Reverser<SchInfo>(si.GetType(), "Plan_starttime", ReverserInfo.Direction.DESC);
                s.Sort(reverser);

                for (int i = 0; i < s.Count; i++)
                {
                    if (s[i].Arrivetime != null)
                    {
                        if (TimeDiff(dte, (DateTime)s[i].Arrivetime) >= 0)
                        {
                            dte = itime;
                            break;
                        }
                    }
                }
                return dte;
            }
            else
            {
                return itime;
            }
        }

        /// <summary>
        /// 获取指定时间点之前最接近的出站时间点
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="busid2"></param>
        /// <param name="direct"></param>
        /// <param name="stationid2"></param>
        /// <param name="itime"></param>
        /// <returns></returns>
        public static DateTime GetNearOutTime(int lineid2, string caseid, int busid2, int direct, int stationid2, DateTime itime)
        {
            try
            {
                //默认往前提前一分钟
                DateTime dte = TimeAdd(-1, itime);

                CaseInfo ci = Line_case(lineid2, caseid);
                if (ci.Linetype != 0)
                { return dte; }

                //反方向的最后一条
                string sql = "SELECT Min(itime) AS itime FROM TB_A" + DateTime.Now.ToString("yyyyMMdd") + " " + Environment.NewLine
                          + "WHERE busid2 = " + busid2.ToString() + " AND direct = " + direct.ToString() + " AND to_char(itime,'hh24:mi:ss') < '" + itime.ToString("HH:mm:ss") + "' " + Environment.NewLine
                          + "AND itime > ( " + Environment.NewLine
                          + "    SELECT Max(itime) FROM TB_A" + DateTime.Now.ToString("yyyyMMdd") + " WHERE busid2 = " + busid2.ToString() + " AND direct = " + (direct == 0 ? "1" : "0") + " AND to_char(itime,'hh24:mi:ss') < '" + itime.ToString("HH:mm:ss") + "' " + Environment.NewLine
                          + ") ";
                DataTable dt = db.GetRs(sql);

                if (dt.Rows[0]["itime"] != null)
                {
                    if (TimeDiff(DateTime.Parse(dt.Rows[0]["itime"].ToString()), itime) <= SaveInterval)
                    {
                        return DateTime.Parse(dt.Rows[0]["itime"].ToString());
                    }
                }

                return dte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判断线路类型
        /// </summary>
        /// <param name="lineid2"></param>
        /// <returns></returns>
        public static int GetLineType(int lineid2)
        {
            List<CaseInfo> cases = Line_Cases(lineid2);
            List<CaseInfo> cis = cases.Where(info => info.Isdefault == 1).ToList();

            CaseInfo ci = cis[0];

            return ci.Linetype;
        }

        /// <summary>
        /// line ID2转ID
        /// </summary>
        /// <param name="lineid2"></param>
        /// <returns></returns>
        public static string LineID2ToID(int lineid2)
        {
            LineInfo li = SngLine(lineid2);

            if (li != null)
            {
                return li.Lineid;
            }
            else
            {
                throw new Exception("未能获取线路guid(lineid=" + lineid2.ToString() + ")");
            }
        }

        /// <summary>
        /// line ID2转Name
        /// </summary>
        /// <param name="lineid2"></param>
        /// <returns></returns>
        public static string LineID2ToName(int lineid2)
        {
            LineInfo li = SngLine(lineid2);

            if (li != null)
            {
                return li.Linename;
            }
            else
            {
                throw new Exception("未能获取线路名称(lineid=" + lineid2.ToString() + ")");
            }
        }

        /// <summary>
        /// bus ID2转ID
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="busid2"></param>
        /// <returns></returns>
        public static string BusID2ToID(int lineid2, int busid2)
        {
            BusInfo bi = Line_bus(lineid2, busid2);

            if (bi != null)
            {
                return bi.Busid;
            }
            else
            {
                throw new Exception("未能获取车辆guid(busid=" + busid2.ToString() + ")");
            }
        }

        /// <summary>
        /// bus ID2转Number
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="busid2"></param>
        /// <returns></returns>
        public static string BusID2ToNumber(int lineid2, int busid2)
        {
            BusInfo bi = Line_bus(lineid2, busid2);

            if (bi != null)
            {
                return bi.Busnumber;
            }
            else
            {
                throw new Exception("未能获取车辆编号(busid=" + busid2.ToString() + ")");
            }
        }

        /// <summary>
        /// bus Number转ID2
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="busnumber"></param>
        /// <returns></returns>
        public static int BusNumberToID2(int lineid2, string busnumber)
        {
            List<BusInfo> buses = Line_Buses(lineid2);

            for (int i = 0; i < buses.Count; i++)
            {
                if (buses[i].Busnumber == busnumber)
                {
                    return buses[i].Busid2;
                }
            }

            throw new Exception("未能获取车辆id(busnumber=" + busnumber + ")");
        }

        /// <summary>
        /// driver Number转ID
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="drvnumber"></param>
        /// <returns></returns>
        public static string DrvNumberToID(int lineid2, string drvnumber)
        {
            DrvInfo di = Line_driver(lineid2, drvnumber);

            if (di != null)
            {
                return di.Drvid;
            }
            else
            {
                string drvid = CFunc.IDValue("TB_DRIVERS", "DRVNUMBER", "DRVID", drvnumber, "", "");

                if (drvid == "")
                {
                    throw new Exception("未能获取驾驶员guid(drvnumber=" + drvnumber + ")");
                }
                else
                {
                    return drvid;
                }
            }
        }

        /// <summary>
        /// driver ID转Number
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="drvid"></param>
        /// <returns></returns>
        public static string DrvIDToNumber(int lineid2, string drvid)
        {
            List<DrvInfo> drvs = Line_Drivers(lineid2);

            for (int i = 0; i < drvs.Count; i++)
            {
                if (drvs[i].Drvid == drvid)
                {
                    return drvs[i].Drvnumber;
                }
            }

            throw new Exception("未能获取驾驶员工号(drvid=" + drvid + ")");
        }

        /// <summary>
        /// 提取日志
        /// </summary>
        public static void CollectLog()
        {
            string sql = "SELECT a.sysid, a.lineid2, a.relatedate, b.linename FROM tb_LogCollect a INNER JOIN tb_Lines b ON b.lineid2 = a.lineid2 " + Environment.NewLine
                        + "WHERE a.lineid2 IN (" + _sellines + ") AND a.zipdate IS NULL";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string srcPath = AppDomain.CurrentDomain.BaseDirectory + "log\\" + (DateTime.Parse(dt.Rows[i]["relatedate"].ToString())).ToString("yyyyMMdd");

                    if (Directory.Exists(srcPath))
                    {
                        string zipPath = srcPath + "\\" + dt.Rows[i]["linename"].ToString() + "_" + (DateTime.Parse(dt.Rows[i]["relatedate"].ToString())).ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + ".zip";
                        zip.ZipFile(zipPath, srcPath);

                        string zipFile = Path.GetFileName(zipPath);

                        ftp.Upload(zipPath);

                        sql = "UPDATE tb_LogCollect SET zipDate = SYSDATE, zipFile = '" + zipFile + "' WHERE sysid = '" + dt.Rows[i]["sysid"].ToString() + "'";
                        db.Execute(sql);

                        File.Delete(zipPath);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Sch类的排序规则
        /// </summary>
        /// <returns></returns>
        //public static int SortSch_BusnumberAsc(SchInfo sch1, SchInfo sch2)
        //{
        //        if (sch1.Busnumber.CompareTo(sch2.Busnumber) != 0)
        //            return sch1.Busnumber.CompareTo(sch2.Busnumber);
        //        else
        //            return sch1.Plan_starttime.CompareTo(sch2.Plan_starttime);
        //}

        //public static int SortSch_RunnumberAsc(SchInfo sch1, SchInfo sch2)
        //{
        //    if (sch1.Runnumber.CompareTo(sch2.Runnumber) != 0)
        //        return sch1.Runnumber.CompareTo(sch2.Runnumber);
        //    else
        //        return sch1.Plan_starttime.CompareTo(sch2.Plan_starttime);
        //}

        //public static int SortSch_DrvnameAsc(SchInfo sch1, SchInfo sch2)
        //{
        //    if (sch1.Drvname.CompareTo(sch2.Drvname) != 0)
        //        return sch1.Drvname.CompareTo(sch2.Drvname);
        //    else
        //        return sch1.Plan_starttime.CompareTo(sch2.Plan_starttime);
        //}

        //public static int SortSch_CasenameAsc(SchInfo sch1, SchInfo sch2)
        //{
        //    if (sch1.Casename.CompareTo(sch2.Casename) != 0)
        //        return sch1.Casename.CompareTo(sch2.Casename);
        //    else
        //        return sch1.Plan_starttime.CompareTo(sch2.Plan_starttime);
        //}

        public static int SortSch_PlanStarttimeAsc(SchInfo sch1, SchInfo sch2)
        {
            if (sch1.Plan_starttime.CompareTo(sch2.Plan_starttime) != 0)
                return sch1.Plan_starttime.CompareTo(sch2.Plan_starttime);
            else
                return sch1.Runnumber.CompareTo(sch2.Runnumber);
        }

        public static int SortByAsc(SchInfo sch1, SchInfo sch2)
        {
            return sch1.Plan_starttime.CompareTo(sch2.Plan_starttime);
        }

        public static int SortByDesc(SchInfo sch1, SchInfo sch2)
        {
            return sch2.Plan_starttime.CompareTo(sch1.Plan_starttime);
        }

        /// <summary>
        /// Queue类的排序规则
        /// </summary>
        /// <returns></returns>
        private static int SortQueue(QueueInfo queue1, QueueInfo queue2)
        {
            if (queue1.Runstatus.CompareTo(queue2.Runstatus) != 0)
                return queue1.Runstatus.CompareTo(queue2.Runstatus);

            else if (queue1.Lineid2.CompareTo(queue2.Lineid2) != 0)
                return queue1.Lineid2.CompareTo(queue2.Lineid2);

            else if (queue1.Outtime.CompareTo(queue2.Outtime) != 0)
                return queue1.Outtime.CompareTo(queue2.Outtime);

            else
                return queue1.Intime.CompareTo(queue2.Intime);
        }
    }
}
