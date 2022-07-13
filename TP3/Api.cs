using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TP3
{
    public class Api
    {
        public static async Task<CurrentWeather> GetWeatherFromApi(string location)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(
                        $"https://api.openweathermap.org/data/2.5/weather?{location}&units=metric&appid=43db2aeef2a8280cb1c107389901a6b2")
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                CurrentWeather currentWeather = JsonSerializer.Deserialize<CurrentWeather>(body);
                return currentWeather;
            }
        }

        public static async Task<Forecast> GetForecastFromApi(string location)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(
                        $"https://api.openweathermap.org/data/2.5/forecast?{location}&units=metric&appid=43db2aeef2a8280cb1c107389901a6b2")
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                Forecast forecast = JsonSerializer.Deserialize<Forecast>(body);
                return forecast;
            }
        }
    }
}