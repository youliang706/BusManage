using System.Collections.Generic;

namespace BusManage
{
    class LineInfo
    {
        private string lineid;
        private int lineid2;
        private string linename;

        Dictionary<string, BusInfo> buses = new Dictionary<string,BusInfo>();
        Dictionary<string, DrvInfo> drivers = new Dictionary<string,DrvInfo>();
        Dictionary<string, CaseInfo> cases = new Dictionary<string,CaseInfo>();

        /// <summary>
        /// 线路ID（后台）
        /// </summary>
        public string Lineid
        {
            get { return lineid; }
            set { lineid = value; }
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
        /// 线路名称
        /// </summary>
        public string Linename
        {
            get { return linename; }
            set { linename = value; }
        }

        /// <summary>
        /// 线路车辆
        /// </summary>
        internal Dictionary<string, BusInfo> Buses
        {
            get { return buses; }
            set { buses = value; }
        }

        /// <summary>
        /// 线路驾驶员
        /// </summary>
        internal Dictionary<string, DrvInfo> Drivers
        {
            get { return drivers; }
            set { drivers = value; }
        }

        /// <summary>
        /// 线路区间
        /// </summary>
        internal Dictionary<string, CaseInfo> Cases
        {
            get { return cases; }
            set { cases = value; }
        }

        public override string ToString()
        {
            return linename;
        }
    }
}
