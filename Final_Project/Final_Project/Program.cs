using Weather_Library;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string CodeName;
            IWeatherDataService service;
            //we used try and catch to demonstrate if the method
            //GetWeatherDataService (in WeatherDataServiceFactory) had been called with valid number
            //the number should choose the method of the service 
            // in our case there is only one service OpenWeahterMap
            try
            {
                //for catching this error, in case of invalid number
                service = WeatherDataServiceFactory.GetWeatherDataService(3);
               
            }
            catch(WeatherDataServiceException ex)
            {
                Console.WriteLine(ex+"\nusing OPEN_WEATHER_MAP service for program continue to work");
              //next line is equal to:
              //service = OpenWeatherMap.Instance
                service = WeatherDataServiceFactory.GetWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);
            }
            while (true)
            {

                Console.WriteLine("Please enter the city name or 'Exit' to exit the program");
                CodeName = Console.ReadLine();
                if (CodeName.Equals("Exit")|| CodeName.Equals("exit")|| CodeName.Equals("EXIST"))
                    break;
                service.GetWeatherData(new Location(CodeName));
                if (service.GetWD() == null) continue;
                Console.Clear();
                Console.WriteLine("Hello, You have requested to see the weather in {0} in country {1}", service.GetWD().cityName, service.GetWD().country);
                Console.WriteLine("And the coord are: {0} , {1} ", service.GetWD().coordLat, service.GetWD().coordLon);
                Console.WriteLine("The last update I had is from {0}", service.GetWD().lastupdate);
                Console.WriteLine("It seems to be {0} today ", service.GetWD().weather);
                Console.WriteLine("The sun will rise at {0} and set at {1}", service.GetWD().sunRise, service.GetWD().sunSet);
                Console.WriteLine("The tempature now is {0} and it should be between {1} - {2}", service.GetWD().tempature, service.GetWD().tempatureMin, service.GetWD().tempatureMax);
                Console.WriteLine("The wind speed is {0} MPH", service.GetWD().windSpeed);
                Console.WriteLine("The pressure is {0} hPa", service.GetWD().pressure);
                Console.WriteLine("Cloud status is {0} ", service.GetWD().clouds);
                Console.WriteLine("Humidity is {0}% \n\n", service.GetWD().humidity);
                service.ClearWeatherData();
            }

            Console.WriteLine("Copyrights Shenkar - Software Engineering");
            Console.WriteLine("Course Programming Languages - By Mr. Life Michael ");
            Console.WriteLine("Written by Or Adar - 201590775 ");
        }
    }
}
