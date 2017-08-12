using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
/*
    class OpenWeatherMap implements IWeatherDataService and parse the XML 
     at  api.openweathermap.org/data/2.5/weather.
    after parse the XML it saves the data on object from WeatherData which it creates
    by using singleton
*/
namespace Weather_Library
{
    public class OpenWeatherMap : IWeatherDataService
    {
        private WeatherData WeatherData;

        private static OpenWeatherMap instance;

        private OpenWeatherMap() { 
        }

        public static OpenWeatherMap Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OpenWeatherMap();
                }
                return instance;
            }
        }

        public WeatherData GetWD()
        {
            return WeatherData;
        }
        public void ClearWeatherData()
        {
            WeatherData = null;
        }
        public WeatherData GetWeatherData(Location location)
        {
            WeatherData = new WeatherData();
            string tmpLoc;
            tmpLoc = location.LocName.ToUpper();

            var address = "http://api.openweathermap.org/data/2.5/weather?q={0}&mode=xml&appid=2fccd10128467348a961d23fc6dc1f59&units=metric";
            var api = string.Format(address, tmpLoc);
            try
            {
                XDocument xdoc = XDocument.Load(api);
                WeatherData.cityName = xdoc.Element("current").Element("city").Attribute("name").Value;
                if (!tmpLoc.Equals(WeatherData.cityName.ToUpper()))
                {
                    throw (new System.Xml.XmlException("Error not valid city name"));
                }
                WeatherData.coordLon = xdoc.Element("current").Element("city").Element("coord").Attribute("lon").Value;
                WeatherData.coordLat = xdoc.Element("current").Element("city").Element("coord").Attribute("lat").Value;
                WeatherData.country = xdoc.Element("current").Element("city").Element("country").Value;
                WeatherData.sunRise = xdoc.Element("current").Element("city").Element("sun").Attribute("rise").Value;
                WeatherData.sunSet = xdoc.Element("current").Element("city").Element("sun").Attribute("set").Value;
                //Temperature Elements
                WeatherData.tempature = xdoc.Element("current").Element("temperature").Attribute("value").Value;
                WeatherData.tempatureMin = xdoc.Element("current").Element("temperature").Attribute("min").Value;
                WeatherData.tempatureMax = xdoc.Element("current").Element("temperature").Attribute("max").Value;
                //Humidity
                WeatherData.humidity = xdoc.Element("current").Element("humidity").Attribute("value").Value;
                //Pressure
                WeatherData.pressure = xdoc.Element("current").Element("pressure").Attribute("value").Value;
                //Wind
                WeatherData.windSpeed = xdoc.Element("current").Element("wind").Element("speed").Attribute("value").Value;
                //Clouds
                WeatherData.clouds = xdoc.Element("current").Element("clouds").Attribute("name").Value;
                //Weather
                WeatherData.weather = xdoc.Element("current").Element("weather").Attribute("value").Value;
                //Lastupdate
                WeatherData.lastupdate = xdoc.Element("current").Element("lastupdate").Attribute("value").Value;
            }
            catch (System.Xml.XmlException ex)
            {
                new WeatherDataServiceException("Exception!\n", ex);
                ClearWeatherData();
                return null;
                
            };
            
            return WeatherData;
        }
    }

}
