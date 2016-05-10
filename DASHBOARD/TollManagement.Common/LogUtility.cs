using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TollManagement.Common
{
    public class LogUtility
    {
        #region FILE CONST

        /// <summary>
        /// Log4Net object
        /// </summary>
        //private static ILog _log = LogManager.GetLogger(typeof(Utility));

        /// <summary>
        /// Log file chungsql
        /// </summary>
        private static string LOG_FILE = "./LogFolder/LogFile_{0}.txt";

        /// <summary>
        /// Log file nhận dạng và overlay
        /// </summary>
        private static string REG_OVERLAY_LOG_FILE = "./LogFolder/Reg_Overlay_Log_{0}.txt";
        /// <summary>
        /// Log file cap nhat ket qua nhan dang 
        /// </summary>
        private static string UPDATE_RECOG_RESULT_LOG_FILE = "./LogFolder/UpdateRecogResult_Log_{0}.txt";
        /// <summary>
        /// Logfile dem so xe uu tien
        /// </summary>
        private static string COUNTER_FORCE_ONCE_VEHICLE_LOG_FILE = "./LogFolder/COUNTER_FORCE_1_CAR_Log_{0}.txt";


        /// <summary>
        /// Log file chup hinh, nhan dang
        /// </summary>
        private static string CAPTURE_LOG_FILE = "./LogFolder/CaptureLog_{0}.txt";

        /// <summary>
        /// Log file doc ghi smart card (PRG 2000)
        /// </summary>
        private static string SMART_CARD_LOG_FILE = "./LogFolder/SmartCardLog_{0}.txt";

        /// <summary>
        /// Log file SQL
        /// </summary>
        private static string SQL_LOG_FILE = "./LogFolder/SQLLog_{0}.txt";

        /// <summary>
        /// Log file ghi giao dich voi OBU
        /// </summary>
        private static string OBU_LOG_FILE = "./LogFolder/ObuTransLog_{0}.txt";

        /// <summary>
        /// Log file ghi ket noi voi WebService
        /// </summary>
        private static string WEBSERVICE_LOG_FILE = "./LogFolder/WebServiceLog_{0}.txt";

        /// <summary>
        /// Log insert thanh cong SQL
        /// </summary>
        private static string Insert_Success_LOG_FILE = "./LogFolder/Insert_Success_Log_{0}.txt";

        /// <summary>
        /// Log insert that bai SQL
        /// </summary>
        private static string Insert_Fail_LOG_FILE = "./LogFolder/Insert_Fail_Log_{0}.txt";

        /// <summary>
        /// Log insert SQL toan bo
        /// </summary>
        private static string Insert_Total_LOG_FILE = "./LogFolder/Insert_Total_Log_{0}.txt";

        /// <summary>
        /// Log insert SQL
        /// </summary>
        private static string Insert_Force_LOG_FILE = "./LogFolder/Insert_Force_Log_{0}.txt";
        /// <summary>
        /// Login/logout
        /// </summary>
        private static string Login_LOG_FILE = "./LogFolder/LogIn_Log_{0}.txt";

        private static string EAC_TEST_LOG_FILE = "./LogFolder/EAC_Test_Log_{0}.txt";

        public static string UpdateVersion = string.Empty;
        #endregion

        public static void WriteLogEACTest(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");

            string filename = string.Format(EAC_TEST_LOG_FILE, strDate);

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.AutoFlush = true;
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                    sw.WriteLine("-------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //#if DEBUG
            //            Utility.ShowError(strFuncName, strMsg);
            //#endif
        }
        public static void WriteLogRetryCounter(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string fi = "./LogFolder/ProcessRetryCounter{0}.txt";
            string filename = string.Format(fi, strDate);
            //System.IO.StreamWriter sw = System.IO.File.AppendText(filename);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.AutoFlush = true;
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                    sw.WriteLine("-------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //#if DEBUG
            //            Utility.ShowError(strFuncName, strMsg);
            //#endif
        }

        public static void WriteLogTimerCard(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd/HH}", DateTime.Now).Replace("/", "");
            string fi = "./LogFolder/TimerCard_{0}.txt";
            string filename = string.Format(fi, strDate);
            //System.IO.StreamWriter sw = System.IO.File.AppendText(filename);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.AutoFlush = true;
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                    sw.WriteLine("-------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //#if DEBUG
            //            Utility.ShowError(strFuncName, strMsg);
            //#endif
        }
        /// <summary>
        /// Ham ghi log file chung
        /// </summary>
        /// <param name="strFuncName"></param>
        /// <param name="strMsg"></param>
        public static void WriteLogFile(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(LOG_FILE, strDate);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.AutoFlush = true;
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                    sw.WriteLine(UpdateVersion + "-------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //  #if DEBUG
            //     LogUtility.ShowError(strFuncName, strMsg);
            //#endif
        }

        public static void WriteLogFile_Login_LogOut(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(Login_LOG_FILE, strDate);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                    sw.WriteLine("-------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Ham ghi log file lien quan den CSDL
        /// </summary>
        /// <param name="strFuncName"></param>
        /// <param name="strMsg"></param>
        public static void WriteLogFile_Insert_Success_SmartCard(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(Insert_Success_LOG_FILE, strDate);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Ham ghi log file lien quan den CSDL
        /// </summary>
        /// <param name="strFuncName"></param>
        /// <param name="strMsg"></param>
        public static void WriteLogFile_Insert_Fail_SmartCard(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(Insert_Fail_LOG_FILE, strDate);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Ham ghi log file lien quan den CSDL
        /// </summary>
        /// <param name="strFuncName"></param>
        /// <param name="strMsg"></param>
        public static void WriteLogFile_Insert_Total_SmartCard(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(Insert_Total_LOG_FILE, strDate);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static void WriteLogFile_Insert_ForceOpen(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(Insert_Force_LOG_FILE, strDate);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void WriteLogFile_ND_Overlay(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(REG_OVERLAY_LOG_FILE, strDate);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.AutoFlush = true;
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// log file cho viec cap nhat ket qua nhan dang
        /// </summary>
        /// <param name="strFuncName"></param>
        /// <param name="strMsg"></param>
        public static void WriteLogFile_UpdateRecogResult(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(UPDATE_RECOG_RESULT_LOG_FILE, strDate);

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        /// <summary>
        /// log file cho viec mo uu tien 1 xe
        /// </summary>
        /// <param name="strFuncName"></param>
        /// <param name="strMsg"></param>
        public static void WriteLogFile_ForceOpen_1_Car(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(COUNTER_FORCE_ONCE_VEHICLE_LOG_FILE, strDate);

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSource">Noi phat sinh loi</param>
        /// <param name="pMessage">Noi dung loi</param>
        public static void ShowError(string pSource, string pMessage)
        {
            if (pSource != null && pMessage != null)
            {
                System.Windows.Forms.MessageBox.Show(pMessage, pSource, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string GetLogLine(string strFuncName, string strMsg)
        {
            string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ") + Environment.NewLine;
            logLine += "-------------------------------------------" + Environment.NewLine;
            return logLine;
        }

        public static void WriteLogLine(string pLogLine)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(LOG_FILE, strDate);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(pLogLine);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// Ham ghi log file chung
        /// </summary>
        /// <param name="strFuncName"></param>
        /// <param name="strMsg"></param>
        public static void WriteLogFile(Exception ex)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(LOG_FILE, strDate);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.AutoFlush = true;
                    string strFuncName = string.Format("{0}.{1}()", ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name);
                    string logLine = System.String.Format("{0:G}: [{1}].", System.DateTime.Now, strFuncName);
                    sw.WriteLine(logLine);
                    sw.WriteLine(ex.Message);
                    sw.WriteLine("-------------------------------------------");
                }
            }
            catch (Exception exx)
            {
                throw exx;

            }
        }

        /// <summary>
        /// Ham ghi log file capture
        /// </summary>
        /// <param name="strFuncName"></param>
        /// <param name="strMsg"></param>
        public static void WriteLogFile_Capture(Exception ex)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(CAPTURE_LOG_FILE, strDate);

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    string strFuncName = string.Format("{0}.{1}()", ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name);
                    string logLine = System.String.Format("{0:G}: [{1}].", System.DateTime.Now, strFuncName);
                    sw.WriteLine(logLine);
                    sw.WriteLine(ex.Message);
                    sw.WriteLine("-------------------------------------------");
                }
            }
            catch (Exception exx)
            {
                throw exx;

            }
        }

        public static void WriteLogFile_Capture(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(CAPTURE_LOG_FILE, strDate);

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                    sw.WriteLine("-------------------------------------------");
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static void WriteLogFile_SmartCard(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(SMART_CARD_LOG_FILE, strDate);

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                    sw.WriteLine("-------------------------------------------");
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// Ham ghi log file OBU transaction
        /// </summary>
        /// <param name="pTransLog"></param>
        public static void WriteLogFile_OBU(string pTransLog)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(OBU_LOG_FILE, strDate);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(pTransLog);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// Ham ghi log file lien quan den CSDL
        /// </summary>
        /// <param name="strFuncName"></param>
        /// <param name="strMsg"></param>
        public static void WriteLogFile_SQL(Exception ex)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(SQL_LOG_FILE, strDate);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    string strFuncName = string.Format("{0}.{1}()", ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name);
                    string logLine = System.String.Format("{0:G}: [{1}].", System.DateTime.Now, strFuncName);
                    sw.WriteLine(logLine);
                    sw.WriteLine(ex.Message);
                    sw.WriteLine("-------------------------------------------");
                }
            }
            catch (Exception exx)
            {
                throw exx;

            }
        }

        /// <summary>
        /// Ham ghi log file lien quan den CSDL
        /// </summary>
        /// <param name="strFuncName"></param>
        /// <param name="strMsg"></param>
        public static void WriteLogFile_SQL(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(SQL_LOG_FILE, strDate);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                    sw.WriteLine("-------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// Ham open log file OBU transaction
        /// </summary>
        /// <param name="strFuncName"></param>
        /// <param name="strMsg"></param>
        public static StreamReader OpenLogFile_OBU()
        {
            try
            {
                string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
                string fileName = string.Format(OBU_LOG_FILE, strDate, DateTime.Now.Hour.ToString());

                return OpenLogFile_OBU(fileName);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static StreamReader OpenLogFile_OBU(DateTime pDateTime, int hour)
        {
            try
            {
                string strDate = String.Format("{0:yyyy/MM/dd}", pDateTime).Replace("/", "");
                string fileName = string.Format(OBU_LOG_FILE, strDate, hour.ToString());

                return OpenLogFile_OBU(fileName);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// Ham open log file OBU transaction
        /// </summary>
        /// <param name="strFuncName"></param>
        /// <param name="strMsg"></param>
        public static StreamReader OpenLogFile_OBU(string pFileName)
        {
            StreamReader sr = null;
            try
            {
                if (File.Exists(pFileName))
                {
                    FileStream fs = new FileStream(pFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    sr = new StreamReader(fs);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return sr;
        }

        /// <summary>
        /// Ham ghi log file lien quan den WebService
        /// </summary>
        /// <param name="strFuncName"></param>
        /// <param name="strMsg"></param>
        public static void WriteLogFile_WebService(string strFuncName, string strMsg)
        {
            string strDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace("/", "");
            string filename = string.Format(WEBSERVICE_LOG_FILE, strDate);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) using (StreamWriter sw = new StreamWriter(fs))
                {
                    string logLine = System.String.Format("{0:G}: {1}.", System.DateTime.Now.ToString("dd/MM/yyy HH:mm:ss:fff"), "[" + strFuncName + " - " + strMsg + "] ");
                    sw.WriteLine(logLine);
                    sw.WriteLine("-------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        /// <summary>
        /// Chuan hoa servername
        /// Ex: NormalizeServerName(VODINHHUY\SQL2008)=>VODINHHUY
        /// </summary>
        /// <param name="pServerName"></param>
        /// <returns></returns>
        public static string NormalizeServerName(string pServerName)
        {
            try
            {
                string server = string.Empty;
                if (string.IsNullOrEmpty(pServerName))
                {
                    return string.Empty;
                }
                else
                {
                    string[] tempArr = pServerName.Split('\\');
                    if (tempArr.Length > 0) return tempArr[0];
                    else
                        return pServerName;
                }
            }
            catch (Exception ex)
            {
                string function = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString()
                                  + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
                LogUtility.WriteLogFile(function, ex.Message);
            }
            return string.Empty;
        }
    }
}
