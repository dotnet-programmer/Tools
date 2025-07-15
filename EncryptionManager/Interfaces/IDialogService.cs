using System.Windows;

namespace EncryptionManager.Interfaces;

internal interface IDialogService
{
	void Show<T>(Window? owner = null) where T : Window;
	Task ShowAsync<T>(Window? owner = null) where T : Window;
	bool? ShowDialog<T>(Window? owner = null) where T : Window;
	Task<bool?> ShowDialogAsync<T>(Window? owner = null) where T : Window;
}