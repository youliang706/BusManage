using System;
using System.Drawing;

namespace BusManage
{
    class QueueInfo
    {
        private string recid;
        private int direct;
        private int runstatus;
        private int lineid2;
        private int busid2;
        private string caseid;
        private string drvnumber;
        private string linename;
        private string busnumber;
        private int runnumber;
        private string drvname;
        private string casename;
        private DateTime intime;
        private int indate;
        private DateTime outtime;
        private int outdate;
        private int stationid2;
        private int cmdType;

        /// <summary>
        /// 系统ID
        /// </summary>
        public string Recid
        {
            get { return recid; }
            set { recid = value; }
        }
        
        /// <summary>
        /// 方向（0-上行、1-下行）
        /// </summary>
        public int Direct
        {
            get { return direct; }
            set { direct = value; }
        }
        
        /// <summary>
        /// 运行状态（0-未发、2-正常发车、5-停站、7-过点未发）
        /// </summary>
        public int Runstatus
        {
            get { return runstatus; }
            set { runstatus = value; }
        }
        
        /// <summary>
        /// 线路ID
        /// </summary>
        public int Lineid2
        {
            get { return lineid2; }
            set { lineid2 = value; }
        }
        
        /// <summary>
        /// 车辆ID
        /// </summary>
        public int Busid2
        {
            get { return busid2; }
            set { busid2 = value; }
        }
        
        /// <summary>
        /// 区间ID
        /// </summary>
        public string Caseid
        {
            get { return caseid; }
            set { caseid = value; }
        }
        
        /// <summary>
        /// 驾驶员工号
        /// </summary>
        public string Drvnumber
        {
            get { return drvnumber; }
            set { drvnumber = value; }
        }
        
        /// <summary>
        /// 线路名称
        /// </summary>
        public string Linename
        {
            get { return linename; }
            set { linename = value; }
        }
        
        /// <summary>
        /// 车辆编号
        /// </summary>
        public string Busnumber
        {
            get { return busnumber; }
            set { busnumber = value; }
        }
        
        /// <summary>
        /// 路牌号
        /// </summary>
        public int Runnumber
        {
            get { return runnumber; }
            set { runnumber = value; }
        }
        
        /// <summary>
        /// 驾驶员姓名
        /// </summary>
        public string Drvname
        {
            get { return drvname; }
            set { drvname = value; }
        }
        
        /// <summary>
        /// 区间名称
        /// </summary>
        public string Casename
        {
            get { return casename; }
            set { casename = value; }
        }
        
        /// <summary>
        /// 进站时间
        /// </summary>
        public DateTime Intime
        {
            get { return intime; }
            set { intime = value; }
        }
        
        /// <summary>
        /// 进站日期（0-当日、1-次日）
        /// </summary>
        public int Indate
        {
            get { return indate; }
            set { indate = value; }
        }
        
        /// <summary>
        /// 发车时间（计划）
        /// </summary>
        public DateTime Outtime
        {
            get { return outtime; }
            set { outtime = value; }
        }
        
        /// <summary>
        /// 发车日期（0-当日、1-次日）
        /// </summary>
        public int Outdate
        {
            get { return outdate; }
            set { outdate = value; }
        }
        
        /// <summary>
        /// 状态图标
        /// </summary>
        public Bitmap ImgStatus
        {
            get
            {
                if (runstatus == 2)
                {
                    int tmrDiff = CVar.TimeDiff(DateTime.Now, outtime);

                    if (tmrDiff <= 0)
                    {
                        return Properties.Resources.wait2;
                    }
                    else if (tmrDiff <=2)
                    {
                        return Properties.Resources.wait3;
                    }
                    else
                    {
                        return Properties.Resources.wait;
                    }
                }
                else
                {
                    return Properties.Resources.stop;
                }
            }
        }
        
        /// <summary>
        /// 站点ID
        /// </summary>
        public int Stationid2
        {
            get { return stationid2; }
            set { stationid2 = value; }
        }

        /// <summary>
        /// 已发送的调度指令
        /// </summary>
        public int CmdType
        {
            get { return cmdType; }
            set { cmdType = value; }
        }

        /// <summary>
        /// 界面显示用进站时间
        /// </summary>
        public String Display_InTime
        {
            get
            {
                return intime.ToString("HH:mm");
            }
        }

        /// <summary>
        /// 界面显示发出时间
        /// </summary>
        public String Display_OutTime
        {
            get
            {
                if (runstatus == 2)
                {
                    return outtime.ToString("HH:mm");
                }
                else
                {
                    return "--";
                }
            }
        }
    }
}
