using ParkHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkHelper.Api.Models
{
    public class Localisation
    {

        #region Fields

        private Attraction attractionDeDepart;
        private IEnumerable<Attraction> listeAttractions;
        
        #endregion

        #region Properties

        public Attraction AttractionLaPlusPres
        {
            get
            {
                Dictionary<Attraction, int> AttractionEtDistance = new Dictionary<Attraction, int>();
                foreach (var item in listeAttractions.Where(a=>a.EstDejaDansLeParcours == false))
                {
                        Deplacement d = new Deplacement(attractionDeDepart,item);
                        AttractionEtDistance.Add(item,d.Duree);   
                }
                Attraction attractionResult = AttractionEtDistance.OrderBy(d => d.Value).First().Key;
                attractionResult.EstDejaDansLeParcours = true;
                return attractionResult;
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
        

        #endregion
    }
}