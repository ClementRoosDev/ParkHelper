using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Data
{
    public class Deplacement : IElementDeParcours
    {
        public Attraction LieuDepart { get; set; }
        public Attraction LieuArrivee { get; set; }

        public int Duree
        {
            get; set;
        }

        public int Ordre
        {
            get; set;
        }
    }
}
