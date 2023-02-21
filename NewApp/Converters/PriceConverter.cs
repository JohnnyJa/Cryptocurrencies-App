using System;
using System.Globalization;
using System.Windows.Data;

namespace NewApp.Converters;

public class PriceConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string price = (string)value;
        int cutSize = 0;
        foreach (var letter in price)
        {
            cutSize++;
            if (letter == '.')
                break;
        }

        return price[..(cutSize + 5)] + " USD";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}