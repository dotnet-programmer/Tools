using System.Windows;
using EncryptionManager.Interfaces;

namespace EncryptionManager.Views;

public partial class LoginView : Window
{
	public LoginView(ILoginViewModel loginViewModel)
	{
		InitializeComponent();
		DataContext = loginViewModel;
	}
}