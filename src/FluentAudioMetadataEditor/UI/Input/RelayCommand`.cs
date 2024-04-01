namespace FluentAudioMetadataEditor.UI.Input;

public class RelayCommand<TParam> : System.Windows.Input.ICommand where TParam : notnull
{
    private readonly Action<TParam?> _execute;

    private readonly Predicate<TParam?>? _canExecute;

    public event EventHandler? CanExecuteChanged;

    public RelayCommand(Action action)
        : this(action, canExecute: null) { }

    public RelayCommand(Action action, Predicate<TParam?>? canExecute)
        : this(execute: _ => action(), canExecute) { }

    public RelayCommand(Action<TParam?> execute)
        : this(execute, canExecute: null) { }

    public RelayCommand(Action<TParam?> execute, Predicate<TParam?>? canExecute)
    {
        ArgumentNullException.ThrowIfNull(execute);

        _execute    = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute?.Invoke((TParam)parameter!) ?? true;
    }

    public void Execute(object? parameter)
    {
        _execute((TParam)parameter!);
    }
}