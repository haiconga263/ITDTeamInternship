using System;
using System.Text.RegularExpressions;
using TollManagement.Common;

namespace TollTicketManagement.Common
{
    public class ValidateTextBox
    {

        #region Use nhập key ở bàn phím
  
        #endregion

        private const string Matching1 = @"[A-Z]";
        private const string MatchingRegis = @"[-,.,\pVehiclePlate]";
        private const string MatchingTicket = @"[/,-]";
        private const string MatchingTicket1 = @"^[A-Z0-9/-]+$";
        private const string Matching3 = @"[0-9]";
        private const string MatchingReceiptNo = @"^[A-Z0-9/-]+$";
        private const string MatchingSmartCard = @"^[A-Z0-9]{9}";

        /// <summary>
        ///validate ký tự số thẻ khi nhập
        /// </summary>
        ///<returns>
        ///true: cho nhập, false: không cho nhập
        ///</returns>
        public bool CardTextAllowed(string text)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    return false;
                }
                var reg = new Regex(@"[A-Z0-9]");
                return reg.IsMatch(text);
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

        /// <summary>
        ///validate ký tự số thẻ OBU khi nhập
        /// </summary>
        ///<returns>
        ///true: cho nhập, false: không cho nhập
        ///</returns>
        public bool OBUTextAllowed(string text)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    return false;
                }
                var reg = new Regex(@"[A-Z0-9]");
                return reg.IsMatch(text);
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

        public bool OnlyNumberAllowed(string text)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    return false;
                }
                var reg = new Regex(@"[0-9]");

                return reg.IsMatch(text);
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

        /// <summary>
        ///validate ký tự số xe khi nhập
        /// </summary>
        ///<returns>
        ///true: cho nhập, false: không cho nhập
        ///</returns>
        public bool PlateTextAllowed(string text)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    return false;
                }
                var reg = new Regex(@"[A-Z0-9]");
                return reg.IsMatch(text);
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

        /// <summary>
        ///validate ký tự số hóa đơn khi nhập
        /// </summary>
        ///<returns>
        ///true: cho nhập, false: không cho nhập
        ///</returns>
        public bool ReceiptTextAllowed(string text)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    return false;
                }
                var reg = new Regex(@"[A-Z0-9-]");
                return reg.IsMatch(text);
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


        /// <summary>
        ///validate ký tự số xe
        /// </summary>
        public bool ValidateRegisPlateNumber(string parttem)
        {
            try
            {
                var fgint1 = new Regex(Matching1);
                //var fgint2 = new Regex(MatchingRegis);
                var fgint3 = new Regex(Matching3);
                return fgint1.IsMatch(parttem.ToUpper()) || fgint3.IsMatch(parttem);
                //return fgint1.IsMatch(parttem.ToUpper()) || fgint2.IsMatch(parttem) || fgint3.IsMatch(parttem);
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

        /// <summary>
        /// validate Vé, ưu tiên, bộ tài chính hoặc tất cả khi không xác định được loại vé!
        /// </summary>
        public bool ValidateTicket(string parttem)
        {
            try
            {
                var fgint = new Regex(MatchingTicket1);
                return fgint.IsMatch(parttem.ToUpper());
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
        /// <summary>
        ///validate SmartCard, Obu 2 mảnh, 1 mảnh và thời gian
        /// </summary>
        public bool ValidateSmartCard(string parttem)
        {
            try
            {
                var reg = new Regex(MatchingSmartCard);
                return reg.IsMatch(parttem);
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

        /// <summary>
        /// Validate định dạng số hóa đơn
        /// </summary>
        /// <param name="pReceiptNo"></param>
        /// <returns> false là nhập lại</returns>
        public bool ValidateReceiptNo(string pReceiptNo)
        {
            try
            {
                var fgint = new Regex(MatchingReceiptNo);
                //var fgint2 = new Regex(MatchingRegis);
                return fgint.IsMatch(pReceiptNo.ToUpper());
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

        /// <summary>
        /// Validate định dạng số xe
        /// </summary>
        /// <param name="pVehiclePlate"></param>
        /// <returns> true là ko cho nhập nữa, ngược lại là cho nhập</returns>
        public bool CheckPlateNumber(string pVehiclePlate)
        {
            try
            {
                var countChar = 0;
                var countLetter = 0;
                var fgint1 = new Regex(Matching1);
                var fgint3 = new Regex(Matching3);
                foreach (var item in pVehiclePlate)
                {
                    // Kiểm tra số chữ cái trong biển số xe có >2 hay không
                    if (fgint1.IsMatch((Convert.ToString(item)).ToUpper()))
                        countChar++;
                    //kiểm tra độ dài của chuỗi số xe có dài hơn 11 hay không 
                    if (fgint1.IsMatch((Convert.ToString(item)).ToUpper()) || fgint3.IsMatch((Convert.ToString(item)).ToUpper()))
                        countLetter++;
                }
                if (countChar > 2 || countLetter > 9)
                {
                    return false;
                }
                else
                {
                    return true;
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
                return false;
            }
        }




        public bool CheckStartString(string s)
        {
            try
            {
                var fgint = new Regex("^" + MatchingTicket);
                return fgint.IsMatch(s) || s.Length > 20;
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
    }
}
