using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TollTicketManagement
{
    public class IntToImageConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType,
                        object parameter, CultureInfo culture)
        {
            if (int.Parse(value.ToString()) == 0)
            {
                return new BitmapImage(new Uri("pack://application:,,,/TollTicketManagement;component/Resources/Images/led_green.png", UriKind.RelativeOrAbsolute));
            }
            else if (int.Parse(value.ToString()) == 1)
            {
                return new BitmapImage(new Uri("pack://application:,,,/TollTicketManagement;component/Resources/Images/led_red.png", UriKind.RelativeOrAbsolute));
            }
            else if (int.Parse(value.ToString()) >= 2)
            {
                return new BitmapImage(new Uri("pack://application:,,,/TollTicketManagement;component/Resources/Images/led_gray.png", UriKind.RelativeOrAbsolute));
            }
            return null;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}