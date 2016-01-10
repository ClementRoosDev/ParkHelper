using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Common.Objets
{
    public class RequeteListeParcours
    {
        //public string __invalid_name__$id { get; set; }
        public string value { get; set; }
        public List<ListeParcour> ListeParcours { get; set; }
    }

    public class ListeParcour
    {
        //public string __invalid_name__$id { get; set; }
        public string value { get; set; }
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
        public int Ordre { get; set; }
        public bool EstDejaDansLeParcours { get; set; }
        public object TypeDeLieu { get; set; }
        public List<object> Indications { get; set; }
        public string type { get; set; }

        public override string ToString()
        {
            return Duree.ToString();
        }
    }

}
