using System;
using System.Drawing;

namespace BusManage
{
    class SchInfo
    {
        private string recid;
        private int lineid2;
        private int busid2;
        private string caseid;
        private string drvnumber;
        private string busnumber;
        private int runnumber;
        private string drvname;
        private string casename;
        private DateTime plan_starttime;
        private DateTime plan_arrivetime;
        private Nullable<DateTime> starttime;
        private Nullable<DateTime> arrivetime;
        private int direct;
        private int status;

        /// <summary>
        /// 系统ID
        /// </summary>
        public string Recid
        {
            get { return recid; }
            set { recid = value; }
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
        /// 计划发车时间
        /// </summary>
        public DateTime Plan_starttime
        {
            get { return plan_starttime; }
            set { plan_starttime = value; }
        }

        /// <summary>
        /// 计划到达时间
        /// </summary>
        public DateTime Plan_arrivetime
        {
            get { return plan_arrivetime; }
            set { plan_arrivetime = value; }
        }

        /// <summary>
        /// 实际发车时间
        /// </summary>
        public Nullable<DateTime> Starttime
        {
            get { return (Nullable<DateTime>)starttime; }
            set { starttime = value; }
        }

        /// <summary>
        /// 实际到达时间
        /// </summary>
        public Nullable<DateTime> Arrivetime
        {
            get { return (Nullable<DateTime>)arrivetime; }
            set { arrivetime = value; }
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
        /// 状态标记（-1-预定跳点、0-未占用、1-占用、2-过时未发、3-完成）
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// 界面发车时间
        /// </summary>
        public String Display_StartTime
        {
            get
            {
                if (starttime == null)
                {
                    return plan_starttime.ToString("HH:mm");
                }
                else
                {
                    return ((DateTime)starttime).ToString("HH:mm");
                }
            }
        }

        /// <summary>
        /// 界面到达时间
        /// </summary>
        public String Display_ArriveTime
        {
            get
            {
                if (arrivetime == null)
                {
                    return plan_arrivetime.ToString("HH:mm");
                }
                else
                {
                    return ((DateTime)arrivetime).ToString("HH:mm");
                }
            }
        }

        /// <summary>
        /// 界面发车时间颜色
        /// </summary>
        public Color Color_StartTime
        {
            get
            {
                if (status == -1 || status == 2)
                {
                    return Color.FromArgb(163, 21, 21);
                }
                else if (status == 1 || status == 3)
                {
                    if (starttime != null)
                    {
                        return Color.Blue;
                    }
                }
                else
                {
                    QueueInfo qi = CVar.SngQueue(recid);
                    if (qi != null)
                    {
                        return Color.FromArgb(43, 145, 175);
                    }
                }

                return Color.FromArgb(32, 31, 53);
            }
        }

        /// <summary>
        /// 界面到达时间颜色
        /// </summary>
        public Color Color_ArriveTime
        {
            get
            {
                if (status == -1 || status == 2)
                {
                    return Color.FromArgb(163, 21, 21);
                }

                if (arrivetime == null)
                {
                    return Color.FromArgb(32, 31, 53);
                }
                else
                {
                    return Color.Blue;
                }
            }
        }

        /// <summary>
        /// 行标记颜色
        /// </summary>
        public Color Color_Status
        {
            get
            {
                if (status == -1 || status == 2)
                {
                    return Color.FromArgb(249, 227, 53);
                }
                else if (status == 1 || status == 3)
                {
                    return Color.FromArgb(0, 192, 241);
                }
                else
                {
                    QueueInfo qi = CVar.SngQueue(recid);
                    if (qi != null)
                    {
                        return Color.FromArgb(103, 235, 214);
                    }
                    else
                    {
                        return Color.FromArgb(101, 111, 209);
                    }
                }
            }
        }
    }
}
