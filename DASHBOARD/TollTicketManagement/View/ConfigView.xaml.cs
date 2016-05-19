using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TollManagement.Common;
using TollManagement.Data;
using TollTicketManagement.Common;
using TollTicketManagement.Controller;
using TollTicketManagement.Model;
using TollTicketManagement.Resources.Message;

namespace TollTicketManagement.View
{
    /// <summary>
    ///     Interaction logic for ConfigView.xaml
    /// </summary>
    public partial class ConfigView : Window
    {
        #region Member.

        private Config_Ctrl _ConfigController;
        private DatabaseConfigModel _DatabaseConfig;
        private TrackChangeControlValues _TrackChangeTab1;
        private Station_Ctrl stationController;

        #endregion

        public ConfigView()
        {
            InitializeComponent();
            //Load thông tin config đã lưu
            LoadDatabaseControls();
            LoadCommonControl();
        }

        private void LoadDatabaseControls()
        {
            _ConfigController = new Config_Ctrl();

            // Init Priority
            cbxActiveServer.Items.Add("Máy chủ 1");
            cbxActiveServer.Items.Add("Máy chủ 2");
            cbxActiveServer.SelectedIndex = 0;

            //Get Database Configuration from the Registry
            _DatabaseConfig = Config_Ctrl.GetDatabaseConfig();

            //Database Configuration was already in the Registry
            if (_DatabaseConfig != null)
            {
                // set the control's values with the Registry values
                // and store to BaseController
                SetDatabaseControlValue(_DatabaseConfig);
            }
        }

        private void SetDatabaseControlValue(DatabaseConfigModel pDatabaseConfig)
        {
            cbxServerName1.Text = pDatabaseConfig.Server1;
            cbxDBName1.Text = pDatabaseConfig.Database1;
            txtUserName1.Text = pDatabaseConfig.Username1;
            txtPassword1.Password = pDatabaseConfig.Password1;
            txtTimeout1.Text = pDatabaseConfig.Timeout1;

            cbxServerName2.Text = pDatabaseConfig.Server2;
            cbxDBName2.Text = pDatabaseConfig.Database2;
            txtUserName2.Text = pDatabaseConfig.Username2;
            txtPassword2.Password = pDatabaseConfig.Password2;
            txtTimeout2.Text = pDatabaseConfig.Timeout2;

            cbxActiveServer.SelectedIndex = pDatabaseConfig.ActiveServer - 1;

            if (pDatabaseConfig.ActiveServer == 1)
            {
                Base_Ctrl.ServerName = pDatabaseConfig.Server1;
                Base_Ctrl.Database = pDatabaseConfig.Database1;
                Base_Ctrl.UserID = pDatabaseConfig.Username1;
                Base_Ctrl.Password = pDatabaseConfig.Password1;
                Base_Ctrl.TimeOut = int.Parse(pDatabaseConfig.Timeout1);
            }
            else
            {
                Base_Ctrl.ServerName = pDatabaseConfig.Server2;
                Base_Ctrl.Database = pDatabaseConfig.Database2;
                Base_Ctrl.UserID = pDatabaseConfig.Username2;
                Base_Ctrl.Password = pDatabaseConfig.Password2;
                Base_Ctrl.TimeOut = int.Parse(pDatabaseConfig.Timeout2);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var closeButton = GetTemplateChild("closeButton") as Button;
            if (closeButton != null) closeButton.Click += CloseClick;
            InitTrackChangeControlValues();
            cbTypeImage.ItemsSource = Enum.GetValues(typeof(SupervisionConfig.ImageExtension)).Cast<SupervisionConfig.ImageExtension>();
            LoadSupervisionConfig();
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void InitTrackChangeControlValues()
        {
            // TrackChangeTab1
            Control[] lstControls1 =
            {
                cbxServerName1, cbxServerName2, cbxDBName1, cbxDBName2,
                txtUserName1, txtUserName2, txtPassword1, txtPassword2,
                txtTimeout1, txtTimeout2, cbxActiveServer
            };
            _TrackChangeTab1 = new TrackChangeControlValues(lstControls1.ToList());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadSupervisionConfig()
        {
            try
            {
                stationController = new Station_Ctrl();
                IEnumerable<sp_LS_Station_GetAll_Result> stations = stationController.GetAllStation();
                cbStation.ItemsSource = stations;
                cbStation.DisplayMemberPath = "Name";
                cbStation.SelectedValuePath = "StationCode";

                _ConfigController = new Config_Ctrl();
                SupervisionConfigModel model = _ConfigController.GetSupervisionConfig();
                //first load
                if (model == null)
                {
                    // rdoStation.IsChecked = true;
                    cbStation.SelectedIndex = 0;
                }
                else
                {
                    //if (model.isTOC == 1)
                    //{
                    //    rdoStation.IsChecked = true;
                    //}
                    //if (model.isTOC == 0)
                    //{
                    //    rdoStationCenter.IsChecked = true;
                    //}
                    cbStation.SelectedIndex = int.Parse(model.StationCode);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
        }

        private SupervisionConfigModel GetSupervisionConfigValue()
        {
            var model = new SupervisionConfigModel();

            try
            {
                model.StationCode = cbStation.SelectedIndex.ToString();
                if (model.StationCode != null && model.StationCode == "0")
                {
                    model.isTOC = 1;
                }
                else
                {
                    model.isTOC = 0;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name,
                        ex.Message);
                }
            }
            return model;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private string CheckControlBlank()
        {
            string result = string.Empty;

            if (TabControl1.SelectedItem == TabDatabase)
            {
                result = CheckDatabaseControlBlank();
            }

            return result;
        }

        // Check Database Control blank.
        private string CheckDatabaseControlBlank()
        {
            string result = string.Empty;
            // Máy chủ 1.
            if (string.IsNullOrWhiteSpace(cbxServerName1.Text))
            {
                result += " - Tên máy chủ 1.\r\n";
            }
            if (string.IsNullOrWhiteSpace(cbxDBName1.Text))
            {
                result += " - Tên database máy chủ 1.\r\n";
            }
            if (string.IsNullOrWhiteSpace(txtUserName1.Text))
            {
                result += " - Tên người dùng máy chủ 1.\r\n";
            }
            if (string.IsNullOrWhiteSpace(txtPassword1.Password))
            {
                result += " - Mật khẩu máy chủ 1.\r\n";
            }
            if (string.IsNullOrWhiteSpace(txtTimeout1.Text))
            {
                txtTimeout1.Text = "30";
            }

            // Máy chủ 2.
            if (string.IsNullOrWhiteSpace(cbxServerName2.Text))
            {
                result += " - Tên máy chủ 2.\r\n";
            }
            if (string.IsNullOrWhiteSpace(cbxDBName2.Text))
            {
                result += " - Tên database máy chủ 2.\r\n";
            }
            if (string.IsNullOrWhiteSpace(txtUserName2.Text))
            {
                result += " - Tên người dùng máy chủ 2.\r\n";
            }
            if (string.IsNullOrWhiteSpace(txtPassword2.Password))
            {
                result += " - Mật khẩu máy chủ 2.\r\n";
            }
            if (string.IsNullOrWhiteSpace(txtTimeout2.Text))
            {
                txtTimeout2.Text = "30";
            }

            return result;
        }

        private string CheckDatabaseControlBlank_DB2()
        {
            string result = string.Empty;

            // Máy chủ 2.
            if (string.IsNullOrWhiteSpace(cbxServerName2.Text))
            {
                result += " - Tên máy chủ 2.\r\n";
            }
            if (string.IsNullOrWhiteSpace(cbxDBName2.Text))
            {
                result += " - Tên database máy chủ 2.\r\n";
            }
            if (string.IsNullOrWhiteSpace(txtUserName2.Text))
            {
                result += " - Tên người dùng máy chủ 2.\r\n";
            }
            if (string.IsNullOrWhiteSpace(txtPassword2.Password))
            {
                result += " - Mật khẩu máy chủ 2.\r\n";
            }
            if (string.IsNullOrWhiteSpace(txtTimeout2.Text))
            {
                txtTimeout2.Text = "30";
            }

            return result;
        }

        private bool Save()
        {
            string result = string.Empty;
            result = CheckControlBlank();

            if (!string.IsNullOrWhiteSpace(result))
            {
                result = "Vui lòng nhập đủ thông tin" + result;
                MessageBox.Show(result, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            //Cursor prevCursor = Mouse.OverrideCursor;
            //Mouse.OverrideCursor = Cursors.Wait;
            //if (TabControl1.SelectedItem == TabDatabase && !BaseController.TestConnection())
            //{
            //    Mouse.OverrideCursor = prevCursor;
            //    MessageBox.Show(MainMessage.errConnectDatabaseFail, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return false;
            //}

            if (TabControl1.SelectedItem == TabDatabase)
            {
                SaveDatabaseConfig();
                SaveSupervisionConfig();
            }
            else if (TabControl1.SelectedItem == TabCommon)
            {
                SaveCommonConfig();
            }

            return true;
        }

        private void SaveDatabaseConfig()
        {
            DatabaseConfigModel oDatabaseConfigModel = GetDatabaseControlValue();
            _ConfigController.SaveDatabaseConfig(oDatabaseConfigModel);
            _TrackChangeTab1.LstControlChanged.Clear();
            if (oDatabaseConfigModel.ActiveServer == 1)
            {
                Base_Ctrl.ServerName = oDatabaseConfigModel.Server1;
                Base_Ctrl.Database = oDatabaseConfigModel.Database1;
                Base_Ctrl.UserID = oDatabaseConfigModel.Username1;
                Base_Ctrl.Password = oDatabaseConfigModel.Password1;
                Base_Ctrl.TimeOut = int.Parse(oDatabaseConfigModel.Timeout1);
                Base_Ctrl._primaryConnectionString = Base_Ctrl.GetConnectionString
                    (oDatabaseConfigModel.Server1, oDatabaseConfigModel.Database1, oDatabaseConfigModel.Username1,
                        oDatabaseConfigModel.Password1, oDatabaseConfigModel.Timeout1);
            }
            else
            {
                Base_Ctrl.ServerName = oDatabaseConfigModel.Server2;
                Base_Ctrl.Database = oDatabaseConfigModel.Database2;
                Base_Ctrl.UserID = oDatabaseConfigModel.Username2;
                Base_Ctrl.Password = oDatabaseConfigModel.Password2;
                Base_Ctrl.TimeOut = int.Parse(oDatabaseConfigModel.Timeout2);
                Base_Ctrl._primaryConnectionString = Base_Ctrl.GetConnectionString
                    (oDatabaseConfigModel.Server2, oDatabaseConfigModel.Database2, oDatabaseConfigModel.Username2,
                        oDatabaseConfigModel.Password2, oDatabaseConfigModel.Timeout2);
            }
            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SaveCommonConfig()
        {
            var configModel = GetCommonControlValue();
            _ConfigController.SaveDirectoryConfig(configModel);
            MessageBox.Show("Lưu dữ liệu thành công", "Thông báo !", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private CommonConfigModel GetCommonControlValue()
        {
            CommonConfigModel result = new CommonConfigModel();
            result.EntryFolderPath = txtEntryFolder.Text;
            result.ExitFolderPath = txtExitFolder.Text;
            result.RecognizeFolderPath = txtRecogFolder.Text;
            result.StandardFolderPath = txtStandarFolder.Text;
            result.ImageType = Convert.ToString(cbTypeImage.SelectedValue);

            int maxTime = 0;
            int.TryParse(txtMaxTime.Text, out maxTime);
            maxTime = maxTime <= 0 ? 1 : maxTime;
            txtMaxTime.Text = Convert.ToString(maxTime);
            result.MaxTime = maxTime;

            return result;
        }

        private void SaveSupervisionConfig()
        {
            try
            {
                var model = GetSupervisionConfigValue();
                _ConfigController = new Config_Ctrl();
                _ConfigController.SaveSupervisionConfig(model);
                //MessageBox.Show(SUP_Message.MSG_SaveSuccess, SUP_Message.MES_Notification, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
        }

        private DatabaseConfigModel GetDatabaseControlValue()
        {
            var result = new DatabaseConfigModel();
            result.Server1 = cbxServerName1.Text;
            result.Username1 = txtUserName1.Text;
            result.Password1 = txtPassword1.Password;
            result.Database1 = cbxDBName1.Text;
            result.Timeout1 = txtTimeout1.Text;

            result.Server2 = cbxServerName2.Text;
            result.Username2 = txtUserName2.Text;
            result.Password2 = txtPassword2.Password;
            result.Database2 = cbxDBName2.Text;
            result.Timeout2 = txtTimeout2.Text;

            result.ActiveServer = cbxActiveServer.SelectedIndex + 1;
            return result;
        }

        private void btnTestConn1_Click(object sender, RoutedEventArgs e)
        {
            string result = string.Empty;
            result = CheckDatabaseControlBlank_DB1();

            if (!string.IsNullOrWhiteSpace(result))
            {
                result = SUP_Message.MES_NotAllowEmpty + result;
                MessageBox.Show(result, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Cursor prevCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            TestConnection(cbxServerName1.Text, cbxDBName1.Text, txtUserName1.Text, txtPassword1.Password,
                txtTimeout1.Text);
            Mouse.OverrideCursor = prevCursor;
        }

        private bool TestConnection(object pServerName, object pDatabaseName, object pUserID, object pPassword,
            object pTimeout)
        {
            bool result = false;
            string conString = Base_Ctrl.GetConnectionString2(pServerName.ToString(), pDatabaseName.ToString(),
                pUserID.ToString(), pPassword.ToString(), pTimeout.ToString());
            result = Base_Ctrl.TestConnection(conString);
            if (result)
            {
                MessageBox.Show("Kết nối CSDL thành công", "Thông báo", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Kết nối CSDL thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return result;
        }

        private string CheckDatabaseControlBlank_DB1()
        {
            string result = string.Empty;
            // Máy chủ 1.
            if (string.IsNullOrWhiteSpace(cbxServerName1.Text))
            {
                result += " - Tên máy chủ 1.\r\n";
            }
            if (string.IsNullOrWhiteSpace(cbxDBName1.Text))
            {
                result += " - Tên database máy chủ 1.\r\n";
            }
            if (string.IsNullOrWhiteSpace(txtUserName1.Text))
            {
                result += " - Tên người dùng máy chủ 1.\r\n";
            }
            if (string.IsNullOrWhiteSpace(txtPassword1.Password))
            {
                result += " - Mật khẩu máy chủ 1.\r\n";
            }
            if (string.IsNullOrWhiteSpace(txtTimeout1.Text))
            {
                txtTimeout1.Text = "30";
            }

            return result;
        }

        private void txtTimeout1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var vTb = new ValidateTextBox();
            e.Handled = !vTb.OnlyNumberAllowed(e.Text);
        }

        private void btnTestConn2_Click(object sender, RoutedEventArgs e)
        {
            string result = string.Empty;
            result = CheckDatabaseControlBlank_DB2();

            if (!string.IsNullOrWhiteSpace(result))
            {
                result = SUP_Message.MES_NotAllowEmpty + result;
                MessageBox.Show(result, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Cursor prevCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            TestConnection(cbxServerName2.Text, cbxDBName2.Text, txtUserName2.Text, txtPassword2.Password,
                txtTimeout2.Text);
            Mouse.OverrideCursor = prevCursor;
        }

        void LoadCommonControl()
        {
            var commonConfigModel = _ConfigController.GetDirectoryConfig();
            try
            {
                if (commonConfigModel != null)
                {
                    txtEntryFolder.Text = commonConfigModel.EntryFolderPath;
                    txtExitFolder.Text = commonConfigModel.ExitFolderPath;
                    txtRecogFolder.Text = commonConfigModel.RecognizeFolderPath;
                    txtStandarFolder.Text = commonConfigModel.StandardFolderPath;
                    if (commonConfigModel.MaxTime > 0)
                    {
                        txtMaxTime.Text = Convert.ToString(commonConfigModel.MaxTime);
                    }
                    else
                    {
                        txtMaxTime.Text = "1";
                    }

                    //if the first time this will be null
                    if (!string.IsNullOrWhiteSpace(commonConfigModel.ImageType))
                    {
                        var index = (int)((SupervisionConfig.ImageExtension)Enum.Parse(typeof(SupervisionConfig.ImageExtension), commonConfigModel.ImageType));
                        cbTypeImage.SelectedIndex = index;
                    }
                }

            }
            catch (Exception ex)
            {
                //log here

            }
        }

        private void btnSelEntryFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();
            txtEntryFolder.Text = dialog.SelectedPath;
        }

        private void btnSelExitFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();
            txtExitFolder.Text = dialog.SelectedPath;
        }

        private void btnSelRecofFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();
            txtRecogFolder.Text = dialog.SelectedPath;
        }

        private void btnSelStandarFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();
            txtStandarFolder.Text = dialog.SelectedPath;
        }
    }
}