using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using ParkHelper.Data;

namespace ParkHelper.Apiv2.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ParkHelper.Data;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<EtatLieu>("EtatLieux");
    builder.EntitySet<Lieu>("Lieux"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EtatLieuxController : ODataController
    {
        private ParcHelperEntities db = new ParcHelperEntities();

        // GET: odata/EtatLieux
        [EnableQuery]
        public IQueryable<EtatLieu> GetEtatLieux()
        {
            return db.EtatLieux;
        }

        // GET: odata/EtatLieux(5)
        [EnableQuery]
        public SingleResult<EtatLieu> GetEtatLieu([FromODataUri] int key)
        {
            return SingleResult.Create(db.EtatLieux.Where(etatLieu => etatLieu.IdEtat == key));
        }

        // GET: odata/EtatLieux(5)/Lieux
        [EnableQuery]
        public IQueryable<Lieu> GetLieux([FromODataUri] int key)
        {
            return db.EtatLieux.Where(m => m.IdEtat == key).SelectMany(m => m.Lieux);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EtatLieuExists(int key)
        {
            return db.EtatLieux.Count(e => e.IdEtat == key) > 0;
        }
    }
}
