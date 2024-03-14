using BluDay.FluentMusicMetadataEditor.UI.Input;
using Microsoft.UI.Input;
using Microsoft.UI.Windowing;

namespace BluDay.FluentMusicMetadataEditor;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private readonly AppWindow _appWindow;

    private readonly EditorView _editorView = new();
    
    private readonly SettingsView _settingsView = new();

    private readonly TitleBar _titleBar;

    public DisplayArea DisplayArea { get; }

    public InputNonClientPointerSource NonClientPointerSource { get; }

    public MainWindow()
    {
        _appWindow = AppWindow;

        _titleBar = TitleBar;

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

        SetTitleBar(_titleBar);

        _titleBar.BackButtonCommand = new RelayCommand(ShowEditor);

        _titleBar.InteractiveRegionRectsChanged += _titleBar_InteractiveRegionRectsChanged;
    }

    private void ConfigureViews()
    {
        _editorView.SettingsButtonCommand = new RelayCommand(ShowSettings);

        // SettingsView
    }

    private void ShowEditor()
    {
        ContentControl.Content = _editorView;

        _titleBar.IsBackButtonVisible = false;
    }

    private void ShowSettings()
    {
        ContentControl.Content = _settingsView;

        _titleBar.IsBackButtonVisible = true;
    }

    #region Event handlers
    private void RootGrid_Loaded(object sender, RoutedEventArgs e)
    {
        ShowEditor();

        RootGrid.Loaded -= RootGrid_Loaded;
    }

    private void _titleBar_InteractiveRegionRectsChanged(object? sender, EventArgs e)
    {
        var region = NonClientRegionKind.Passthrough;

        if (!_titleBar.IsBackButtonVisible)
        {
            NonClientPointerSource.ClearRegionRects(region);

            return;
        }

        NonClientPointerSource.SetRegionRects(region, _titleBar.InteractiveRegionRects);
    }
    #endregion
}