using BluDay.FluentAudioMetadataEditor.Core.Models;
using System.Windows.Input;

namespace BluDay.FluentAudioMetadataEditor.UI.Controls.Views;

public sealed partial class EditorView : UserControl, IView
{
    public AudioFileInfo? FileInfo { get; set; }

    public ICommand? SettingsButtonCommand
    {
        get => SettingsButton.Command;
        set => SettingsButton.Command = value;
    }

    public EditorView() => InitializeComponent();
}