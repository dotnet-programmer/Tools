using System.Windows;
using EncryptionManager.ViewModels;

namespace EncryptionManager.Views;

public partial class MainView : Window
{
	public MainView()
	{
		InitializeComponent();
		DataContext = new MainViewModel();
	}
}