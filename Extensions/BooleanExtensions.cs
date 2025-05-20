﻿namespace BluDay.FluentAudioMetadataEditor.Extensions;

public static class BooleanExtensions
{
    public static Visibility ToVisibility(this bool source)
    {
        return source is true ? Visibility.Visible : Visibility.Collapsed;
    }
}