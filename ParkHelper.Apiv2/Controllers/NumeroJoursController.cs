using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using ParkHelper.Data;

namespace ParkHelper.Apiv2.Controllers
{
    public class NumeroJoursController : ODataController
    {
        private readonly ParcHelperEntities _db = new ParcHelperEntities();

        // GET: odata/NumeroJours
        [EnableQuery]
        public IQueryable<NumeroJour> GetNumeroJours()
        {
            return _db.NumeroJours;
        }

        // GET: odata/NumeroJours(5)
        [EnableQuery]
        public SingleResult<NumeroJour> GetNumeroJour([FromODataUri] int key)
        {
            return SingleResult.Create(_db.NumeroJours.Where(numeroJour => numeroJour.Id == key));
        }

        // GET: odata/NumeroJours(5)/Plannings
        [EnableQuery]
        public IQueryable<Planning> GetPlannings([FromODataUri] int key)
        {
            return _db.NumeroJours.Where(m => m.Id == key).SelectMany(m => m.Plannings);
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
