namespace BluDay.FluentMusicMetadataEditor.Core.Models;

public sealed class AudioFileInfo : Model
{
    public AudioFileCodecInfo? CodecInfo { get; }

    public AudioFileDescriptionInfo? DescriptionInfo { get; }

    public string? PreferredTitle
    {
        get
        {
            string title = DescriptionInfo?.Title!;

            if (title.IsNullOrWhiteSpace())
            {
                return System.IO.Path.GetFileName(LocationUri.AbsolutePath);
            }

            return title;
        }
    }

    public Uri LocationUri { get; } = null!;
}