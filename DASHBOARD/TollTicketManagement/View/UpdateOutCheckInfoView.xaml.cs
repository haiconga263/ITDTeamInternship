using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using TollManagement.Common;
using TollManagement.Data;
using TollTicketManagement.Common;
using TollTicketManagement.Controller;

namespace TollTicketManagement.View
{
    /// <summary>
    /// Interaction logic for UpdateOutCheckInfo.xaml
    /// </summary>
    public partial class UpdateOutCheckInfo : Window
    {
        TollManagement_Ctrl tollmanegement_Ctrl = new TollManagement_Ctrl();
        DispatcherTimer dt, trafficTimer, deviceTimer;
        bool isAlowAuto = false;
        bool isRunning = false;
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private readonly BackgroundWorker trafficWorker = new BackgroundWorker();
        private readonly BackgroundWorker deviceWorker = new BackgroundWorker();


        private MenuItem btnQuit;

        public UpdateOutCheckInfo()
        {
            InitializeComponent();
            lblUpdateStatus.Content = string.Empty;
            dt = new DispatcherTimer();
            dt.Tick += new EventHandler(timer_Tick);
            dt.Interval = new TimeSpan(0, 0, 10); // execute every 1 MIN
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            //---------------
            InitializeComponent();
            lblUpdateStatus.Content = string.Empty;
            deviceTimer = new DispatcherTimer();
            deviceTimer.Tick += new EventHandler(deviceTimer_Tick);
            deviceTimer.Interval = new TimeSpan(0, 1, 0); // execute every 1 MIN
            deviceWorker.DoWork += DeviceWorkerOnDoWork;
            deviceWorker.RunWorkerCompleted += DeviceWorkerOnRunWorkerCompleted;
            //-------------------------
            trafficTimer = new DispatcherTimer();
            trafficTimer.Tick += new EventHandler(trafficTimer_Tick);
            trafficTimer.Interval = new TimeSpan(0, 5, 0); // execute every 5 MIN
            trafficWorker.DoWork += trafficWorker_DoWork;
            trafficWorker.RunWorkerCompleted += trafficWorker_RunWorkerCompleted;
        }

        private void DeviceWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void DeviceWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
               #region Insert Device Status
                List<sp_ToolManagement_GetDeviceStatus_Result> data = tollmanegement_Ctrl.GetAllDeviceStatus();
                List<sp_LS_Lane_GetAll_Result> listLane = tollmanegement_Ctrl.GetAllLane();
                DataTable rs = new DataTable();

                rs = Utility.ConvertToDataTable(data);
                if (data.Count > 0)
                {
                    for (int i = 0; i < listLane.Count; i++)
                    {
                        var laneCode = listLane[i].Name;
                        string PCLane, PLC, LaneStatus, Barrier, Printer, CardReader;
                        PCLane = PLC = LaneStatus = Barrier = Printer = CardReader = string.Empty;

                        List<sp_ToolManagement_GetDeviceStatus_Result> rowData = data.Where(p => p.LaneCode == laneCode).ToList();
                        foreach (var spToolManagementGetDeviceStatusResult in rowData)
                        {
                            switch (spToolManagementGetDeviceStatusResult.DeviceName)
                            {
                                case "PCLane":
                                    PCLane = spToolManagementGetDeviceStatusResult.Status.ToString();
                                    break;
                                case "PLC":
                                    PLC = spToolManagementGetDeviceStatusResult.Status.ToString();
                                    break;
                                case "Lane Status":
                                    LaneStatus = spToolManagementGetDeviceStatusResult.Status.ToString();
                                    break;
                                case "Red":
                                    Barrier = spToolManagementGetDeviceStatusResult.Status.ToString();
                                    break;
                                case "Printer":
                                    Printer = spToolManagementGetDeviceStatusResult.Status.ToString();
                                    break;
                                case "SVR":
                                    CardReader = spToolManagementGetDeviceStatusResult.Status.ToString();
                                    break;
                            }
                        }
                        string stringStatus = string.Format("{0}{1}{2}{3}{4}{5}", PCLane, PLC, LaneStatus, Barrier, Printer, CardReader);
                        if (!string.IsNullOrEmpty(stringStatus))
                        {
                            //Insert db
                            tollmanegement_Ctrl.InsertDeviceStatus(laneCode, DateTime.Now, stringStatus);
                        }
                    }
                }
                #endregion
            }));
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                #region Update Entry info
                //Run all background tasks here
                Mouse.OverrideCursor = Cursors.Wait;
                //Load ds các giao dịch chưa có thông tin đầu vào trên bảng OUT
                var rs = tollmanegement_Ctrl.GetAllOutCheck_NoEntryInfo();
                if (rs != null)
                {
                    for (int i = 0; i < rs.Count; i++)
                    {
                        //Cập nhật thông tin đầu vào lên bảng OUT
                        tollmanegement_Ctrl.UpdateEntryInfo(rs[i].TransactionID.ToString(), rs[i].EntryTracsactionID.ToString(), (int)rs[i].EntryLaneID, rs[i].EntryPlateNumber);
                    }
                    Mouse.OverrideCursor = Cursors.Arrow;
                    lblUpdateStatus.Content = string.Empty;
                }
                #endregion

                #region Insert Device Status
                //List<sp_ToolManagement_GetDeviceStatus_Result> data = tollmanegement_Ctrl.GetAllDeviceStatus();
                //List<sp_LS_Lane_GetAll_Result> listLane = tollmanegement_Ctrl.GetAllLane();
                //DataTable rs = new DataTable();

                //rs = Utility.ConvertToDataTable(data);
                //if (data.Count > 0)
                //{
                //    for (int i = 0; i < listLane.Count; i++)
                //    {
                //        var laneCode = listLane[i].Name;
                //        string PCLane, PLC, LaneStatus, Barrier, Printer, CardReader;
                //        PCLane = PLC = LaneStatus = Barrier = Printer = CardReader = string.Empty;

                //        List<sp_ToolManagement_GetDeviceStatus_Result> rowData = data.Where(p => p.LaneCode == laneCode).ToList();
                //        foreach (var spToolManagementGetDeviceStatusResult in rowData)
                //        {
                //            switch (spToolManagementGetDeviceStatusResult.DeviceName)
                //            {
                //                case "PCLane":
                //                    PCLane = spToolManagementGetDeviceStatusResult.Status.ToString();
                //                    break;
                //                case "PLC":
                //                    PLC = spToolManagementGetDeviceStatusResult.Status.ToString();
                //                    break;
                //                case "Lane Status":
                //                    LaneStatus = spToolManagementGetDeviceStatusResult.Status.ToString();
                //                    break;
                //                case "Red":
                //                    Barrier = spToolManagementGetDeviceStatusResult.Status.ToString();
                //                    break;
                //                case "Printer":
                //                    Printer = spToolManagementGetDeviceStatusResult.Status.ToString();
                //                    break;
                //                case "SVR":
                //                    CardReader = spToolManagementGetDeviceStatusResult.Status.ToString();
                //                    break;
                //            }
                //        }
                //        string stringStatus = string.Format("{0}{1}{2}{3}{4}{5}", PCLane, PLC, LaneStatus, Barrier, Printer, CardReader);
                //        if (!string.IsNullOrEmpty(stringStatus))
                //        {
                //            //Insert db
                //            tollmanegement_Ctrl.InsertDeviceStatus(laneCode, DateTime.Now, stringStatus);
                //        }
                //    }
                //}
                #endregion
            }));
        }

        private void trafficWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DataTable rsTraffic = new DataTable();

                #region Insert Traffic
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    //Run all background tasks here
                    Mouse.OverrideCursor = Cursors.Wait;
                    var listTraffic = new List<sp_ToolManagement_GetTrafficVolume_Result>();
                    //------------------
                    listTraffic = tollmanegement_Ctrl.GetTrafficVolume(DateTime.Now.AddMinutes(-5), DateTime.Now, 1);
                    if (listTraffic != null)
                    {
                        foreach (var spToolManagementGetTrafficVolumeResult in listTraffic)
                        {
                            //Insert db
                            tollmanegement_Ctrl.InsertTrafficVolume((DateTime)spToolManagementGetTrafficVolumeResult.REG_DATE, (DateTime)spToolManagementGetTrafficVolumeResult.COLLECT_DATE, spToolManagementGetTrafficVolumeResult.Tollgate_ID.ToString(), spToolManagementGetTrafficVolumeResult.Lane_ID.ToString(), (decimal)spToolManagementGetTrafficVolumeResult.VOLUME);
                        }
                    }
                    //----------------
                    listTraffic = tollmanegement_Ctrl.GetTrafficVolume(DateTime.Now.AddMinutes(-5), DateTime.Now, 2);
                    if (listTraffic != null)
                    {
                        foreach (var spToolManagementGetTrafficVolumeResult in listTraffic)
                        {
                            //Insert db
                            tollmanegement_Ctrl.InsertTrafficVolume((DateTime)spToolManagementGetTrafficVolumeResult.REG_DATE, (DateTime)spToolManagementGetTrafficVolumeResult.COLLECT_DATE, spToolManagementGetTrafficVolumeResult.Tollgate_ID.ToString(), spToolManagementGetTrafficVolumeResult.Lane_ID.ToString(), (decimal)spToolManagementGetTrafficVolumeResult.VOLUME);
                        }
                    }
                    //--------------------
                    listTraffic = tollmanegement_Ctrl.GetTrafficVolume(DateTime.Now.AddMinutes(-5), DateTime.Now, 3);
                    if (listTraffic != null)
                    {
                        foreach (var spToolManagementGetTrafficVolumeResult in listTraffic)
                        {
                            //Insert db
                            tollmanegement_Ctrl.InsertTrafficVolume((DateTime)spToolManagementGetTrafficVolumeResult.REG_DATE, (DateTime)spToolManagementGetTrafficVolumeResult.COLLECT_DATE, spToolManagementGetTrafficVolumeResult.Tollgate_ID.ToString(), spToolManagementGetTrafficVolumeResult.Lane_ID.ToString(), (decimal)spToolManagementGetTrafficVolumeResult.VOLUME);
                        }
                    }
                    //--------------------
                    listTraffic = tollmanegement_Ctrl.GetTrafficVolume(DateTime.Now.AddMinutes(-5), DateTime.Now, 4);
                    if (listTraffic != null)
                    {
                        foreach (var spToolManagementGetTrafficVolumeResult in listTraffic)
                        {
                            //Insert db
                            tollmanegement_Ctrl.InsertTrafficVolume((DateTime)spToolManagementGetTrafficVolumeResult.REG_DATE, (DateTime)spToolManagementGetTrafficVolumeResult.COLLECT_DATE, spToolManagementGetTrafficVolumeResult.Tollgate_ID.ToString(), spToolManagementGetTrafficVolumeResult.Lane_ID.ToString(), (decimal)spToolManagementGetTrafficVolumeResult.VOLUME);
                        }
                    }
                    //-----------------------
                    listTraffic = tollmanegement_Ctrl.GetTrafficVolume(DateTime.Now.AddMinutes(-5), DateTime.Now, 5);
                    if (listTraffic != null)
                    {
                        foreach (var spToolManagementGetTrafficVolumeResult in listTraffic)
                        {
                            //Insert db
                            tollmanegement_Ctrl.InsertTrafficVolume((DateTime)spToolManagementGetTrafficVolumeResult.REG_DATE, (DateTime)spToolManagementGetTrafficVolumeResult.COLLECT_DATE, spToolManagementGetTrafficVolumeResult.Tollgate_ID.ToString(), spToolManagementGetTrafficVolumeResult.Lane_ID.ToString(), (decimal)spToolManagementGetTrafficVolumeResult.VOLUME);
                        }
                    }
                }));
                

                #endregion
                
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile_SQL(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile_SQL(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
           
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
            var rs = tollmanegement_Ctrl.GetUpdateEntryRowEffect().ToString();
            Application.Current.Dispatcher.Invoke(
                DispatcherPriority.Normal, (System.Threading.ThreadStart)delegate { lblUpdateStatus.Content = rs + " dòng đã cập nhật"; });
            //Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void trafficWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void ProcessTask()
        {
            if (!worker.IsBusy)
                worker.RunWorkerAsync();
        }

        private void btnUpdateEntryInfo_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning)//Đang chạy tu dong bấm lần nữa sẽ stop
            {
                isAlowAuto = false;
                isRunning = false;
                if (dt != null) 
                    dt.Stop();
                btnUpdateEntryInfo.Content = "Cập nhật đầu vào"; //Chuyển sang manual
                return;
            }

            if ((bool)chkAuto.IsChecked && isAlowAuto && isRunning == false) //Run auto
            {
                btnUpdateEntryInfo.Content = "Dừng";
                dt.Start();
                isRunning = true;
            }
            else //Run manual
            {
                Mouse.OverrideCursor = Cursors.Wait;
                ProcessTask();
            }
        }

        // Tick handler    
        private void timer_Tick(object sender, EventArgs e)
        {
            ProcessTask();
        }

        // Tick handler    
        private void trafficTimer_Tick(object sender, EventArgs e)
        {
            if (!trafficWorker.IsBusy)
                trafficWorker.RunWorkerAsync();
        }

        // Tick handler    
        private void deviceTimer_Tick(object sender, EventArgs e)
        {
            if (!deviceWorker.IsBusy)
                deviceWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Cập nhật thống kê lưu lượng xe vào db SK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInsertTrafficVol_OnClick(object sender, RoutedEventArgs e)
        {
            trafficTimer.Start();
            deviceTimer.Start();
        }

        private void chkAuto_Checked(object sender, RoutedEventArgs e)
        {
            isAlowAuto = true;
            btnUpdateEntryInfo.Content = "Chạy tự động";
        }

        private void chkAuto_Unchecked(object sender, RoutedEventArgs e)
        {
            isAlowAuto = false;
            if (dt != null)
                dt.Stop();
            btnUpdateEntryInfo.Content = "Cập nhật đầu vào"; //Chuyển sang manual
        }

        private void UpdateOutCheckInfo_OnLoaded(object sender, RoutedEventArgs e)
        {
            var closeButton = GetTemplateChild("closeButton") as Button;
            if (closeButton != null) closeButton.Click += CloseClick;

            btnQuit = GetTemplateChild("btnQuit") as MenuItem;
            if (btnQuit != null) btnQuit.Click += btnQuitClick;

            var minimizeButton = GetTemplateChild("minimizeButton") as Button;
            if (minimizeButton != null) minimizeButton.Click += MinimizeClick;
        }

        private void btnQuitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            if (SupervisionConfig.IsVehicleImporting)
            {
                Utility.SendWpfWindowBack(this);
                e.Handled = true;
            }
            else
            {
                Topmost = false;
                Close();
            }
        }

    }
}
