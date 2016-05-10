using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollManagement.Common;
using TollManagement.Data;


namespace TollTicketManagement.Controller
{
    class Base_Ctrl
    {
        private string _connectionString;
        //public static Logger writeLog;

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public static string ServerName = "HUYTO-PC\\MSSQLSERVER2K14";
        public static string Database = "HPE";
        public static string UserID = "sa";
        public static string Password = "Abcd1234";
        
        public static string ModuleCode = "SUP";

        public static int TimeOut = 30;
        public static int TimeOut2 = 30;
        public static int _activeServer = 1;

        public static string _primaryConnectionString = @"metadata=res://*/EntityFramework.Supervision.csdl|res://*/EntityFramework.Supervision.ssdl|res://*/EntityFramework.Supervision.msl;provider=System.Data.SqlClient;provider " +
            @"connection string='data source=HUYTO-PC\MSSQLSERVER2K14;initial catalog=HPE;persist security info=True;user id=sa;password=Abcd1234;multipleactiveresultsets=True;Connect Timeout=1;App=EntityFramework'";

        public static string _mirrorConnectionString = @"metadata=res://*/EntityFramework.Supervision.csdl|res://*/EntityFramework.Supervision.ssdl|res://*/EntityFramework.Supervision.msl;provider=System.Data.SqlClient;provider " +
            @"connection string='data source=localhost;initial catalog=CTS_DB;persist security info=True;user id=sa;password=november4th;multipleactiveresultsets=True;Connect Timeout=1;App=EntityFramework'";

        public static string GetConnectionString(string server, string database, string userid, string password, string tiemout)
        {
            var sConnectionString = string.Format(@"metadata=res://*/EntityFramework.Supervision.csdl|res://*/EntityFramework.Supervision.ssdl|res://*/EntityFramework.Supervision.msl;provider=System.Data.SqlClient;provider " +
             @"connection string='data source={0};initial catalog={1};persist security info=True;user id={2};password={3};multipleactiveresultsets=True;Connect Timeout={4};App=EntityFramework'", server, database, userid, password, tiemout);
            return sConnectionString;
        }

        public static string GetConnectionString2(string server, string database, string userid, string password, string tiemout)
        {
            var sConnectionString = string.Format(@"data source={0};initial catalog={1};persist security info=True;user id={2};password={3};multipleactiveresultsets=True;Connect Timeout={4};App=EntityFramework", server, database, userid, password, tiemout);
            return sConnectionString;
        }

        public static string GetConnectionStringFromDirector(string server, string database, string userid, string password, string tiemout)
        {
            return "Driver={SQL Server}; server=" + server + ";database=" + database + ";Uid=" + userid + ";Pwd=" + password;
        }


        //public static bool TestConnection_DbExists(string connectionString)
        //{
        //    bool result;
        //    try
        //    {
        //        using (var _supervision = new HPEEntities())
        //        {
        //            if (_supervision.Database.Connection.ConnectionString != null)
        //                LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, "Entity connection string: " + _supervision.Database.Connection.ConnectionString);
        //            else
        //                LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, "Entity connection string is null ");
        //            _supervision.Database.Connection.ConnectionString = connectionString;
        //            result = _supervision.Database.Exists();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null)
        //        {
        //            LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message + ".InnerMessage:" + ex.InnerException.Message);
        //        }
        //        else
        //        {
        //            LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
        //        }
        //        result = false;
        //    }
        //    return result;
        //}

        public static bool TestConnection(string connectionString)
        {
            bool result;
            try
            {
                using (var _supervision = new HPEEntities())
                {
                    if (_supervision.Database.Connection.ConnectionString != null)
                        LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, "Entity connection string: " + _supervision.Database.Connection.ConnectionString);
                    else
                        LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, "Entity connection string is null ");
                    _supervision.Database.Connection.ConnectionString = connectionString;
                    _supervision.Database.Connection.Open();
                    if (_supervision.Database.Connection.State == System.Data.ConnectionState.Open)
                    {
                        _supervision.Database.Connection.Close();
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
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
                result = false;
            }
            return result;
        }

        public static bool TestConnection()
        {
            try
            {
                var result = TestConnection(ServerName, Database, UserID, Password, TimeOut.ToString());
                return result;
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
                return false;
            }
        }

        public static bool TestConnection(string server, string database, string userid, string password, string tiemout)
        {
            try
            {
                var connectionString = GetConnectionString2(server, database, userid, password, tiemout);
                using (var supervision = new HPEEntities())
                {
                    supervision.Database.Connection.ConnectionString = connectionString;
                    supervision.Database.Connection.Open();
                    return supervision.Database.Connection.State == System.Data.ConnectionState.Open;
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
                return false;
            }
        }
    }
}
