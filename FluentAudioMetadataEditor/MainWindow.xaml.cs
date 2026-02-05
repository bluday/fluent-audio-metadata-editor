using FluentAudioMetadataEditor.Extensions;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.Windows.ApplicationModel.Resources;
using System;
using Windows.Win32;
using Windows.Win32.Foundation;
using WinRT.Interop;

namespace FluentAudioMetadataEditor;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    /// <summary>
    /// The standard or user-default screen DPI value.
    /// </summary>
    public const int DEFAULT_DPI_SCALE = 96;

    private ResourceLoader _resourceLoader = new();

    private double _dpiScaleFactor;

    /// <summary>
    /// The absolute path for the 64x64 icon.
    /// </summary>
    public static readonly string IconPath = System.IO.Path.Combine(
        AppContext.BaseDirectory, "Assets", "Icon-64.ico"
    );

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();

        RetrieveAndUpdateDpiScaleFactor();

        ConfigureAppWindow();
        ConfigureTitleBar();
    }

    private void RetrieveAndUpdateDpiScaleFactor()
    {
        uint value = PInvoke.GetDpiForWindow((HWND)WindowNative.GetWindowHandle(this));

        _dpiScaleFactor = (double)value / DEFAULT_DPI_SCALE;
    }

    /// <summary>
    /// Configures the underlying native app window instance.
    /// </summary>
    public void ConfigureAppWindow()
    {
        OverlappedPresenter presenter = OverlappedPresenter.Create();

        presenter.IsMaximizable = false;
        presenter.IsResizable   = false;

        AppWindow appWindow = AppWindow;

        appWindow.SetPresenter(presenter);
        
        appWindow.Resize(1200, 1200);

        appWindow.MoveToCenter();

        appWindow.SetIcon(IconPath);
    }

    /// <summary>
    /// Configures the client and non-client title bar.
    /// </summary>
    public void ConfigureTitleBar()
    {
        string title = _resourceLoader.GetString("General/AppDisplayName");

        AppWindow.SetIcon(IconPath);

        SetTitleBar(AppTitleBar);
        
        ExtendsContentIntoTitleBar = true;

        Title = title;

        AppTitleBar.Icon = new BitmapImage(new Uri(IconPath));

        AppTitleBar.Title = title;
    }
}
