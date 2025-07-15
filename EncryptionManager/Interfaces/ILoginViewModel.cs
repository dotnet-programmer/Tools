using System.Windows.Input;
using EncryptionManager.DataLayer.Dtos;
using EncryptionManager.Models;

namespace EncryptionManager.Interfaces;

public interface ILoginViewModel
{
	UserDto User { get; set; }
	ConnectionStatus? Status { get; set; }
	bool IsCheckConnectionEnabled { get; set; }
	ICommand CheckConnectionCommand { get; }
	ICommand ShowSettingsCommand { get; }
	ICommand LoginCommand { get; }
	ICommand CloseAppCommand { get; }
	event EventHandler? LoginSuccessful;
}