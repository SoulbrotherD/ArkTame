using System;
using System.Windows.Input;

namespace ArkTameClassic.Framework;

public class RelayCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool>? _canExecute;

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute();
    }

    public void Execute(object? parameter)
    {
        _execute();
    }

    public event EventHandler? CanExecuteChanged;
}

public class RelayCommand<T> : ICommand
{
    private readonly Action<T> _execute;
    private readonly Func<T, bool>? _canExecute;

    public RelayCommand(Action<T> execute, Func<T, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        if (parameter is T value)
        {
            return _canExecute == null || _canExecute(value);
        }

        return false;
    }

    public void Execute(object? parameter)
    {
        if (parameter is T value)
        {
            _execute(value);
        }
    }

    public event EventHandler? CanExecuteChanged;
}