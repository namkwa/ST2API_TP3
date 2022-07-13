namespace TP3
{
    public class GetUtils
    {
        public static async Task<string> GetWeatherInformation(string location)
        {
            CurrentWeather weatherInformationLocation;
            try
            {
                weatherInformationLocation = await Api.GetWeatherFromApi(location);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            string nameOrCoord = location.Contains("lon=") ? $"at latitude {weatherInformationLocation.coord.lat}  and longitude {weatherInformationLocation.coord.lon}" : "in";
            string returnString =
                $"The weather {nameOrCoord} {weatherInformationLocation.name} : {weatherInformationLocation.weather[0].main}.\n";
            returnString += $"It is {weatherInformationLocation.main.temp} degrees celsius.\n";
            List<string> cardinalPoints = new List<string>
                { "north", "north-east", "east", "south-east", "south", "south-west", "west", "north-west", "north" };
            returnString +=
                $"There is a {cardinalPoints[weatherInformationLocation.wind.deg / 45]} wind with a speed of {weatherInformationLocation.wind.speed * 3.6} km/h.\n";
            return returnString;
        }

        public static async Task<string> GetForecastInformation(string location)
        {
            Forecast forecastInformationLocation;
            try
            {
                forecastInformationLocation = await Api.GetForecastFromApi(location);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            string returnString =
                $"The weather in {forecastInformationLocation.city.name} at {DateUtils.ConvertDate(forecastInformationLocation.list[8].dt)}: {forecastInformationLocation.list[8].weather[0].main}.\n";
            returnString += $"It will be {forecastInformationLocation.list[8].main.temp} degrees celsius.\n";
            List<string> cardinalPoints = new List<string>
                { "north", "north-east", "east", "south-east", "south", "south-west", "west", "north-west", "north" };
            returnString +=
                $"There will be a {cardinalPoints[forecastInformationLocation.list[6].wind.deg / 45]} wind with a speed of {forecastInformationLocation.list[8].wind.speed * 3.6} km/h.\n";
            return returnString;
        }
    }
}