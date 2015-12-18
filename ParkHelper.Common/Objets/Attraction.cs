using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Common.Objets
{
    class Attraction
    {
        public object Type { get; set; }
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public object LienGif { get; set; }
        public double Latittude { get; set; }
        public double Longitude { get; set; }
        public int Attente { get; set; }
        public int CapaciteWagon { get; set; }
        public object IdType { get; set; }
        public int Duree { get; set; }
        public bool EstDejaDansLeParcours { get; set; }
        public int Ordre { get; set; }
    }
}
