using ParkHelper.Apiv2.Repository;
using ParkHelper.Data;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace ParkHelper.Apiv2.Model
{
    public class CalculParcours
    {
        #region Fields

        #endregion

        #region Properties

        public Parcours Parcours { get; set; }
        List<Lieu> ListeAttraction { get; set; }

        #endregion

        #region Constructor

        public CalculParcours(int[] listeIdAttractions)
        {
            ListeAttraction = new List<Lieu>();
            ListeAttraction = ConvertIdToAttraction(listeIdAttractions) as List<Lieu>;

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

        List<Lieu> ConvertIdToAttraction(int[] listeIdAttractions)
        {
            /*using (var db = new ParcHelperEntities())
            {
                var listeResultats = db.Attractions.Where(a => listeIdAttractions.Contains(a.Id)).ToList();
                listeResultats= listeResultats.Select(a => { a.Ordre = 0; return a; }).ToList();
                return listeResultats;
            }*/

            AttractionRepository repository = new AttractionRepository();
            List<Lieu> listeResultats = repository.ConvertIdToAttraction(listeIdAttractions);

            return listeResultats;
        }

        void DeterminePremiereAttraction()
        {
            //On va dire que on doit commencer par le premier de la liste
            ListeAttraction.First().Ordre = 1;
            ListeAttraction.First().EstDejaDansLeParcours = true;
        }

        void DetermineOrdreAttractions()
        {
            Lieu attractionTemp = ListeAttraction.First(a => a.Ordre == 1);
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