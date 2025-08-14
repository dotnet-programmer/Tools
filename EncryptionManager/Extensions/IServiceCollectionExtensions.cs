using System.Configuration;
using System.Reflection;
using System.Windows;
using EncryptionManager.DataLayer;
using EncryptionManager.DataLayer.Repositories;
using EncryptionManager.Interfaces;
using EncryptionManager.Models;
using EncryptionManager.Services;
using EncryptionManager.ViewModels;
using Microsoft.EntityFrameworkCore;
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

		// Encryption
		// once run it will generate keys, just run once in debugger, copy keys and remove call
		// var keyInfo = new KeyInfo();
		// keys can also be read from the configuration file
		//EncryptionService encryptionService = new(new KeyInfo("kk3zd3HAIZjiZnDUhuU9OMASs4eljyPBZ1WbFdgC3UE=", "4ITbLvvo3BWGObJRFH4wDg=="));
		var key = ConfigurationManager.AppSettings["key"];
		var iv = ConfigurationManager.AppSettings["iv"];
		if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(iv))
		{
			var keyInfo = new KeyInfo();
			key = keyInfo.KeyString;
			iv = keyInfo.IVString;
		}
		EncryptionService encryptionService = new(new KeyInfo(key, iv));
		services.AddSingleton<IEncryptionService>(encryptionService);

		// Configure Entity Framework Core and DbContext
		services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
		services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(new UserSettings(encryptionService).GetConnectionString()));
		services.AddDbContext<ApplicationDbContext>();

		services.AddTransient<IUnitOfWork, UnitOfWork>();
		services.AddTransient<IDbRepository, DbRepository>();

		// Register ViewModels
		services.AddTransient<IMainViewModel, MainViewModel>();
		services.AddTransient<ILoginViewModel, LoginViewModel>();
		services.AddTransient<ISettingsViewModel, SettingsViewModel>();

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