using System.Windows.Data;
using System.Windows.Media;

namespace Terminarz.Model;

public class ColorHexToBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value == null) return Brushes.Blue;

        try
        {
            var color = (Color)ColorConverter.ConvertFromString(value.ToString());
            return new SolidColorBrush(color);
        }
        catch
        {
            return Brushes.Blue;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}