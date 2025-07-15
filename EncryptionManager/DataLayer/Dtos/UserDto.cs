using System.Collections;
using System.ComponentModel;

namespace EncryptionManager.DataLayer.Dtos;

public class UserDto : INotifyDataErrorInfo
{
	private string? _name;
	private string? _password;

	// The key is for the property name, the value is the error list for the property
	private readonly Dictionary<string, List<string>> _errors = [];

	public string? Name
	{
		get => _name;
		set
		{
			if (_name != value)
			{
				_name = value;
				ValidateProperty(nameof(Name), value);
			}
		}
	}

	public string? Password
	{
		get => _password;
		set
		{
			if (_password != value)
			{
				_password = value;
				ValidateProperty(nameof(Password), value);
			}
		}
	}

	// HasErrors and GetErrors are implemented for WPF binding compatibility.
	public bool HasErrors => _errors.Count > 0;

	// ErrorsChanged is raised when errors change.
	public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

	public IEnumerable GetErrors(string? propertyName)
	{
		if (string.IsNullOrEmpty(propertyName))
			return new List<string>();

		return _errors.TryGetValue(propertyName, out var errors)
			? errors
			: new List<string>();
	}

	// ValidateProperty is called in the property setters.
	private void ValidateProperty(string propertyName, object? value)
	{
		var errors = new List<string>();

		switch (propertyName)
		{
			case nameof(Name):
				if (string.IsNullOrWhiteSpace((string?)value))
					errors.Add("Pole Login jest wymagane.");
				break;
			case nameof(Password):
				if (string.IsNullOrWhiteSpace((string?)value))
					errors.Add("Pole Hasło jest wymagane.");
				break;
		}

		if (errors.Count > 0)
			_errors[propertyName] = errors;
		else
			_errors.Remove(propertyName);

		ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
	}
}