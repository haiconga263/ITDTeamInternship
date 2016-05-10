using System;
using System.Windows;
using Microsoft.Win32;
using TollManagement.Common;

namespace TollTicketManagement.Common
{
    public class ModifyRegistry
    {
        private string _rootKey = "";
        public string RootKey
        {
            get { return _rootKey; }
            set { _rootKey = value; }
        }

        public ModifyRegistry(RegistryKey baseRegistryKey, string rootKey)
        {
            _baseRegistryKey = baseRegistryKey;
            _rootKey = rootKey;
        }

        private RegistryKey _baseRegistryKey = Registry.CurrentUser;
        public RegistryKey BaseRegistryKey
        {
            get { return _baseRegistryKey; }
            set { _baseRegistryKey = value; }
        }

        public string Read(string keyName)
        {
            RegistryKey rk = _baseRegistryKey;
            RegistryKey sk1 = rk.OpenSubKey(_rootKey);
            if (sk1 == null)
            {
                return null;
            }
            try
            {
                return Convert.ToString(sk1.GetValue(keyName.ToUpper()));
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, "Reading registry " + keyName.ToUpper());
                if (e.InnerException != null)
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message + ".InnerMessage:" + e.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                }
                return null;
            }
        }
        public bool Write(string keyName, object value)
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(_rootKey);
                sk1.SetValue(keyName.ToUpper(), value);
                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, "Writing registry " + keyName.ToUpper());
                if (e.InnerException != null)
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message + ".InnerMessage:" + e.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                }
                return false;
            }
        }
        public bool DeleteKey(string keyName)
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(_rootKey);
                if (sk1 == null)
                    return true;
                else
                    sk1.DeleteValue(keyName);

                return true;
            }
            catch (Exception e)
            {
                // AAAAAAAAAAARGH, an error!
                ShowErrorMessage(e, "Deleting SubKey " + _rootKey);
                if (e.InnerException != null)
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message + ".InnerMessage:" + e.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                }
                return false;
            }
        }
        public bool DeleteSubKeyTree()
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(_rootKey);
                if (sk1 != null)
                    rk.DeleteSubKeyTree(_rootKey);
                return true;
            }
            catch (Exception e)
            {
                ShowErrorMessage(e, "Deleting SubKey " + _rootKey);
                if (e.InnerException != null)
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message + ".InnerMessage:" + e.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                }
                return false;
            }
        }

        public int SubKeyCount()
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(_rootKey);
                if (sk1 != null)
                    return sk1.SubKeyCount;
                else
                    return 0;
            }
            catch (Exception e)
            {
                // AAAAAAAAAAARGH, an error!
                ShowErrorMessage(e, "Retriving subkeys of " + _rootKey);
                if (e.InnerException != null)
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message + ".InnerMessage:" + e.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                }
                return 0;
            }
        }
        public int ValueCount()
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(_rootKey);
                if (sk1 != null)
                    return sk1.ValueCount;
                else
                    return 0;
            }
            catch (Exception e)
            {
                // AAAAAAAAAAARGH, an error!
                ShowErrorMessage(e, "Retriving keys of " + _rootKey);
                if (e.InnerException != null)
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message + ".InnerMessage:" + e.InnerException.Message);
                }
                else
                {
                    LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, e.Message);
                }
                return 0;
            }
        }

        private void ShowErrorMessage(Exception e, string title)
        {
            MessageBox.Show(e.Message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
