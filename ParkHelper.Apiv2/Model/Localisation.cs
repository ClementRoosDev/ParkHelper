using ParkHelper.Data;
using System.Collections.Generic;
using System.Linq;

namespace ParkHelper.Apiv2.Model
{
    public class Localisation
    {

        #region Fields

        Lieu attractionDeDepart;
        IEnumerable<Lieu> listeAttractions;
        Lieu attractionLaPlusPres;

        #endregion

        #region Properties

        public Lieu AttractionLaPlusPres
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

        public Localisation(Lieu attractionDeDepart, IEnumerable<Lieu> listeAttractions)
        {
            this.attractionDeDepart = attractionDeDepart;
            this.listeAttractions = listeAttractions;
        }

        #endregion

        #region Methodes
        
        public void CalculeAttractionLaPlusPres()
        {
            Dictionary<Lieu, int> AttractionEtDistance = new Dictionary<Lieu, int>();
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