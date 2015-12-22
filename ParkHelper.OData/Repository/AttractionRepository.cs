using System.Collections.Generic;
using System.Linq;
using ParkHelper.Data;

namespace ParkHelper.OData.Repository
{

    public class AttractionRepository : GenericRepository<Attraction>
    {
        public List<Attraction> FindByName(string name)
        {
            return Table.Where(a => a.Libelle == name).ToList();
        }

    }
}