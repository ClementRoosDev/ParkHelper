using System.Collections.Generic;
using ParkHelper.Data;

namespace ParkHelper.Api.Models
{
    public class ParcoursRepository
    {
        public static Parcours GetBestParcours(List<int> attractions)
        {
            var parcours = new CalculParcours(attractions.ToArray());
            return parcours.Parcours;
        }
    }
}