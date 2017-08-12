using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * holding Location data
 */
namespace Weather_Library
{
    public class Location
    {
        public string LocName { get; set; }
        public Location(string location)
        {
            LocName = location;
        }
    }
}
