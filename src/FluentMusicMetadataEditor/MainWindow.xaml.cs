using FluentMusicMetadataEditor.UI.Input;
using Microsoft.UI.Input;
using Microsoft.UI.Windowing;

namespace FluentMusicMetadataEditor;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private readonly AppWindow _appWindow;

    private readonly EditorView _editorView = new();
    
    private readonly SettingsView _settingsView = new();

    public DisplayArea DisplayArea { get; }

    public InputNonClientPointerSource NonClientPointerSource { get; }

    public MainWindow()
    {
        _appWindow = AppWindow;

        DisplayArea            = _appWindow.GetDisplayArea();
        NonClientPointerSource = _appWindow.GetNonClientPointerSource();

        InitializeComponent();

        ConfigureAppWindow();
        ConfigureTitleBar();
        ConfigureViews();
    }

    private void ConfigureAppWindow()
    {
        _appWindow.MakeTitleBarTransparent();
        _appWindow.SetIsResizable(false);
        _appWindow.Resize(size: 1200);
        _appWindow.MoveToCenter(DisplayArea);
    }

    private void ConfigureTitleBar()
    {
        ExtendsContentIntoTitleBar = true;

        TitleBar titleBar = TitleBar;

        SetTitleBar(titleBar);

        titleBar.BackButtonCommand = new RelayCommand(ShowEditor);

        titleBar.InteractiveRegionRectsChanged += TitleBar_InteractiveRegionRectsChanged;
    }

    private void ConfigureViews()
    {
        _editorView.SettingsButtonCommand = new RelayCommand(ShowSettings);

        // SettingsView
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
        var region = NonClientRegionKind.Passthrough;

        TitleBar titleBar = TitleBar;

        if (!titleBar.IsBackButtonVisible)
        {
            NonClientPointerSource.ClearRegionRects(region);

            return;
        }

        NonClientPointerSource.SetRegionRects(region, titleBar.InteractiveRegionRects);
    }
    #endregion
}