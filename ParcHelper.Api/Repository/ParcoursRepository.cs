using System.Collections.Generic;
using ParkHelper.Api.Models;
using ParkHelper.Data;

namespace ParkHelper.Api.Repository
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