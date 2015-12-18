using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Data
{
    public class Deplacement : ElementDeParcours
    {
        public Attraction LieuDepart { get; set; }
        public Attraction LieuArrivee { get; set; }
    }
}
