using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace YouTubeDownloaderMAUI.Converters;

// ✅ This converter reverses true/false for button enabling and UI logic
public class InverseBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is bool b ? !b : value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is bool b ? !b : value;
    }
}
