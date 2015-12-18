using ParkHelper.Data;
using ParkHelper.Api.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkHelper.Api.Models
{
    public class CalculParcours
    {
        #region Fields

        #endregion

        #region Properties

        public Parcours Parcours { get; set; }

        private IEnumerable<Attraction> ListeAttraction { get; set; }

        #endregion

        #region Constructor

        public CalculParcours(int[] listeIdAttractions)
        {
            this.ListeAttraction = ConvertIdToAttraction(listeIdAttractions);
            this.Parcours = new Parcours { ListeParcours = ListeAttraction };
        }

        #endregion

        #region Methods

        public void CalculeParcoursOptimal()
        {
            DeterminePremiereAttraction();
            DetermineOrdreAttractions();
        }

        

        private List<Attraction> ConvertIdToAttraction(int[] listeIdAttractions)
        {
            using (var db = new ParcHelperEntities())
            {
                List<Attraction> ListeResultats = db.Attractions.Where(a => listeIdAttractions.Contains(a.Id)).ToList();
                ListeResultats= ListeResultats.Select(a => { a.Ordre = 0; return a; }).ToList();
                return ListeResultats;
            }
        }

        private void DeterminePremiereAttraction()
        {
            if (Settings.Default.FeatureGeolocalition)
            {
                //TODO : Calculer le manège le plus près de l'utilisateur
            }
            else
            {
                //On va dire que on doit commencer par le premier de la liste
                ListeAttraction.First().Ordre = 1;
                ListeAttraction.First().EstDejaDansLeParcours = true;


            }
        }

        private void DetermineOrdreAttractions()
        {
            Attraction attractionTemp = ListeAttraction.First(a => a.Ordre == 1);
            for (int i = 2; i <= ListeAttraction.Count(); i++)
            {
                                
                //Localisation localisation = new Localisation();
                Localisation l = new Localisation(attractionTemp,ListeAttraction);
                ListeAttraction.First(a => a == l.AttractionLaPlusPres).Ordre = i;
                attractionTemp = l.AttractionLaPlusPres;
            }
        }


        #endregion
    }
}