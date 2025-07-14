using System.Windows;
using EncryptionManager.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EncryptionManager.Services;

internal class DialogService(IServiceProvider serviceProvider) : IDialogService
{
	public bool? ShowDialog<T>(Window? owner = null) where T : Window
	{
		T dialog = serviceProvider.GetRequiredService<T>();
		dialog.Owner = owner ?? Application.Current.MainWindow;
		return dialog.ShowDialog();
	}

	public async Task<bool?> ShowDialogAsync<T>(Window? owner = null) where T : Window
	{
		T dialog = serviceProvider.GetRequiredService<T>();
		dialog.Owner = owner ?? Application.Current.MainWindow;
		TaskCompletionSource<bool?> taskCompletionSource = new();
		await dialog.Dispatcher.InvokeAsync(() => { taskCompletionSource.SetResult(dialog.ShowDialog()); });
		return await taskCompletionSource.Task;
	}
}