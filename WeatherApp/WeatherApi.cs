using System.Text.Json;

namespace WeatherApp;

internal class WeatherApi
{
	//private const string _apiAddressId = "https://api.openweathermap.org/data/2.5/weather?id=";
	private const string _apiAddressCity = "https://api.openweathermap.org/data/2.5/weather?q=";

	private const string _apiKey = "&appid=";
	private const string _parameters = "&units=metric&lang=pl";

	public static async Task<List<WeatherJson>> GetWeather(params string[] cities)
	{
		List<WeatherJson> result = new(cities.Length);

		foreach (var item in cities)
		{
			var weather = JsonSerializer.Deserialize<WeatherJson>(await GetWeatherJsonAsync($"{_apiAddressCity}{item}{_apiKey}{_parameters}"));

			if (weather.cod != 200)
			{
				Console.WriteLine($"Błąd dla miejscowości: {item}");
				break;
			}

			result.Add(weather);
		}

		return result;
	}

	private static async Task<string> GetWeatherJsonAsync(string url)
	{
		string json = string.Empty;
		try
		{
			HttpClient httpClient = new();
			var response = await httpClient.GetAsync(url);

			if (!response.IsSuccessStatusCode)
			{
				throw new Exception(response.RequestMessage.ToString());
			}

			json = await response.Content.ReadAsStringAsync();
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Http.Get method error: {ex.Message}");
		}

		return json;
	}
}