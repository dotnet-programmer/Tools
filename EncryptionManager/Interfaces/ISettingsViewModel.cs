using System.Windows.Input;
using EncryptionManager.Models;

namespace EncryptionManager.Interfaces;

public interface ISettingsViewModel
{
	UserSettings Settings { get; set; }

	ICommand ConfirmCommand { get; }
	ICommand CloseWindowCommand { get; }
}