namespace FluentMusicMetadataEditor.UI.Converters;

public sealed class BooleanToVisibilityConverter : Microsoft.UI.Xaml.Data.IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var visible = (bool)value;

        if (parameter is string option && option is "Negate")
        {
            visible = !visible;
        }

        return visible ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        var visibility = (Visibility)value;

        bool visible = visibility is Visibility.Visible;

        if (parameter is string option && option is "Negate")
        {
            visible = !visible;
        }

        return visible;
    }
}