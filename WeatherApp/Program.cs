using WeatherApp;

ConsoleColor defaultColor = Console.ForegroundColor;
int defaultHeight = Console.WindowHeight;

var weatherList = WeatherApi.GetWeather("Gdańsk", "Kielce");

Console.WindowHeight = defaultHeight + 10;

foreach (var weather in weatherList)
{
	Console.ForegroundColor = ConsoleColor.White;
	Console.WriteLine($"\t  {weather.name.ToUpper()}\n");
	Console.ForegroundColor = defaultColor;

	Console.WriteLine("Aktualna Odczuwalna   Max     Min");
	Console.ForegroundColor = ConsoleColor.Green;
	Console.Write($" {weather.main.temp:f2}\x00B0C    ");
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.Write($"{weather.main.feels_like:f2}\x00B0C   ");
	Console.ForegroundColor = ConsoleColor.Red;
	Console.Write($"{weather.main.temp_max:f2}\x00B0C  ");
	Console.ForegroundColor = ConsoleColor.Blue;
	Console.WriteLine($"{weather.main.temp_min:f2}\x00B0C");
	Console.ForegroundColor = defaultColor;

	Console.WriteLine($"\nPogoda: {weather.weather[0].main} - {weather.weather[0].description}");
	Console.WriteLine($"\nPrędkość wiatru: {weather.wind.speed:f2}m/s = {MpsToKph(weather.wind.speed):f2}km/h");
	Console.WriteLine($"\nCiśnienie: {weather.main.pressure}hPa");
	Console.WriteLine($"\nWilgotność: {weather.main.humidity}%");

	Console.WriteLine(Environment.NewLine);
	Console.WriteLine(Environment.NewLine);
}

Console.ReadLine();

static double MpsToKph(double mps)
	=> mps * 3.6;