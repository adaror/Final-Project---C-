using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Library.Tests
{
    [TestClass()]
    public class WeatherDataServiceFactoryTests
    {
        [TestMethod()]
        public void openWeatherMapTest()
        {
            IWeatherDataService ServiceTest1 = WeatherDataServiceFactory.openWeatherMap();
            IWeatherDataService ServiceTest2 = WeatherDataServiceFactory.openWeatherMap();
            Assert.AreEqual(ServiceTest1.GetHashCode(), ServiceTest2.GetHashCode());
        }
        [TestMethod()]
        public void GetWeatherDataServiceTest()
        {
            IWeatherDataService ServiceTest1 = WeatherDataServiceFactory.GetWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);
            IWeatherDataService ServiceTest2 = WeatherDataServiceFactory.GetWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);
            Assert.AreEqual(ServiceTest1.GetHashCode(), ServiceTest2.GetHashCode());
        }
    }
}