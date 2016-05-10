using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ITD_VehicleRegister;
using TollManagement.Data;
using TollTicketManagement.Common;
using TollTicketManagement.Controller;
using System.Windows.Threading;
using System.Runtime.InteropServices;

namespace TollTicketManagement.View
{
    
    /// <summary>
    /// Interaction logic for UpdatePrecheckStatusView.xaml
    /// </summary>
    public partial class UpdatePrecheckStatusView : Window
    {
        
        private VehicleRegister itdgeris;
        TollManagement_Ctrl tollmanegement_Ctrl = new TollManagement_Ctrl();
        DispatcherTimer dt;
        bool isAlowAuto = false;
        bool isRunning = false;
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private MenuItem btnQuit;

        public UpdatePrecheckStatusView()
        {
            InitializeComponent();
            itdgeris = new VehicleRegister();
            lblUpdateStatus.Content = string.Empty;
            dt = new DispatcherTimer();
            dt.Tick += new EventHandler(timer_Tick);
            dt.Interval = new TimeSpan(0, 0, 10); // execute every 5 sec
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                //Run all background tasks here
                Mouse.OverrideCursor = Cursors.Wait;
                var rs = tollmanegement_Ctrl.GetAllOutCheck_UnPrecheck();
                if (rs != null)
                {
                    foreach (sp_ToolManagement_GetAllOutCheck_UnPrecheck_Result t in rs)
                    {
                        if (!string.IsNullOrEmpty(t.ExitPlateNumber))
                        {
                            var encodePlate = itdgeris.Encode_Vehicle(t.ExitPlateNumber);
                            tollmanegement_Ctrl.UpdatePrecheckStatus(t.TransactionID, (int) t.ExitVehicleTypeID, encodePlate);
                        }
                    }
                }
            }));
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
            var rs = tollmanegement_Ctrl.GetUpdatePrecheckRowEffect().ToString();
            Application.Current.Dispatcher.Invoke(
                DispatcherPriority.Normal, (System.Threading.ThreadStart)delegate { lblUpdateStatus.Content = rs + " dòng đã cập nhật"; });
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning)//Đang chạy tu dong bấm lần nữa sẽ stop
            {
                isAlowAuto = false;
                isRunning = false;
                if (dt != null) 
                    dt.Stop();
                btnUpdate.Content = "Hệ thống chấm HK"; //Chuyển sang manual
                return;
            }

            if ((bool)chkAuto.IsChecked && isAlowAuto && isRunning == false) //Run auto
            {
                btnUpdate.Content = "Dừng";
                
                dt.Start();
                isRunning = true;
            }
            else //Run manual
            {
                btnUpdate.Content = "Hệ thống chấm HK";
                Mouse.OverrideCursor = Cursors.Wait;
                lblUpdateStatus.Content = "Chương trình đang cập nhật ...";
                ProcessTask();
            }
        }

        // Tick handler    
        private void timer_Tick(object sender, EventArgs e)
        {
            ProcessTask();
        }

        private void ProcessTask()
        {
            if (!worker.IsBusy) 
                worker.RunWorkerAsync();
        }

        private void chkAuto_Unchecked(object sender, RoutedEventArgs e)
        {
            isAlowAuto = false;
            if(dt != null)
                dt.Stop();
            btnUpdate.Content = "Hệ thống chấm HK"; //Chuyển sang manual
        }

        private void chkAuto_Checked(object sender, RoutedEventArgs e)
        {
            isAlowAuto = true;
            btnUpdate.Content = "Chạy tự động";
        }
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            string decode = itdgeris.Encode_Vehicle("88C01529");
            string decode2 = itdgeris.Encode_Vehicle("89K3489");
            string decode3 = itdgeris.Encode_Vehicle("63C009T8");
        }

        private void UpdatePrecheckStatusView_OnLoaded(object sender, RoutedEventArgs e)
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
