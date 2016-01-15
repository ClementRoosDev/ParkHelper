using System.Collections.Generic;
using ParkHelper.Common.Models.RequeteListeLieux;

namespace ParkHelper.Common.Models
{
    public class RequeteListeParcours
    {
        public List<ListeParcour> ListeParcours { get; set; }
    }

    public class ListeParcour
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public object LienGif { get; set; }
        public double Latittude { get; set; }
        public double Longitude { get; set; }
        public int Attente { get; set; }
        public int Duree { get; set; }
        public int CapaciteWagon { get; set; }
        public int IdType { get; set; }
        public object TypeDeLieu { get; set; }
        public List<Indication> Indications { get; set; }
        public List<Planning> Plannings { get; set; }
        public bool EstDejaDansLeParcours { get; set; }
        public int Ordre { get; set; }
        public string type { get; set; }

        public override string ToString()
        {
            return Duree.ToString();
        }
    }

}
