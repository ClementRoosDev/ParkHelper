using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Script.Serialization;
using ParkHelper.Data;

namespace ParkHelper.Api.Controllers
{
    class AttractionsController : ApiController
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

        [AcceptVerbs("GET","POST")]
        [HttpGet]
        public string getall()
        {
            List<Attraction> attractions;
            using (var db = new ParcHelperEntities())
            {
                attractions = db.Attractions.ToList();
            }
            var attraction = _attractions.FirstOrDefault((p) => p.Id == 1);
            if (attraction == null)
            {
                return null;
            }
            JavaScriptSerializer json = new JavaScriptSerializer();
            return json.Serialize(attractions);
        }
    }
}
