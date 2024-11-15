using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MasterPol.Converters;

/// <summary>
/// Конвертер для конвертации bool к Visibility
/// </summary>
public class BoolToVisibilityConverter:IValueConverter
{
    /// <summary>
    /// Логика конвертации
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
            return boolValue? Visibility.Visible : Visibility.Collapsed;

        throw new InvalidOperationException();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
}