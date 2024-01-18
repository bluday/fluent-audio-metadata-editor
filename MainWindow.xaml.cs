using FluentMusicMetadataEditor.UI.Input;
using Microsoft.UI.Input;
using Microsoft.UI.Windowing;

namespace FluentMusicMetadataEditor;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public readonly EditorView _editorView = new();
    
    public readonly SettingsView _settingsView = new();

    public DisplayArea DisplayArea { get; }

    public InputNonClientPointerSource NonClientPointerSource { get; }

    public MainWindow()
    {
        DisplayArea            = AppWindow.GetDisplayArea();
        NonClientPointerSource = AppWindow.GetNonClientPointerSource();

        InitializeComponent();

        ConfigureAppWindow();
        ConfigureTitleBar();
        ConfigureViews();
    }

    private void ConfigureAppWindow()
    {
        AppWindow.MakeTitleBarTransparent();
        AppWindow.SetIsResizable(false);
        AppWindow.Resize(size: 1200);
        AppWindow.MoveToCenter(DisplayArea);
    }

    private void ConfigureTitleBar()
    {
        ExtendsContentIntoTitleBar = true;

        SetTitleBar(TitleBar);

        TitleBar.BackButtonCommand = new RelayCommand(ShowEditor);

        TitleBar.InteractiveRegionRectsChanged += TitleBar_InteractiveRegionRectsChanged;
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

        if (!TitleBar.IsBackButtonVisible)
        {
            NonClientPointerSource.ClearRegionRects(region);

            return;
        }

        NonClientPointerSource.SetRegionRects(region, TitleBar.InteractiveRegionRects);
    }
    #endregion
}