using ParkHelper.Data;
using System.Collections.Generic;
using System.Linq;
using ParkHelper.Data.Parcours;

namespace ParkHelper.Api.Models
{
    public class Localisation
    {

        #region Fields

        Data.Parcours.Lieu attractionDeDepart;
        IEnumerable<Data.Parcours.Lieu> listeAttractions;
        Data.Parcours.Lieu attractionLaPlusPres;

        #endregion

        #region Properties

        public Data.Parcours.Lieu AttractionLaPlusPres
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

        public Localisation(Data.Parcours.Lieu attractionDeDepart, IEnumerable<Data.Parcours.Lieu> listeAttractions)
        {
            this.attractionDeDepart = attractionDeDepart;
            this.listeAttractions = listeAttractions;
        }

        #endregion

        #region Methodes
        
        public void CalculeAttractionLaPlusPres()
        {
            Dictionary<Data.Parcours.Lieu, int> AttractionEtDistance = new Dictionary<Data.Parcours.Lieu, int>();
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