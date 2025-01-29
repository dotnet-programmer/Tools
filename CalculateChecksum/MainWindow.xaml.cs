using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Win32;

namespace CalculateChecksum;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private const string _mainTitle = "Suma kontrolna";
	private const string _subKey = @"SOFTWARE\Classes\*\shell\CheckMD5Hash";

	private readonly RegistryKey _myRoot = Registry.CurrentUser;

	public MainWindow()
	{
		InitializeComponent();
		SetComponentsOnForm();
		CheckStartArguments();
	}

	private void BtnChooseFile_DragEnter(object sender, DragEventArgs e)
		=> e.Effects = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;

	private void BtnChooseFile_Drop(object sender, DragEventArgs e)
	{
		if (((string[])e.Data.GetData(DataFormats.FileDrop, false)).Length > 1)
		{
			MessageBox.Show("Wybierz tylko 1 plik!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
			return;
		}

		string file = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
		if (File.Exists(file))
		{
			SetMainTitle(file);
			CalculateCheckSum(file);
		}
	}

	private void ChContextMenu_Click(object sender, RoutedEventArgs e)
	{
		if (ChContextMenu.IsChecked.GetValueOrDefault())
		{
			RegistryKey myKey = _myRoot.CreateSubKey(_subKey, true);
			myKey.SetValue("", "Suma kontrolna");
			var appLocation = Application.ResourceAssembly.Location.Replace('/', '\\');
			appLocation = appLocation.EndsWith(".dll") ? appLocation.Replace(".dll", ".exe") : appLocation;
			myKey.CreateSubKey("command", true).SetValue("", $"\"{appLocation}\" \"%1\"");
			myKey.Close();
		}
		else
		{
			_myRoot.DeleteSubKeyTree(_subKey);
		}
	}

	private void BtnChooseFile_Click(object sender, RoutedEventArgs e)
	{
		OpenFileDialog openFileDialog = new();
		if (openFileDialog.ShowDialog().GetValueOrDefault())
		{
			SetMainTitle(openFileDialog.FileName);
			CalculateCheckSum(openFileDialog.FileName);
		}
	}

	private void SetComponentsOnForm()
		=> ChContextMenu.IsChecked = _myRoot.OpenSubKey(_subKey) != null;

	private void CheckStartArguments()
	{
		string[] args = Environment.GetCommandLineArgs();
		if (args.Length > 1)
		{
			SetMainTitle(args[1]);
			CalculateCheckSum(args[1]);
		}
	}

	private void SetMainTitle(string filename)
		=> Title = $"{_mainTitle} - {filename}";

	private void CalculateCheckSum(string filename)
	{
		TxtMd5.Text = TxtSha1.Text = TxtSha256.Text = TxtSha384.Text = TxtSha512.Text = string.Empty;
		Stopwatch watch = Stopwatch.StartNew();

		Task<string> task5 = Task.Run(() => CheckSum.CalculateSHA512(filename));
		Task<string> task4 = Task.Run(() => CheckSum.CalculateSHA384(filename));
		Task<string> task3 = Task.Run(() => CheckSum.CalculateSHA256(filename));
		Task<string> task2 = Task.Run(() => CheckSum.CalculateSHA1(filename));
		Task<string> task1 = Task.Run(() => CheckSum.CalculateMD5(filename));

		UpdateTextBox(TxtMd5, task1.Result);
		UpdateTextBox(TxtSha1, task2.Result);
		UpdateTextBox(TxtSha256, task3.Result);
		UpdateTextBox(TxtSha384, task4.Result);
		UpdateTextBox(TxtSha512, task5.Result);

		watch.Stop();
		LbTime.Content = $"ms: {watch.ElapsedMilliseconds}";
	}

	private void TxtValueToCheck_TextChanged(object sender, TextChangedEventArgs e)
	{
		string valueToCheck = TxtValueToCheck.Text;

		SetPicture(valueToCheck, TxtMd5, ImgMd5);
		SetPicture(valueToCheck, TxtSha1, ImgSha1);
		SetPicture(valueToCheck, TxtSha256, ImgSha256);
		SetPicture(valueToCheck, TxtSha384, ImgSha384);
		SetPicture(valueToCheck, TxtSha512, ImgSha512);

		static void SetPicture(string valueToCheck, TextBox textBox, Image image)
		{
			string imageName = textBox.Text.Equals(valueToCheck, StringComparison.CurrentCultureIgnoreCase) ? "imgYes.png" : "imgNo.png";
			var uriSource = new Uri(@$"/CalculateChecksum;component/Images/{imageName}", UriKind.Relative);
			image.Source = new BitmapImage(uriSource);
		}
	}

	private void UpdateTextBox(TextBox textBox, string result)
	{
		textBox.Text = result;
		Progress.Value += 20;
		Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle);
	}
}