using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TollTicketManagement.Controller;

namespace TollTicketManagement.Model
{
    public class OverTimeSmartCard: INotifyPropertyChanged
    {
        #region Notify property changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        private int stt;
        public int STT
        {
            set { stt = value; OnPropertyChanged(); }
            get { return stt; }
        }
        //private const string Table
        private string smartCardID;
        public string SmartCardID
        {
            set { smartCardID = value; OnPropertyChanged(); }
            get { return smartCardID; }
        }
        private string recogPlateNumber;
        public string RecogPlateNumber
        {
            set { recogPlateNumber = value; OnPropertyChanged(); }
            get { return recogPlateNumber; }
        }
        private int? stationIDIn;
        public int? StationIDIn
        {
            set { stationIDIn = value; OnPropertyChanged(); }
            get { return stationIDIn; }
        }
        private int? laneIn;
        public int? LaneIn
        {
            set { laneIn = value; OnPropertyChanged(); }
            get { return laneIn; }
        }
        private int? shiftID;
        public int? ShiftID
        {
            set { shiftID = value; OnPropertyChanged(); }
            get { return shiftID; }
        }
        private string dateTimeIn;
        public string DateTimeIn
        {
            set { dateTimeIn = value; OnPropertyChanged(); }
            get { return dateTimeIn; }
        }
        private string imageID;
        public string ImageID
        {
            set { imageID = value; OnPropertyChanged(); }
            get { return imageID; }
        }
        private string overTime;
        public string OverTime
        {
            set { overTime = value; OnPropertyChanged(); }
            get { return overTime; }
        }
        public static OverTimeSmartCard CreateFromIN_CheckSmartCard(DataRow row)
        {
            string tmpOverTime = string.Empty;
            int tick = (int)(ConvertToTimestamp(DateTime.Now) - ConvertToTimestamp((DateTime)row.ItemArray[6]));
            tmpOverTime += tick / 86400 + " Ngày " + (tick % 86400) / (60*60) + " Giờ " + (tick % 60) + " Phút";
            OverTimeSmartCard result = new OverTimeSmartCard();
            result.STT = Int32.Parse(row.ItemArray[0].ToString());
            result.SmartCardID = row.ItemArray[1].ToString();
            result.RecogPlateNumber = row.ItemArray[2].ToString();
            result.StationIDIn = (int)row.ItemArray[3];
            result.LaneIn = Int32.Parse(row.ItemArray[4].ToString().Substring(1, 2));
            result.ShiftID = (int)row.ItemArray[5];
            result.DateTimeIn = ((DateTime)row.ItemArray[6]).ToShortDateString() + " " + ((DateTime)row.ItemArray[6]).ToLongTimeString();
            result.ImageID = row.ItemArray[7].ToString();
            result.OverTime = tmpOverTime;
            tmpOverTime = string.Empty;
            tick = 0;
            return result;
        }
        private static long ConvertToTimestamp(DateTime value)
        {
            TimeZoneInfo NYTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            TimeZone localZone = TimeZone.CurrentTimeZone;
            TimeSpan span = (TimeZoneInfo.ConvertTime(value, NYTimeZone) - new DateTime(1970, 1, 1, 0, 0, 0, 0));
            NYTimeZone = null;
            localZone = null;
            return (long)Convert.ToDouble(span.TotalSeconds);
        }
        public static List<OverTimeSmartCard> getListOverTimeSmartCardbyCondition(string condition)
        {
            List<OverTimeSmartCard> result = new List<OverTimeSmartCard>();
            DAL da = new DAL(Base_Ctrl.ServerName, Base_Ctrl.UserID, Base_Ctrl.Password, Base_Ctrl.Database);
            using (DataTable dt = da.selectDataBase("[dbo].[OverTransaction_TempTable]", "*", condition))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    result.Add(CreateFromIN_CheckSmartCard(dt.Rows[i]));
                }
            }
            return result;
        }
        public static int getCountListOverTimeSmartCardbyTime(DateTime from,DateTime to,int timeout,int StationID,string Condition)
        {
            int count = 0;
            DAL da = new DAL(Base_Ctrl.ServerName, Base_Ctrl.UserID, Base_Ctrl.Password, Base_Ctrl.Database);
            using (DataTable dt = da.ExecCommand("exec [HPE].[dbo].[OverTimeSmartCard_Store_Data] 1,'" + getDateDBString(from) + "','" + getDateDBString(to) + "','19700101',0," + timeout + "," + StationID + ",'" + Condition + "'"))
            {
                try
                {
                    count = (int)dt.Rows[0].ItemArray[0];
                }
                catch { }
            }
            return count;
        }
        public static int getCountListOverTimeSmartCardbyDateShift(DateTime date, int shiftID, int timeout, int StationID, string Condition)
        {
            int count = 0;
            DAL da = new DAL(Base_Ctrl.ServerName, Base_Ctrl.UserID, Base_Ctrl.Password, Base_Ctrl.Database);
            using (DataTable dt = da.ExecCommand("exec [HPE].[dbo].[OverTimeSmartCard_Store_Data] 0,'19700101','19700101','" + getDateString(date) + "'," + shiftID + "," + timeout + "," + StationID + ",'" + Condition + "'"))
            {
                try
                { 
                count = (int)dt.Rows[0].ItemArray[0];
                }
                catch { }
            }
            return count;
        }
        private static string getDateString(DateTime dt)
        {
            string tmp = string.Empty;
            tmp += dt.Year;
            tmp += (dt.Month >= 10) ? dt.Month.ToString() : "0" + dt.Month;
            tmp += (dt.Day >= 10) ? dt.Day.ToString() : "0" + dt.Day;
            return tmp;
        }
        private static string getDateDBString(DateTime dt)
        {
            string tmp = string.Empty;
            tmp += dt.Year + "-";
            tmp += ((dt.Month >= 10) ? dt.Month.ToString() : "0" + dt.Month) + "-";
            tmp += ((dt.Day >= 10) ? dt.Day.ToString() : "0" + dt.Day) + " ";
            tmp += ((dt.Hour >= 10) ? dt.Hour.ToString() : "0" + dt.Hour) + ":";
            tmp += ((dt.Minute >= 10) ? dt.Minute.ToString() : "0" + dt.Minute) + ":";
            tmp += ((dt.Second >= 10) ? dt.Second.ToString() : "0" + dt.Second);
            return tmp;
        }
        private class DAL
        {
            private SqlConnection conn = null;
            public bool IsconnectionSusses = false;
            #region Contructor
            public DAL()
            {
            }
            public DAL(string ServerName, string UserName, string Password, string Database)
            {
                IsconnectionSusses = connectDataBase(ServerName, UserName, Password, Database);
            }
            #endregion
            /// <summary>
            /// Creating Connection to Database
            /// </summary>
            /// <returns></returns>
            public bool connectDataBase(string ServerName, string UserName, string Password, string Database)
            {

                IsconnectionSusses = false;
                bool result = false;
                if (conn != null) conn = null;
                conn = new SqlConnection();
                conn.ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + Database + ";User ID=" + UserName + ";Password=" + Password;
                try
                {
                    conn.Open();
                }
                catch { return false; }
                if (conn.State == ConnectionState.Open)
                {
                    IsconnectionSusses = true;
                    result = true;
                }
                conn.Close();
                return result;
            }
            /// <summary>
            /// Creating Table with this Connection
            /// </summary>
            /// <returns></returns>
            public bool createTable()
            {
                bool result = false;
                if (conn == null) return false;
                if (conn.State == ConnectionState.Closed) conn.Open();

                return result;
            }
            /// <summary>
            /// Droping Table with this Connection
            /// </summary>
            /// <returns></returns>
            public bool dropTable()
            {
                bool result = false;
                return result;

            }
            public bool SQLcommandExecute(string cmd)
            {
                bool result = false;
                if (conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        return false;
                    }
                }
                SqlCommand scmd = new SqlCommand(cmd, conn);
                try
                {
                    scmd.ExecuteNonQuery();
                    result = true;
                }
                catch { }
                return result;
            }
            public DataTable ExecCommand(string cmd)
            {
                DataTable dt = new DataTable();
                if (IsconnectionSusses)
                {
                    if (conn == null) return null;
                    if (conn.State == ConnectionState.Closed)
                    {
                        try
                        {
                            conn.Open();
                        }
                        catch
                        {
                            return null;
                        }
                    }
                    SqlCommand Scmd = new SqlCommand();
                    Scmd.Connection = conn;
                    Scmd.CommandText = cmd;
                    SqlDataAdapter Sda = new SqlDataAdapter(Scmd);
                    Sda.Fill(dt);
                    conn.Close();
                    Scmd.Dispose();
                    Sda.Dispose();
                }
                return dt;
            }
            /// <summary>
            /// Get DataTable with this Connection
            /// </summary>
            /// <returns></returns>
            public DataTable selectDataBase(string TableName, string getObjects, string Condition, string Others = "")
            {
                DataTable dt = new DataTable();
                if (IsconnectionSusses)
                {
                    if (conn == null) return null;
                    if (conn.State == ConnectionState.Closed)
                    {
                        try
                        {
                            conn.Open();
                        }
                        catch
                        {
                            return null;
                        }
                    }
                    string cmd = string.Empty;
                    cmd = "select " + getObjects + " " +
                          "from " + TableName + " " +
                          ((Condition == "") ? "" : " where ") + Condition + " " +
                          Others;
                    SqlCommand Scmd = new SqlCommand();
                    Scmd.Connection = conn;
                    Scmd.CommandText = cmd;
                    SqlDataAdapter Sda = new SqlDataAdapter(Scmd);
                    Sda.Fill(dt);
                    conn.Close();
                    Scmd.Dispose();
                    Sda.Dispose();
                }
                return dt;
            }
            public Guid getNewGuid()
            {
                Guid result = new Guid();
                DataTable dt = new DataTable();
                if (IsconnectionSusses)
                {
                    if (conn == null) return result;
                    if (conn.State == ConnectionState.Closed)
                    {
                        try
                        {
                            conn.Open();
                        }
                        catch
                        {
                            return result;
                        }
                    }
                    string cmd = string.Empty;
                    cmd = "select newid()";
                    SqlCommand Scmd = new SqlCommand();
                    Scmd.Connection = conn;
                    Scmd.CommandText = cmd;
                    SqlDataAdapter Sda = new SqlDataAdapter(Scmd);
                    Sda.Fill(dt);
                    result = (Guid)dt.Rows[0].ItemArray[0];
                    dt.Dispose();
                    conn.Close();
                    Scmd.Dispose();
                    Sda.Dispose();
                }
                return result;
            }
            /// <summary>
            /// Insert DataBase with this Connection
            /// </summary>
            /// <returns></returns>
            public bool insertDataBase(string TableName, string colunmNameString, string colunmValueString)
            {
                bool result = false;
                if (IsconnectionSusses)
                {
                    if (conn == null) return false;
                    if (conn.State == ConnectionState.Closed)
                    {
                        try
                        {
                            conn.Open();
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    string cmd = string.Empty;
                    cmd = "INSERT INTO [dbo].[" + TableName + "] " +
                          colunmNameString +
                          " VALUES " + colunmValueString;
                    SqlCommand Scmd = new SqlCommand();
                    Scmd.Connection = conn;
                    Scmd.CommandText = cmd;
                    if (Scmd.ExecuteNonQuery() > 0) result = true;
                    conn.Close();
                    Scmd.Dispose();
                }
                return result;
            }
            /// <summary>
            /// Update DataTable with this Connection
            /// </summary>
            /// <returns></returns>
            public int updateDataBase(string TableName, string set, string where)
            {
                int result = -1;
                if (IsconnectionSusses)
                {
                    if (conn == null) return -1;
                    if (conn.State == ConnectionState.Closed)
                    {
                        try
                        {
                            conn.Open();
                        }
                        catch
                        {
                            return -1;
                        }
                    }
                    string cmd = string.Empty;
                    cmd += "UPDATE [dbo].[" + TableName + "] " +
                           "SET " + set + " " +
                           "WHERE " + where;
                    SqlCommand Scmd = new SqlCommand();
                    Scmd.Connection = conn;
                    Scmd.CommandText = cmd;
                    int tmp = Scmd.ExecuteNonQuery();
                    if (tmp >= 0)
                    {
                        result = tmp;
                    }
                    conn.Close();
                    Scmd.Dispose();
                }
                return result;
            }
            /// <summary>
            /// Delete DataTable with this Connection
            /// </summary>
            /// <returns></returns>
            public bool deleteDataBase(string TableName, string where)
            {
                bool result = false;
                if (IsconnectionSusses)
                {
                    if (conn == null) return false;
                    if (conn.State == ConnectionState.Closed)
                    {
                        try
                        {
                            conn.Open();
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    string cmd = string.Empty;
                    cmd = "DELETE FROM [dbo].[" + TableName + "] " +
                          "WHERE " + where;
                    SqlCommand Scmd = new SqlCommand();
                    Scmd.Connection = conn;
                    Scmd.CommandText = cmd;
                    if (Scmd.ExecuteNonQuery() > 0) result = true;
                    conn.Close();
                    Scmd.Dispose();
                }
                return result;
            }
            public void Dispose()
            {
                if (this.conn.State == ConnectionState.Open) this.conn.Close();
                this.conn.Dispose();
            }
        }

    }
}
