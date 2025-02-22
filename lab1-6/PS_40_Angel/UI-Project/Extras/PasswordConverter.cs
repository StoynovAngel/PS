﻿using System.Globalization;
using System.Windows.Data;

namespace UI_Project.Extras;

public class PasswordConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return string.Empty;
        return new string('*', value.ToString().Length);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}