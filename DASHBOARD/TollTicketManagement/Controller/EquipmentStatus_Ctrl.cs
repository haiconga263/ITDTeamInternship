using System;
using System.Collections.Generic;
using System.Linq;
using TollManagement.Common;
using TollManagement.Data;

namespace TollTicketManagement.Controller
{
    public class EquipmentStatus_Ctrl
    {
        public List<sp_LS_Lane_Station_GetInformation_Result> getInformation_Lane_Station(string id_station)
        {
            {
                try
                {
                    using (var supEntity = new HPEEntities())
                    {
                        supEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                        return supEntity.sp_LS_Lane_Station_GetInformation(id_station).ToList();
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
        }
        public List<sp_LS_Lane_Devices_GetInformation_Result> getInformation_Lane_Devices(string id_lane)
        {
            {
                try
                {
                    using (var supEntity = new HPEEntities())
                    {
                        supEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                        return supEntity.sp_LS_Lane_Devices_GetInformation(id_lane).ToList();
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
        }
    }
}
