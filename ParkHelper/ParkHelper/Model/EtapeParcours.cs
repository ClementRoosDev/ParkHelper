using ParkHelper.Common.Objets;

namespace ParkHelper.Model
{
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
