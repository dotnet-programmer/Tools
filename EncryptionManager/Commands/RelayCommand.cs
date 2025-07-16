using System.Windows.Input;

namespace EncryptionManager.Commands;

internal class RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null) : ICommand
{
	private readonly Action<object?> _execute = execute ?? throw new ArgumentNullException(nameof(execute));
	private readonly Predicate<object?>? _canExecute = canExecute;

	public RelayCommand(Action execute, Func<bool>? canExecute = null) : this(
		execute != null ? _ => execute() : throw new ArgumentNullException(nameof(execute)),
		canExecute != null ? _ => canExecute() : null)
	{
	}

	public event EventHandler? CanExecuteChanged
	{
		add => CommandManager.RequerySuggested += value;
		remove => CommandManager.RequerySuggested -= value;
	}

	public bool CanExecute(object? parameter)
		=> _canExecute == null || _canExecute(parameter);

	public void Execute(object? parameter)
		=> _execute(parameter);

	// Allows manual raising of CanExecuteChanged
	public void RaiseCanExecuteChanged()
		=> CommandManager.InvalidateRequerySuggested();
}