using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TollManagement.Common;
using TollManagement.Data;
using TollTicketManagement.Common;
using TollTicketManagement.Controller;

namespace TollTicketManagement
{
    /// <summary>
    /// Interaction logic for ManagementView.xaml
    /// </summary>
    public partial class ManagementView : Window
    {
        TollManagement_Ctrl tollManegement_Ctrl = new TollManagement_Ctrl();
        Shift_Ctrl shift_Ctrl = new Shift_Ctrl();
        Station_Ctrl station_Ctrl = new Station_Ctrl();
        List<sp_GetInLane_Result> listInLane;
        List<sp_GetOutLane_Result> listOutLane;
         
        public ManagementView()
        {
            InitializeComponent();
            listInLane = station_Ctrl.GetInLane().ToList();
            listOutLane = station_Ctrl.GetOutLane().ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var closeButton = GetTemplateChild("closeButton") as Button;
                if (closeButton != null)
                    closeButton.Click += CloseClick;
                dtpFromDate.SelectedDate = DateTime.Now;
                //dtpToDate.SelectedDate = DateTime.Now;
                //dtpFromTime.Value = DateTime.Now;
                //dtpToTime.Value = DateTime.Now;
                //GetData();
                //List Shift
                var shifts = shift_Ctrl.GetAllShift();
                //shifts.Insert(0, new sp_LS_Shift_GetAll_Result { Name = "Tất cả", Code = string.Empty });
                cbShift.ItemsSource = shifts;
                cbShift.DisplayMemberPath = "Name";
                cbShift.SelectedValuePath = "Code";
                cbShift.SelectedIndex = 0;

                System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += dispatcherTimer_Tick;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
                dispatcherTimer.Start();
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
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            GetData();   
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            GetData();   
        }

        private void GetData()
        {
            try
            {
                DateTime fromDate, toDate, pStartTime, pEndTime;
                int shiftID;
                if (chkRealTime.IsChecked == true)
                {
                    shiftID = int.Parse(shift_Ctrl.GetCurrentShift().ToString());
                    var shiftModel = shift_Ctrl.GetShiftByShiftID(shiftID);

                    DateTime.TryParse(shiftModel.StartTime, out pStartTime);
                    DateTime.TryParse(shiftModel.EndTime, out pEndTime); 
                    fromDate = Utility.GetDateTime(pStartTime);
                    if (shiftID == 3)
                    {
                        toDate = Utility.GetDateTime_Shift3(pEndTime);
                    }
                    else
                    {
                        toDate = Utility.GetDateTime(pEndTime);
                    }
                }
                else
                {
                    shiftID = int.Parse(cbShift.Text.Trim());
                    var shiftModel = shift_Ctrl.GetShiftByShiftID(shiftID);
                    DateTime.TryParse(shiftModel.StartTime, out pStartTime);
                    DateTime.TryParse(shiftModel.EndTime, out pEndTime);
                    fromDate = Utility.GetDateTime(dtpFromDate,pStartTime);
                    if (shiftID == 3)
                    {
                        toDate = Utility.GetDateTime_Shift3(dtpFromDate, pEndTime);
                    }
                    else
                    {
                        toDate = Utility.GetDateTime(dtpFromDate, pEndTime);
                    }
                }
                
                DataTable rs = new DataTable();
                int sum = 0; //Tong ton kho toan tuyen
                Mouse.OverrideCursor = Cursors.Wait;
                List<cts_supervision_sp_rpt_TollManagement_Result> rptTollManagementResults = tollManegement_Ctrl.GetAll(-1, fromDate, toDate, 0, shiftID, 1, 3, 12, 30);
                if (rptTollManagementResults == null)
                {
                    Mouse.OverrideCursor = Cursors.Arrow;
                    dgvListSearchResult.ItemsSource = null;
                    return;
                }
                Mouse.OverrideCursor = Cursors.Arrow;
                
                rs = Utility.ConvertToDataTable(rptTollManagementResults);

                for (int row = 0; row < rptTollManagementResults.Count; row++)
                {
                    rptTollManagementResults[row].SumIn = 0;
                    rptTollManagementResults[row].SumOut = 0;
                    sum += (int)rptTollManagementResults[row].InStock;

                    var sumInOut = listInLane[row].SumInLane + listOutLane[row].SumOutLane; //Tổng số làn của từng trạm 
                    for (int i = 0; i < sumInOut; i++)
                    {
                        if (i < listInLane[row].SumInLane)
                        {
                            rptTollManagementResults[row].SumIn += string.IsNullOrEmpty(rs.Rows[row][i + 1].ToString()) ? 0 : Convert.ToInt32(rs.Rows[row][i + 1].ToString().Replace(".", ""));
                        }
                        else
                        {
                            if (rptTollManagementResults[row].StationName == "Đình Vũ")
                            {
                                rptTollManagementResults[row].SumOut +=
                                    string.IsNullOrEmpty(rs.Rows[row][i + 3].ToString())
                                        ? 0
                                        : Convert.ToInt32(rs.Rows[row][i + 3].ToString().Replace(".", ""));
                                ;
                            }
                            else
                                rptTollManagementResults[row].SumOut +=
                                    string.IsNullOrEmpty(rs.Rows[row][i + 1].ToString())
                                        ? 0
                                        : Convert.ToInt32(rs.Rows[row][i + 1].ToString().Replace(".", ""));
                            ;
                            }
                    }
                }
                txtSumInStock.Text = sum.ToString();
                dgvListSearchResult.ItemsSource = rptTollManagementResults;
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

        private void dgvListSearchResult_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var heightWindow = ActualHeight;
            DataGridRow row = e.Row;
            row.Height = (heightWindow - 95 - txtTitle.ActualHeight) / 6;
        }

        private void ManagementView_OnClosed(object sender, EventArgs e)
        {
            Close();
        }

        private void chkRealTime_Checked(object sender, RoutedEventArgs e)
        {
            if (chkRealTime.IsChecked == true)
            {
                dgvListSearchResult.ItemsSource = null;
                dtpFromDate.IsEnabled = false;
                cbShift.IsEnabled = false;
                btnSearch.IsEnabled = false;
            }
        }

        private void chkRealTime_Unchecked(object sender, RoutedEventArgs e)
        {
            if (chkRealTime.IsChecked == false)
            {
                dtpFromDate.IsEnabled = true;
                cbShift.IsEnabled = true;
                btnSearch.IsEnabled = true;
            }
        }
    }
}
