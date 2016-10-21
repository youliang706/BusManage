namespace BusManage
{
    class BusInfo
    {
        private int lineid2;
        private string busid;
        private int busid2;
        private string busnumber;
        private string platenumber;

        /// <summary>
        /// 线路ID
        /// </summary>
        public int Lineid2
        {
            get { return lineid2; }
            set { lineid2 = value; }
        }
        
        /// <summary>
        /// 车辆ID（后台）
        /// </summary>
        public string Busid
        {
            get { return busid; }
            set { busid = value; }
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
        /// 车辆编号
        /// </summary>
        public string Busnumber
        {
            get { return busnumber; }
            set { busnumber = value; }
        }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string Platenumber
        {
            get { return platenumber; }
            set { platenumber = value; }
        }

        public override string ToString()
        {
            return busnumber;
        }
    }
}
