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
                string rs = str.Substring(0, 2) + "/" + str.Substring(2, 2) + "/" + str.Substring(4, 2) + "/" + str + ".jpeg";
                return rs;
            }
            catch (Exception)
            {
                return "";   
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
