using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * initialize data source ,can use only openweathermap.com
 */
namespace Weather_Library
{
    public class WeatherDataServiceFactory
    {
        public static int OPEN_WEATHER_MAP = 1;
        public static IWeatherDataService openWeatherMap()
        {
            Console.WriteLine("OPEN_WEATHER_MAP");
            return OpenWeatherMap.Instance;
        }
        public  static IWeatherDataService GetWeatherDataService(int Temp)
        {
            switch (Temp)
            {
                case 1: return openWeatherMap();
                default: throw (new WeatherDataServiceException("Invalid Service\n"));
            }
           
        }
    }
    
}
