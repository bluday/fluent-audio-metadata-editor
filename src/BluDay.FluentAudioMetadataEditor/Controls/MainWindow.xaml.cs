namespace BluDay.FluentAudioMetadataEditor.Controls;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private readonly AppWindow _appWindow;

    private readonly DisplayArea _displayArea;

    private readonly InputNonClientPointerSource _nonClientPointerSource;

    private readonly EditorView _editorView = new();

    private readonly SettingsView _settingsView = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        _appWindow = AppWindow;

        _displayArea            = _appWindow.GetDisplayArea();
        _nonClientPointerSource = _appWindow.GetNonClientPointerSource();

        _appWindow.MakeTitleBarTransparent();
        _appWindow.SetIsResizable(false);
        _appWindow.Resize(size: 1200);
        _appWindow.MoveToCenter(_displayArea);

        InitializeComponent();

        ConfigureTitleBar();
    }

    private void ConfigureTitleBar()
    {
        ExtendsContentIntoTitleBar = true;

        SetTitleBar(TitleBar);

        _appWindow.SetIcon("Assets/Icon-64.ico");

        TitleBar.InteractiveRegionRectsChanged += TitleBar_InteractiveRegionRectsChanged;
    }

    private void ShowEditor()
    {
        ContentControl.Content = _editorView;

        TitleBar.IsBackButtonVisible = false;
    }

    private void ShowSettings()
    {
        ContentControl.Content = _settingsView;

        TitleBar.IsBackButtonVisible = true;
    }

    #region Event handlers
    private void RootGrid_Loaded(object sender, RoutedEventArgs e)
    {
        ShowEditor();

        RootGrid.Loaded -= RootGrid_Loaded;
    }

    private void TitleBar_InteractiveRegionRectsChanged(object? sender, EventArgs e)
    {
        NonClientRegionKind region = NonClientRegionKind.Passthrough;

        if (!TitleBar.IsBackButtonVisible)
        {
            _nonClientPointerSource.ClearRegionRects(region);

            return;
        }

        _nonClientPointerSource.SetRegionRects(region, TitleBar.InteractiveRegionRects);
    }
    #endregion
}
