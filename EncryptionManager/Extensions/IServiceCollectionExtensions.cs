using System.Reflection;
using System.Windows;
using EncryptionManager.Interfaces;
using EncryptionManager.Services;
using EncryptionManager.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace EncryptionManager.Extensions;

internal static class IServiceCollectionExtensions
{
	public static void ConfigureServices(this IServiceCollection services)
	{
		// Configure Logging
		services.AddLogging(loggingBuilder =>
		{
			loggingBuilder.ClearProviders();
			loggingBuilder.SetMinimumLevel(LogLevel.Information);
			loggingBuilder.AddNLog("nlog.config");
		});

		// Register ViewModels
		services.AddSingleton<IMainViewModel, MainViewModel>();

		// Register DialogService
		services.AddSingleton<IDialogService, DialogService>();

		// Automatically register all Windows (dialogs)
		var windowType = typeof(Window);
		var assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();
		foreach (var type in assemblyTypes)
		{
			if (type.IsSubclassOf(windowType) && !type.IsAbstract)
			{
				services.AddTransient(type);
			}
		}
	}
}