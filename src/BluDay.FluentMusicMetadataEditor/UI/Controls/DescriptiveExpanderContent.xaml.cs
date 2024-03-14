using Microsoft.UI.Xaml.Media;

namespace BluDay.FluentMusicMetadataEditor.UI.Controls;

public sealed partial class DescriptiveExpanderContent : UserControl
{
    public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
        nameof(Description),
        typeof(string),
        typeof(DescriptiveExpanderContent),
        new PropertyMetadata(
            defaultValue:            null,
            propertyChangedCallback: OnDescriptionChanged
        )
    );

    public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(
        nameof(Glyph),
        typeof(string),
        typeof(DescriptiveExpanderContent),
        new PropertyMetadata(
            defaultValue:            null,
            propertyChangedCallback: OnGlyphChanged
        )
    );

    public static readonly DependencyProperty GlyphSizeProperty = DependencyProperty.Register(
        nameof(GlyphSize),
        typeof(double),
        typeof(DescriptiveExpanderContent),
        new PropertyMetadata(defaultValue: 20.0)
    );

    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon),
        typeof(ImageSource),
        typeof(DescriptiveExpanderContent),
        new PropertyMetadata(
            defaultValue:            null,
            propertyChangedCallback: OnIconChanged
        )
    );

    public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register(
        nameof(SelectedValue),
        typeof(string),
        typeof(DescriptiveExpanderContent),
        new PropertyMetadata(defaultValue: null)
    );

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title),
        typeof(string),
        typeof(DescriptiveExpanderContent),
        new PropertyMetadata(defaultValue: nameof(Title))
    );

    public ImageSource? Icon
    {
        get => GetValue(IconProperty) as ImageSource;
        set => SetValue(IconProperty, value);
    }

    public double GlyphSize
    {
        get => (double)GetValue(GlyphSizeProperty);
        set => SetValue(GlyphSizeProperty, value);
    }

    public string? Glyph
    {
        get => GetValue(GlyphProperty) as string;
        set => SetValue(GlyphProperty, value);
    }

    public string? Description
    {
        get => GetValue(DescriptionProperty) as string;
        set => SetValue(DescriptionProperty, value);
    }

    public string? SelectedValue
    {
        get => GetValue(SelectedValueProperty) as string;
        set => SetValue(SelectedValueProperty, value);
    }

    public string? Title
    {
        get => GetValue(TitleProperty) as string;
        set => SetValue(TitleProperty, value);
    }

    public DescriptiveExpanderContent() => InitializeComponent();

    private static void OnDescriptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        bool empty = !((string)e.NewValue).IsNullOrWhiteSpace();
        
        ((DescriptiveExpanderContent)d).DescriptionTextBlock.Visibility = empty.ToVisibility();
    }

    private static void OnGlyphChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var content = (DescriptiveExpanderContent)d;

        var value = (string)e.NewValue;

        bool hasValue = !value.IsNullOrWhiteSpace();

        content.GlyphFontIcon.Visibility = hasValue.ToVisibility();

        if (!hasValue) content.Icon = null;
    }

    private static void OnIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var content = (DescriptiveExpanderContent)d;

        var value = e.NewValue as ImageSource;

        bool hasValue = value is not null;

        content.IconImage.Visibility = hasValue.ToVisibility();

        if (!hasValue) content.Glyph = null;
    }
}