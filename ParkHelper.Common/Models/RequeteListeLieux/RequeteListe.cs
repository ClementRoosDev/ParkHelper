using System.Collections.Generic;

namespace ParkHelper.Common.Models.RequeteListeLieux
{
    public class RequeteListe
    {
        public string metadata { get; set; }
        public List<Lieu> value { get; set; }
    }
}
