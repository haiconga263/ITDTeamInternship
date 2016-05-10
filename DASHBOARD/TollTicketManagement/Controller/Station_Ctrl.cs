using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollManagement.Common;
using TollManagement.Data;

namespace TollTicketManagement.Controller
{
    public class Station_Ctrl
    {
        public IEnumerable<sp_LS_Station_GetAll_Result> GetAllStation()
        {
            try
            {
                using (var supEntity = new HPEEntities())
                {
                    supEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    var result = supEntity.sp_LS_Station_GetAll().ToList();
                    return result;
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

        public IEnumerable<sp_GetInLane_Result> GetInLane()
        {
            try
            {
                using (var supEntity = new HPEEntities())
                {
                    supEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    var result = supEntity.sp_GetInLane().ToList();
                    return result;
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

        public IEnumerable<sp_GetOutLane_Result> GetOutLane()
        {
            try
            {
                using (var supEntity = new HPEEntities())
                {
                    supEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    var result = supEntity.sp_GetOutLane().ToList();
                    return result;
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

        //public List<sp_SUP_LSStation_GetAll_Result> GetAllStation2()
        //{
        //    try
        //    {
        //        using (var supEntity = new HPEEntities())
        //        {
        //            supEntity.Database.Connection.ConnectionString = BaseController._primaryConnectionString;
        //            return supEntity.sp_SUP_LSStation_GetAll().ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null)
        //        {
        //            LogUtility.WriteLogFile_SQL(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message + ".InnerMessage:" + ex.InnerException.Message);
        //        }
        //        else
        //        {
        //            LogUtility.WriteLogFile_SQL(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
        //        }
        //        return null;
        //    }
        //}
    }
}
