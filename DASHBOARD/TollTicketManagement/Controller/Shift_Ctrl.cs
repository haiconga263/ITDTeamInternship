using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollManagement.Common;
using TollManagement.Data;

namespace TollTicketManagement.Controller
{
    public class Shift_Ctrl
    {
        public List<sp_LS_Shift_GetAll_Result> GetAllShift()
        {
            try
            {
                using (var tollEntity = new HPEEntities())
                {
                    tollEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    return tollEntity.sp_LS_Shift_GetAll().ToList();
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


        /// <summary>
        /// Lấy mã ca hiện tại
        /// </summary>
        /// <returns></returns>
        public int? GetCurrentShift()
        {
            try
            {
                using (var supEntity = new HPEEntities())
                {
                    supEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    return supEntity.sp_Shift_GetCurrentShift_ByTime(DateTime.Now.TimeOfDay).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Lấy mã ca hiện tại
        /// </summary>
        /// <returns></returns>
        public sp_LS_Shift_GetByID_Result GetShiftByShiftID(int shiftID)
        {
            try
            {
                using (var supEntity = new HPEEntities())
                {
                    supEntity.Database.Connection.ConnectionString = Base_Ctrl._primaryConnectionString;
                    return supEntity.sp_LS_Shift_GetByID(shiftID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                LogUtility.WriteLogFile(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "." + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                return null;
            }
        }
    }
}
