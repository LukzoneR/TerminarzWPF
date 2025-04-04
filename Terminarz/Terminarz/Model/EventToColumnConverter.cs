using System.Globalization;
using System.Windows.Data;

namespace Terminarz.Model;

public class EventToColumnConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTime date)
        {
            int dayOfWeek = (int)date.DayOfWeek;
            return dayOfWeek == 0 ? 6 : dayOfWeek - 1;
        }
        return 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
