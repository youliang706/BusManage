using BusManage.Properties;
using Com.Database;
using Com.SubClass;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace BusManage
{
    public partial class frmMain : Form
    {
        public const int Direct_Up = 0;
        public const int Direct_Dn = 1;

        public const int RunStatus_WaitSend = 2;
        public const int RunStatus_StopRun = 5;

        public const int SchStatus_CrossPoint = -1;
        public const int SchStatus_Init = 0;
        public const int SchStatus_Normal = 1;
        public const int SchStatus_OverTime = 2;
        public const int SchStatus_Complete = 3;

        CSocket sck = Program.sck;
        CDatabase db = Program.db;

        private object tmrLock = new object();

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));

        //时刻表列
        private GridColumn[] colS_ID = new GridColumn[2];
        private GridColumn[] colS_No = new GridColumn[2];
        private GridColumn[] colS_Busno = new GridColumn[2];
        private GridColumn[] colS_Runno = new GridColumn[2];
        private GridColumn[] colS_Drv = new GridColumn[2];
        private GridColumn[] colS_Case = new GridColumn[2];
        private GridColumn[] colS_StartTime = new GridColumn[2];
        private GridColumn[] colS_ArriveTime = new GridColumn[2];
        private GridColumn[] colS_Opr = new GridColumn[2];
        private GridColumn[] colS_Status = new GridColumn[2];
        private GridColumn[] colS_ColorStatus = new GridColumn[2];

        //车辆队列列
        private GridColumn[] colQ_ID = new GridColumn[2];
        private GridColumn[] colQ_Line = new GridColumn[2];
        private GridColumn[] colQ_Busno = new GridColumn[2];
        private GridColumn[] colQ_Runno = new GridColumn[2];
        private GridColumn[] colQ_Drv = new GridColumn[2];
        private GridColumn[] colQ_Case = new GridColumn[2];
        private GridColumn[] colQ_InTime = new GridColumn[2];
        private GridColumn[] colQ_OutTime = new GridColumn[2];
        private GridColumn[] colQ_Status = new GridColumn[2];
        private GridColumn[] colQ_RunStatus = new GridColumn[2];
        private GridColumn[] colQ_ImgStatus = new GridColumn[2];

        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            //注册Socket类的事件    
            sck.GetDccMsg += new GetDataEvent(GetDccMsg);
            sck.DccConnecting += new ConnectingEvevt(DccConnecting);
            sck.DccBreak += new ConnectingEvevt(DccBroken);

            tniRepair.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(tniRepair_ElementClick);
            tniReport.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(tniReport_ElementClick);
            tniOprRecord.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(tniOprRecord_ElementClick);
            tniUnOprRecord.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(tniUnOprRecord_ElementClick);
            tniSchedule.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(tniSchedule_ElementClick);
            tniBusDrivers.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(tniBusDrivers_ElementClick);

            tniMapMonitor.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(tniMapMonitor_ElementClick);
            tniLineGraph.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(tniLineGraph_ElementClick);
            tniPlayBack.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(tniPlayBack_ElementClick);

            this.Width = 1200;
            this.Height = 640;

            InitUcl();
            InitCbo();
            FillQueue(0);
            FillQueue(1);

            if (!CVar.QueryMode)
            {
                tmrQueue.Interval = 5 * 1000;   //5秒轮询一次
            }
            tmrLsnr.Interval = 30 * 1000;

            this.Show();
            EventArgs e = new EventArgs();
            this.OnResize(e);
        }

        /// <summary>
        /// 当前线路ID
        /// </summary>
        private int CurLineID
        {
            get 
            {
                LineInfo li = (LineInfo)cboLine.SelectedItem;
                if (li != null)
                {
                    return li.Lineid2;
                }
                else
                {
                    return 0;
                }
            }
        }

        private int CurDirect
        {
            get
            {
                return tabList.SelectedTabPageIndex == 0 ? Direct_Up : Direct_Dn;
            }
        }

        /// <summary>
        /// 初始化时刻表列表
        /// </summary>
        /// <param name="updown"></param>
        private void InitFlx_Sch(int updown)
        {
            GridView dgv = updown == Direct_Up ? dgvUp_Sch : dgvDn_Sch;

            colS_ID[updown] = CSubClass.CreateColumn("Recid", "系统ID", 0, 0);
            colS_No[updown] = CSubClass.CreateColumn("No", " ", 0, 40, HorzAlignment.Center);
            colS_Busno[updown] = CSubClass.CreateColumn("Busnumber", "车号", 1, 100);
            colS_Runno[updown] = CSubClass.CreateColumn("Runnumber", "班次", 2, 60, HorzAlignment.Center);
            colS_Drv[updown] = CSubClass.CreateColumn("Drvname", "驾驶员", 3, 100);
            colS_Case[updown] = CSubClass.CreateColumn("Casename", "区间", 4, 120);
            colS_StartTime[updown] = CSubClass.CreateColumn("Display_StartTime", "发车时间", 5, 100, HorzAlignment.Center);
            colS_ArriveTime[updown] = CSubClass.CreateColumn("Display_ArriveTime", "到达时间", 6, 100, HorzAlignment.Center);
            colS_Status[updown] = CSubClass.CreateColumn("Status", "状态", 7, 0);

            CreateButtonColumn(updown);
            colS_Opr[updown].VisibleIndex = 8;

            colS_ColorStatus[updown] = CSubClass.CreateColumn("ColorStatus", " ", 9, 1);
            colS_ColorStatus[updown].Fixed = FixedStyle.Right;
            colS_ColorStatus[updown].OptionsColumn.AllowSize = false;
            colS_ColorStatus[updown].OptionsColumn.FixedWidth = true;
            colS_ColorStatus[updown].MaxWidth = 1;
            colS_ColorStatus[updown].MinWidth = 1;
            colS_ColorStatus[updown].OptionsColumn.ShowCaption = false;

            dgv.Columns.AddRange(new GridColumn[] {
                colS_ID[updown], colS_No[updown], colS_Busno[updown], colS_Runno[updown], colS_Drv[updown], colS_Case[updown],
                colS_StartTime[updown], colS_ArriveTime[updown], colS_Opr[updown], colS_Status[updown], colS_ColorStatus[updown]
            });

            colS_ID[updown].Visible = false;
            colS_Status[updown].Visible = false;

            dgv.OptionsBehavior.Editable = true;
            foreach (GridColumn c in dgv.Columns)
            {
                c.OptionsColumn.AllowEdit = c.ColumnEdit is RepositoryItemButtonEdit;
                c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                c.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                c.AppearanceCell.TextOptions.HAlignment = c.AppearanceCell.HAlignment;
            }

            dgv.OptionsSelection.MultiSelect = true;
            dgv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            dgv.OptionsSelection.InvertSelection = false;
            dgv.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        private void CreateButtonColumn(int updown)
        {
            GridView dgv = updown == Direct_Up ? dgvUp_Sch : dgvDn_Sch;

            RepositoryItemButtonEdit riButtonEdit = CSubClass.CreateOprColumn(new ExColumn[] { 
                new ExColumn("edit","", Properties.Resources.Edit)
            });
            riButtonEdit.Buttons[0].ImageLocation = ImageLocation.MiddleCenter;
            riButtonEdit.ButtonClick += new ButtonPressedEventHandler(riButtonEdit_ButtonClick);

            colS_Opr[updown] = new GridColumn();
            colS_Opr[updown].Caption = " ";
            colS_Opr[updown].FieldName = "operate";
            colS_Opr[updown].Fixed = FixedStyle.Right;
            colS_Opr[updown].Width = 40;
            colS_Opr[updown].Visible = true;
            colS_Opr[updown].UnboundType = DevExpress.Data.UnboundColumnType.String;
            colS_Opr[updown].ColumnEdit = riButtonEdit;
            colS_Opr[updown].OptionsColumn.AllowSize = false;
            dgv.GridControl.RepositoryItems.Add(riButtonEdit);
        }

        private void riButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            GridView dgv = CurDirect == Direct_Up ? dgvUp_Sch : dgvDn_Sch;

            int RowIndex = dgv.FocusedRowHandle;      //获取当前行的index
            DataRow row = dgv.GetDataRow(RowIndex);   //获取当前行   

            if (e.Button.Tag.ToString() == "edit")
            {
                Sch_Modify(CurDirect);
            }
        }

        /// <summary>
        /// 初始化排队列表
        /// </summary>
        /// <param name="dgv"></param>
        private void InitFlx(int updown)
        {
            GridView dgv = updown == Direct_Up ? dgvUp : dgvDn;
            dgv.RowHeight = 32;

            colQ_ID[updown] = CSubClass.CreateColumn("Recid", "系统ID", 0, 0);
            colQ_Line[updown] = CSubClass.CreateColumn("Linename", "线路", 1, 100);
            colQ_Busno[updown] = CSubClass.CreateColumn("Busnumber", "车号", 2, 100);
            colQ_Runno[updown] = CSubClass.CreateColumn("Runnumber", "班次", 3, 60, HorzAlignment.Center);
            colQ_Drv[updown] = CSubClass.CreateColumn("Drvname", "驾驶员", 4, 100);
            colQ_Case[updown] = CSubClass.CreateColumn("Casename", "区间", 5, 120);
            colQ_InTime[updown] = CSubClass.CreateColumn("Display_InTime", "进站时间", 6, 100, HorzAlignment.Center);
            colQ_OutTime[updown] = CSubClass.CreateColumn("Display_OutTime", "发车时间", 7, 100, HorzAlignment.Center);
            colQ_Status[updown] = CSubClass.CreateColumn("Status", "状态", 8, 0);
            colQ_RunStatus[updown] = CSubClass.CreateColumn("Runstatus", " ", 9, 0);

            colQ_ImgStatus[updown] = CSubClass.CreateColumn("ImgStatus", " ", 10, 40);
            colQ_ImgStatus[updown].Fixed = FixedStyle.Right;
            colQ_ImgStatus[updown].OptionsColumn.AllowSize = false;
            colQ_ImgStatus[updown].OptionsColumn.FixedWidth = true;
            colQ_ImgStatus[updown].MaxWidth = 40;
            colQ_ImgStatus[updown].MinWidth = 40;
            colQ_ImgStatus[updown].OptionsColumn.ShowCaption = false;
            colQ_ImgStatus[updown].ColumnEdit = new RepositoryItemPictureEdit();
            colQ_ImgStatus[updown].UnboundType = DevExpress.Data.UnboundColumnType.Object;

            dgv.Columns.AddRange(new GridColumn[] {
                colQ_ID[updown], colQ_Line[updown], colQ_Busno[updown], colQ_Runno[updown],
                colQ_Drv[updown], colQ_Case[updown], colQ_InTime[updown], colQ_OutTime[updown], colQ_Status[updown], colQ_RunStatus[updown], colQ_ImgStatus[updown]
            });

            colQ_ID[updown].Visible = false;
            colQ_Status[updown].Visible = false;
            colQ_RunStatus[updown].Visible = false;
            colQ_InTime[updown].Visible = false;

            foreach (GridColumn c in dgv.Columns)
            {
                c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                c.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                c.AppearanceCell.TextOptions.HAlignment = c.AppearanceCell.HAlignment;
            }
        }

        /// <summary>
        /// 初始化线路选择框
        /// </summary>
        private void InitCbo()
        {
            cboLine.Items.Clear();

            foreach(var li in CVar.Lines)
            {
                cboLine.Items.Add(li.Value);
            }

            if (cboLine.Items.Count > 0)
            {
                cboLine.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 填写发车点
        /// </summary>
        private void InitList(int lineid2, int updown)
        {
            RefreshRate();

            if (lineid2 != CurLineID)
            { return; }
            if (updown != CurDirect)
            { return; }

            GridView dgv = updown == Direct_Up ? dgvUp_Sch : dgvDn_Sch;

            int rowIndex = -1;
            int toprow = -1;
            int[] selectRows = dgv.GetSelectedRows();

            if (dgv.RowCount > 0)
            {
                rowIndex = dgv.FocusedRowHandle;      //获取当前行的index
                toprow = dgv.TopRowIndex;
            }

            List<SchInfo> sch = CVar.Line_Sch(lineid2, updown);

            //dgv.BeginDataUpdate();
            dgv.GridControl.DataSource = sch;
            dgv.GridControl.RefreshDataSource();
            //dgv.EndDataUpdate();

            dgv.ClearSelection();
            for (int i = 0; i < selectRows.Length; i++)
            {
                dgv.SelectRow(selectRows[i]);
            }
            if (toprow >= 0) dgv.TopRowIndex = toprow;
            if (rowIndex >= 0) dgv.FocusedRowHandle = rowIndex;
        }

        /// <summary>
        /// 填写排队队列
        /// </summary>
        /// <param name="updown"></param>
        private void FillQueue(int updown)
        {
            GridView dgv = updown == Direct_Up ? dgvUp : dgvDn;

            List<QueueInfo> queue = CVar.Line_Queue(updown);

            //dgv.BeginDataUpdate();
            dgv.GridControl.DataSource = queue;
            dgv.GridControl.RefreshDataSource();
            //dgv.EndDataUpdate();

            if (updown == Direct_Up)
            {
                lblUpQueue.Text = "上行队列（" + queue.Count.ToString() + "）";
            }
            else
            {
                lblDnQueue.Text = "下行队列（" + queue.Count.ToString() + "）";
            }
        }

        /// <summary>
        /// 新增时刻点
        /// </summary>
        /// /// <param name="updown"></param>
        private void Sch_Add(int updown)
        {
            frmSchEdit frm = new frmSchEdit(CurLineID, updown);
            frm.DataChanged += new DataChangedEvevt(AddSch);
            frm.ShowDialog();
        }

        private void AddSch(EditMode editType, object obj)
        {
            GridView dgv = CurDirect == Direct_Up ? dgvUp_Sch : dgvDn_Sch;

            string recid = (string)obj;

            InitList(CurLineID, CurDirect);
            dgv.FocusedRowHandle = dgv.LocateByValue(0, dgv.Columns["Recid"], recid);

            SchInfo si = CVar.SngSch(recid);
            DebugDcc(si.Lineid2, si.Busid2, "新增发车点（" + si.Plan_starttime + "）");
        }

        /// <summary>
        /// 修改时刻点
        /// </summary>
        /// /// <param name="updown"></param>
        private void Sch_Modify(int updown)
        {
            GridView dgv = updown == Direct_Up ? dgvUp_Sch : dgvDn_Sch;

            int RowIndex = dgv.FocusedRowHandle;      //获取当前行的index
            string recid = dgv.GetRowCellValue(RowIndex, "Recid").ToString();

            switch (int.Parse(dgv.GetRowCellValue(RowIndex, "Status").ToString()))
            {
                case SchStatus_OverTime:
                    MessageBox.Show("已过期的发车点，禁止修改。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                case SchStatus_Normal:
                    QueueInfo qi = CVar.SngQueue(recid);
                    if (qi == null)
                    {
                        MessageBox.Show("已完成的发车点，禁止修改。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    break;
            }

            frmSchEdit frm = new frmSchEdit(CurLineID, updown, recid);
            frm.DataChanged += new DataChangedEvevt(ModifySch);
            frm.ShowDialog();
        }

        private void ModifySch(EditMode editType, object obj)
        {
            GridView dgv = CurDirect == Direct_Up ? dgvUp_Sch : dgvDn_Sch;

            string recid = (string)obj;

            InitList(CurLineID, CurDirect);
            dgv.FocusedRowHandle = dgv.LocateByValue(0, dgv.Columns["Recid"], recid);

            QueueInfo qi = CVar.SngQueue(recid);
            if (qi != null)
            {
                FillQueue(qi.Direct);
            }

            SchInfo si = CVar.SngSch(recid);
            DebugDcc(si.Lineid2, si.Busid2, "修改发车点（" + si.Plan_starttime + "）");
        }

        /// <summary>
        /// 删除时刻点
        /// </summary>
        /// /// <param name="updown"></param>
        private void Sch_Delete(int updown)
        {
            GridView dgv = updown == Direct_Up ? dgvUp_Sch : dgvDn_Sch;
            bool inQueue = false;   //处理对象是否在排队队列中

            if (CVar.QueryMode)
            {
                MessageBox.Show("浏览模式下禁止操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("确定删除发车点？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int[] rowHandles = dgv.GetSelectedRows();

                for (int i = 0; i < rowHandles.Length; i++)
                {
                    string recid = dgv.GetRowCellValue(rowHandles[i], "Recid").ToString();

                    if (DeleteData(recid))
                    {
                        SchInfo si = CVar.SngSch(recid);

                        //从记录集中移除
                        DebugDcc(si.Lineid2, si.Busid2, "删除发车点（" + si.Plan_starttime + "）");
                        CVar.Sch.Remove(si);

                        if (!inQueue)
                        {
                            QueueInfo qi = CVar.SngQueue(recid);
                            if (qi != null)
                            {
                                inQueue = true;
                            }
                        }
                    }
                }

                //刷新界面显示
                InitList(CurLineID, updown);

                if (inQueue)
                {
                    FillQueue(updown);
                }
            }
        }

        /// <summary>
        /// 批量调整发车点
        /// </summary>
        /// /// <param name="updown"></param>
        private void Sch_TmrChange(int updown)
        {
            GridView dgv = updown == Direct_Up ? dgvUp_Sch : dgvDn_Sch;
            bool inQueue = false;

            if (CVar.QueryMode)
            {
                MessageBox.Show("浏览模式下禁止操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmTmrChange frm = new frmTmrChange();
            int tmrInterval = 0;
            bool ret = frm.ShowMe(ref tmrInterval);

            if (ret)
            {
                int[] rowHandles = dgv.GetSelectedRows();

                for (int i = 0; i < rowHandles.Length; i++)
                {
                    string recid = dgv.GetRowCellValue(rowHandles[i], "Recid").ToString();

                    SchInfo si = CVar.SngSch(recid);
                    si.Plan_starttime = CVar.TimeAdd(tmrInterval, si.Plan_starttime);
                    si.Plan_arrivetime = CVar.TimeAdd(tmrInterval, si.Plan_arrivetime);

                    UpdateTmr(si);

                    DebugDcc(si.Lineid2, si.Busid2, "批量调整发车点（" + si.Plan_starttime + "）");

                    if (!inQueue)
                    {
                        QueueInfo qi = CVar.SngQueue(recid);
                        if (qi != null)
                        {
                            inQueue = true;
                        }
                    }
                }

                //刷新界面显示
                InitList(CurLineID, updown);

                if (inQueue)
                {
                    FillQueue(updown);
                }
            }
        }

        /// <summary>
        /// 平均分割发车点
        /// </summary>
        /// /// <param name="updown"></param>
        private void Sch_TmrEqual(int updown)
        {
            GridView dgv = updown == Direct_Up ? dgvUp_Sch : dgvDn_Sch;
            bool inQueue = false;

            if (CVar.QueryMode)
            {
                MessageBox.Show("浏览模式下禁止操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int[] rowHandles = dgv.GetSelectedRows();

            SchInfo sib = CVar.SngSch(dgv.GetRowCellValue(rowHandles[0], "Recid").ToString());
            DateTime begTime = sib.Plan_starttime;

            SchInfo sie = CVar.SngSch(dgv.GetRowCellValue(rowHandles[rowHandles.Length - 1], "Recid").ToString());
            DateTime endTime = sie.Plan_starttime;

            double tmrInterval = (double)CVar.TimeDiff(begTime, endTime) / (dgv.SelectedRowsCount - 1);

            if (MessageBox.Show("是否按照" + Math.Round(tmrInterval,1) + "分钟间隔重新设置发车点？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 1; i < rowHandles.Length - 1; i++)
                {
                    string recid = dgv.GetRowCellValue(rowHandles[i], "Recid").ToString();

                    SchInfo si = CVar.SngSch(recid);

                    int intT = CVar.TimeDiff(si.Plan_starttime, CVar.TimeAdd((int)(i * tmrInterval), begTime));  //和计算值的差值
    
                    si.Plan_starttime = CVar.TimeAdd(intT, si.Plan_starttime);
                    si.Plan_arrivetime = CVar.TimeAdd(intT, si.Plan_arrivetime);

                    UpdateTmr(si);

                    DebugDcc(si.Lineid2, si.Busid2, "批量调整发车点（" + si.Plan_starttime + "）");

                    if (!inQueue)
                    {
                        QueueInfo qi = CVar.SngQueue(recid);
                        if (qi != null)
                        {
                            inQueue = true;
                        }
                    }
                }

                //刷新界面显示
                InitList(CurLineID, updown);

                if (inQueue)
                {
                    FillQueue(updown);
                }
            }
        }

        /// <summary>
        /// 对调发车点
        /// </summary>
        /// /// <param name="updown"></param>
        private void Sch_Swap(int updown)
        {
            GridView dgv = updown == Direct_Up ? dgvUp_Sch : dgvDn_Sch;
            bool inQueue = false;

            if (CVar.QueryMode)
            {
                MessageBox.Show("浏览模式下禁止操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int[] rowHandles = dgv.GetSelectedRows();

            SchInfo si1 = CVar.SngSch(dgv.GetRowCellValue(rowHandles[0], "Recid").ToString());
            DateTime startTime = si1.Plan_starttime;
            DateTime arriveTime = si1.Plan_arrivetime;

            SchInfo si2 = CVar.SngSch(dgv.GetRowCellValue(rowHandles[rowHandles.Length - 1], "Recid").ToString());

            si1.Plan_starttime = si2.Plan_starttime;
            si1.Plan_arrivetime = si2.Plan_arrivetime;
            si2.Plan_starttime = startTime;
            si2.Plan_arrivetime = arriveTime;

            UpdateTmr(si1);
            UpdateTmr(si2);

            DebugDcc(si1.Lineid2, si1.Busid2, "对调发车点（" + si1.Plan_starttime + "）");
            DebugDcc(si2.Lineid2, si2.Busid2, "对调发车点（" + si2.Plan_starttime + "）");

            QueueInfo qi = CVar.SngQueue(si1.Recid);
            if (qi != null)
            {
                inQueue = true;
            }
            else
            {
                qi = CVar.SngQueue(si2.Recid);
                if (qi != null)
                {
                    inQueue = true;
                }
            }
            
            //刷新界面显示
            InitList(CurLineID, updown);

            if (inQueue)
            {
                FillQueue(updown);
            }
        }

        /// <summary>
        /// 更换车辆
        /// </summary>
        /// /// <param name="updown"></param>
        private void Sch_ChangeBus(int updown)
        {
            GridView dgv = updown == Direct_Up ? dgvUp_Sch : dgvDn_Sch;

            if (CVar.QueryMode)
            {
                MessageBox.Show("浏览模式下禁止操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string recid = dgv.GetFocusedRowCellValue("Recid").ToString();
            SchInfo si = CVar.SngSch(recid);

            if (si != null)
            {
                frmBusChange frm = new frmBusChange(si.Lineid2, si.Busid2);
                frm.DataChanged += new DataChangedEvevt(ChangeBus);
                frm.ShowDialog();
            }
        }

        private void ChangeBus(EditMode editType, object obj)
        {
            DebugDcc(CurLineID, (int)obj, "修改车辆");

            InitList(CurLineID, CurDirect);
            FillQueue(Direct_Up);
            FillQueue(Direct_Dn);
        }

        /// <summary>
        /// 手工添加到队列
        /// </summary>
        /// /// <param name="updown"></param>
        private void Queue_Add(int updown)
        {
            if (CVar.QueryMode)
            {
                MessageBox.Show("浏览模式下禁止操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        /// <summary>
        /// 手工从队列中移除
        /// </summary>
        /// /// <param name="updown"></param>
        private void Queue_Remove(int updown)
        {
            if (CVar.QueryMode)
            {
                MessageBox.Show("浏览模式下禁止操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="recid"></param>
        /// <returns></returns>
        private bool DeleteData(string recid)
        {
            string sql;
            List<string> sqls = new List<string>();

            sql = "UPDATE TB_DRIVING_RECORDS SET SRCTYPE = 1, EDITSIGN = 2 "
                +"WHERE RECID = '" + recid + "'";
            sqls.Add(sql);

            sql = "DELETE TB_LOCAL_QUEUE WHERE RECID = '" + recid + "'";
            sqls.Add(sql);

            try
            {
                db.Execute(sqls);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改计划点（批量调整时间点）
        /// </summary>
        /// <param name="recid"></param>
        /// <returns></returns>
        private bool UpdateTmr(SchInfo si)
        {
            string sql;
            List<string> sqls = new List<string>();

            sql = "UPDATE TB_DRIVING_RECORDS SET "
                + "    PLAN_STARTTIME = " + CVar.TransTime(si.Plan_starttime) + ", plan_arrivetime = " + CVar.TransTime(si.Plan_arrivetime) + " "
                + "WHERE recid = '" + si.Recid + "'";
            sqls.Add(sql);

            sql = "UPDATE TB_LOCAL_QUEUE SET STARTTIME = " + CVar.TransTime(si.Plan_starttime) + " "
                + "WHERE RECID = '" + si.Recid + "'";
            sqls.Add(sql);

            try
            {
                db.Execute(sqls);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void DccConnecting()
        {
            tssStsatus.Image = ((System.Drawing.Image)(resources.GetObject("tssStsatus.Image")));
            tssStsatus.Text = "中心连接正常";

            if (DateTime.Now.Second < 30)
            { 
                CVar.CollectLog();
            }

            TmrToRec();
        }

        private void DccBroken()
        {
            tssStsatus.Image = ((System.Drawing.Image)(resources.GetObject("tssStsatus2.Image")));
            tssStsatus.Text = "中心连接断开";
        }

        private void GetDccMsg(int lineid, int busid, string drvnumber, int stationid, DateTime itime, string ssign, int direct, ref bool iscomp)
        {
            //处理相关数据
            try
            {
                if (direct != 0 && direct != 1)
                { return; }

                if (ssign == "enter")
                {
                    SavRecInStation(lineid, busid, drvnumber, stationid, itime, direct);
                }
                else if (ssign == "leave")
                {
                    SavRecOutStation(lineid, busid, drvnumber, stationid, itime, direct);
                }
            }
            finally
            {
                iscomp = true;
            }
        }

        /// <summary>
        /// 处理进站
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="busid2"></param>
        /// <param name="drvnumber"></param>
        /// <param name="stationid2"></param>
        /// <param name="itime"></param>
        /// <param name="direct"></param>
        private void SavRecInStation(int lineid2, int busid2, string drvnumber, int stationid2, DateTime itime, int direct, byte bytSav = 0)
        {
            DebugDcc(lineid2, busid2, "SavRecInStation(" + lineid2 + "," + busid2 + "," + drvnumber + "," + stationid2 + "," + itime + "," + direct + ")");

            string sql;

            //判断是否终点站进站
            if (!CVar.ChkOrigin_TerminalStation(lineid2, busid2, direct, stationid2, false))
            {
                DebugDcc(lineid2, busid2, "*非终点进站");
                return;
            }
            else
            {
                List<SchInfo> s = CVar.Sch.Where(info => info.Lineid2 == lineid2).Where(info => info.Busid2 == busid2).Where(info => info.Direct == direct).Where(info => info.Status != 0).ToList();
                
                if (s.Count == 0)
                {
                    //没有路单可更新
                    DebugDcc(lineid2, busid2, "没有发车路单可供更新");
                }
                else
                {
                    s.Sort(CVar.SortByDesc);
                    SchInfo si = s[0];

                    if (si.Arrivetime != null)
                    {
                        //车辆已进站
                        DebugDcc(lineid2, busid2, "发车路单已进站，进站时间为" + si.Arrivetime.ToString());
                    }
                    else
                    {
                        CaseInfo ci = CVar.Line_case(lineid2, si.Caseid);
                        
                        int audsign = 0;
                        string summary = "";

                        if (si.Starttime == null)
                        {
                            audsign = 0;
                            summary = "未能匹配发车；";

                            sql = "UPDATE TB_Driving_Records SET "
                                + "    arriveTime = " + CVar.TransTime(itime) + ", "
                                + "    opr_Mileage = 0, con_busTimes = 1, "
                                + "    audsign = " + audsign.ToString() + ", makeDate = SYSDATE, "
                                + "    summary = summary || '" + summary + (bytSav == 1 ? "(手工进站)" : (bytSav == 2 ? "(自动增补进站)" : "")) + "' "
                                + "WHERE recid = '" + si.Recid + "'";
                            db.Execute(sql);
                        }
                        else
                        {
                            if (Math.Abs(CVar.TimeDiff(si.Plan_starttime, (DateTime)si.Starttime)) > CVar.PassInterval)
                            {
                                audsign = 0;
                                summary = "实际发车与计划发车偏差过大；";
                            }
                            else
                            {
                                int stationnum = (direct == Direct_Up ? ci.Up_stationnum : ci.Dn_stationnum);
                                double plan_km = (direct == Direct_Up ? ci.Uplength : ci.Downlength);

                                int num = CVar.GetNotPassStations(lineid2, si.Caseid, direct, busid2, DateTime.Now, (DateTime)si.Starttime, itime);
                                double km = CVar.GetRealMileage(busid2, itime, (DateTime)si.Starttime, itime);

                                if (num / stationnum < (1 - CVar.PassStationRate))
                                {
                                    audsign = 1;
                                    summary = "站点通过率达标；";
                                }
                                else
                                {
                                    summary = "站点通过率未达标(" + num.ToString() + "站未获取进出站)；";

                                    if (plan_km != 0)
                                    {
                                        if (Math.Abs(km - plan_km) / plan_km < (1 - CVar.PassMileRate))
                                        {
                                            audsign = 1;
                                            summary = summary + "里程达标；";
                                        }
                                        else
                                        {
                                            audsign = 0;
                                            summary = summary + "里程未达标；";
                                        }
                                    }
                                }

                                int fastOrSlow = CVar.TimeDiff((DateTime)si.Starttime, itime) - CVar.TimeDiff(si.Plan_starttime, si.Plan_arrivetime);

                                sql = "UPDATE TB_Driving_Records SET " 
                                    + "    arriveTime = " + CVar.TransTime(itime) + ", run_Time = " + CVar.TimeDiff(si.Plan_starttime, itime) + ", " 
                                    + "    fastOrSlow = " + fastOrSlow.ToString() + ", opr_Mileage = " + km + ", con_busTimes = 1, " 
                                    + "    audsign = " + audsign.ToString() + ", makeDate = SYSDATE, "
                                    + "    summary = '" + summary + "' || summary || '" + (bytSav == 1 ? "(手工进站)" : (bytSav == 2 ? "(自动增补进站)" : "")) + "' " 
                                    + "WHERE recid = '" + si.Recid + "'";
                                db.Execute(sql);
                            }

                            //维护记录集
                            si.Arrivetime = itime;
                            si.Status = SchStatus_Complete;

                            //进站路单维护正常
                            DebugDcc(lineid2, busid2, "进站维护路单正常");
                        }
                    }
                }
            }

            //添加到队列
            QueueInfo qi = new QueueInfo();

            qi.Lineid2 = lineid2;
            qi.Busid2 = busid2;
            qi.Intime = itime;
            qi.Indate = 0;
            switch (CVar.GetLineType(lineid2))
            {
                case 1:
                    if (direct != Direct_Up)
                    {
                        DebugDcc(lineid2, busid2, "上行环线出现下行数据");
                        return;
                    }
                    qi.Direct = Direct_Up;
                    break;

                case 2:
                    if (direct != Direct_Dn)
                    {
                        DebugDcc(lineid2, busid2, "上行环线出现下行数据");
                        return;
                    }
                    qi.Direct = Direct_Dn;
                    break;

                default:
                    qi.Direct = direct == Direct_Up ? Direct_Dn : Direct_Up;
                    break;
            }
            qi.Stationid2 = stationid2;

            LineInfo li = CVar.SngLine(lineid2);
            qi.Linename = li.Linename;

retPoint:
            //计算趟次
            List<SchInfo> s2 = CVar.Sch.Where(info => info.Lineid2 == lineid2).Where(info => info.Busid2 == busid2).Where(info => info.Direct == qi.Direct).Where(info => info.Status <= 0).ToList();

            if (s2.Count != 0)
            {
                //有剩余趟次
                DebugDcc(lineid2, busid2, "有剩余趟次");

                s2.Sort(CVar.SortByAsc);
                SchInfo si = null;

                for (int i = 0; i < s2.Count; i++)
                {
                    si = s2[i];

                    if (CVar.TimeDiff(si.Plan_starttime, itime) > 30)   //30分钟之内进站，仍匹配
                    {
                        SavSkippedRec(si.Recid);   //记录"过点未发"

                        DebugDcc(lineid2, busid2, "发车点已过（" + si.Plan_starttime + "）,匹配下一发车点");

                        if (i == s2.Count - 1)
                        {
                            //趟次已用完
                            DebugDcc(lineid2, busid2, "能用发车点已全部跳过，进入停站");
                            goto retPoint;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                DebugDcc(lineid2, busid2, "匹配发车点(" + si.Plan_starttime + ")");

                qi.Recid = si.Recid;
                qi.Busnumber = si.Busnumber;
                qi.Caseid = si.Caseid;
                qi.Casename = si.Casename;
                qi.Runnumber = si.Runnumber;
                qi.Drvnumber = si.Drvnumber;
                qi.Drvname = si.Drvname;
                qi.Outtime = si.Plan_starttime;
                qi.Outdate = 0;
                qi.Runstatus = RunStatus_WaitSend;

                string strMsg = "运行区间：" + qi.Casename + "，发车时间：" + qi.Outtime.ToString("HH:mm") + "。";
                sck.SendMsg(lineid2, busid2, strMsg);
            }
            else
            {
                //车辆已完成当日趟次
                s2 = CVar.Sch.Where(info => info.Lineid2 == lineid2).Where(info => info.Busid2 == busid2).Where(info => info.Direct == qi.Direct).ToList();
                
                if (s2.Count != 0)
                {
                    //取当日最后计划点作为停站数据
                    DebugDcc(lineid2, busid2, "取当日最后计划点作为停站数据");

                    s2.Sort(CVar.SortByDesc);
                    SchInfo si = s2[0];

                    qi.Busnumber = si.Busnumber;
                    qi.Caseid = si.Caseid;
                    qi.Casename = si.Casename;
                    qi.Runnumber = si.Runnumber;
                    qi.Drvnumber = si.Drvnumber;
                    qi.Drvname = si.Drvname;
                }
                else
                {
                    DebugDcc(lineid2, busid2, "未取得计划点，使用默认区间作为停站数据");

                    BusInfo bi = CVar.Line_bus(lineid2, busid2);
                    qi.Busnumber = bi.Busnumber;

                    CaseInfo ci = CVar.Line_Defcase(lineid2);
                    qi.Caseid = ci.Caseid;
                    qi.Casename = ci.Casename;
                    qi.Runnumber = 0;
                    qi.Drvnumber = "";
                    qi.Drvname = "";
                }

                qi.Recid = CFunc.DBID();
                qi.Outtime = DateTime.Now;
                qi.Outdate = 0;
                qi.Runstatus = RunStatus_StopRun;            
            }

            //保存本地队列
            sql = "INSERT INTO tb_Local_Queue ( " 
                + "    RECID, DIRECT, LINEID2, BUSID2, RUNNUMBER, DRVNUMBER, CASEID, INTIME, INDATE, STARTTIME, STARTDATE, RUNSTATUS, STATIONID2 " 
                + ") VALUES ( " 
                + "    '" + qi.Recid + "', " + qi.Direct.ToString() + ", " + qi.Lineid2.ToString() + ", " + qi.Busid2.ToString() + ", " 
                + "    " + qi.Runnumber.ToString() + ", '" + qi.Drvnumber + "', '" + qi.Caseid + "', " + CVar.TransTime(qi.Intime).ToString() + ", " + qi.Indate.ToString() + ", " 
                + "    " + CVar.TransTime(qi.Outtime).ToString() + ", " + qi.Outdate.ToString() + ", " + qi.Runstatus.ToString() + ", " + qi.Stationid2.ToString() + " " 
                + ") ";
            db.Execute(sql);

            //维护记录集
            SchInfo sch = CVar.SngSch(qi.Recid);
            sch.Status = SchStatus_Normal;

            CVar.Queue.Add(qi);

            //维护界面
            FillQueue(qi.Direct);
            InitList(lineid2, qi.Direct);
        }

        /// <summary>
        /// 处理出站
        /// </summary>
        /// <param name="lineid2"></param>
        /// <param name="busid2"></param>
        /// <param name="drvnumber"></param>
        /// <param name="stationid2"></param>
        /// <param name="itime"></param>
        /// <param name="direct"></param>
        private void SavRecOutStation(int lineid2, int busid2, string drvnumber, int stationid2, DateTime itime, int direct, byte bytSav = 0)
        {
            DebugDcc(lineid2, busid2, "SavRecOutStation(" + lineid2 + "," + busid2 + "," + drvnumber + "," + stationid2 + "," + itime + "," + direct + ")");

            string sql;
rePoint:
            List<QueueInfo> q = CVar.Queue.Where(info => info.Lineid2 == lineid2).Where(info => info.Busid2 == busid2).ToList();
            
            if (q.Count != 0)
            { 
                if (CVar.ChkEndStation(lineid2, direct, stationid2))
                {
                    //忽略终点站出站
                    DebugDcc(lineid2, busid2, "终点站出站，忽略");
                    return;
                }

                QueueInfo qi = q[0];

                if (qi.Direct != direct)
                {
                    //出站方向与队列不符
                    DebugDcc(lineid2, busid2, "出站方向与队列不符，忽略");
                    return;
                }
                else
                {
                    if (Math.Abs(CVar.TimeDiff(qi.Outtime, itime)) > CVar.SaveInterval)
                    {
                        //计划发车与出站信号偏差太大
                        DebugDcc(lineid2, busid2, "计划发车与出站信号偏差太大（" + qi.Outtime + "），不记录路单，移除队列，释放发车点");

                        //释放发车点
                        SchInfo sch = CVar.SngSch(qi.Recid);
                        sch.Status = SchStatus_Init;
                    }
                    else
                    {
                        //正常出站
                        DebugDcc(lineid2, busid2, "正常出站");

                        sql = "UPDATE TB_Driving_Records SET "
                            + "    runstatus = 2, startTime = " + CVar.TransTime(itime) + ", makeDate = SYSDATE, " 
                            + "    summary = summary || '" + (bytSav == 1 ? "(手工出站)" : (bytSav == 2 ? "(自动增补出站)" : "")) + "' " 
                            + "WHERE recid = '" + qi.Recid + "'";
                        db.Execute(sql);

                        //维护记录集
                        SchInfo sch = CVar.SngSch(qi.Recid);
                        sch.Starttime = itime;
                        sch.Status = SchStatus_Normal;
                    }
                }

                //移除本地队列
                sql = "DELETE tb_Local_Queue WHERE RECID = '" + qi.Recid + "'";
                db.Execute(sql);

                CVar.Queue.Remove(qi);

                //维护界面
                FillQueue(direct);
                InitList(lineid2, direct);
            }
            else
            {
                List<SchInfo> s;

                if (!CVar.ChkOrigin_TerminalStation(lineid2, busid2, direct, stationid2, true))
                {
                    //非起点站出站
                    DebugDcc(lineid2, busid2, "*非起点出站");

                    //处理当前时间和gps时间的不一致
                    s = CVar.Sch.Where(info => info.Lineid2 == lineid2).Where(info => info.Busid2 == busid2).Where(info => info.Direct == direct).Where(info => info.Status == 0).ToList();
                    if (s.Count != 0)
                    {
                        s.Sort(CVar.SortByAsc);

                        for (int i = 0; i < s.Count; i++)
                        {
                            SchInfo si = s[i];
                            if (CVar.TimeDiff(si.Plan_starttime, itime) > 0)
                            {
                                //判断已过的时间点，跳点
                                DebugDcc(lineid2, busid2, "判断已过的时间点，跳点（" + si.Plan_starttime + "）");

                                sql = "UPDATE TB_Driving_Records SET runstatus = 7 WHERE recid = '" + si.Recid + "'";
                                db.Execute(sql);

                                si.Status = SchStatus_CrossPoint;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    //判断增补
                    s = CVar.Sch.Where(info => info.Lineid2 == lineid2).Where(info => info.Busid2 == busid2).Where(info => info.Direct == direct).Where(info => info.Status != 0).ToList();
                        
                    if (s.Count != 0)
                    {
                        s.Sort(CVar.SortByDesc);
                        SchInfo si = s[0];

                        if (si.Starttime == null)
                        {
                            if (Math.Abs(CVar.TimeDiff(si.Plan_starttime, itime)) > CVar.SaveInterval)
                            {
                                //缺少首站出站
                                DebugDcc(lineid2, busid2, "缺少首站出站，但时间和计划不符（" + si.Plan_starttime + "），忽略");
                            }
                            else
                            {
                                int outstationid = CVar.GetOutStationID(lineid2, si.Caseid, direct);
                                DateTime outtime = CVar.GetNearOutTime(lineid2, si.Caseid, busid2, direct, outstationid, itime);

                                //缺少首站出站，增补出站
                                DebugDcc(lineid2, busid2, "缺少首站出站，增补出站（" + outtime + "）");

                                SavRecOutStation(lineid2, busid2, drvnumber, outstationid, outtime, direct, 2);
                            }
                        }
                    }

                    return;
                }

                DebugDcc(lineid2, busid2, "出站车辆在不在队列中，判断上张路单");

                int direction;
                switch (CVar.GetLineType(lineid2))
                {
                    case 1:
                        direction = Direct_Dn;
                        break;

                    case 2:
                        direction = Direct_Dn;
                        break;

                    default:
                        direction = direct == Direct_Up ? Direct_Dn : Direct_Up;
                        break;
                }

                //上张路单的状态
                int instationid;
                DateTime intime;

                s = CVar.Sch.Where(info => info.Lineid2 == lineid2).Where(info => info.Busid2 == busid2).Where(info => info.Direct == direction).Where(info => info.Status != 0).ToList();
                if (s.Count != 0)
                {
                    s.Sort(CVar.SortByDesc);
                    SchInfo si = s[0];

                    instationid = CVar.GetInStationID(lineid2, si.Caseid, si.Direct);
                    intime = CVar.GetNearInTime(lineid2, busid2, si.Direct, instationid, itime);

                    if (si.Arrivetime == null)
                    {
                        //上张路单未进站
                        DebugDcc(lineid2, busid2, "上张路单未进站，增补进站（" + intime + "）");
                    }
                    else
                    {
                        //上张路单已进站但不在队列中
                        DebugDcc(lineid2, busid2, "上张路单已进站但不在队列中，增补进站（" + intime + "）");
                    }
                }
                else
                {
                    //当日没有路单，增补进站
                    s = CVar.Sch.Where(info => info.Lineid2 == lineid2).Where(info => info.Busid2 == busid2).Where(info => info.Direct == direct).ToList();    

                    if (s.Count != 0)
                    {
                        //首班车
                        s.Sort(CVar.SortByAsc);
                        SchInfo si = s[0];

                        instationid = CVar.GetInStationID(lineid2, si.Caseid, (int)(direct == Direct_Up ? 1 : 0));
                    }
                    else
                    {
                        //未排班时按照默认区间
                        CaseInfo ci = CVar.Line_Defcase(lineid2);

                        instationid = CVar.GetInStationID(lineid2, ci.Caseid, (int)(direct == Direct_Up ? 1 : 0));
                    }

                    intime = CVar.GetNearInTime(lineid2, busid2, (int)(direct == Direct_Up ? 1 : 0), instationid, itime);

                    DebugDcc(lineid2, busid2, "当日没有路单，增补进站（" + intime + "）");
                }

                SavRecInStation(lineid2, busid2, drvnumber, instationid, intime, (int)(direct == Direct_Up ? 1 : 0), 2);
                goto rePoint;
            }
        }

        /// <summary>
        /// 记录跳点
        /// </summary>
        /// <param name="recid"></param>
        private void SavSkippedRec(string recid)
        {
            string sql = "UPDATE TB_DRIVING_RECORDS SET runstatus = 7, summary = '过点未发', makeDate = SYSDATE WHERE recid = '" + recid + "'";
            db.Execute(sql);

            SchInfo sch = CVar.SngSch(recid);
            sch.Status = SchStatus_OverTime;
        }

        private void SendCommands()
        {
            for (int i = 0; i < CVar.Queue.Count; i++)
            {
                QueueInfo qi = CVar.Queue[i];

                if (qi.Runstatus == RunStatus_WaitSend) //排队车辆
                {
                    if (CVar.TimeDiff(DateTime.Now, qi.Outtime) <= 0)  //过点未发
                    {
                        if (qi.CmdType != 1)
                        {
                            string strMsg = "运行区间：" + qi.Casename + "，发车时间已到，请发车。";
                            sck.SendMsg(qi.Lineid2, qi.Busid2, strMsg);
                            qi.CmdType = 1;
                        }
                    }
                    else if (CVar.TimeDiff(DateTime.Now, qi.Outtime) <= 2)  //临近发车
                    {
                        if (qi.CmdType != 2)
                        {
                            string strMsg = "运行区间：" + qi.Casename + "，发车时间：" + qi.Outtime.ToString("HH:mm") + "，请进站上客。";
                            sck.SendMsg(qi.Lineid2, qi.Busid2, strMsg);
                            qi.CmdType = 2;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 将未执行的计划点在路单中显示
        /// </summary>
        private void TmrToRec()
        {
            bool bln = false;

            List<SchInfo> s = CVar.Sch.Where(info => info.Status == SchStatus_Init).ToList();
            s.Sort(CVar.SortByAsc);

            for (int i = 0; i < s.Count; i++)
            {
                if (CVar.TimeDiff(s[i].Plan_starttime, CVar.DccSend) > 0 && s[i].Starttime == null)
                {
                    //到时间未进站的路单，直接标注跳过，但和接收到进站后的跳点判断不太一样的是，这里的数据是不确定的，所以makeDate依旧保存null
                    //以便进站时能正常的维护该条路单，修改runstatus只是为了在路单列表中能够看到
                    string sql = "UPDATE TB_Driving_Records SET runstatus = 7 " 
                                + "WHERE recid = '" + s[i].Recid + "'";
                    db.Execute(sql);

                    s[i].Status = SchStatus_CrossPoint;

                    bln = true;
                }
                else
                {
                    break;
                }

                if (bln)
                {
                    InitList(CurLineID, CurDirect);
                }
            }

        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.ClientSize.Width < 900)
            {
                pnlCase.Width = 900;
            }
            else
            {
                pnlCase.Width = this.ClientSize.Width;
            }
            if (this.ClientSize.Height < 540)
            {
                pnlCase.Height = 540 - pnlCase.Top - sStrip.Height;
            }
            else
            {
                pnlCase.Height = this.ClientSize.Height - pnlCase.Top - sStrip.Height;
            }
        }

        /// <summary>
        /// 初始化界面控件
        /// </summary>
        private void InitUcl()
        {
            //dgvUp.Tag = -1;
            //dgvDn.Tag = -1;
            //dgvUp_Sch.Tag = -1;
            //dgvDn_Sch.Tag = -1;

            CSubClass.SetXtraGridStyle(dgvUp_Sch);
            CSubClass.SetXtraGridStyle(dgvDn_Sch);
            CSubClass.SetXtraGridStyle(dgvUp);
            CSubClass.SetXtraGridStyle(dgvDn);

            InitFlx_Sch(0);
            InitFlx_Sch(1);

            InitFlx(0);
            InitFlx(1);

            tspRate.Minimum = 0;
            tspRate.Maximum = 100;
        }

        private void mnuSch_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (((ContextMenuStrip)sender).Items[0] == e.ClickedItem)
            {
                Sch_Add((int)mnuSch.Tag);
            }
            else if (((ContextMenuStrip)sender).Items[1] == e.ClickedItem)
            {
                Sch_Modify((int)mnuSch.Tag);
            }
            else if (((ContextMenuStrip)sender).Items[2] == e.ClickedItem)
            {
                Sch_Delete((int)mnuSch.Tag);
            }
            else if (((ContextMenuStrip)sender).Items[4] == e.ClickedItem)
            {
                Sch_ChangeBus((int)mnuSch.Tag);
            }
            else if (((ContextMenuStrip)sender).Items[5] == e.ClickedItem)
            {
                Sch_TmrChange((int)mnuSch.Tag);
            }
            else if (((ContextMenuStrip)sender).Items[6] == e.ClickedItem)
            {
                Sch_TmrEqual((int)mnuSch.Tag);
            }
            else if (((ContextMenuStrip)sender).Items[7] == e.ClickedItem)
            {
                Sch_Swap((int)mnuSch.Tag);
            }
        }

        private void mnuQueue_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (((ContextMenuStrip)sender).Items[0] == e.ClickedItem)
            {
                Queue_Add((int)mnuQueue.Tag);
            }
            else if (((ContextMenuStrip)sender).Items[1] == e.ClickedItem)
            {
                Queue_Remove((int)mnuQueue.Tag);
            }
        }

        private void mnuQueue_Opening(object sender, CancelEventArgs e)
        {
            string whichcontrol_name = (sender as ContextMenuStrip).SourceControl.Name;
            mnuQueue.Tag = whichcontrol_name == gridUp.Name ? Direct_Up : Direct_Dn;    
        }

        private void mnuSch_Opening(object sender, CancelEventArgs e)
        {
            string whichcontrol_name = (sender as ContextMenuStrip).SourceControl.Name;
            mnuSch.Tag = whichcontrol_name == gridUp_Sch.Name ? Direct_Up : Direct_Dn;   
        }

        private void SaveLogout()
        {
            if (CVar.QueryMode)
            {
                return;
            }

            string sql = "INSERT INTO tb_LoginRec(userCode, ipAddress, loginDate, loginSign, manageLines) "
                        + "VALUES ('" + CVar.LoginID + "', '" + CFunc.GetOuterIP() + "', SYSDATE, 1, '" + CVar.SelLines + "')";
            db.Execute(sql);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Settings.Default.WindowLocation != null)
            {
                this.Location = Settings.Default.WindowLocation;
            }
            if (Settings.Default.WindowSize != null)
            {
                this.Size = Settings.Default.WindowSize;
            }
            pnlCase.SplitterPosition = Settings.Default.VSplitterPosition;
            pnlQueue.SplitterPosition = Settings.Default.HSplitterPosition;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否退出系统？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            sck = null;
            SaveLogout();

            Settings.Default.VSplitterPosition = pnlCase.SplitterPosition;
            Settings.Default.HSplitterPosition = pnlQueue.SplitterPosition;
            Settings.Default.WindowLocation = this.Location;
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowSize = this.Size;
            }
            else
            {
                Settings.Default.WindowSize = this.RestoreBounds.Size;
            }
            if (this.WindowState != FormWindowState.Minimized)
            {
                Settings.Default.Save();//使用Save方法保存更改
            }
        }

        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitList(CurLineID, CurDirect);
        }

        private void tmrQueue_Tick(object sender, EventArgs e)
        {
            //通过重新绑定刷新界面显示
            FillQueue(Direct_Up);
            FillQueue(Direct_Dn);

            SendCommands();
        }

        private void tmrLsnr_Tick(object sender, EventArgs e)
        {
            lock (tmrLock)
            {
                if (CVar.QueryMode)
                {
                    //加载最新数据
                    if (DateTime.Now.Second < 30)
                    {
                        FillData();
                    }
                }
                else
                {
                    //检测是否存在提取log的请求
                    if (DateTime.Now.Second < 30)
                    {
                        CVar.CollectLog();
                    }

                    TmrToRec();   //定时处理数据
                }
            }
        }

        private void FillData()
        {
            string sql = "";
            DataTable dt = null;

            //构建本地记录集
            sql = "SELECT a.RECID, a.LINEID2, c.BUSID2, a.CASEID, a.DRVNUMBER, c.BUSNUMBER, a.RUNNUMBER, d.DRVNAME, e.CASENAME, " + Environment.NewLine
                + "    a.PLAN_STARTTIME, a.PLAN_ARRIVETIME, a.STARTTIME, a.ARRIVETIME, a.DIRECT, DECODE(a.RUNSTATUS,0,0,2,1,7,CASE WHEN a.MAKEDATE IS NULL THEN -1 ELSE 2 END) AS STATUS " + Environment.NewLine
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
                SchInfo si = new SchInfo();
                si.Recid = dt.Rows[i]["RECID"].ToString();
                si.Lineid2 = int.Parse(dt.Rows[i]["LINEID2"].ToString());
                si.Busid2 = int.Parse(dt.Rows[i]["BUSID2"].ToString());
                si.Caseid = dt.Rows[i]["CASEID"].ToString();
                si.Drvnumber = dt.Rows[i]["DRVNUMBER"].ToString();
                si.Busnumber = dt.Rows[i]["BUSNUMBER"].ToString();
                si.Runnumber = int.Parse(dt.Rows[i]["RUNNUMBER"].ToString());
                si.Drvname = dt.Rows[i]["DRVNAME"].ToString();
                si.Casename = dt.Rows[i]["CASENAME"].ToString();
                si.Plan_starttime = DateTime.Parse(dt.Rows[i]["PLAN_STARTTIME"].ToString());
                si.Plan_arrivetime = DateTime.Parse(dt.Rows[i]["PLAN_ARRIVETIME"].ToString());
                if (!String.IsNullOrEmpty(dt.Rows[i]["STARTTIME"].ToString()))
                {
                    si.Starttime = DateTime.Parse(dt.Rows[i]["STARTTIME"].ToString());
                }
                if (!String.IsNullOrEmpty(dt.Rows[i]["ARRIVETIME"].ToString()))
                {
                    si.Arrivetime = DateTime.Parse(dt.Rows[i]["ARRIVETIME"].ToString());
                }
                si.Direct = int.Parse(dt.Rows[i]["DIRECT"].ToString());
                si.Status = int.Parse(dt.Rows[i]["STATUS"].ToString());

                CVar.Sch.Add(si);
            }

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
                QueueInfo qi = new QueueInfo();
                qi.Recid = dt.Rows[i]["RECID"].ToString();
                qi.Direct = int.Parse(dt.Rows[i]["DIRECT"].ToString());
                qi.Lineid2 = int.Parse(dt.Rows[i]["LINEID2"].ToString());
                qi.Caseid = dt.Rows[i]["CASEID"].ToString();
                qi.Drvnumber = dt.Rows[i]["DRVNUMBER"].ToString();
                qi.Linename = dt.Rows[i]["LINENAME"].ToString();
                qi.Busnumber = dt.Rows[i]["BUSNUMBER"].ToString();
                qi.Runnumber = int.Parse(dt.Rows[i]["RUNNUMBER"].ToString());
                qi.Drvname = dt.Rows[i]["DRVNAME"].ToString();
                qi.Casename = dt.Rows[i]["CASENAME"].ToString();
                qi.Intime = DateTime.Parse(dt.Rows[i]["INTIME"].ToString());
                qi.Indate = int.Parse(dt.Rows[i]["INDATE"].ToString());
                qi.Outtime = DateTime.Parse(dt.Rows[i]["STARTTIME"].ToString());
                qi.Outdate = int.Parse(dt.Rows[i]["STARTDATE"].ToString());
                qi.Runstatus = int.Parse(dt.Rows[i]["RUNSTATUS"].ToString());
                qi.Stationid2 = int.Parse(dt.Rows[i]["STATIONID2"].ToString());

                CVar.Queue.Add(qi);
            }

            InitList(CurLineID, CurDirect);
          
            FillQueue(0);
            FillQueue(1);
        }

        private void dgv_Sch_MouseDown(GridView dgv, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                bool blnSwap = false;
                bool blnSng = false;
                bool blnMuti = false;
                bool blnSeq = false;

                switch (dgv.SelectedRowsCount)
                {
                    case 1:
                        blnSwap = false;
                        blnSng = true;
                        break;

                    case 2:
                        blnSwap = true;
                        blnSng = false;
                        break;
                }

                int[] rowHandles = dgv.GetSelectedRows();

                for (int i = 1; i < rowHandles.Length; i++)
                {
                    if (rowHandles[i] == rowHandles[i - 1] + 1)
                    {
                        blnSeq = true;
                    }
                    else
                    {
                        blnSeq = false;
                        break;
                    }
                }

                for (int i = 0; i < rowHandles.Length; i++)
                {
                    int state = int.Parse(dgv.GetRowCellValue(rowHandles[i], "Status").ToString());

                    if (state == SchStatus_Init)
                    {
                        blnMuti = true;
                    }
                    else
                    {
                        blnMuti = false;
                        break;
                    }
                }

                mnuSchAdd.Enabled = true;
                mnuSchModify.Enabled = blnSng;
                mnuSchDelete.Enabled = blnMuti;
                mnuChangeBus.Enabled = blnSng;
                mnuTmrChange.Enabled = blnMuti;
                mnuTmrEqual.Enabled = blnMuti && blnSeq;
                mnuSchSwap.Enabled = blnMuti && blnSwap;
            }
        }

        private void dgv_Sch_RowCellStyle(GridView dgv, RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                try
                {
                    SchInfo si = null;

                    if (e.Column.FieldName == "Display_StartTime" || e.Column.FieldName == "Display_ArriveTime" || e.Column.FieldName == "ColorStatus")
                    {
                        string recid = dgv.GetRowCellDisplayText(e.RowHandle, dgv.Columns["Recid"]);
                        si = CVar.SngSch(recid);
                    }

                    if (si != null)
                    {
                        switch (e.Column.FieldName)
                        {
                            case "Display_StartTime":
                                e.Appearance.ForeColor = si.Color_StartTime;
                                break;

                            case "Display_ArriveTime":
                                e.Appearance.ForeColor = si.Color_ArriveTime;
                                break;

                            case "ColorStatus":
                                e.Appearance.BackColor = si.Color_Status;
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void tabList_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            InitList(CurLineID, CurDirect);
        }

        private void dgvUp_Sch_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "No")
            {
                e.Appearance.DrawString(e.Cache, (e.RowHandle + 1).ToString(), e.Bounds);
                e.Handled = true;
            }
        }

        private void dgvDn_Sch_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "No")
            {
                e.Appearance.DrawString(e.Cache, (e.RowHandle + 1).ToString(), e.Bounds);
                e.Handled = true;
            }
        }

        private void dgvUp_Sch_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            dgv_Sch_RowCellStyle(dgvUp_Sch, e);
        }

        private void dgvDn_Sch_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            dgv_Sch_RowCellStyle(dgvDn_Sch, e);
        }

        private void tniRepair_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            frmRepairLog frm = new frmRepairLog(this);
            frm.Show();
        }

        private void tniReport_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            frmRunningLog frm = new frmRunningLog(this);
            frm.Show();
        }

        private void tniOprRecord_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            frmDrvingRecord frm = new frmDrvingRecord(this);
            frm.Show();
        }

        private void tniUnOprRecord_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            frmNonRunRecord frm = new frmNonRunRecord(this);
            frm.Show();
        }

        private void tniSchedule_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            frmSchedule frm = new frmSchedule(this);
            frm.Show();
        }

        private void tniBusDrivers_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            frmBusDrivers frm = new frmBusDrivers(this);
            frm.Show();
        }

        private void tniMapMonitor_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            RunProgram(CVar.MonitorExe);
        }

        private void tniLineGraph_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            RunProgram(CVar.ChartExe);
        }

        private void tniPlayBack_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            RunProgram(CVar.PlaybackExe);
        }

        private void dgvUp_Sch_MouseDown(object sender, MouseEventArgs e)
        {
            dgv_Sch_MouseDown(dgvUp_Sch, e);
        }

        private void dgvDn_Sch_MouseDown(object sender, MouseEventArgs e)
        {
            dgv_Sch_MouseDown(dgvDn_Sch, e);
        }

        private void RefreshRate()
        {
            List<SchInfo> cschs = CVar.Sch.FindAll(delegate (SchInfo s) { return s.Lineid2 == CurLineID && (s.Status == SchStatus_Complete || s.Status == SchStatus_Normal); });
            List<SchInfo> aschs = CVar.Sch.FindAll(delegate (SchInfo s) { return s.Lineid2 == CurLineID; });

            double dblRate = (double)cschs.Count / (double)aschs.Count;
            tspRate.Value = (int)(Math.Round(dblRate,2) * 100);
            tssRate.Text = string.Format("趟次完成率：{0}%", tspRate.Value.ToString());
        }

        /// <summary>
        /// 鼠标事件，以浮动窗口显示状态信息
        /// </summary>
        private void dgv_Sch_MouseMove(GridView dgv, MouseEventArgs e)
        {
            //// 获取鼠标焦点
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = dgv.CalcHitInfo(new Point(e.X, e.Y));

            //// 如果鼠标不是在行上.或者不在列上
            //if (hi.RowHandle < 0 || hi.Column == null)
            //{
            //    dgv.Tag = -1;
            //    toolTipController.HideHint();
            //    return;
            //}
            //else if (int.Parse(dgv.Tag.ToString()) == hi.RowHandle)
            //{
            //    // rowHandle为全局变量,如果上次指向的是这一行的数据.则这次不重新初始化ToolTip.(因为鼠标一移到列上面则会触发多次的MouseMove)
            //    return;
            //}

            //if (hi.Column.FieldName == "ColorStatus")
            //{
            //    // 如果RowHandle为不等于rowHandle则重新显示ToolTip
            //    dgv.Tag = hi.RowHandle;

            //    // 创建ToolTip的数据显示,只有订单有备注的时候才显示ToolTip
            //    int state = int.Parse(dgv.GetRowCellDisplayText(hi.RowHandle, dgv.Columns["Status"]).ToString());
            //    string tooltipText = "";

            //    if (state == SchStatus_CrossPoint || state == SchStatus_OverTime)
            //    {
            //        tooltipText = "过点未发";
            //    }
            //    else if (state == SchStatus_Normal)
            //    {
            //        tooltipText = "已执行";
            //    }
            //    else if (state == SchStatus_Complete)
            //    {
            //        tooltipText = "已执行";
            //    }
            //    else
            //    {
            //        string recid = dgv.GetRowCellDisplayText(hi.RowHandle, dgv.Columns["Recid"]).ToString();
            //        QueueInfo qi = CVar.SngQueue(recid);
            //        tooltipText = qi != null ? "正在排队" : "未执行";
            //    }

            //    if (!string.IsNullOrEmpty(tooltipText))
            //    {
            //        // 获取显示ToolTip事件实例
            //        ToolTipControllerShowEventArgs args = CreateShowArgs(tooltipText);
            //        // 显示ToolTip 这里不可以用控件的坐标.要用屏幕的坐标Control.MousePosition
            //        toolTipController.ShowHint(args, System.Windows.Forms.Control.MousePosition);
            //    }
            //}
            //else
            //{
            //    toolTipController.HideHint();
            //}
        }

        private void dgv_MouseMove(GridView dgv, MouseEventArgs e)
        {
            //// 获取鼠标焦点
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = dgv.CalcHitInfo(new Point(e.X, e.Y));

            //// 如果鼠标不是在行上.或者不在列上
            //if (hi.RowHandle < 0 || hi.Column == null)
            //{
            //    dgv.Tag = -1;
            //    toolTipController.HideHint();
            //    return;
            //}
            //else if (int.Parse(dgv.Tag.ToString()) == hi.RowHandle)
            //{
            //    // rowHandle为全局变量,如果上次指向的是这一行的数据.则这次不重新初始化ToolTip.(因为鼠标一移到列上面则会触发多次的MouseMove)
            //    return;
            //}

            //if (hi.Column.FieldName == "ImgStatus")
            //{
            //    // 如果RowHandle为不等于rowHandle则重新显示ToolTip
            //    dgv.Tag = hi.RowHandle;

            //    // 创建ToolTip的数据显示,只有订单有备注的时候才显示ToolTip
            //    int state = int.Parse(dgv.GetRowCellDisplayText(hi.RowHandle, dgv.Columns["Runstatus"]).ToString());
            //    string tooltipText = "";

            //    if (state == RunStatus_WaitSend)
            //    {
            //        tooltipText = "等待发车";
            //    }
            //    else if (state == RunStatus_StopRun)
            //    {
            //        tooltipText = "停止运营";
            //    }

            //    if (!string.IsNullOrEmpty(tooltipText))
            //    {
            //        // 获取显示ToolTip事件实例
            //        ToolTipControllerShowEventArgs args = CreateShowArgs(tooltipText);
            //        // 显示ToolTip 这里不可以用控件的坐标.要用屏幕的坐标Control.MousePosition
            //        toolTipController.ShowHint(args, System.Windows.Forms.Control.MousePosition);
            //    }
            //}
            //else
            //{
            //    toolTipController.HideHint();
            //}
        }

        /// <summary>
        /// 创建显示ToolTip事件实例
        /// </summary>
        /// <param name="tooltipText"></param>
        /// <returns></returns>
        private ToolTipControllerShowEventArgs CreateShowArgs(string tooltipText)
        {
            ToolTipControllerShowEventArgs args = toolTipController.CreateShowArgs();
            args.ToolTip = tooltipText;
            return args;
        }

        private void dgvUp_Sch_MouseMove(object sender, MouseEventArgs e)
        {
            dgv_Sch_MouseMove(dgvUp_Sch, e);
        }

        private void dgvDn_Sch_MouseMove(object sender, MouseEventArgs e)
        {
            dgv_Sch_MouseMove(dgvDn_Sch, e);
        }

        private void dgvUp_MouseMove(object sender, MouseEventArgs e)
        {
            dgv_MouseMove(dgvUp, e);
        }

        private void dgvDn_MouseMove(object sender, MouseEventArgs e)
        {
            dgv_MouseMove(dgvDn, e);
        }

        private readonly object obj = new object();

        public void DebugDcc(int lineid2, int busid2, string msg)
        {
            string linename = CVar.LineID2ToName(lineid2);
            string busnumber = CVar.BusID2ToNumber(lineid2, busid2);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(busnumber + " >> " + msg);
            Console.ResetColor();

            lock (obj)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                if (!string.IsNullOrEmpty(path))
                {
                    path = AppDomain.CurrentDomain.BaseDirectory + "log\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + linename;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    path = path + "\\" + busnumber + ".log";
                    if (!File.Exists(path))
                    {
                        FileStream fs = File.Create(path);
                        fs.Close();
                    }
                    if (File.Exists(path))
                    {
                        StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                        sw.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\t" + msg);
                        sw.Close();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Sch_Add(CurDirect);
        }

        private void pnlUp_Paint(object sender, PaintEventArgs e)
        {
            panel_Paint(pnlUp, e);
        }

        private void pnlDn_Paint(object sender, PaintEventArgs e)
        {
            panel_Paint(pnlDn, e);
        }

        private void panel_Paint(Panel pnl, PaintEventArgs e)
        {
            Color c = Color.FromArgb(157, 160, 170);

            ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle, 
                                c, 1, ButtonBorderStyle.Solid,
                                c, 1, ButtonBorderStyle.Solid,
                                c, 1, ButtonBorderStyle.Solid,
                                c, 1, ButtonBorderStyle.Solid);
        }

        private void RunProgram(string exe)
        {
            try
            {
                ////查找进程、存在就退出过程
                //if (chartPid != 0)
                //{
                //    ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + chartPid);
                //    ManagementObjectCollection moc = searcher.Get();
                //    if (moc.Count > 0)
                //    { return; }
                //}

                //启用进程
                Process p;//实例化一个Process对象
                p = Process.Start(System.Windows.Forms.Application.StartupPath + "\\" + exe);    //要开启的进程（或 要启用的程序），括号内为绝对路径
                //chartPid = p.Id;
            }
            catch
            {
                MessageBox.Show("打开程序时发生错误，请检查程序路径是否正确。" + Environment.NewLine + System.Windows.Forms.Application.StartupPath + "\\" + exe, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
