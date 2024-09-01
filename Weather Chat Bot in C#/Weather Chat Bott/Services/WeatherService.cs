using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Chat_Bott.Config;
using Weather_Chat_Bott.Models;
using Weather_Chat_Bott.Utilities;

namespace Weather_Chat_Bott.Services
{
    public class WeatherService
    {
        private readonly ApiHelper _apiHelper;

        public WeatherService(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<string> GetWeatherAsync(string city)
        {
            try
            {
                // Log the API URL
                string endpoint = $"q={city}&units=metric";
                Console.WriteLine($"Requesting weather data from: {_apiHelper.BaseUrl}{_apiHelper.ApiKey}&{endpoint}");

                var response = await _apiHelper.GetAsync<WeatherResponse>(endpoint);

                // Check if the response is null
                if (response == null)
                {
                    return "No data returned from the weather service.";
                }

                // Log the raw JSON response for debugging
                string rawJson = await _apiHelper.GetRawJsonAsync(endpoint);
                Console.WriteLine($"Raw JSON Response: {rawJson}");

                // Validate if the necessary fields are present
                if (response.Main == null || response.Weather == null || response.Weather.Count == 0)
                {
                    return "Incomplete weather data received.";
                }

                string weatherInfo = $"The weather in {city} is {response.Main.Temp}°C with {response.Weather[0].Description}.";

                // Randomly ask the user about how they feel about the weather
                if (ShouldAskAboutWeather())
                {
                    weatherInfo += " How do you feel about the weather?";
                }

                return weatherInfo;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}. Please check the city name and try again.";
            }
        }

        private bool ShouldAskAboutWeather()
        {
            Random random = new Random();
            return random.Next(0, 2) == 1;
        }
    }

}
