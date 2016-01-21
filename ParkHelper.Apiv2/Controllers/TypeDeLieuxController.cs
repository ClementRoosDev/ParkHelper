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
    builder.EntitySet<TypeDeLieu>("TypeDeLieux");
    builder.EntitySet<Lieu>("Lieux"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TypeDeLieuxController : ODataController
    {

        // GET: odata/TypeDeLieux
        [EnableQuery]
        public IQueryable<TypeDeLieu> GetTypeDeLieux()
        {
            using (var db = new ParcHelperEntities())
            {
                return db.TypeDeLieux;
            }
        }

        // GET: odata/TypeDeLieux(5)
        [EnableQuery]
        public SingleResult<TypeDeLieu> GetTypeDeLieu([FromODataUri] int key)
        {
            using (var db = new ParcHelperEntities())
            {
                return SingleResult.Create(db.TypeDeLieux.Where(typeDeLieu => typeDeLieu.Id == key));
            }
        }

        // GET: odata/TypeDeLieux(5)/Lieux
        [EnableQuery]
        public IQueryable<Lieu> GetLieux([FromODataUri] int key)
        {
            using (var db = new ParcHelperEntities())
            {
                return db.TypeDeLieux.Where(m => m.Id == key).SelectMany(m => m.Lieux);
            }
        }
        
    }
}
