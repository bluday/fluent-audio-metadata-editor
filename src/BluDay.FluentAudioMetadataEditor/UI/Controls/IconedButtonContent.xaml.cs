namespace BluDay.FluentAudioMetadataEditor.UI.Controls;

public sealed partial class IconedButtonContent : UserControl
{
    public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(
        nameof(Glyph),
        typeof(string),
        typeof(IconedButtonContent),
        new PropertyMetadata(defaultValue: string.Empty)
    );

    public static readonly DependencyProperty GlyphSizeProperty = DependencyProperty.Register(
        nameof(GlyphSize),
        typeof(double),
        typeof(IconedButtonContent),
        new PropertyMetadata(defaultValue: 16.0)
    );

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text),
        typeof(string),
        typeof(IconedButtonContent),
        new PropertyMetadata(defaultValue: string.Empty)
    );

    public static readonly DependencyProperty SpacingProperty = DependencyProperty.Register(
        nameof(Spacing),
        typeof(double),
        typeof(IconedButtonContent),
        new PropertyMetadata(defaultValue: (double)6)
    );

    public double GlyphSize
    {
        get => (double)GetValue(GlyphSizeProperty);
        set => SetValue(GlyphSizeProperty, value);
    }

    public double Spacing
    {
        get => (double)GetValue(SpacingProperty);
        set => SetValue(SpacingProperty, value);
    }

    public string? Glyph
    {
        get => GetValue(GlyphProperty) as string;
        set => SetValue(GlyphProperty, value);
    }

    public string? Text
    {
        get => GetValue(TextProperty) as string;
        set => SetValue(TextProperty, value);
    }

    public IconedButtonContent() => InitializeComponent();
}