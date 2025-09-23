using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace WeatherApp;

internal class WeatherApi
{
	// base url for UriBuilder
	private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

	// one instance of HttpClient for the entire application lifecycle, to prevent port exhaustion problems
	private static readonly HttpClient _httpClient = new();

	// configuration with connection parameters
	private static readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
		.SetBasePath(AppContext.BaseDirectory)
		.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
		.Build();

	public static async Task<IReadOnlyList<WeatherJson>> GetWeatherAsync(params string[] cities)
	{
		List<WeatherJson> results = [];

		foreach (var city in cities.Where(c => !string.IsNullOrWhiteSpace(c)))
		{
			try
			{
				Uri uri = BuildWeatherUri(city);
				string json = await GetWeatherJsonAsync(uri);

				if (string.IsNullOrWhiteSpace(json))
				{
					Console.WriteLine($"Brak danych dla miasta: {city}");
					continue;
				}

				var weather = JsonSerializer.Deserialize<WeatherJson>(json);

				if (weather is null || weather.cod != 200)
				{
					Console.WriteLine($"Błąd API dla miasta: {city}");
					continue;
				}

				results.Add(weather);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Błąd przy pobieraniu pogody dla miasta '{city}': {ex.Message}");
			}
		}

		return results;
	}

	private static Uri BuildWeatherUri(string city)
	{
		UriBuilder builder = new(BaseUrl);
		var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
		query["q"] = city;
		query["appid"] = GetValueFromConfiguration("ApiKey");
		query["units"] = GetValueFromConfiguration("Units");
		query["lang"] = GetValueFromConfiguration("Lang");
		builder.Query = query.ToString();
		return builder.Uri;
	}

	private static string GetValueFromConfiguration(string key)
	{
		string? value = _configuration[$"WeatherApi:{key}"];

		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidOperationException($"No {key} in the configuration");
		}

		return value;
	}

	private static async Task<string> GetWeatherJsonAsync(Uri uri, CancellationToken cancellationToken = default)
	{
		try
		{
			// using block because HttpResponseMessage implements IDisposable
			using var response = await _httpClient.GetAsync(uri, cancellationToken);

			// check if the response is successful (status code 2xx)
			response.EnsureSuccessStatusCode();

			// read the contents of the response as a string
			return await response.Content.ReadAsStringAsync(cancellationToken);
		}
		catch (HttpRequestException ex)
		{
			Console.WriteLine($"Błąd HTTP: {ex.Message}");
		}
		catch (TaskCanceledException)
		{
			Console.WriteLine("Żądanie zostało anulowane");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Nieoczekiwany błąd: {ex.Message}");
		}

		return string.Empty;
	}
}


/*
 * problem  ->  rozwiązanie
 * 
 * HttpClient tworzony w metodzie, może powodować wyczerpanie gniazd TCP  ->  Statyczny HttpClient
 * Klucz API zaszyty w kodzie  ->  Klucz API w pliku konfiguracji
 * Brak możliwości zmiany parametrów połączenia (jednostki, język)  ->  dodatkowe opcje w pliku konfiguracji
 * Brak sprawdzenia czy klucz API istnieje  ->  wprawdzenie czy jest null
 * Ręczne sklejanie adresu ze stringów  ->  użycie UriBuilder, dzięki temu gwarancja poprawnego kodowania parametrów i poprawnego formatowania adresu
 * Brak walidacji miast, pusty string generuje błędne zapytanie  ->  Pobieranie poprawnej listy miast 
 * Break w foreach przy błędzie przerywa całą pętlę, zamiast tylko pominąć błędne miasto  ->  użycie continue
 * JsonSerializer.Deserialize<WeatherJson> może zwrócić null. Brak sprawdzenia, możliwy NullReferenceException  ->  walidacja null dla json
 * throw new Exception(response.RequestMessage.ToString()) generuje ogólny wyjątek, trudny do diagnozy  ->  Obsługa wyjątków z bardziej precyzyjnymi typami (HttpRequestException, TaskCanceledException).
 * Brak obsługi anulowania (CancellationToken), przy dłuższych requestach użytkownik nie może przerwać  ->  CancellationToken obsłużony w GetWeatherJsonAsync.
 * Nazwy miast mogą zawierać błędne znaki dla url  ->  Uri.EscapeDataString() zabezpiecza nazwy miast.
 * 
 * Zmiana typu zwracanego z List<WeatherJson> na IReadOnlyList<WeatherJson> czyli kolekcja elementów tylko do odczytu, do których można uzyskać dostęp za pomocą indeksu.
 * Dodanie bloku using do wywołania _httpClient.GetAsync() dla HttpResponseMessage
 * 
 */