using System.Collections.Generic;
using ParkHelper.Apiv2.Models;
using ParkHelper.Data;

namespace ParkHelper.Apiv2.Repository
{
    public class ParcoursRepository : GenericRepository<Parcours>
    {
        public Parcours GetBestParcours(List<int> attractions)
        {
            var parcours = new CalculParcours(attractions.ToArray());
            return parcours.Parcours;
        }
    }
}