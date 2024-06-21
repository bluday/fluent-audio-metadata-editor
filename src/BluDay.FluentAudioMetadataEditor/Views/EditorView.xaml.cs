namespace BluDay.FluentAudioMetadataEditor.Views;

public sealed partial class EditorView : UserControl
{
    public AudioFileInfo? FileInfo { get; set; }

    public ICommand? SettingsButtonCommand
    {
        get => SettingsButton.Command;
        set => SettingsButton.Command = value;
    }

    public EditorView() => InitializeComponent();
}