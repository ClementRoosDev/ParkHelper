using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkHelper.Data;

namespace ParkHelper.Api.Repository
{
    public class AttractionRepository : GenericRepository<Attraction>
    {
        public List<Attraction> FindByName(string name)
        {
            return Table.Where(a => a.Libelle == name).ToList();
        }

    }
}