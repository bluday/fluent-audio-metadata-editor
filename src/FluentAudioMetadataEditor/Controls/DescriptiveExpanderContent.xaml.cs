using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

namespace FluentAudioMetadataEditor.Controls;

/// <summary>
/// Interaction logic for DescriptiveExpanderContent.xaml.
/// </summary>
public sealed partial class DescriptiveExpanderContent : Microsoft.UI.Xaml.Controls.UserControl
{
    public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
        nameof(Description),
        typeof(string),
        typeof(DescriptiveExpanderContent),
        new PropertyMetadata(defaultValue: null)
    );

    public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(
        nameof(Glyph),
        typeof(string),
        typeof(DescriptiveExpanderContent),
        new PropertyMetadata(defaultValue: null)
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
        new PropertyMetadata(defaultValue: null)
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

    /// <summary>
    /// Initializes a new instance of the <see cref="DescriptiveExpanderContent"/> class.
    /// </summary>
    public DescriptiveExpanderContent()
    {
        InitializeComponent();
    }
}