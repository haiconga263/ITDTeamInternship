using System;
using System.Collections.Generic;
using System.Linq;
using TollManagement.Common;
using TollManagement.Data;

namespace TollTicketManagement.Controller
{
    public class TollManagement_Ctrl
    {
        public List<cts_supervision_sp_rpt_TollManagement_Result> GetAll(int checkTime, DateTime fromdate, DateTime todate, int stationId, int shiftId, int shiftFirst, int ShiftLast, int shiftTime, int shiftT)
        {
            try
            {
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    var rs = tollEntity.cts_supervision_sp_rpt_TollManagement(checkTime,
                                                                                fromdate,
                                                                                todate,
                                                                                stationId,
                                                                                shiftId,
                                                                                shiftFirst,
                                                                                ShiftLast,
                                                                                shiftTime,
                                                                                shiftT);

                    return rs.ToList();                    
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
        }

        public List<sp_CMO_DASHBOARD_Result> GetDashBoardList(int pStationID)
        {
            try
            {
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    var rs = tollEntity.sp_CMO_DASHBOARD(pStationID);

                    return rs.ToList();
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
        }

        public List<sp_ToolManagement_GetAllOutCheck_NoEntryInfo_Result> GetAllOutCheck_NoEntryInfo()
        {
            try
            {
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    var rs = tollEntity.sp_ToolManagement_GetAllOutCheck_NoEntryInfo();//sp_ToolManagement_GetAllOutCheck_NoEntryInfo();

                    return rs.ToList();
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
        }
        public List<sp_LS_Lane_GetAll_Result> GetAllLane()
        {
            try
            {
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    var rs = tollEntity.sp_LS_Lane_GetAll();
                    return rs.ToList();
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
        }

        public List<sp_ToolManagement_GetDeviceStatus_Result> GetAllDeviceStatus()
        {
            try
            {
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    var rs = tollEntity.sp_ToolManagement_GetDeviceStatus();
                    return rs.ToList();
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
        }

        public List<sp_ToolManagement_GetAllOutCheck_UnPrecheck_Result> GetAllOutCheck_UnPrecheck()
        {
            try
            {
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    var rs = tollEntity.sp_ToolManagement_GetAllOutCheck_UnPrecheck();

                    return rs.ToList();
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
        }

        public int GetUpdatePrecheckRowEffect()
        {
            try
            {
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    int rs = tollEntity.sp_ToolManagement_UpdatePrecheck_CountRowEffect().FirstOrDefault() ?? -1;

                    return rs;
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
                return -1;
            }
        }

        public List<sp_ToolManagement_GetTrafficVolume_Result> GetTrafficVolume(DateTime pFromDate, DateTime pToDate, int pStationID)
        {
            try
            {
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.CommandTimeout = 0;
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    return tollEntity.sp_ToolManagement_GetTrafficVolume(pFromDate, pToDate, pStationID).ToList();
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
        }

        public void InsertTrafficVolume(DateTime pRegTime, DateTime pCollectDate, string pStationID, string pLaneID, decimal pVol)
        {
            try
            {
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.CommandTimeout = 0;
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    tollEntity.sp_ToolManagement_InsertTrafficVolume(pRegTime, pCollectDate, pStationID, pLaneID, pVol);
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
            }
        }

        public void InsertDeviceStatus(string pLaneCode, DateTime pCollectDate, string pStatus)
        {
            try
            {
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.CommandTimeout = 0;
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    tollEntity.sp_ToolManagement_InsertDeviceStatus(pLaneCode, pCollectDate, pStatus);
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
            }
        }

        public int GetUpdateEntryRowEffect()
        {
            try
            {
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    int rs = tollEntity.sp_ToolManagement_UpdateEntryInfo_CountRowEffect().FirstOrDefault() ?? -1;

                    return rs;
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
                return -1;
            }
        }

        public int UpdatePrecheckStatus(string pTranID, int pVehicleTypeID, string pEncodePlate)
        {
            try
            {
                int rs = -1;
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.CommandTimeout = 0;
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    rs = tollEntity.sp_ToolManagement_UpdatePrecheckStatus(pTranID, (int)pVehicleTypeID, pEncodePlate);
                    return rs;
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
                return -1;
            }
        }

        public int UpdateEntryInfo(string pTranID, string pEntryTranID, int pEntryLaneID, string pEntryRecogPlate)
        {
            try
            {
                int rs = -1;
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.CommandTimeout = 0;
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    rs = tollEntity.sp_ToolManagement_GetAllOutCheck_UpdateEntryInfo(pTranID, pEntryTranID, (int)pEntryLaneID, pEntryRecogPlate);
                    return rs;
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
                return -1;
            }
        }
    }
}
