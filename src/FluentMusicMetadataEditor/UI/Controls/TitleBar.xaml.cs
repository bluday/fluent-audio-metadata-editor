using FluentMusicMetadataEditor.Common;
using Microsoft.UI.Xaml.Media;
using Windows.Graphics;

namespace FluentMusicMetadataEditor.UI.Controls;

public sealed partial class TitleBar : UserControl
{
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon),
        typeof(ImageSource),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: null)
    );

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title),
        typeof(string),
        typeof(TitleBar),
        new PropertyMetadata(defaultValue: null)
    );

    public RectInt32[] InteractiveRegionRects { get; private set; } = null!;

    public ImageSource? Icon
    {
        get => GetValue(IconProperty) as ImageSource;
        set => SetValue(IconProperty, value);
    }

    public bool IsBackButtonEnabled
    {
        get => BackButton.IsEnabled;
        set => BackButton.IsEnabled = value;
    }

    public bool IsBackButtonVisible
    {
        get => BackButton.Visibility is Visibility.Visible;
        set
        {
            if (value == BackButton.IsEnabled)
            {
                return;
            }

            BackButton.IsEnabled = value;

            BackButton.Visibility = (value is true).ToVisibility();

            UpdateInteractiveRegionRects();
        }
    }

    public string? Title
    {
        get => GetValue(TitleProperty) as string;
        set => SetValue(TitleProperty, value);
    }

    public System.Windows.Input.ICommand? BackButtonCommand
    {
        get => BackButton.Command;
        set => BackButton.Command = value;
    }

    public event EventHandler InteractiveRegionRectsChanged = null!;

    public TitleBar() => InitializeComponent();

    private void UpdateInteractiveRegionRects()
    {
        InteractiveRegionRects = GetInteractiveRegionRects();

        InteractiveRegionRectsChanged?.Invoke(this, EventArgs.Empty);
    }

    private RectInt32[] GetInteractiveRegionRects(double? scaleAdjustment = null)
    {
        double scale = scaleAdjustment ?? XamlRoot.RasterizationScale;

        return new RectInt32[]
        {
            BackButton
                .GetVisualTransformBoundsRect()
                .GetScaledRect(scale)
        };
    }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        UpdateInteractiveRegionRects();

        Loaded -= UserControl_Loaded;
    }

    private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        UpdateInteractiveRegionRects();
    }
}