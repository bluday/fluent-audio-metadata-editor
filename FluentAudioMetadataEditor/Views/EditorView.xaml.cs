using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace FluentAudioMetadataEditor.Views;

/// <summary>
/// Interaction logic for EditorView.xaml.
/// </summary>
public sealed partial class EditorView : UserControl
{
    /// <summary>
    /// The height of the settings dialog.
    /// </summary>
    public const int SETTINGS_DIALOG_HEIGHT = 500;

    /// <summary>
    /// The width of the settings dialog.
    /// </summary>
    public const int SETTINGS_DIALOG_WIDTH = 1000;

    /// <summary>
    /// Initializes a new instance of the <see cref="EditorView"/> class.
    /// </summary>
    public EditorView()
    {
        InitializeComponent();
    }

    private void ShowSettingsDialog()
    {
        ContentDialog contentDialog = new()
        {
            CloseButtonText = "Close",
            Content         = new SettingsView(),
            FullSizeDesired = true,
            Style           = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title           = "Settings",
            XamlRoot        = XamlRoot
        };

        DispatcherQueue.TryEnqueue(async () => await contentDialog.ShowAsync());
    }

    private void SettingsButton_Click(object sender, RoutedEventArgs e)
    {
        ShowSettingsDialog();
    }
}