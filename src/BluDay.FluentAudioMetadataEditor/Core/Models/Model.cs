using System.ComponentModel;

namespace BluDay.FluentAudioMetadataEditor.Core.Models;

public abstract class Model : IEquatable<Model>, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public bool Equals(Model? other) => this == other;
}