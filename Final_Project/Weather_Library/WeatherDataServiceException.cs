using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
* Class for dealing with diffrents excepptions from the libary
*/
namespace Weather_Library
{
    public class WeatherDataServiceException : Exception 
    {
        public WeatherDataServiceException()
        {
           
        }
        public WeatherDataServiceException(string Message) : base(Message)
        {
            Console.WriteLine(Message);

        }
        public WeatherDataServiceException(string message, System.Xml.XmlException inner) : base(message, inner)
        {
            Console.WriteLine(message+ "XML file problem. \n"+inner+"\n");
        }
    }
}
