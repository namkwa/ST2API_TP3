using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace TP3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("type 1 to input coordinates and 2 to input city name");
                string input_choice = Console.ReadLine();
                try
                {
                    switch (input_choice)
                    {
                        case "1":
                            Console.WriteLine("input latitude");
                            double input_lat = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("input longitude");
                            double input_lon = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine(await GetUtils.GetWeatherInformation($"lat={input_lat}&lon={input_lon}"));
                            break;
                        case "2":
                            Console.WriteLine("type the city you want the information about");
                            string input_city = Console.ReadLine();
                            Console.WriteLine("type 1 for weather and 2 for a forecast");
                            string input_type = Console.ReadLine();
                            switch (input_type)
                            {
                                case "1":
                                    Console.WriteLine(await GetUtils.GetWeatherInformation($"q={input_city}"));
                                    break;
                                case "2":
                                    Console.WriteLine(await GetUtils.GetForecastInformation($"q={input_city}"));
                                    break;
                            }

                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong input, be sure to input a double");
                }
            }
        }
    }
}