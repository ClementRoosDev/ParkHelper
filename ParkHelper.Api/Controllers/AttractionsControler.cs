using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ParkHelper.Data;

namespace ParkHelper.Api.Controllers
{
    class AttractionsControler : ApiController
    {
        private List<Attraction> _attractions
        {
            get
            {
                using (var db = new ParcHelperEntities())
                {
                    return db.Attractions.ToList();
                }
            }
        }

        public IHttpActionResult GetAttractions(int id)
        {
            var attraction = _attractions.FirstOrDefault((p) => p.id == id);
            if (attraction == null)
            {
                return NotFound();
            }
            return Ok(attraction);
        }
    }
}
