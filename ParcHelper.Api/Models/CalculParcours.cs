using ParkHelper.Data;
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

        private List<Attraction> ListeAttraction { get; set; }

        #endregion

        #region Constructor

        public CalculParcours(int[] listeIdAttractions)
        {
            this.ListeAttraction = ConvertIdToAttraction(listeIdAttractions);
        }

        #endregion

        #region Methods

        private List<Attraction> ConvertIdToAttraction(int[] listeIdAttractions)
        {
            using (var db = new ParcHelperEntities())
            {
                return db.Attractions.Where(a => listeIdAttractions.Contains(a.Id)).ToList();
            }
        }

        private void SequencerAttraction()
        {

        }

        #endregion


    }
}