using BluDay.Net.WinUI3.Extensions;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.Windows.ApplicationModel.Resources;
using System;

namespace FluentAudioMetadataEditor.Controls;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Microsoft.UI.Xaml.Window
{
    private ResourceLoader _resourceLoader;

    private double _currentDpiScaleFactor;

    private readonly AppWindow _appWindow;

    private readonly OverlappedPresenter _overlappedPresenter;

    /// <summary>
    /// The absolute path for the 64x64 icon.
    /// </summary>
    public static readonly string IconPath = System.IO.Path.Combine(AppContext.BaseDirectory, "Assets", "Icon-64.ico");

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();

        _resourceLoader = new ResourceLoader();

        _currentDpiScaleFactor = this.GetDpiScaleFactorInDecimal();

        _appWindow = AppWindow;

        _overlappedPresenter = OverlappedPresenter.Create();

        ConfigureAppWindow();
        ConfigureTitleBar();
    }

    /// <summary>
    /// Configures the underlying native app window instance.
    /// </summary>
    public void ConfigureAppWindow()
    {
        _overlappedPresenter.IsMaximizable = false;
        _overlappedPresenter.IsResizable   = false;

        _appWindow.SetPresenter(_overlappedPresenter);
        
        _appWindow.Resize(1200, 1200);

        _appWindow.MoveToCenter();

        _appWindow.SetIcon(IconPath);
    }

    /// <summary>
    /// Configures the client and non-client title bar.
    /// </summary>
    public void ConfigureTitleBar()
    {
        string title = _resourceLoader.GetString("General/AppDisplayName");

        _appWindow.SetIcon(IconPath);

        SetTitleBar(AppTitleBar);
        
        ExtendsContentIntoTitleBar = true;

        Title = title;

        AppTitleBar.Icon = new BitmapImage(new Uri(IconPath));

        AppTitleBar.Title = title;
    }
}
