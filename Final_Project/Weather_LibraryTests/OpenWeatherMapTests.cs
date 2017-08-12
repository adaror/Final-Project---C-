using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Library.Tests
    //testing class
{
    [TestClass()]
    public class OpenWeatherMapTests
    {
        OpenWeatherMap WDMTest = OpenWeatherMap.Instance;

        [TestMethod()]
        public void GetWDTest()
        {
            WDMTest.GetWeatherData(new Location("Tel Aviv"));
            Assert.IsNotNull(WDMTest.GetWD());
        }

        [TestMethod()]
        public void ClearWeatherDataTest()
        {
            WDMTest.GetWeatherData(new Location("Tel Aviv"));
            Assert.IsNotNull(WDMTest.GetWD());
            WDMTest.ClearWeatherData();
            Assert.IsNull(WDMTest.GetWD());
        }

        [TestMethod()]
        public void GetWeatherDataTest()
        {
            WDMTest.GetWeatherData(new Location("Tel Aviv"));
            Assert.AreEqual<string>(WDMTest.GetWD().cityName, "Tel Aviv");
            Assert.AreEqual<string>(WDMTest.GetWD().coordLon, "2.75");
            Assert.AreEqual<string>(WDMTest.GetWD().coordLat, "38.9");
            Assert.AreEqual<string>(WDMTest.GetWD().country, "ISR");
            Assert.AreEqual<string>(WDMTest.GetWD().lastupdate, "2017-08-02T07:12:08");
            Assert.AreEqual<string>(WDMTest.GetWD().sunRise, "2017-08-02T05:52:29");
            Assert.AreEqual<string>(WDMTest.GetWD().sunSet, "2017-08-02T17:26:05");
            Assert.AreEqual<string>(WDMTest.GetWD().tempatureMin, "7.89");
            Assert.AreEqual<string>(WDMTest.GetWD().tempatureMax, "11.11");
            Assert.AreEqual<string>(WDMTest.GetWD().tempature, "8.81");
            Assert.AreEqual<string>(WDMTest.GetWD().humidity, "92");
            Assert.AreEqual<string>(WDMTest.GetWD().pressure, "1013");
            Assert.AreEqual<string>(WDMTest.GetWD().windSpeed, "4.91");
            Assert.AreEqual<string>(WDMTest.GetWD().weather, "Few clouds");
        }
    }
}