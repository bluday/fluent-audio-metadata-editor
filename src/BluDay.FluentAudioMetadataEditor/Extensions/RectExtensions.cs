namespace BluDay.FluentAudioMetadataEditor.Extensions;

public static class RectExtensions
{
    public static RectInt32 GetScaledRect(this Rect source, double scale)
    {
        return new RectInt32(
            (int)Math.Round(source.X * scale),
            (int)Math.Round(source.Y * scale),
            (int)Math.Round(source.Width  * scale),
            (int)Math.Round(source.Height * scale)
        );
    }
}