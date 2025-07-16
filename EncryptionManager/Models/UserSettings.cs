using System.ComponentModel;
using System.Configuration;
using System.Text;
using EncryptionManager.Interfaces;

namespace EncryptionManager.Models;

public class UserSettings : IDataErrorInfo
{
	private const string NotEncryptedPrefix = "encrypt:";
	
	private readonly IEncryptionService _encryptionService;

	private bool _isServerAddressValid;
	private bool _isServerNameValid;
	private bool _isDatabaseValid;
	private bool _isUserValid;
	private bool _isPasswordValid;

	public UserSettings(IEncryptionService encryptionService)
	{
		_encryptionService = encryptionService;
		try
		{
			ServerAddress = GetStringFromConfig(nameof(ServerAddress));
			ServerName = GetStringFromConfig(nameof(ServerName));
			Database = GetStringFromConfig(nameof(Database));
			User = GetStringFromConfig(nameof(User));
			Password = GetEncryptedStringFromConfig(nameof(Password));
		}
		catch (ConfigurationErrorsException ex)
		{
			System.Windows.MessageBox.Show(ex.Message);
		}
	}

	public string? ServerAddress { get; set; }
	public string? ServerName { get; set; }
	public string? Database { get; set; }
	public string? User { get; set; }
	public string? Password { get; set; }

	public bool IsValid
		=> _isServerAddressValid && _isServerNameValid && _isDatabaseValid && _isUserValid && _isPasswordValid;

	public string Error { get; set; } = default!;

	public string this[string columnName]
	{
		get
		{
			switch (columnName)
			{
				case nameof(ServerAddress):
					_isServerAddressValid = !string.IsNullOrWhiteSpace(ServerAddress);
					Error = GetRequiredFieldErrorMessage(_isServerAddressValid, "Adres serwera");
					break;
				case nameof(ServerName):
					_isServerNameValid = !string.IsNullOrWhiteSpace(ServerName);
					Error = GetRequiredFieldErrorMessage(_isServerNameValid, "Nazwa serwera");
					break;
				case nameof(Database):
					_isDatabaseValid = !string.IsNullOrWhiteSpace(Database);
					Error = GetRequiredFieldErrorMessage(_isDatabaseValid, "Baza danych");
					break;
				case nameof(User):
					_isUserValid = !string.IsNullOrWhiteSpace(User);
					Error = GetRequiredFieldErrorMessage(_isUserValid, "Użytkownik");
					break;
				case nameof(Password):
					_isPasswordValid = !string.IsNullOrWhiteSpace(Password);
					Error = GetRequiredFieldErrorMessage(!string.IsNullOrWhiteSpace(Password), "Hasło"); ;
					break;
			}
			return Error;
		}
	}

	public void Save()
	{
		var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		var settings = configFile.AppSettings.Settings;
		settings[nameof(ServerAddress)].Value = ServerAddress;
		settings[nameof(ServerName)].Value = ServerName;
		settings[nameof(Database)].Value = Database;
		settings[nameof(User)].Value = User;
		if (!string.IsNullOrWhiteSpace(Password))
		{
			settings[nameof(Password)].Value = _encryptionService.Encrypt(Password);
		}
		configFile.Save();
		ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
	}

	public string GetConnectionString()
	{
		StringBuilder sb = new();
		sb.Append($"Server={ServerAddress}\\{ServerName};");
		sb.Append($"Database={Database};");
		sb.Append($"User Id={User};");
		sb.Append($"Password={Password};");
		sb.Append($"TrustServerCertificate=True;");
		return sb.ToString();
	}

	private string GetRequiredFieldErrorMessage(bool isValid, string fieldName)
		=> isValid ? string.Empty : $"Pole {fieldName} jest wymagane.";

	private static string GetStringFromConfig(string key)
		=> ConfigurationManager.AppSettings[key] ?? string.Empty;

	private string GetEncryptedStringFromConfig(string key)
	{
		string value = ConfigurationManager.AppSettings[key] ?? string.Empty;
		if (!string.IsNullOrWhiteSpace(value))
		{
			if (value.StartsWith(NotEncryptedPrefix))
			{
				value = _encryptionService.Encrypt(value.Replace(NotEncryptedPrefix, string.Empty));
				var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				configFile.AppSettings.Settings[nameof(Password)].Value = value;
				configFile.Save();
				ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
			}
			return _encryptionService.Decrypt(value);
		}
		return value;
	}
}