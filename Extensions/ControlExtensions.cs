﻿namespace BluDay.FluentAudioMetadataEditor.Extensions;

public static class ControlExtensions
{
    public static Rect GetVisualTransformBoundsRect(this FrameworkElement source)
    {
        Rect rect = new(0, 0, source.ActualWidth, source.ActualHeight);

        return source.TransformToVisual(null).TransformBounds(rect);
    }
}