using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ImageBrowser;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly Random _random = new();
	private readonly List<string> _files = [];

	private int _imgNumber;

	private enum ActionType
	{
		previous, random, next
	}

	public MainWindow()
	{
		InitializeComponent();
		GetFiles();
		_files = _files.OrderBy(x => x).ToList();
		NewImage(ActionType.random);
	}

	private void BtnPrevious_Click(object sender, RoutedEventArgs e)
		=> NewImage(ActionType.previous);

	private void BtnRandom_Click(object sender, RoutedEventArgs e)
		=> NewImage(ActionType.random);

	private void BtnNext_Click(object sender, RoutedEventArgs e)
		=> NewImage(ActionType.next);

	private void Window_KeyDown(object sender, KeyEventArgs e)
	{
		switch (e.Key)
		{
			case Key.Left:
				NewImage(ActionType.previous);
				break;
			case Key.Space:
				NewImage(ActionType.random);
				break;
			case Key.Right:
				NewImage(ActionType.next);
				break;
			case Key.Escape:
				Close();
				break;
		}
	}

	private void ImgViewer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		=> NewImage(ActionType.random);

	private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
	{
		ActionType actionType = e.Delta > 0 ? ActionType.previous : ActionType.next;
		NewImage(actionType);
	}

	private void GetFiles()
	{
		var files = Directory.GetFiles(Environment.CurrentDirectory, "*", SearchOption.AllDirectories);
		foreach (var file in files)
		{
			if (file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".png") || file.EndsWith(".gif"))
			{
				_files.Add(file);
			}
		}
	}

	private void NewImage(ActionType actionType)
	{
		if (_files.Count == 0)
		{
			return;
		}

		BitmapImage image = new();
		image.BeginInit();

		switch (actionType)
		{
			case ActionType.previous:
				_imgNumber--;
				if (_imgNumber < 0)
				{
					_imgNumber = _files.Count - 1;
				}
				break;
			case ActionType.random:
				_imgNumber = _random.Next(_files.Count);
				break;
			case ActionType.next:
				_imgNumber++;
				if (_imgNumber >= _files.Count)
				{
					_imgNumber = 0;
				}
				break;
		}

		image.UriSource = new Uri(_files[_imgNumber]);

		image.EndInit();
		ImgViewer.Source = image;
		Title = image.UriSource.ToString();
	}
}