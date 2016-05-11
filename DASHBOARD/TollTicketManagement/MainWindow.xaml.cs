using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using TollManagement.Common;
using TollTicketManagement.Common;
using TollTicketManagement.Controller;
using TollTicketManagement.Model;
using TollTicketManagement.View;

namespace TollTicketManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _ReleaseDate = "Ngày cập nhật: 19/01/2016 08:00:00";
        private MenuItem btnChangePassword;
        private MenuItem btnLogin;
        private MenuItem btnLogout;
        private MenuItem btnQuit;

        public MainWindow()
        {
            InitializeComponent();
            //this.Hide();
            //ManagementView managementView = new ManagementView();
            //managementView.Activate();
            //managementView.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            //Date formate
            CultureInfo ci = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            ci.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = ci;

            var closeButton = GetTemplateChild("closeButton") as Button;
            if (closeButton != null) closeButton.Click += CloseClick;

            btnQuit = GetTemplateChild("btnQuit") as MenuItem;
            if (btnQuit != null) btnQuit.Click += btnQuitClick;

            var minimizeButton = GetTemplateChild("minimizeButton") as Button;
            if (minimizeButton != null) minimizeButton.Click += MinimizeClick;

            try
            {
                //If the databse configuration is already store in the Registry => show login form
                if (IsDatabaseConfigInRegistry())
                {
                    lblStatusConnect.Content = "MÁY CHỦ: " + SupervisionConfig.ServerName.ToUpper();
                    //Load time
                    var timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal,
                        delegate { lblDateTime.Content = "Ngày giờ: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"); }, Dispatcher);
                    lblVersion.Content = _ReleaseDate;
                    //Focus first tab
                    TabControl1.SelectedItem = TabDashBoard;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
        }

       

        private bool IsDatabaseConfigInRegistry()
        {
            try
            {
                // get the databse configuration from the Registry
                // Server, DatabaseName, UserName, Password, Timeout ????
                DatabaseConfigModel _databaseConfigModel = Config_Ctrl.GetDatabaseConfig();
                if (_databaseConfigModel == null)
                {
                    // Chưa cấu hình cơ sở dữ liệu
                    MessageBox.Show("Không có kết nối CSDL", "Thông báo", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    //Focus vào tab cầu hình
                    ConfigView configView = new ConfigView();
                    configView.ShowDialog();
                    return false;
                }

                string sConString;
                if (_databaseConfigModel.ActiveServer == 1)
                {
                    sConString = Base_Ctrl.GetConnectionString2(
                        _databaseConfigModel.Server1, _databaseConfigModel.Database1,
                        _databaseConfigModel.Username1, _databaseConfigModel.Password1, _databaseConfigModel.Timeout1);
                  
                    // Test the connection if necessary

                    SupervisionConfig.ServerName = _databaseConfigModel.Server1;
                    Base_Ctrl.ServerName = _databaseConfigModel.Server1;
                    Base_Ctrl.Database = _databaseConfigModel.Database1;
                    Base_Ctrl.UserID = _databaseConfigModel.Username1;
                    Base_Ctrl.Password = _databaseConfigModel.Password1;
                    Base_Ctrl.TimeOut = int.Parse(_databaseConfigModel.Timeout1);
                }
                else
                {
                    sConString = Base_Ctrl.GetConnectionString2(_databaseConfigModel.Server2,
                        _databaseConfigModel.Database2, _databaseConfigModel.Username2, _databaseConfigModel.Password2,
                        _databaseConfigModel.Timeout2);
                    
                    // Test the connection if necessary

                    SupervisionConfig.ServerName = _databaseConfigModel.Server2;
                    Base_Ctrl.ServerName = _databaseConfigModel.Server2;
                    Base_Ctrl.Database = _databaseConfigModel.Database2;
                    Base_Ctrl.UserID = _databaseConfigModel.Username2;
                    Base_Ctrl.Password = _databaseConfigModel.Password2;
                    Base_Ctrl.TimeOut = int.Parse(_databaseConfigModel.Timeout2);
                }
                Base_Ctrl._primaryConnectionString = sConString;
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
                return false;
            }
        }

        /// <summary>
        /// Quản lý trạng thái thiết bị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMonitorEquipment_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor prevCursor = Mouse.OverrideCursor;
                Mouse.OverrideCursor = Cursors.Arrow;
                var w = new EquipmentStatusView();
                lblFunctionActiving.Content = w.Title;
                w.Activate();
                w.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
        }

        // Store the config password into the Registry if this is the first time running on this PC
        private void SavePasswordConfig()
        {
            var _ConfigController = new Config_Ctrl();
            string password = _ConfigController.GetRegistry(SupervisionConfig.ConfigPasswordKey);
            if (password == null)
            {
                _ConfigController.SetRegistry(SupervisionConfig.ConfigPasswordKey, SupervisionConfig.ConfigPassword);
            }
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

        /// <summary>
        /// Quản lý thẻ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCardManagement_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var w = new ManagementView();
                lblFunctionActiving.Content = w.Title;
                w.Activate();
                w.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
        }

        private void BtnConfigSystem_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //// store the config password into the Registry if first time running on this PC
                SavePasswordConfig(); 
                var w = new ConfigView();
                lblFunctionActiving.Content = w.Title;
                w.Activate();
                w.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
        }

        private void btnUpdateOutCheckInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor prevCursor = Mouse.OverrideCursor;
                Mouse.OverrideCursor = Cursors.Arrow;
                var w = new UpdateOutCheckInfo();
                lblFunctionActiving.Content = w.Title;
                w.Activate();
                w.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
        }

        private void btnSmartSupervion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor prevCursor = Mouse.OverrideCursor;
                Mouse.OverrideCursor = Cursors.Arrow;
                var w = new UpdatePrecheckStatusView();
                lblFunctionActiving.Content = w.Title;
                w.Activate();
                w.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
        }

        private void BtnDashBoard_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor prevCursor = Mouse.OverrideCursor;
                Mouse.OverrideCursor = Cursors.Arrow;
                var w = new DashboardView();
                lblFunctionActiving.Content = w.Title;
                w.Activate();
                w.ShowDialog();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile_SQL(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
        }

        private void btnLookup_Click(object sender, RoutedEventArgs e)
        {
            var wdn = new wdnLookup();
            wdn.ShowDialog();
        }

        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
