namespace FluentMusicMetadataEditor.UI.Input;

public sealed class RelayCommand : RelayCommand<object>
{
    public RelayCommand(Action action)
        : this(action, canExecute: null) { }

    public RelayCommand(Action action, Predicate<object?>? canExecute)
        : base(action, canExecute) { }
}