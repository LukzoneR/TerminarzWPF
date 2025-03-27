using System;
using System.Windows.Input;

public class RelayCommand(Action<object> execute, Predicate<object>? canExecute = null) : ICommand
{
    private readonly Predicate<object>? _canExecute = canExecute;

    public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
    public void Execute(object parameter) => execute(parameter);
    public event EventHandler? CanExecuteChanged;
}