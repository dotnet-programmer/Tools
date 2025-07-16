using System.Windows;
using EncryptionManager.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EncryptionManager.Services;

internal class DialogService(IServiceProvider serviceProvider) : IDialogService
{
	public void Show<T>() where T : Window
	{
		T dialog = serviceProvider.GetRequiredService<T>();
		dialog.Show();
	}

	public async Task ShowAsync<T>() where T : Window
	{
		T window = serviceProvider.GetRequiredService<T>();
		await window.Dispatcher.InvokeAsync(() => window.Show());
	}

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

//public bool? ShowDialogWithErrorHandling<T>() where T : Window
//	{
//		// Error Handling where a dialog cannot be resolved or shown
//		try
//		{
//			var dialog = _serviceProvider.GetRequiredService<T>();
//			dialog.Owner = Application.Current?.MainWindow;
//			return dialog.ShowDialog();
//		}
//		catch (Exception ex)
//		{
//			_logger?.LogError(ex, "Failed to show dialog of type {DialogType}", typeof(T).Name);
//			MessageBox.Show(
//				$"An error occurred while opening the dialog: {typeof(T).Name}\n\n{ex.Message}",
//				"Dialog Error",
//				MessageBoxButton.OK,
//				MessageBoxImage.Error);
//			return false;
//		}
//	}

//public async Task<bool?> ShowDialogAsyncWithErrorHandling<T>() where T : Window
//	{
//		try
//		{
//			var dialog = _serviceProvider.GetRequiredService<T>();
//			dialog.Owner = Application.Current?.MainWindow;
//			var tcs = new TaskCompletionSource<bool?>();

//			await dialog.Dispatcher.InvokeAsync(() =>
//			{
//				tcs.SetResult(dialog.ShowDialog());
//			});

//			return await tcs.Task;
//		}
//		catch (Exception ex)
//		{
//			_logger?.LogError(ex, "Failed to show dialog asynchronously of type {DialogType}", typeof(T).Name);
//			MessageBox.Show(
//				$"An error occurred while opening the dialog: {typeof(T).Name}\n\n{ex.Message}",
//				"Dialog Error",
//				MessageBoxButton.OK,
//				MessageBoxImage.Error);
//			return false;
//		}
//	}