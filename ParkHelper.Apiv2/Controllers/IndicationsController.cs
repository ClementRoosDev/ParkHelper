using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using ParkHelper.Data;

namespace ParkHelper.Apiv2.Controllers
{
    public class IndicationsController : ODataController
    {
        private readonly ParcHelperEntities _db = new ParcHelperEntities();

        // GET: odata/Indications
        [EnableQuery]
        public IQueryable<Indication> GetIndications()
        {
            return _db.Indications;
        }

        // GET: odata/Indications(5)
        [EnableQuery]
        public SingleResult<Indication> GetIndication([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Indications.Where(indication => indication.Id == key));
        }

        // GET: odata/Indications(5)/Lieux
        [EnableQuery]
        public IQueryable<Lieu> GetLieux([FromODataUri] int key)
        {
            return _db.Indications.Where(m => m.Id == key).SelectMany(m => m.Lieux);
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
