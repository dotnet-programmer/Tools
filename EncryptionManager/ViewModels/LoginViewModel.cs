using System.Timers;
using System.Windows;
using System.Windows.Input;
using EncryptionManager.Commands;
using EncryptionManager.DataLayer.Dtos;
using EncryptionManager.Interfaces;
using EncryptionManager.Models;
using EncryptionManager.Views;
using Microsoft.Extensions.Logging;

namespace EncryptionManager.ViewModels;

internal class LoginViewModel : BaseViewModel, ILoginViewModel
{
	private static readonly string _windowsUserName = $@"{Environment.MachineName}\\{Environment.UserDomainName}\\{Environment.UserName} - {System.Security.Principal.WindowsIdentity.GetCurrent().Name}";

	private static readonly ConnectionStatus _connected = new() { StatusText = "Połączono z bazą danych!", IsValidConnection = true };
	private static readonly ConnectionStatus _disconnected = new() { StatusText = "Błąd połączenia!", IsValidConnection = false };
	private readonly System.Timers.Timer _checkConnectionTimer = new(5000);
	private readonly ILogger<LoginViewModel> _logger;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IDialogService _dialogService;

	private UserDto _user = new();
	private ConnectionStatus _status = new();
	private bool _isCheckConnectionEnabled = true;

	public LoginViewModel(ILogger<LoginViewModel> logger, IUnitOfWork unitOfWork, IDialogService dialogService)
	{
		_logger = logger;
		_unitOfWork = unitOfWork;
		_dialogService = dialogService;
		_checkConnectionTimer.Elapsed += UnlockRefreshButton;
		SetConnectionStatus();
	}

	public UserDto User
	{
		get => _user;
		set { _user = value; OnPropertyChanged(); }
	}

	public ConnectionStatus Status
	{
		get => _status;
		set { _status = value; OnPropertyChanged(); }
	}

	public bool IsCheckConnectionEnabled
	{
		get => _isCheckConnectionEnabled;
		set { _isCheckConnectionEnabled = value; OnPropertyChanged(); }
	}

	public ICommand CheckConnectionCommand => new RelayCommand(CheckConnection);
	public ICommand ShowSettingsCommand => new RelayCommand(ShowSettings);
	public ICommand LoginCommand => new RelayCommand(Login, CanLogin);
	public ICommand CloseAppCommand => new RelayCommand(CloseApp);

	//public event EventHandler? LoginSuccessful;

	private void CheckConnection()
	{
		IsCheckConnectionEnabled = false;
		_checkConnectionTimer.Start();
		SetConnectionStatus();
		if (!Status.IsValidConnection)
		{
			_logger.LogInformation("{Status.StatusText} - user: {User.Name}, użytkownik: {_windowsUserName}", Status.StatusText, User.Name, _windowsUserName);
		}
	}

	private void ShowSettings(object? commandParameter)
	{
		_dialogService.Show<SettingsView>();
		CloseWindow(commandParameter);
	}

	private void Login(object? commandParameter)
	{
		if (_unitOfWork.DbRepository.LoginToApplication(User))
		{
			CloseWindow(commandParameter);
			Application.Current.MainWindow.Visibility = Visibility.Visible;
		}
		else
		{
			_logger.LogInformation("Błąd logowania - user: {User.Name}, użytkownik: {_windowsUserName}", User.Name, _windowsUserName);
			MessageBox.Show("Podałeś złe dane do logowania!", "Błąd logowania!", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}

	private bool CanLogin(object? commandParameter)
		=> !User.HasErrors && Status.IsValidConnection;

	private void CloseApp()
		=> Application.Current.Shutdown();

	private void SetConnectionStatus()
		=> Status = _unitOfWork.DbRepository.IsValidConnectionToDataBase() ? _connected : _disconnected;

	private void UnlockRefreshButton(object? sender, ElapsedEventArgs e)
	{
		IsCheckConnectionEnabled = true;
		_checkConnectionTimer.Stop();
	}

	private void CloseWindow(object? commandParameter)
	{
		if (commandParameter is Window window)
		{
			window.Close();
		}
	}
}