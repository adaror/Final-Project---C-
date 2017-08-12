using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * interface 
 * currently have GetWeatherData methode
 * this mthode should receive loctation and return object of WeatherData
 */
namespace Weather_Library
{
    public interface IWeatherDataService
    {
        WeatherData GetWeatherData(Location location);
        WeatherData GetWD();
        void ClearWeatherData();
    }
}
