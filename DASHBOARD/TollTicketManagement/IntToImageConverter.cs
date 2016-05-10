using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TollTicketManagement
{
    public class IntToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                        object parameter, CultureInfo culture)
        {
            if (value!= null)
            {
                if (int.Parse(value.ToString()) == 0)
                {
                    return new BitmapImage(new Uri("pack://application:,,,/TollTicketManagement;component/Resources/Images/close-icon.png", UriKind.RelativeOrAbsolute));
                }
                else if (int.Parse(value.ToString()) == 1)
                {
                    return new BitmapImage(new Uri("pack://application:,,,/TollTicketManagement;component/Resources/Images/ok-icon.png", UriKind.RelativeOrAbsolute));
                }
            }
           
            return null;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}