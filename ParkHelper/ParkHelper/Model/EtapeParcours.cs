using ParkHelper.Common.Objets;

namespace ParkHelper.Model
{
    public class EtapeParcours
    {
        public EtapeParcours(ListeParcour attractionAFaire)
        {
            AttractionAFaire = attractionAFaire;
        }

        public ListeParcour AttractionAFaire { get; set; }

        /**public override string ToString()
        {
            return AttractionAFaire.Duree.ToString();
        }*/
    }
}
