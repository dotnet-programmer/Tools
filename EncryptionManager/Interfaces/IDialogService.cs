using System.Windows;

namespace EncryptionManager.Interfaces;

public interface IDialogService
{
	bool? ShowDialog<T>(Window? owner = null) where T : Window;
	Task<bool?> ShowDialogAsync<T>(Window? owner = null) where T : Window;
}