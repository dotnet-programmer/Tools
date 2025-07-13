namespace ShutdownPC;

internal class Clock(int minutes)
{
	private static readonly string[,] _digits =
	{
		{"XXXXX", "   X ", " XXX ", "XXXXX", "   X ", "XXXXX", "XXXXX", "XXXXX", "XXXXX", "XXXXX", "     " },
		{"X   X", " X X ", "X   X", "    X", "  XX ", "X    ", "X    ", "    X", "X   X", "X   X", "     " },
		{"X   X", "X  X ", "    X", "    X", " X X ", "X    ", "X    ", "   X ", "X   X", "X   X", "  X  " },
		{"X   X", "   X ", "   X ", " XXXX", "X  X ", "XXXXX", "XXXXX", "  X  ", "XXXXX", "XXXXX", "     " },
		{"X   X", "   X ", "  X  ", "    X", "XXXXX", "    X", "X   X", " X   ", "X   X", "    X", "  X  " },
		{"X   X", "   X ", " X   ", "    X", "   X ", "    X", "X   X", " X   ", "X   X", "    X", "     " },
		{"XXXXX", "   X ", "XXXXX", "XXXXX", "   X ", "XXXXX", "XXXXX", " X   ", "XXXXX", "XXXXX", "     " },
	};

	private static readonly int _timeHalfWidth = (8 * 5 + 7) / 2;
	private static readonly int _timeHalfHeight = 4;
	private const int NumberOfLines = 7;
	private const int SecondsInMinute = 60;

	private int _hour = minutes / SecondsInMinute;
	private int _minute = minutes % SecondsInMinute;
	private int _second = 0;

	public bool IsRunning { get; set; } = true;

	public void ShowTime()
	{
		Console.Clear();
		Console.CursorVisible = false;
		Task clockTask = Task.Run(ActualTime);
	}

	private void ActualTime()
	{
		while (IsRunning)
		{
			DrawClock(PrepareTimeToDraw());
			Thread.Sleep(1000);
		}
	}

	private void DrawClock(string time)
	{
		int digit;
		for (int i = 0; i < NumberOfLines; i++)
		{
			Console.SetCursorPosition((Console.WindowWidth / 2) - _timeHalfWidth, (Console.WindowHeight / 2) - _timeHalfHeight + i);
			for (int j = 0; j < time.Length; j++)
			{
				if (_hour == 0 && _minute < 2)
				{
					if (_minute == 1 && _second == 59)
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
					}
					else if (_minute == 0 && _second == 59)
					{
						Console.ForegroundColor = ConsoleColor.Red;
					}
				}
				
				digit = time[j] != ':' ? time[j] - 48 : 10;
				Console.Write(_digits[i, digit] + " ");
			}
			Console.WriteLine();
		}
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine("Spacja żeby anulować proces wyłączania.");
	}

	private string PrepareTimeToDraw()
	{
		_second--;
		if (_second < 0)
		{
			_second = 59;
			_minute--;
			if (_minute < 0)
			{
				_minute = 59;
				_hour--;
			}
		}
		return $"{_hour:00}:{_minute:00}:{_second:00}";
	}
}