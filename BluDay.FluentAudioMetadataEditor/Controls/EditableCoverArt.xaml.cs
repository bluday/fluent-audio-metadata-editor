namespace BluDay.FluentAudioMetadataEditor.Controls;

public sealed partial class EditableCoverArt : UserControl
{
    public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
        nameof(ImageSource),
        typeof(ImageSource),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: null)
    );

    public static readonly DependencyProperty IsEditableProperty = DependencyProperty.Register(
        nameof(IsEditable),
        typeof(bool),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: false)
    );

    public ImageSource? ImageSource
    {
        get => GetValue(ImageSourceProperty) as ImageSource;
        set => SetValue(ImageSourceProperty, value);
    }

    public bool IsEditable
    {
        get => (bool)GetValue(IsEditableProperty);
        set => SetValue(IsEditableProperty, value);
    }

    public EditableCoverArt() => InitializeComponent();
}