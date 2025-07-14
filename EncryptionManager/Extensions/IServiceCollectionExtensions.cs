﻿using System.Configuration;
using System.Reflection;
using System.Windows;
using EncryptionManager.DataLayer;
using EncryptionManager.Interfaces;
using EncryptionManager.Models;
using EncryptionManager.Services;
using EncryptionManager.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace EncryptionManager.Extensions;

internal static class IServiceCollectionExtensions
{
	public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
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
		EncryptionService encryptionService = new(new KeyInfo("kk3zd3HAIZjiZnDUhuU9OMASs4eljyPBZ1WbFdgC3UE=", "4ITbLvvo3BWGObJRFH4wDg=="));
		services.AddSingleton<IEncryptionService>(encryptionService);

		// Configure Entity Framework Core and DbContext
		services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
		var connectionString = "connection string"; // TODO: read from configuration and decrypt encrypted string
		//var connectionString = encryptionService.Decrypt(configuration.GetConnectionString("DefaultConnection"));
		services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

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