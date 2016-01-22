using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Common.Models.Visite
{
    public class Location
    {
        public Location(double x, double y)
        {
            X = x;
            Y = y;
        }

        // We could add other properties, like the name, the description
        // or anything similar that we consider useful.

        public double X { get; set; }
        public double Y { get; set; }
    }
}
