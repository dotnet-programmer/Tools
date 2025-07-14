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
		ServiceCollection serviceCollection = new();
		serviceCollection.ConfigureServices();
		_serviceProvider = serviceCollection.BuildServiceProvider();
		var mainView = _serviceProvider.GetRequiredService<MainView>();
		mainView.Show();
		base.OnStartup(e);
	}

	protected override void OnExit(ExitEventArgs e)
	{
		if (_serviceProvider is IDisposable disposable)
		{
			disposable.Dispose();
		}
		base.OnExit(e);
	}
}