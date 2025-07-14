using System.Windows;
using EncryptionManager.Interfaces;

namespace EncryptionManager.Views;

public partial class MainView : Window
{
	public MainView(IMainViewModel mainViewModel)
	{
		InitializeComponent();
		DataContext = mainViewModel;
	}
}