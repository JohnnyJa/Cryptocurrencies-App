using System;
using System.Globalization;
using System.Windows.Data;

namespace NewApp.Converters;

public class PercentConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string percent = (string)value;
        int cutSize = 0;
        foreach (var letter in percent)
        {
            cutSize++;
            if (letter == '.')
                break;
        }

        return percent[..(cutSize + 2)] + "%";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}