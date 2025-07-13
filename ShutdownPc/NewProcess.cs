using System.Diagnostics;

namespace ShutdownPC;

internal class NewProcess()
{
	public static void StartProcess(string command)
	{
		// Utwórz obiekt ProcessStartInfo: Ten obiekt pozwala skonfigurować proces, który chcesz uruchomić.
		ProcessStartInfo processStartInfo = new()
		{
			// FileName – ścieżka do pliku wykonywalnego (np. "cmd.exe" dla wiersza poleceń)
			FileName = "cmd",

			// Arguments – argumenty dla pliku wykonywalnego (czyli komendy CMD, które chcesz wykonać, np. "/c dir"
			// Użycie /c w argumentach spowoduje wykonanie komendy i następnie zamknięcie okna konsoli CMD. Jeśli chcesz, aby okno konsoli pozostało otwarte po wykonaniu komendy, użyj /k zamiast /c
			Arguments = $"/c {command}",

			// Ustaw przekierowanie wyjścia (opcjonalnie): Jeśli chcesz przechwycić dane wyjściowe z polecenia CMD, ustaw RedirectStandardOutput na true.
			RedirectStandardOutput = false,

			// Musi być false, jeśli RedirectStandardOutput jest true
			UseShellExecute = false,

			// ukryj okno konsoli
			CreateNoWindow = true,
		};

		// Rozpocznij proces: Użyj Process.Start(), aby uruchomić zdefiniowany proces.
		using (Process? process = Process.Start(processStartInfo))
		{
			if (process != null)
			{
				// Odczytaj dane wyjściowe (jeśli są przekierowane):
				if (processStartInfo.RedirectStandardOutput)
				{
					Console.WriteLine("Wynik polecenia CMD:");
					Console.WriteLine(process.StandardOutput.ReadToEnd());
				}

				// Poczekaj na zakończenie procesu (opcjonalnie):
				process.WaitForExit();
			}
			else
			{
				Console.WriteLine("Nie udało się uruchomić procesu.");
			}
		}
	}
}