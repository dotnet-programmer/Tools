using System.Windows;
using EncryptionManager.Interfaces;

namespace EncryptionManager.Views;

public partial class SettingsView : Window
{
	public SettingsView(ISettingsViewModel settingsViewModel)
	{
		InitializeComponent();
		DataContext = settingsViewModel;
	}
}