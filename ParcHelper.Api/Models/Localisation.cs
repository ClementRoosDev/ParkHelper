using ParkHelper.Data;
using System.Collections.Generic;
using System.Linq;

namespace ParkHelper.Api.Models
{
    public class Localisation
    {

        #region Fields

        private Attraction attractionDeDepart;
        private IEnumerable<Attraction> listeAttractions;
        private Attraction attractionLaPlusPres;

        #endregion

        #region Properties

        public Attraction AttractionLaPlusPres
        {
            get
            {
                return attractionLaPlusPres;
            }
            set
            {
                attractionLaPlusPres = value;
            }
        }

        #endregion

        #region Constructeur

        public Localisation(Attraction attractionDeDepart, IEnumerable<Attraction> listeAttractions)
        {
            this.attractionDeDepart = attractionDeDepart;
            this.listeAttractions = listeAttractions;
        }

        #endregion

        #region Methodes
        
        public void CalculeAttractionLaPlusPres()
        {
            Dictionary<Attraction, int> AttractionEtDistance = new Dictionary<Attraction, int>();
            foreach (var item in listeAttractions.Where(a => a.EstDejaDansLeParcours == false))
            {
                Deplacement d = new Deplacement(attractionDeDepart, item);
                AttractionEtDistance.Add(item, d.Duree);
            }
            AttractionLaPlusPres = AttractionEtDistance.OrderBy(d => d.Value).First().Key;
            AttractionLaPlusPres.EstDejaDansLeParcours = true;            
        }

        #endregion
    }
}