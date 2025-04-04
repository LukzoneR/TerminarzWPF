using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Terminarz.Model;

public class EventToColumnMultiConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length < 2 || !(values[0] is Event eventItem) || !(values[1] is DateTime currentWeekStart))
            return DependencyProperty.UnsetValue;

        int dayDifference = (int)(eventItem.Starts.Date - currentWeekStart.Date).TotalDays;

        if (dayDifference >= 0 && dayDifference < 7)
            return dayDifference;

        return DependencyProperty.UnsetValue;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}