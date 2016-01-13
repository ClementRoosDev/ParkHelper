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
    builder.EntitySet<Indication>("Indications");
    builder.EntitySet<Lieu>("Lieux"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class IndicationsController : ODataController
    {
        private ParcHelperEntities db = new ParcHelperEntities();

        // GET: odata/Indications
        [EnableQuery]
        public IQueryable<Indication> GetIndications()
        {
            return db.Indications;
        }

        // GET: odata/Indications(5)
        [EnableQuery]
        public SingleResult<Indication> GetIndication([FromODataUri] int key)
        {
            return SingleResult.Create(db.Indications.Where(indication => indication.Id == key));
        }

        // GET: odata/Indications(5)/Lieux
        [EnableQuery]
        public IQueryable<Lieu> GetLieux([FromODataUri] int key)
        {
            return db.Indications.Where(m => m.Id == key).SelectMany(m => m.Lieux);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
