using ShutdownPC;

Console.ForegroundColor = ConsoleColor.Green;
while (true)
{
	int minutes;
	do
	{
		Console.Write("Za ile minut wyłączyć komputer: ");
	} while (!int.TryParse(Console.ReadLine(), out minutes));

	NewProcess.StartProcess($"shutdown /s /t {minutes * 60}");
	Clock clock = new(minutes);
	clock.ShowTime();

	while (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
	{ }

	NewProcess.StartProcess("shutdown /a");
	clock.IsRunning = false;

	Console.WriteLine();
	Console.ForegroundColor = ConsoleColor.Red;
	Console.WriteLine("***** Wyłączanie komputera zostało przerwane! *****");
	Console.WriteLine();
	Console.ForegroundColor = ConsoleColor.Green;
	Console.Write("Spacja żeby zacząć od nowa, każdy inny klawisz zamyka aplikację.");
	if (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
	{
		Environment.Exit(0);
	}
	Console.Clear();
	Console.CursorVisible = true;
}