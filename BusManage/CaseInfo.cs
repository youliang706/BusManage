using System;

namespace BusManage
{
    class CaseInfo
    {
        private int lineid2;
        private string caseid;
        private string casename;
        private double uplength;
        private double downlength;
        private int countway;
        private DateTime breakpoint;
        private int isdefault;
        private int up_s_stationid;
        private int up_e_stationid;
        private int dn_s_stationid;
        private int dn_e_stationid;
        private int up_stationnum;
        private int dn_stationnum;
        private int linetype;

        /// <summary>
        /// 线路ID
        /// </summary>
        public int Lineid2
        {
            get { return lineid2; }
            set { lineid2 = value; }
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
        /// 区间名称
        /// </summary>
        public string Casename
        {
            get { return casename; }
            set { casename = value; }
        }
        
        /// <summary>
        /// 上行线路长度
        /// </summary>
        public double Uplength
        {
            get { return uplength; }
            set { uplength = value; }
        }
        
        /// <summary>
        /// 下行线路长度
        /// </summary>
        public double Downlength
        {
            get { return downlength; }
            set { downlength = value; }
        }
        
        /// <summary>
        /// 趟次统计方式
        /// </summary>
        public int Countway
        {
            get { return countway; }
            set { countway = value; }
        }
        
        /// <summary>
        /// 时间分割点
        /// </summary>
        public DateTime Breakpoint
        {
            get { return breakpoint; }
            set { breakpoint = value; }
        }
        
        /// <summary>
        /// 默认区间线
        /// </summary>
        public int Isdefault
        {
            get { return isdefault; }
            set { isdefault = value; }
        }
        
        /// <summary>
        /// 上行起点站ID
        /// </summary>
        public int Up_s_stationid
        {
            get { return up_s_stationid; }
            set { up_s_stationid = value; }
        }
        
        /// <summary>
        /// 上行终点站ID
        /// </summary>
        public int Up_e_stationid
        {
            get { return up_e_stationid; }
            set { up_e_stationid = value; }
        }
        
        /// <summary>
        /// 下行起点站ID
        /// </summary>
        public int Dn_s_stationid
        {
            get { return dn_s_stationid; }
            set { dn_s_stationid = value; }
        }
        
        /// <summary>
        /// 下行终点站ID
        /// </summary>
        public int Dn_e_stationid
        {
            get { return dn_e_stationid; }
            set { dn_e_stationid = value; }
        }
        
        /// <summary>
        /// 上行站点数
        /// </summary>
        public int Up_stationnum
        {
            get { return up_stationnum; }
            set { up_stationnum = value; }
        }
        
        /// <summary>
        /// 下行站点数
        /// </summary>
        public int Dn_stationnum
        {
            get { return dn_stationnum; }
            set { dn_stationnum = value; }
        }
        
        /// <summary>
        /// 线路类型（0-上下行、1-上行环线、2-下行环线）
        /// </summary>
        public int Linetype
        {
            get { return linetype; }
            set { linetype = value; }
        }

        public override string ToString()
        {
            return casename;
        }
    }
}
