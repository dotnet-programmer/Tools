using System.Windows.Input;
using EncryptionManager.Commands;
using EncryptionManager.Interfaces;

namespace EncryptionManager.ViewModels;

internal class LoginViewModel : BaseViewModel, ILoginViewModel
{
	public LoginViewModel()
	{

	}

	public ICommand LoginCommand => new RelayCommand(Login, CanLogin);

	public event EventHandler? LoginSuccessful;

	private void Login()
	{
		LoginSuccessful?.Invoke(this, EventArgs.Empty);
	}

	private bool CanLogin()
		=> true;
}