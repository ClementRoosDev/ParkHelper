using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Model
{
    using ParkHelper.Common.Objets;

    public class EtapeParcours
    {
        public EtapeParcours(string heure, Attraction attractionAFaire)
        {
            Heure = heure;
            AttractionAFaire = attractionAFaire;
        }

        string Heure { get; set; }

        Attraction AttractionAFaire { get; set; }

        public override string ToString()
        {
            return AttractionAFaire.Libelle;
        }
    }
}
