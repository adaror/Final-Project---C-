using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Testing the inputs

namespace Weather_Library.Tests
{
    [TestClass()]
    public class LocationTests
    {

        [TestMethod()]
        public void LocationTest()
        {
            Location LocationTest = new Location("New York");
            Assert.AreEqual<string>(LocationTest.LocName, "New York");
        }
    }
}