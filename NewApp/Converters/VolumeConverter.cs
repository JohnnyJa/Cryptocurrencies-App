using System;
using System.Globalization;
using System.Windows.Data;

namespace NewApp.Converters;

public class VolumeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string volume = (string)value;
        int cutSize = 0;
        foreach (var letter in volume)
        {
            cutSize++;
            if (letter == '.')
                break;
        }

        return volume[..(cutSize + 5)];
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}