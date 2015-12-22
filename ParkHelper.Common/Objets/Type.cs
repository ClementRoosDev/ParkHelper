using System.Collections.Generic;

namespace ParkHelper.Common.Objets
{
    public class Type
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public List<Attraction> Attractions { get; set; }
    }
}
