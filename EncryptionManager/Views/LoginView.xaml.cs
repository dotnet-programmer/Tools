using System.Windows;
using EncryptionManager.Interfaces;

namespace EncryptionManager.Views;

public partial class LoginView : Window
{
	public event EventHandler? LoginSucceeded;

	public LoginView(ILoginViewModel loginViewModel)
	{
		InitializeComponent();
		DataContext = loginViewModel;

		loginViewModel.LoginSuccessful += (s, e) => { LoginSucceeded?.Invoke(this, EventArgs.Empty); };
	}
}