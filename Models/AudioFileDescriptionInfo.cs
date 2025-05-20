namespace BluDay.FluentAudioMetadataEditor.Models;

public sealed class AudioFileDescriptionInfo : Model
{
    public string? Title { get; set; }

    public string? Artist { get; set; }

    public string? Album { get; set; }

    public string? Date { get; set; }

    public string? Publisher { get; set; }

    public string? Copyright { get; set; }

    public string? Comments { get; set; }

    public int? Rating { get; set; }
}