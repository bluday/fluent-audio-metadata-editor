namespace FluentAudioMetadataEditor.UI.Converters;

public sealed class DoubleToGridLengthConverter : Microsoft.UI.Xaml.Data.IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        GridUnitType? unitType = null;
        
        if (parameter is string unitTypeString && !unitTypeString.IsNullOrWhiteSpace())
        {
            unitType = Enum.Parse<GridUnitType>(unitTypeString);
        }

        double number = (value as double?) ?? 0;

        return new GridLength(number, unitType ?? GridUnitType.Auto);
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return value is GridLength length ? length.Value : null!;
    }
}