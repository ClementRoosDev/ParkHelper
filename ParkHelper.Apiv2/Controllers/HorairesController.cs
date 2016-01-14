using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using ParkHelper.Data;

namespace ParkHelper.Apiv2.Controllers
{
    public class HorairesController : ODataController
    {
        private readonly ParcHelperEntities _db = new ParcHelperEntities();

        // GET: odata/Horaires
        [EnableQuery]
        public IQueryable<Horaire> GetHoraires()
        {
            return _db.Horaires;
        }

        // GET: odata/Horaires(5)
        [EnableQuery]
        public SingleResult<Horaire> GetHoraire([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Horaires.Where(horaire => horaire.Id == key));
        }

        // GET: odata/Horaires(5)/Plannings
        [EnableQuery]
        public IQueryable<Planning> GetPlannings([FromODataUri] int key)
        {
            return _db.Horaires.Where(m => m.Id == key).SelectMany(m => m.Plannings);
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
