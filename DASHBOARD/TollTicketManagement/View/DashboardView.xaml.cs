using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TollManagement.Common;
using TollManagement.Data;
using TollTicketManagement.Common;
using TollTicketManagement.Controller;


namespace TollTicketManagement.View
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Window
    {
        TollManagement_Ctrl tollManegement_Ctrl = new TollManagement_Ctrl();

        public DashboardView()
        {
            InitializeComponent();
        }

        private void DashboardView_OnLoaded(object sender, RoutedEventArgs e)
        {
            var closeButton = GetTemplateChild("closeButton") as Button;
            if (closeButton != null)
                closeButton.Click += CloseClick;
            var minimizeButton = GetTemplateChild("minimizeButton") as Button;
            if (minimizeButton != null) minimizeButton.Click += MinimizeClick;
            
            GetData();

            System.Windows.Threading.DispatcherTimer dashBoard_Timer = new System.Windows.Threading.DispatcherTimer();
            dashBoard_Timer.Tick += DashBoardTimerOnTick;
            dashBoard_Timer.Interval = new TimeSpan(0, 0, 10);
            dashBoard_Timer.Start();
        }

        private void DashBoardTimerOnTick(object sender, EventArgs eventArgs)
        {
            GetData();
        }

        private void GetData()
        {
            try
            {
                DataTable rs = new DataTable();
                int totalLane_IsOpen, totalLane_IsClose = 0; 
                Mouse.OverrideCursor = Cursors.Wait;
                //----------------DAU TUYEN----------------
                List<sp_CMO_DASHBOARD_Result> spCmoDashboardResults = tollManegement_Ctrl.GetDashBoardList(1);//DTuyen
                if (spCmoDashboardResults == null)
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    dgvListSearchResult.ItemsSource = null;
                    return;
                }
                Mouse.OverrideCursor = Cursors.Arrow;
                rs = Utility.ConvertToDataTable(spCmoDashboardResults);
                for (var i = 0; i < spCmoDashboardResults.Count; i++)
                {
                    if (spCmoDashboardResults[i].LaneStatus == 0)
                    {
                        totalLane_IsClose++;
                    }
                }
                
                dgvListSearchResult.ItemsSource = spCmoDashboardResults;
                //--------NH39
                List<sp_CMO_DASHBOARD_Result> spCmoDashboardResults_39 = tollManegement_Ctrl.GetDashBoardList(2);//39
                if (spCmoDashboardResults_39 == null)
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    dgvListSearchResult.ItemsSource = null;
                    return;
                }
                Mouse.OverrideCursor = Cursors.Arrow;
                rs = Utility.ConvertToDataTable(spCmoDashboardResults_39);
                for (var i = 0; i < spCmoDashboardResults_39.Count; i++)
                {
                    if (spCmoDashboardResults_39[i].LaneStatus == 0)
                    {
                        totalLane_IsClose += 1;
                    }
                }
                //totalLane_IsOpen = spCmoDashboardResults.Count - totalLane_IsClose;
                //txtTotalLane_IsClose.Text = totalLane_IsClose.ToString();
                //txtTotalLane_IsOpen.Text = totalLane_IsOpen.ToString();
                dgvListSearchResult_39.ItemsSource = spCmoDashboardResults_39;
                //--------NH38B------------------
                List<sp_CMO_DASHBOARD_Result> spCmoDashboardResults_38 = tollManegement_Ctrl.GetDashBoardList(3);//38
                if (spCmoDashboardResults_38 == null)
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    dgvListSearchResult.ItemsSource = null;
                    return;
                }
                Mouse.OverrideCursor = Cursors.Arrow;
                rs = Utility.ConvertToDataTable(spCmoDashboardResults_38);
                for (var i = 0; i < spCmoDashboardResults_38.Count; i++)
                {
                    if (spCmoDashboardResults_38[i].LaneStatus == 0)
                    {
                        totalLane_IsClose += 1;
                    }
                }
                //totalLane_IsOpen = spCmoDashboardResults.Count - totalLane_IsClose;
                //txtTotalLane_IsClose.Text = totalLane_IsClose.ToString();
                //txtTotalLane_IsOpen.Text = totalLane_IsOpen.ToString();
                dgvListSearchResult_38.ItemsSource = spCmoDashboardResults_38;

                //--------NH10------------------
                List<sp_CMO_DASHBOARD_Result>  spCmoDashboardResults_10 = tollManegement_Ctrl.GetDashBoardList(4);//10
                if (spCmoDashboardResults_10 == null)
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    dgvListSearchResult.ItemsSource = null;
                    return;
                }
                Mouse.OverrideCursor = Cursors.Arrow;
                rs = Utility.ConvertToDataTable(spCmoDashboardResults_10);
                for (var i = 0; i < spCmoDashboardResults_10.Count; i++)
                {
                    if (spCmoDashboardResults_10[i].LaneStatus == 0)
                    {
                        totalLane_IsClose += 1;
                    }
                }
                //totalLane_IsOpen = spCmoDashboardResults.Count - totalLane_IsClose;
                //txtTotalLane_IsClose.Text = totalLane_IsClose.ToString();
                //txtTotalLane_IsOpen.Text = totalLane_IsOpen.ToString();
                dgvListSearchResult_10.ItemsSource = spCmoDashboardResults_10;
                //--------CUOI TUYEN------------------
                List<sp_CMO_DASHBOARD_Result>  spCmoDashboardResults_CT = tollManegement_Ctrl.GetDashBoardList(5);//CT
                if (spCmoDashboardResults_CT == null)
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    dgvListSearchResult.ItemsSource = null;
                    return;
                }
                spCmoDashboardResults_CT.RemoveAll(p => p.IsUsed == false);
                Mouse.OverrideCursor = Cursors.Arrow;
                rs = Utility.ConvertToDataTable(spCmoDashboardResults_CT);
                for (var i = 0; i < spCmoDashboardResults_CT.Count; i++)
                {
                    if (spCmoDashboardResults_CT[i].LaneStatus == 0)
                    {
                        totalLane_IsClose += 1;
                    }
                }
                dgvListSearchResult_CT.ItemsSource = spCmoDashboardResults_CT;
                //--------DINH VU------------------
                List<sp_CMO_DASHBOARD_Result>  spCmoDashboardResults_DV = tollManegement_Ctrl.GetDashBoardList(6);//DV
                if (spCmoDashboardResults_DV == null)
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    dgvListSearchResult.ItemsSource = null;
                    return;
                }
                spCmoDashboardResults_DV.RemoveAll(p => p.IsUsed == false);
                Mouse.OverrideCursor = Cursors.Arrow;
                rs = Utility.ConvertToDataTable(spCmoDashboardResults_DV);
                for (var i = 0; i < spCmoDashboardResults_DV.Count; i++)
                {
                    if (spCmoDashboardResults_DV[i].LaneStatus == 0)
                    {
                        totalLane_IsClose += 1;
                    }
                }
              
                dgvListSearchResult_DV.ItemsSource = spCmoDashboardResults_DV;
                //--------353------------------
                List<sp_CMO_DASHBOARD_Result> spCmoDashboardResults_353 = tollManegement_Ctrl.GetDashBoardList(7);//353
                if (spCmoDashboardResults_353 == null)
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    dgvListSearchResult.ItemsSource = null;
                    return;
                }
                spCmoDashboardResults_353.RemoveAll(p => p.IsUsed == false);
                Mouse.OverrideCursor = Cursors.Arrow;
                rs = Utility.ConvertToDataTable(spCmoDashboardResults_353);
                for (var i = 0; i < spCmoDashboardResults_353.Count; i++)
                {
                    if (spCmoDashboardResults_353[i].LaneStatus == 0)
                    {
                        totalLane_IsClose += 1;
                    }
                }

                dgvListSearchResult_353.ItemsSource = spCmoDashboardResults_353;
                //---------------

                totalLane_IsOpen = (spCmoDashboardResults.Count + spCmoDashboardResults_39.Count + spCmoDashboardResults_38.Count + spCmoDashboardResults_10.Count + spCmoDashboardResults_CT.Count + spCmoDashboardResults_DV.Count + spCmoDashboardResults_353.Count) - totalLane_IsClose;
                txtTotalLane_IsClose.Text = totalLane_IsClose.ToString();
                txtTotalLane_IsOpen.Text = totalLane_IsOpen.ToString();
                //txtLastUpdate.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
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

        private void CloseClick(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void MinimizeClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
