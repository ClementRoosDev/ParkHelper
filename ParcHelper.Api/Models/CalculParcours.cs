using ParkHelper.Data;
using ParkHelper.Api.Properties;
using System.Collections.Generic;
using System.Linq;

namespace ParkHelper.Api.Models
{
    public class CalculParcours
    {
        #region Fields

        #endregion

        #region Properties

        public Parcours Parcours { get; set; }
        List<Attraction> ListeAttraction { get; set; }

        #endregion

        #region Constructor

        public CalculParcours(int[] listeIdAttractions)
        {
            ListeAttraction = ConvertIdToAttraction(listeIdAttractions);
            Parcours = new Parcours { ListeParcours = ListeAttraction.Cast<IElementDeParcours>().ToList() };
        }

        #endregion

        #region Methods

        public void CalculeParcoursOptimal()
        {
            DeterminePremiereAttraction();
            DetermineOrdreAttractions();
            AjoutDeplacements();
        }

        List<Attraction> ConvertIdToAttraction(int[] listeIdAttractions)
        {
            using (var db = new ParcHelperEntities())
            {
                var listeResultats = db.Attractions.Where(a => listeIdAttractions.Contains(a.Id)).ToList();
                listeResultats= listeResultats.Select(a => { a.Ordre = 0; return a; }).ToList();
                return listeResultats;
            }
        }

        void DeterminePremiereAttraction()
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

        void DetermineOrdreAttractions()
        {
            Attraction attractionTemp = ListeAttraction.First(a => a.Ordre == 1);
            for (int i = 3; i <= ListeAttraction.Count()*2; i+=2)
            {
                Localisation l = new Localisation(attractionTemp,ListeAttraction);
                l.CalculeAttractionLaPlusPres();
                ListeAttraction.First(a => a == l.AttractionLaPlusPres).Ordre = i;
                attractionTemp = l.AttractionLaPlusPres;
            }
        }

        void AjoutDeplacements()
        {
            for (int i = 2 ; i < ListeAttraction.Count()*2; i+=2)
            {
                Deplacement d = new Deplacement(ListeAttraction.FirstOrDefault(a=>a.Ordre==i-1), ListeAttraction.FirstOrDefault(a => a.Ordre == (i+1)));
                d.Ordre = i;
                Parcours.ListeParcours.Add(d);
            }
        }

        #endregion
    }
}