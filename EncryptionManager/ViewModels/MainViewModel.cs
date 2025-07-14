using EncryptionManager.Interfaces;
using Microsoft.Extensions.Logging;

namespace EncryptionManager.ViewModels;

internal class MainViewModel : BaseViewModel, IMainViewModel
{
	private readonly ILogger<MainViewModel> _logger;

	public MainViewModel(ILogger<MainViewModel> logger)
	{
		_logger = logger;
		_logger.LogInformation("MainViewModel initialized.");
	}
}