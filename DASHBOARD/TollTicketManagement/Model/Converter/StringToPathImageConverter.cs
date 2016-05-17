using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TollTicketManagement.Model.Converter
{
    public class StringToPathImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string str = value.ToString();
                string rs = "D:/HinhAnh/HinhLan/" + str.Substring(18, 2) + "/" + str.Substring(0, 4) + "/" + str.Substring(4, 2) + "/" + str.Substring(6, 2) + "/" + str.Substring(8, 2) + "/" + str.Substring(18, 4) + str + ".jpg";
                return rs;
            }
            catch (Exception)
            {
                return "";   
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = value.ToString();
            return str.Substring(str.LastIndexOf('/') + 1);
        }
    }
}
