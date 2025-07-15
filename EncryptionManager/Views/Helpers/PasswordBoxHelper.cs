using System.Windows;
using System.Windows.Controls;

namespace EncryptionManager.Views.Helpers;

// Enables two-way binding for the Password property in your ViewModel or DTO.
// Supports validation and error notification via INotifyDataErrorInfo.
public static class PasswordBoxHelper
{
	public static readonly DependencyProperty BoundPasswordProperty =
		DependencyProperty.RegisterAttached(
			"BoundPassword",
			typeof(string),
			typeof(PasswordBoxHelper),
			new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

	public static readonly DependencyProperty BindPasswordProperty =
		DependencyProperty.RegisterAttached(
			"BindPassword",
			typeof(bool),
			typeof(PasswordBoxHelper),
			new PropertyMetadata(false, OnBindPasswordChanged));

	private static readonly DependencyProperty UpdatingPasswordProperty =
		DependencyProperty.RegisterAttached(
			"UpdatingPassword",
			typeof(bool),
			typeof(PasswordBoxHelper),
			new PropertyMetadata(false));

	public static string GetBoundPassword(DependencyObject obj)
		=> (string)obj.GetValue(BoundPasswordProperty);

	public static void SetBoundPassword(DependencyObject obj, string value)
		=> obj.SetValue(BoundPasswordProperty, value);

	public static bool GetBindPassword(DependencyObject obj)
		=> (bool)obj.GetValue(BindPasswordProperty);

	public static void SetBindPassword(DependencyObject obj, bool value)
		=> obj.SetValue(BindPasswordProperty, value);

	private static bool GetUpdatingPassword(DependencyObject obj)
		=> (bool)obj.GetValue(UpdatingPasswordProperty);

	private static void SetUpdatingPassword(DependencyObject obj, bool value)
		=> obj.SetValue(UpdatingPasswordProperty, value);

	private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is PasswordBox passwordBox && !GetUpdatingPassword(passwordBox))
		{
			passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
			passwordBox.Password = e.NewValue as string ?? string.Empty;
			passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
		}
	}

	private static void OnBindPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is PasswordBox passwordBox)
		{
			bool wasBound = (bool)e.OldValue;
			bool needToBind = (bool)e.NewValue;

			if (wasBound)
			{
				passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
			}

			if (needToBind)
			{
				passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
			}
		}
	}

	private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
	{
		if (sender is PasswordBox passwordBox)
		{
			SetUpdatingPassword(passwordBox, true);
			SetBoundPassword(passwordBox, passwordBox.Password);
			SetUpdatingPassword(passwordBox, false);
		}
	}
}