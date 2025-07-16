using System.Windows;
using System.Windows.Input;
using EncryptionManager.Commands;
using EncryptionManager.Interfaces;
using EncryptionManager.Models;
using EncryptionManager.Views;

namespace EncryptionManager.ViewModels;

internal class SettingsViewModel(IDialogService dialogService) : BaseViewModel, ISettingsViewModel
{
	private UserSettings _settings = new();
	public UserSettings Settings
	{
		get => _settings;
		set { _settings = value; OnPropertyChanged(); }
	}

	public ICommand ConfirmCommand => new RelayCommand(Confirm, CanConfirm);
	public ICommand CloseWindowCommand => new RelayCommand(CloseWindow);

	private void Confirm(object? commandParameter)
	{
		Settings.Save();
		ShowLoginWindow(commandParameter);
	}

	private bool CanConfirm(object? commandParameter)
		=> Settings.IsValid;

	private void CloseWindow(object? commandParameter)
		=> ShowLoginWindow(commandParameter);

	private void ShowLoginWindow(object? commandParameter)
	{
		dialogService.Show<LoginView>();
		if (commandParameter is Window window)
		{
			window.Close();
		}
	}
}