using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using TollManagement.Common;

namespace TollTicketManagement.Common
{
    public class Utility
    {
        public static string ImageFolderDisconnectUri = @"pack://application:,,,/ITD.CTS.Supervision.HDLE_UI;component/Resources/Images/ImageDisconnect.png";
        public static DateTime GetDateTime(DatePicker dtpDate, Xceed.Wpf.Toolkit.DateTimeUpDown dtpTime)
        {
            try
            {
                if (dtpTime.Value != null)
                {
                    if (dtpDate.SelectedDate != null)
                    {
                        return new DateTime(dtpDate.SelectedDate.Value.Year,
                            dtpDate.SelectedDate.Value.Month,
                            dtpDate.SelectedDate.Value.Day,
                            dtpTime.Value.Value.Hour,
                            dtpTime.Value.Value.Minute,
                            dtpTime.Value.Value.Second);
                    }
                    return new DateTime();
                }
                return new DateTime();
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
                return new DateTime();
            }
        }

        public static DateTime GetDateTime(DateTime pStartTime)
        {
            try
            {
                    return new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month,
                        DateTime.Now.Day,
                        pStartTime.Hour,
                        pStartTime.Minute,
                        pStartTime.Second);
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
                return new DateTime();
            }
        }

        public static DateTime GetDateTime(DatePicker dtpDate, DateTime pStartTime)
        {
            try
            {
                return new DateTime(dtpDate.SelectedDate.Value.Year,
                            dtpDate.SelectedDate.Value.Month,
                            dtpDate.SelectedDate.Value.Day,
                            pStartTime.Hour,
                            pStartTime.Minute,
                            pStartTime.Second);
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
                return new DateTime();
            }
        }
        public static DateTime GetDateTime_Shift3(DatePicker dtpDate, DateTime pStartTime)
        {
            try
            {
                return new DateTime(dtpDate.SelectedDate.Value.Year,
                        dtpDate.SelectedDate.Value.Month,
                        dtpDate.SelectedDate.Value.Day + 1,
                        pStartTime.Hour,
                        pStartTime.Minute,
                        pStartTime.Second);
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
                return new DateTime();
            }
        }
        public static DateTime GetDateTime_Shift3(DateTime pStartTime)
        {
            try
            {
                return new DateTime(DateTime.Now.Year,
                    DateTime.Now.Month,
                    DateTime.Now.Day + 1,
                    pStartTime.Hour,
                    pStartTime.Minute,
                    pStartTime.Second);
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
                return new DateTime();
            }
        }
        public static string CreateImgPath(string entrytransactionID)
        {
            var path = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(entrytransactionID))
                {
                    return null;
                }

                var year = entrytransactionID.Substring(0, 2);

                var month = entrytransactionID.Substring(2, 2);

                var day = entrytransactionID.Substring(4, 2);

                var hour = entrytransactionID.Substring(6, 2);

                var index = entrytransactionID.Length - 4;

                var stationNlane = entrytransactionID.Substring(index, 4);

                var strationCode = stationNlane.Substring(0, 2);

                path = string.Format(@"{0}\{1}\{2}\{3}\{4}\{5}\20", strationCode, "20" + year, month, day, hour, stationNlane);

                return path;
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

            return path;
        }

        public static BitmapImage GetImage(string pFilePath)
        {
            BitmapImage bmp = null;
            try
            {
                if (!File.Exists(pFilePath))
                    return null;
                var f = new FileInfo(pFilePath);
                if (f.Length > 0)
                {
                    bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = new Uri(pFilePath, UriKind.Absolute);
                    bmp.CacheOption = BitmapCacheOption.OnLoad;
                    bmp.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    bmp.EndInit();
                }
                else
                {
                    LogUtility.WriteLogFile_Capture(pFilePath, "size=0");
                }
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
            return bmp;

        }

        public static BitmapImage GetImageResource(string pFilePath)
        {
            BitmapImage bmp = null;
            try
            {
                bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = new Uri(pFilePath, UriKind.Absolute);
                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bmp.EndInit();
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
            return bmp;

        }

        //public static ImageSource GetImageResource(string channel)
        //{
        //    BitmapImage bmp = new BitmapImage(new Uri(channel));
        //    return bmp;
        //}
        private static void InvokeIfRequired(System.Windows.Threading.DispatcherObject control, Action methodcall, System.Windows.Threading.DispatcherPriority priorityForCall)
        {
            //see if we need to Invoke call to Dispatcher thread  
            if (control.Dispatcher.Thread != System.Threading.Thread.CurrentThread)
                control.Dispatcher.Invoke(priorityForCall, methodcall);
            else
                methodcall();
        }

        public static string GetComBoxSelectedValue(System.Windows.Controls.ComboBox c)
        {

            string res = "";
            // string rs = null;
            try
            {
                InvokeIfRequired(c, () => { res = c.SelectedValue.ToString(); }, System.Windows.Threading.DispatcherPriority.Background);
            }
            catch (Exception ex)
            {
                //LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            }

            return res;
        }

        public static bool TestConnection()
        {
            //bool result = false;
            //string conString = BaseController.GetConnectionString2(pServerName.ToString(), pDatabaseName.ToString(), pUserID.ToString(), pPassword.ToString(), pTimeout.ToString());
            //return Base_Ctrl.TestConnection(Base_Ctrl._primaryConnectionString);
            //if (result)
            //{
            //    //MessageBox.Show("Kết nối CSDL thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    //MessageBox.Show("Kết nối CSDL thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //return result;
            return true;
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException ex)
            {
                return pingable;
            }
            return pingable;
        }

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int X,
            int Y,
            int cx,
            int cy,
            uint uFlags);

        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;

        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        public static void SendWpfWindowBack(System.Windows.Window window)
        {
            var hWnd = new WindowInteropHelper(window).Handle;
            SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE);
        }
    }
}
