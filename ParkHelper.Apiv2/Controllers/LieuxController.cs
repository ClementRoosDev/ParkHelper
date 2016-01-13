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
    builder.EntitySet<Lieu>("Lieux");
    builder.EntitySet<TypeDeLieu>("TypeDeLieux"); 
    builder.EntitySet<Indication>("Indications"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class LieuxController : ODataController
    {
        private ParcHelperEntities db = new ParcHelperEntities();

        // GET: odata/Lieux
        [EnableQuery]
        public IQueryable<Lieu> GetLieux()
        {
            return db.Lieux;
        }

        // GET: odata/Lieux(5)
        [EnableQuery]
        public SingleResult<Lieu> GetLieu([FromODataUri] int key)
        {
            return SingleResult.Create(db.Lieux.Where(lieu => lieu.Id == key));
        }

        // GET: odata/Lieux(5)/TypeDeLieu
        [EnableQuery]
        public SingleResult<TypeDeLieu> GetTypeDeLieu([FromODataUri] int key)
        {
            return SingleResult.Create(db.Lieux.Where(m => m.Id == key).Select(m => m.TypeDeLieu));
        }

        // GET: odata/Lieux(5)/Indications
        [EnableQuery]
        public IQueryable<Indication> GetIndications([FromODataUri] int key)
        {
            return db.Lieux.Where(m => m.Id == key).SelectMany(m => m.Indications);
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
