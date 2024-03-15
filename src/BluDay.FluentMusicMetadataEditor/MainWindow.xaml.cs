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

    private readonly DisplayArea _displayArea;

    private readonly InputNonClientPointerSource _nonClientPointerSource;

    private readonly EditorView _editorView;
    
    private readonly SettingsView _settingsView;

    private readonly TitleBar _titleBar;

    public MainWindow()
    {
        InitializeComponent();

        _appWindow = AppWindow;

        _displayArea            = _appWindow.GetDisplayArea();
        _nonClientPointerSource = _appWindow.GetNonClientPointerSource();

        _editorView   = new();
        _settingsView = new();

        _titleBar = TitleBar;

        ConfigureAppWindow();
        ConfigureTitleBar();
        ConfigureViews();
    }

    private void ConfigureAppWindow()
    {
        _appWindow.MakeTitleBarTransparent();
        _appWindow.SetIsResizable(false);
        _appWindow.Resize(size: 1200);
        _appWindow.MoveToCenter(_displayArea);
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

        // TODO: Configure commands for settings view.
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
