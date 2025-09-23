using WeatherApp;

ConsoleColor defaultColor = Console.ForegroundColor;
const string celsiusSign = "°C"; // \x00B0

var weatherList = await WeatherApi.GetWeatherAsync("Gdańsk", "Kielce");

foreach (var weather in weatherList)
{
	Console.ForegroundColor = ConsoleColor.White;
	Console.WriteLine($"\t  {weather.name.ToUpper()}\n");
	Console.ForegroundColor = defaultColor;

	Console.WriteLine("Aktualna Odczuwalna   Max     Min");
	Console.ForegroundColor = ConsoleColor.Green;
	Console.Write($" {weather.main.temp:f2}{celsiusSign}    ");
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.Write($"{weather.main.feels_like:f2}{celsiusSign}   ");
	Console.ForegroundColor = ConsoleColor.Red;
	Console.Write($"{weather.main.temp_max:f2}{celsiusSign}  ");
	Console.ForegroundColor = ConsoleColor.Blue;
	Console.WriteLine($"{weather.main.temp_min:f2}{celsiusSign}");
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