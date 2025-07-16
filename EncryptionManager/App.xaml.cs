using System.Windows;
using EncryptionManager.Extensions;
using EncryptionManager.Views;
using Microsoft.Extensions.DependencyInjection;

namespace EncryptionManager;

public partial class App : Application
{
	private IServiceProvider? _serviceProvider;

	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);
		ServiceCollection serviceCollection = new();
		serviceCollection.ConfigureServices();
		_serviceProvider = serviceCollection.BuildServiceProvider();
		//ShowLoginWindow();
		LoginToApplication();
	}

	protected override void OnExit(ExitEventArgs e)
	{
		if (_serviceProvider is IDisposable disposable)
		{
			disposable.Dispose();
		}
		base.OnExit(e);
	}

	//private void ShowLoginWindow()
	//{
	//	var loginWindow = _serviceProvider!.GetRequiredService<LoginView>();
	//	loginWindow.LoginSucceeded += OnLoginSucceeded;
	//	loginWindow.Show();
	//}

	//private void OnLoginSucceeded(object? sender, EventArgs e)
	//{
	//	var mainWindow = _serviceProvider!.GetRequiredService<MainView>();
	//	Current.MainWindow = mainWindow;
	//	mainWindow.Show();

	//	if (sender is Window loginWindow)
	//	{
	//		loginWindow.Close();
	//	}
	//}

	private void LoginToApplication()
	{
		var mainWindow = _serviceProvider!.GetRequiredService<MainView>();
		Current.MainWindow = mainWindow;
		mainWindow.Hide();

		var loginWindow = _serviceProvider!.GetRequiredService<LoginView>();
		loginWindow.Show();
	}
}