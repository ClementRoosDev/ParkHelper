using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using ParkHelper.Data;

namespace ParkHelper.Apiv2.Controllers
{
    public class MoisController : ODataController
    {
        private readonly ParcHelperEntities _db = new ParcHelperEntities();

        // GET: odata/Mois
        [EnableQuery]
        public IQueryable<Mois> GetMois()
        {
            return _db.Mois;
        }

        // GET: odata/Mois(5)
        [EnableQuery]
        public SingleResult<Mois> GetMois([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Mois.Where(mois => mois.Id == key));
        }

        // GET: odata/Mois(5)/Plannings
        [EnableQuery]
        public IQueryable<Planning> GetPlannings([FromODataUri] int key)
        {
            return _db.Mois.Where(m => m.Id == key).SelectMany(m => m.Plannings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
