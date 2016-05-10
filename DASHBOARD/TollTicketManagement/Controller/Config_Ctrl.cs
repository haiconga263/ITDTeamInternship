using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using TollManagement.Common;
using TollTicketManagement.Common;
using TollTicketManagement.Model;

namespace TollTicketManagement.Controller
{
    public class Config_Ctrl
    {
        private const string RootKey = "SOFTWARE\\ITD\\CTS\\DeviceManagement";

        #region Database config

        public static DatabaseConfigModel GetDatabaseConfig()
        {
            try
            {
                DatabaseConfigModel databaseConfigModel = null;
                var reg = new ModifyRegistry(Registry.CurrentUser, RootKey);
                var sActiveServer = reg.Read("ActiveServer");

                if (string.IsNullOrWhiteSpace(sActiveServer)) return databaseConfigModel;
                databaseConfigModel = new DatabaseConfigModel();

                var activeServer = 1;//Default sv 1
                int.TryParse(EncodeString.Decode(sActiveServer), out activeServer);
                databaseConfigModel.ActiveServer = activeServer;
                //Server 1 info
                databaseConfigModel.Server1 = EncodeString.Decode(reg.Read("Server1"));
                databaseConfigModel.Database1 = EncodeString.Decode(reg.Read("Database1"));
                databaseConfigModel.Username1 = EncodeString.Decode(reg.Read("Username1"));
                databaseConfigModel.Password1 = EncodeString.Decode(reg.Read("Password1"));
                databaseConfigModel.Timeout1 = EncodeString.Decode(reg.Read("Timeout1"));
                //Server 2 info
                databaseConfigModel.Server2 = EncodeString.Decode(reg.Read("Server2"));
                databaseConfigModel.Database2 = EncodeString.Decode(reg.Read("Database2"));
                databaseConfigModel.Username2 = EncodeString.Decode(reg.Read("Username2"));
                databaseConfigModel.Password2 = EncodeString.Decode(reg.Read("Password2"));
                databaseConfigModel.Timeout2 = EncodeString.Decode(reg.Read("Timeout2"));

                return databaseConfigModel;
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
                return null;
            }
        }

        public DatabaseConfigModel SaveDatabaseConfig(DatabaseConfigModel configModel)
        {
            try
            {
                var reg = new ModifyRegistry(Registry.CurrentUser, RootKey);

                reg.Write("ActiveServer", EncodeString.Encode(configModel.ActiveServer.ToString()));

                reg.Write("Server1", EncodeString.Encode(configModel.Server1));
                reg.Write("Database1", EncodeString.Encode(configModel.Database1));
                reg.Write("Username1", EncodeString.Encode(configModel.Username1));
                reg.Write("Password1", EncodeString.Encode(configModel.Password1));
                reg.Write("Timeout1", EncodeString.Encode(configModel.Timeout1));

                reg.Write("Server2", EncodeString.Encode(configModel.Server2));
                reg.Write("Database2", EncodeString.Encode(configModel.Database2));
                reg.Write("Username2", EncodeString.Encode(configModel.Username2));
                reg.Write("Password2", EncodeString.Encode(configModel.Password2));
                reg.Write("Timeout2", EncodeString.Encode(configModel.Timeout2));

                DatabaseConfigModel result = configModel;
                return result;
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
                return null;
            }
        }

        public string GetRegistry(string key)
        {
            try
            {
                string result = null;
                var reg = new ModifyRegistry(Registry.CurrentUser, RootKey);
                string sConfigPasswordr = reg.Read(key);

                if (!string.IsNullOrWhiteSpace(sConfigPasswordr))
                {
                    result = EncodeString.Decode(sConfigPasswordr);
                }
                return result;
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
                return null;
            }
        }

        public bool SetRegistry(string key, string value)
        {
            try
            {
                var reg = new ModifyRegistry(Registry.CurrentUser, RootKey);
                bool result = reg.Write(key, EncodeString.Encode(value));
                return result;
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
                return false;
            }
        }

        #endregion

        #region Common config

        public CommonConfigModel SaveDirectoryConfig(CommonConfigModel configModel)
        {
            CommonConfigModel result;
            var reg = new ModifyRegistry(Registry.CurrentUser, RootKey);
            try
            {
                reg.Write("EntryFolderPath", EncodeString.Encode(configModel.EntryFolderPath));
                reg.Write("ExitFolderPath", EncodeString.Encode(configModel.ExitFolderPath));
                reg.Write("RecognizeFolderPath", EncodeString.Encode(configModel.RecognizeFolderPath));
                reg.Write("StandardFolderPath", EncodeString.Encode(configModel.StandardFolderPath));
                reg.Write("ImageType", EncodeString.Encode(configModel.ImageType));

                reg.Write("MaxTime", EncodeString.Encode(configModel.MaxTime.ToString()));

                result = configModel;
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
                return null;
            }
            return result;
        }

        public CommonConfigModel GetDirectoryConfig()
        {
            var reg = new ModifyRegistry(Registry.CurrentUser, RootKey);

            var result = new CommonConfigModel();
            try
            {
                if (!string.IsNullOrWhiteSpace(reg.Read("EntryFolderPath")))
                {
                    result.EntryFolderPath = EncodeString.Decode(reg.Read("EntryFolderPath"));
                }
                if (!string.IsNullOrWhiteSpace(reg.Read("ExitFolderPath")))
                {
                    result.ExitFolderPath = EncodeString.Decode(reg.Read("ExitFolderPath"));
                }
                if (!string.IsNullOrWhiteSpace(reg.Read("ImageType")))
                {
                    result.ImageType = EncodeString.Decode(reg.Read("ImageType"));
                }

                var maxTime = 0;
                if (!string.IsNullOrWhiteSpace(reg.Read("MaxTime")))
                {
                    int.TryParse(EncodeString.Decode(reg.Read("MaxTime")), out maxTime);
                }
                result.MaxTime = maxTime;

                if (!string.IsNullOrWhiteSpace(reg.Read("RecognizeFolderPath")))
                {
                    result.RecognizeFolderPath = EncodeString.Decode(reg.Read("RecognizeFolderPath"));
                }
                if (!string.IsNullOrWhiteSpace(reg.Read("StandardFolderPath")))
                {
                    result.StandardFolderPath = EncodeString.Decode(reg.Read("StandardFolderPath"));
                }
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
                return null;
            }

            return result;
        }

        #endregion

        #region Security config



        #endregion

        #region

        public SupervisionConfigModel SaveSupervisionConfig(SupervisionConfigModel model)
        {
            SupervisionConfigModel result = null;
            ModifyRegistry reg = new ModifyRegistry(Registry.CurrentUser, RootKey);
            try
            {
                reg.Write("isTOC", EncodeString.Encode(model.isTOC.ToString()));
                reg.Write("StationID", EncodeString.Encode(model.StationCode));

                result = model;
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
            return result;
        }

        public SupervisionConfigModel GetSupervisionConfig()
        {
            var model = new SupervisionConfigModel();
            var reg = new ModifyRegistry(Registry.CurrentUser, RootKey);
            try
            {
                var isTOC = reg.Read("isTOC");
                var stationId = reg.Read("StationID");
                if (string.IsNullOrWhiteSpace(isTOC) || string.IsNullOrWhiteSpace(stationId))
                {
                    //first time load
                    return null;
                }
                model.isTOC = int.Parse(EncodeString.Decode(isTOC));
                model.StationCode = EncodeString.Decode(stationId);
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

            return model;
        }

        #endregion

    }
}
