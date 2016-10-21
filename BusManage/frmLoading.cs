using Com.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmLoading : Form
    {
        private CDatabase db = Program.db;
        private bool blnRet = false;

        public frmLoading()
        {
            InitializeComponent();

            lblInfo.Text = "正在加载数据...";
            pgbInfo.Position = 1;
        }

        public bool ShowMe()
        {
            tmr.Interval = 1;
            tmr.Enabled = true;

            this.ShowDialog();
            return blnRet;
        }

        private void InitLines()
        {
            InitData();

            lblInfo.Text = "数据加载完毕，正在进入系统...";
            pgbInfo.Position = 100;
            this.Refresh();
        }

        /// <summary>
        /// 初始化基础数据
        /// </summary>
        private void InitData()
        {
            string sql = "";
            DataTable dt = null;

            //移除过期排队数据
            lblInfo.Text = "移除过期排队数据...";
            pgbInfo.Position = 10;
            this.Refresh();

            sql = "DELETE FROM TB_LOCAL_QUEUE A " + Environment.NewLine
                + "WHERE A.LINEID2 IN (" + CVar.SelLines + ") " + Environment.NewLine
                + "AND NOT EXISTS ( " + Environment.NewLine
                + "    SELECT * FROM TB_DRIVING_RECORDS WHERE LINEID2 = A.LINEID2 AND TRUNC(CHKDATE) = TRUNC(SYSDATE) " + Environment.NewLine
                + ") ";
            db.Execute(sql);


            //保存当日初始路单(当天无任何路单的时候才会插入数据)
            lblInfo.Text = "创建初始数据...";
            pgbInfo.Position = 20;
            this.Refresh();

            sql = "INSERT INTO TB_DRIVING_RECORDS ( " + Environment.NewLine
                + "    recID, lineID, lineID2, caseID, busID, busID2, startTime, arriveTime, plan_startTime, plan_arriveTime, chkDate, drvID, drvNumber, " + Environment.NewLine
                + "    runStatus, direct, run_Time, fastOrSlow, plan_opr_mileage, opr_Mileage, " + Environment.NewLine
                + "    runNumber, con_busTimes, summary, out_onTime, run_onTime, srcType, editSign, crDate, " + Environment.NewLine
                + "    maker, makeDate, audSign, audor, audDate " + Environment.NewLine
                + ") " + Environment.NewLine
                + "SELECT FN_GET_UUID, D.LINEID, D.LINEID2, C.CASEID, F.BUSID, F.BUSID2, NULL, NULL, " + Environment.NewLine
                + "    TO_DATE(TO_CHAR(SYSDATE,'YYYY-MM-DD') ||' '||TO_CHAR(C.STARTTIME,'HH24:MI:SS'), 'YYYY-MM-DD HH24:MI:SS') AS PLAN_STARTTIME, " + Environment.NewLine
                + "    TO_DATE(TO_CHAR(SYSDATE,'YYYY-MM-DD') ||' '||TO_CHAR(C.ARRIVETIME,'HH24:MI:SS'), 'YYYY-MM-DD HH24:MI:SS') AS PLAN_ARRIVETIME, " + Environment.NewLine
                + "    SYSDATE, G.DRVID, G.DRVNUMBER, " + Environment.NewLine
                + "    0, C.DIRECT, NULL, NULL, DECODE(C.DIRECT,0,E.LINELENGTH,E.LINELENGTH2), 0, " + Environment.NewLine
                + "    B.RUNNUMBER, NULL, NULL, NULL, NULL, 0, 0, SYSDATE, " + Environment.NewLine
                + "    NULL, NULL, 0, NULL, NULL " + Environment.NewLine
                + "FROM TB_ORIGINALATTEMPER A " + Environment.NewLine
                + "INNER JOIN TB_SCHEDULE_T C ON C.SCHID = A.SCHID " + Environment.NewLine
                + "INNER JOIN TB_SCHEDULE T ON T.SCHID = C.SCHID AND T.STOPSIGN = 0 " + Environment.NewLine
                + "INNER JOIN TB_ORIGINALATTEMPER_D B ON B.ORIID = A.ORIID AND B.RUNNUMBER = C.RUNNUMBER " + Environment.NewLine
                + "INNER JOIN TB_LINES D ON D.LINEID = A.LINEID " + Environment.NewLine
                + "INNER JOIN TB_LINE_CASES E ON E.LINEID = A.LINEID AND E.CASEID = C.CASEID " + Environment.NewLine
                + "INNER JOIN TB_BUSES F ON F.BUSID = B.BUSID " + Environment.NewLine
                + "LEFT JOIN TB_DRIVERS G ON G.DRVID = DECODE(C.BUSSTATUS2, 1, B.DRV1ID, 2, B.DRV2ID) " + Environment.NewLine
                + "WHERE D.LINEID2 IN (" + CVar.SelLines + ") AND C.BUSSTATUS = 3 AND TRUNC(A.ORIDATE) = TRUNC(SYSDATE) " + Environment.NewLine
                + "AND NOT EXISTS ( " + Environment.NewLine
                + "    SELECT * FROM TB_DRIVING_RECORDS WHERE LINEID = A.LINEID AND TRUNC(CHKDATE) = TRUNC(SYSDATE) " + Environment.NewLine
                + ") ";
            db.Execute(sql);

            //构建本地记录集
            lblInfo.Text = "正在加载时刻表...";
            pgbInfo.Position = 40;
            this.Refresh();

            sql = "SELECT a.RECID, a.LINEID2, c.BUSID2, a.CASEID, a.DRVNUMBER, c.BUSNUMBER, a.RUNNUMBER, d.DRVNAME, e.CASENAME, " + Environment.NewLine
                + "    a.PLAN_STARTTIME, a.PLAN_ARRIVETIME, a.STARTTIME, a.ARRIVETIME, a.DIRECT, DECODE(a.RUNSTATUS,0,0,2,CASE WHEN a.ARRIVETIME IS NULL THEN 1 ELSE 3 END,7,CASE WHEN a.MAKEDATE IS NULL THEN -1 ELSE 2 END) AS STATUS " + Environment.NewLine
                + "FROM TB_DRIVING_RECORDS a " + Environment.NewLine
                + "INNER JOIN TB_LINES b ON b.LINEID2 = a.LINEID2 " + Environment.NewLine
                + "INNER JOIN TB_BUSES c ON c.BUSID2 = a.BUSID2 " + Environment.NewLine
                + "LEFT JOIN TB_DRIVERS d ON d.DRVNUMBER = a.DRVNUMBER " + Environment.NewLine
                + "INNER JOIN TB_LINE_CASES e ON e.LINEID = b.LINEID AND e.CASEID = a.CASEID " + Environment.NewLine
                + "WHERE a.LINEID2 IN (" + CVar.SelLines + ") AND TRUNC(a.CHKDATE) = TRUNC(SYSDATE) AND EDITSIGN <> 2 AND plan_starttime IS NOT NULL " + Environment.NewLine
                + "ORDER BY a.PLAN_STARTTIME ";
            dt = db.GetRs(sql);

            CVar.Sch = new List<SchInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SchInfo si = new SchInfo()
                {
                    Recid = dt.Rows[i]["RECID"].ToString(),
                    Lineid2 = int.Parse(dt.Rows[i]["LINEID2"].ToString()),
                    Busid2 = int.Parse(dt.Rows[i]["BUSID2"].ToString()),
                    Caseid = dt.Rows[i]["CASEID"].ToString(),
                    Drvnumber = dt.Rows[i]["DRVNUMBER"].ToString(),
                    Busnumber = dt.Rows[i]["BUSNUMBER"].ToString(),
                    Runnumber = int.Parse(dt.Rows[i]["RUNNUMBER"].ToString()),
                    Drvname = dt.Rows[i]["DRVNAME"].ToString(),
                    Casename = dt.Rows[i]["CASENAME"].ToString(),
                    Plan_starttime = DateTime.Parse(dt.Rows[i]["PLAN_STARTTIME"].ToString()),
                    Plan_arrivetime = DateTime.Parse(dt.Rows[i]["PLAN_ARRIVETIME"].ToString()),
                    Starttime = String.IsNullOrEmpty(dt.Rows[i]["STARTTIME"].ToString()) ? (Nullable<DateTime>)null : (Nullable<DateTime>)DateTime.Parse(dt.Rows[i]["STARTTIME"].ToString()),
                    Arrivetime = String.IsNullOrEmpty(dt.Rows[i]["ARRIVETIME"].ToString()) ? (Nullable<DateTime>)null : (Nullable<DateTime>)DateTime.Parse(dt.Rows[i]["ARRIVETIME"].ToString()),
                    Direct = int.Parse(dt.Rows[i]["DIRECT"].ToString()),
                    Status = int.Parse(dt.Rows[i]["STATUS"].ToString())
                };

                CVar.Sch.Add(si);
            }

            lblInfo.Text = "正在加载车辆队列...";
            pgbInfo.Position = 50;
            this.Refresh();

            sql = "SELECT a.RECID, a.DIRECT, a.RUNSTATUS, a.LINEID2, c.BUSID2, a.CASEID, a.DRVNUMBER, b.LINENAME, c.BUSNUMBER, a.RUNNUMBER, d.DRVNAME, e.CASENAME, " + Environment.NewLine
                + "    a.INTIME, a.INDATE, a.STARTTIME, a.STARTDATE, a.STATIONID2 " + Environment.NewLine
                + "FROM TB_LOCAL_QUEUE a " + Environment.NewLine
                + "INNER JOIN TB_LINES b ON b.LINEID2 = a.LINEID2 " + Environment.NewLine
                + "INNER JOIN TB_BUSES c ON c.BUSID2 = a.BUSID2 " + Environment.NewLine
                + "LEFT JOIN TB_DRIVERS d ON d.DRVNUMBER = a.DRVNUMBER " + Environment.NewLine
                + "INNER JOIN TB_LINE_CASES e ON e.LINEID = b.LINEID AND e.CASEID = a.CASEID " + Environment.NewLine
                + "WHERE a.LINEID2 IN (" + CVar.SelLines + ") "
                + "ORDER BY a.STARTTIME ";
            dt = db.GetRs(sql);

            CVar.Queue = new List<QueueInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                QueueInfo qi = new QueueInfo()
                {
                    Recid = dt.Rows[i]["RECID"].ToString(),
                    Direct = int.Parse(dt.Rows[i]["DIRECT"].ToString()),
                    Lineid2 = int.Parse(dt.Rows[i]["LINEID2"].ToString()),
                    Caseid = dt.Rows[i]["CASEID"].ToString(),
                    Drvnumber = dt.Rows[i]["DRVNUMBER"].ToString(),
                    Linename = dt.Rows[i]["LINENAME"].ToString(),
                    Busid2 = int.Parse(dt.Rows[i]["BUSID2"].ToString()),
                    Busnumber = dt.Rows[i]["BUSNUMBER"].ToString(),
                    Runnumber = int.Parse(dt.Rows[i]["RUNNUMBER"].ToString()),
                    Drvname = dt.Rows[i]["DRVNAME"].ToString(),
                    Casename = dt.Rows[i]["CASENAME"].ToString(),
                    Intime = DateTime.Parse(dt.Rows[i]["INTIME"].ToString()),
                    Indate = int.Parse(dt.Rows[i]["INDATE"].ToString()),
                    Outtime = DateTime.Parse(dt.Rows[i]["STARTTIME"].ToString()),
                    Outdate = int.Parse(dt.Rows[i]["STARTDATE"].ToString()),
                    Runstatus = int.Parse(dt.Rows[i]["RUNSTATUS"].ToString()),
                    Stationid2 = int.Parse(dt.Rows[i]["STATIONID2"].ToString()),
                    CmdType = 0
                };
                CVar.Queue.Add(qi);
            }

            //构建基础数据集
            lblInfo.Text = "正在加载线路信息...";
            pgbInfo.Position = 60;
            this.Refresh();

            sql = "SELECT LINEID, LINEID2, LINENAME FROM TB_LINES " + Environment.NewLine
                + "WHERE LINEID2 IN (" + CVar.SelLines + ")";
            dt = db.GetRs(sql);

            CVar.Lines = new Dictionary<string, LineInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LineInfo li = new LineInfo()
                {
                    Lineid = dt.Rows[i]["LINEID"].ToString(),
                    Lineid2 = int.Parse(dt.Rows[i]["LINEID2"].ToString()),
                    Linename = dt.Rows[i]["LINENAME"].ToString()
                };

                CVar.Lines.Add(dt.Rows[i]["LINEID2"].ToString(), li);
            }

            lblInfo.Text = "正在加载车辆信息...";
            pgbInfo.Position = 70;
            this.Refresh();

            sql = "SELECT C.LINEID2, B.BUSID, B.BUSID2, B.BUSNUMBER, B.PLATENUMBER " + Environment.NewLine
                + "FROM TB_LINE_BUSES A INNER JOIN TB_BUSES B ON B.BUSID = A.BUSID AND B.STOPSIGN = 0 " + Environment.NewLine
                + "INNER JOIN TB_LINES C ON C.LINEID = A.LINEID " + Environment.NewLine
                + "WHERE C.LINEID2 IN (" + CVar.SelLines + ")" + Environment.NewLine
                + "ORDER BY B.BUSNUMBER ";
            dt = db.GetRs(sql);

            foreach (var li in CVar.Lines)
            {
                DataRow[] dr = dt.Select("LINEID2 = " + li.Key);

                for (int i = 0; i < dr.Length; i++)
                {
                    BusInfo bi = new BusInfo()
                    {
                        Lineid2 = int.Parse(dr[i]["LINEID2"].ToString()),
                        Busid = dr[i]["BUSID"].ToString(),
                        Busid2 = int.Parse(dr[i]["BUSID2"].ToString()),
                        Busnumber = dr[i]["BUSNUMBER"].ToString(),
                        Platenumber = dr[i]["PLATENUMBER"].ToString()
                    };

                    li.Value.Buses.Add(bi.Busid2.ToString(), bi);
                }
            }

            lblInfo.Text = "正在加载人员信息...";
            pgbInfo.Position = 80;
            this.Refresh();

            sql = "SELECT C.LINEID2, B.DRVID, B.DRVNUMBER, B.DRVNAME " + Environment.NewLine
                + "FROM TB_LINE_DRIVERS A INNER JOIN TB_DRIVERS B ON B.DRVID = A.DRVID AND B.STOPSIGN = 0 " + Environment.NewLine
                + "INNER JOIN TB_LINES C ON C.LINEID = A.LINEID " + Environment.NewLine
                + "WHERE C.LINEID2 IN (" + CVar.SelLines + ") " + Environment.NewLine
                + "ORDER BY B.DRVNAME ";
            dt = db.GetRs(sql);

            foreach (var li in CVar.Lines)
            {
                DataRow[] dr = dt.Select("LINEID2 = " + li.Key);

                for (int i = 0; i < dr.Length; i++)
                {
                    DrvInfo di = new DrvInfo()
                    {
                        Lineid2 = int.Parse(dr[i]["LINEID2"].ToString()),
                        Drvid = dr[i]["DRVID"].ToString(),
                        Drvnumber = dr[i]["DRVNUMBER"].ToString(),
                        Drvname = dr[i]["DRVNAME"].ToString()
                    };

                    li.Value.Drivers.Add(di.Drvnumber, di);
                }
            }

            lblInfo.Text = "正在加载线路区间信息...";
            pgbInfo.Position = 90;
            this.Refresh();

            sql = "SELECT B.LINEID2, A.CASEID, A.CASENAME, A.LINELENGTH, A.LINELENGTH2, A.COUNTWAY, A.BREAKPOINT, A.ISDEFAULT, " + Environment.NewLine
                + "    NVL(D1.STATIONID2,0) AS UP_S_STATIONID, NVL(D2.STATIONID2,0) AS UP_E_STATIONID, NVL(D3.STATIONID2,0) AS DN_S_STATIONID, NVL(D4.STATIONID2,0) AS DN_E_STATIONID, " + Environment.NewLine
                + "    NVL(E1.STATIONNUM,0) AS UP_STATIONNUM, NVL(E2.STATIONNUM,0) AS DN_STATIONNUM, " + Environment.NewLine
                + "    CASE NVL(E1.STATIONNUM,0) WHEN 0 THEN 2 ELSE (CASE NVL(E2.STATIONNUM,0) WHEN 0 THEN 1 ELSE 0 END) END AS LINETYPE " + Environment.NewLine
                + "FROM TB_LINE_CASES A INNER JOIN TB_LINES B ON B.LINEID = A.LINEID " + Environment.NewLine
                + "LEFT JOIN TB_LINE_STATIONS C1 ON C1.LINEID = A.LINEID AND C1.CASEID = A.CASEID AND C1.STATION_DIREC = 0 AND C1.STATION_TYPE = 1 " + Environment.NewLine
                + "LEFT JOIN TB_STATIONS D1 ON D1.STATIONID = C1.STATIONID " + Environment.NewLine
                + "LEFT JOIN TB_LINE_STATIONS C2 ON C2.LINEID = A.LINEID AND C2.CASEID = A.CASEID AND C2.STATION_DIREC = 0 AND C2.STATION_TYPE = 3 " + Environment.NewLine
                + "LEFT JOIN TB_STATIONS D2 ON D2.STATIONID = C2.STATIONID " + Environment.NewLine
                + "LEFT JOIN TB_LINE_STATIONS C3 ON C3.LINEID = A.LINEID AND C3.CASEID = A.CASEID AND C3.STATION_DIREC = 1 AND C3.STATION_TYPE = 1 " + Environment.NewLine
                + "LEFT JOIN TB_STATIONS D3 ON D3.STATIONID = C3.STATIONID " + Environment.NewLine
                + "LEFT JOIN TB_LINE_STATIONS C4 ON C4.LINEID = A.LINEID AND C4.CASEID = A.CASEID AND C4.STATION_DIREC = 1 AND C4.STATION_TYPE = 3 " + Environment.NewLine
                + "LEFT JOIN TB_STATIONS D4 ON D4.STATIONID = C4.STATIONID " + Environment.NewLine
                + "LEFT JOIN (SELECT LINEID, CASEID, COUNT(STATIONID) AS STATIONNUM FROM TB_LINE_STATIONS WHERE STATION_DIREC = 0 GROUP BY LINEID, CASEID) E1 ON E1.LINEID = A.LINEID AND E1.CASEID = A.CASEID " + Environment.NewLine
                + "LEFT JOIN (SELECT LINEID, CASEID, COUNT(STATIONID) AS STATIONNUM FROM TB_LINE_STATIONS WHERE STATION_DIREC = 1 GROUP BY LINEID, CASEID) E2 ON E2.LINEID = A.LINEID AND E2.CASEID = A.CASEID " + Environment.NewLine
                + "WHERE B.LINEID2 IN (" + CVar.SelLines + ") AND A.STOPSIGN = 0 AND EXISTS (SELECT * FROM TB_LINE_STATIONS X WHERE X.LINEID = A.LINEID AND X.CASEID = A.CASEID) " + Environment.NewLine
                + "ORDER BY A.ISDEFAULT DESC, A.CASENAME ";
            dt = db.GetRs(sql);

            foreach (var li in CVar.Lines)
            {
                DataRow[] dr = dt.Select("LINEID2 = " + li.Key);

                for (int i = 0; i < dr.Length; i++)
                {
                    CaseInfo ci = new CaseInfo()
                    {
                        Lineid2 = int.Parse(dr[i]["LINEID2"].ToString()),
                        Caseid = dr[i]["CASEID"].ToString(),
                        Casename = dr[i]["CASENAME"].ToString(),
                        Uplength = double.Parse(dr[i]["LINELENGTH"].ToString()),
                        Downlength = double.Parse(dr[i]["LINELENGTH2"].ToString()),
                        Countway = int.Parse(dr[i]["COUNTWAY"].ToString()),
                        Breakpoint = DateTime.Parse(dr[i]["BREAKPOINT"].ToString()),
                        Isdefault = int.Parse(dr[i]["ISDEFAULT"].ToString()),
                        Up_s_stationid = int.Parse(dr[i]["UP_S_STATIONID"].ToString()),
                        Up_e_stationid = int.Parse(dr[i]["UP_E_STATIONID"].ToString()),
                        Dn_s_stationid = int.Parse(dr[i]["DN_S_STATIONID"].ToString()),
                        Dn_e_stationid = int.Parse(dr[i]["DN_E_STATIONID"].ToString()),
                        Up_stationnum = int.Parse(dr[i]["UP_STATIONNUM"].ToString()),
                        Dn_stationnum = int.Parse(dr[i]["DN_STATIONNUM"].ToString()),
                        Linetype = int.Parse(dr[i]["LINETYPE"].ToString())
                    };

                    li.Value.Cases.Add(ci.Caseid, ci);
                }
            }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            try
            {
                tmr.Enabled = false;

                InitLines();
                blnRet = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库错误: " + ex.Message + Environment.NewLine + "错误位置:" + ex.StackTrace, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
