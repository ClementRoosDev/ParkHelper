using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using ParkHelper.Data;

namespace ParkHelper.Apiv2.Controllers
{
    public class LieuxController : ODataController
    {
        private readonly ParcHelperEntities _db = new ParcHelperEntities();

        // GET: odata/Lieux
        [EnableQuery]
        public IQueryable<Lieu> GetLieux()
        {
            return _db.Lieux;
        }

        // GET: odata/Lieux(5)
        [EnableQuery]
        public SingleResult<Lieu> GetLieu([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Lieux.Where(lieu => lieu.Id == key));
        }

        // GET: odata/Lieux(5)/TypeDeLieu
        [EnableQuery]
        public SingleResult<TypeDeLieu> GetTypeDeLieu([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Lieux.Where(m => m.Id == key).Select(m => m.TypeDeLieu));
        }

        // GET: odata/Lieux(5)/Indications
        [EnableQuery]
        public IQueryable<Indication> GetIndications([FromODataUri] int key)
        {
            return _db.Lieux.Where(m => m.Id == key).SelectMany(m => m.Indications);
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
