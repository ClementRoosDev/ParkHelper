using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using ParkHelper.Data;

namespace ParkHelper.Apiv2.Controllers
{
    public class EtatLieuxController : ODataController
    {
        private readonly ParcHelperEntities _db = new ParcHelperEntities();

        // GET: odata/EtatLieux
        [EnableQuery]
        public IQueryable<EtatLieu> GetEtatLieux()
        {
            return _db.EtatLieux;
        }

        // GET: odata/EtatLieux(5)
        [EnableQuery]
        public SingleResult<EtatLieu> GetEtatLieu([FromODataUri] int key)
        {
            return SingleResult.Create(_db.EtatLieux.Where(etatLieu => etatLieu.IdEtat == key));
        }

        // GET: odata/EtatLieux(5)/Plannings
        [EnableQuery]
        public IQueryable<Planning> GetPlannings([FromODataUri] int key)
        {
            return _db.EtatLieux.Where(m => m.IdEtat == key).SelectMany(m => m.Plannings);
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
