namespace BusManage
{
    public class DrvInfo
    {
        private int lineid2;
        private string drvid;
        private string drvnumber;
        private string drvname;

        /// <summary>
        /// 线路ID
        /// </summary>
        public int Lineid2
        {
            get { return lineid2; }
            set { lineid2 = value; }
        }
        
        /// <summary>
        /// 驾驶员ID（后台）
        /// </summary>
        public string Drvid
        {
            get { return drvid; }
            set { drvid = value; }
        }
        
        /// <summary>
        /// 驾驶员工号（ID）
        /// </summary>
        public string Drvnumber
        {
            get { return drvnumber; }
            set { drvnumber = value; }
        }
        
        /// <summary>
        /// 驾驶员姓名
        /// </summary>
        public string Drvname
        {
            get { return drvname; }
            set { drvname = value; }
        }

        public override string ToString()
        {
            return drvname;
        }
    }
}
