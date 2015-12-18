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

        private List<Attraction> ConvertIdToAttraction(int[] listeIdAttractions)
        {
            using (var db = new ParcHelperEntities())
            {
                List<Attraction> ListeResultats = db.Attractions.Where(a => listeIdAttractions.Contains(a.Id)).ToList();
                ListeResultats= ListeResultats.Select(a => { a.EstLePremierDuParcours = false; return a; }).ToList();
                return ListeResultats;
            }
        }

        private void SequencerAttraction()
        {
            if (Settings.Default.FeatureGeolocalition)
            {
                //TODO : Calculer le manège le plus près de l'utilisateur
            }
            else
            {
                //On va dire que on doit commencer par la première
                ListeAttraction.First().EstLePremierDuParcours = true;
                
            }
        }

        

        #endregion
    }
}