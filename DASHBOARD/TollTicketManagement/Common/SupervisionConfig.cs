using System;

namespace TollTicketManagement.Common
{
    internal class SupervisionConfig
    {
        internal static int CommandTimeout = 30;
        internal static bool IsLogin = false;
        internal static bool LogByCard = false;
        internal static int PageSize = 2;

        internal static string ShiftCode = "02";
        internal static string Shift = string.Empty;
        internal static string LaneCode = "01";
        internal static DateTime LoginDate = DateTime.Now;

        internal static string DelimitSign = ".";
        internal static int BatchUnit = 10;

        //internal static EnumStationType StationType = EnumStationType.Center;
        internal static int StationId = 0;
        internal static string StationCode = "STA0000001";
        internal static string StationName = "Trung tâm";
        internal static int EmployeeID = 1;
        internal static string EmployeeCode = "01";

        internal static int StockID = 1;

        internal static int TeamLeaderID = 7;

        internal static string ServerName = @"soft-w";
        internal static string UserName = "sa";
        internal static string Password = "Abcd1234";
        internal static string FullName = "admin";


        #region Maintenance Cofig.

        internal static bool IsSqlCompleteLog = true;
        internal static bool IsInputReturn = false;
        internal static bool IsRealTime = false;
        #endregion Maintenance Cofig.

        #region Common Config.
        internal static bool IsConfigLogin = false;
        internal static string ConfigPasswordKey = "ConfigPassword";
        internal static string ConfigPassword = "123";
        internal static string VoucherPrefix = "NCC";
        internal static string BarCodeComport = string.Empty;
        internal static string EquipmentComport = string.Empty;
        internal static bool IsCabin = false;
        internal static bool IsShiftStatistic = false;
        internal static bool IsProductSerial = false;

        #endregion Common Config.

        //Card ID Prefix
        internal static string CARDIDPREFIX = "VECSFF";

        /// <summary>
        /// Thời gian lệch ca
        /// </summary>
        internal static int BonusShiftTime = 30;

        internal static bool IsVehicleImporting = false;

    }
}
