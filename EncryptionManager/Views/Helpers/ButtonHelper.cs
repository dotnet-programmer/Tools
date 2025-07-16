using System.Windows;
using System.Windows.Controls;

namespace EncryptionManager.Views.Helpers;

internal static class ButtonHelper
{
	public static readonly DependencyProperty DialogResultProperty =
		DependencyProperty.RegisterAttached(
			"DialogResult",
			typeof(bool?),
			typeof(ButtonHelper),
			new PropertyMetadata(null, OnDialogResultChanged));

	public static bool? GetDialogResult(DependencyObject obj)
		=> (bool?)obj.GetValue(DialogResultProperty);

	public static void SetDialogResult(DependencyObject obj, bool? value)
		=> obj.SetValue(DialogResultProperty, value);

	private static void OnDialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is not Button button)
		{
			throw new InvalidOperationException("DialogResult attached property can only be used with Button.");
		}

		button.Click -= Button_Click;
		if (e.NewValue is not null)
		{
			button.Click += Button_Click;
		}
	}

	private static void Button_Click(object sender, RoutedEventArgs e)
	{
		if (sender is Button button)
		{
			var result = GetDialogResult(button);
			var window = Window.GetWindow(button);

			if (window != null)
			{
				try
				{
					window.DialogResult = result;
				}
				catch (InvalidOperationException)
				{
					window.Close();
				}
			}
		}
	}
}