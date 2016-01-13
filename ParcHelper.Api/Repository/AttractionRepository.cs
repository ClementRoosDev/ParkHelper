using System.Collections.Generic;
using System.Linq;
using ParkHelper.Data;

namespace ParkHelper.Api.Repository
{
    public class AttractionRepository : GenericRepository<Lieu>
    {
        public List<Lieu> FindByName(string name)
        {
            return Table.Where(a => a.Libelle == name).ToList();
        }

        public List<Lieu> ConvertIdToAttraction(int[] listeIdAttractions)
        {
            var listeResultats = Table.Where(a => listeIdAttractions.Contains(a.Id)).ToList();
            listeResultats = listeResultats.Select(a => { a.Ordre = 0; return a; }).ToList();
            return listeResultats;
        }

    }
}