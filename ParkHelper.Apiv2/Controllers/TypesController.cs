using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
    builder.EntitySet<Type>("Types");
    builder.EntitySet<Attraction>("Attractions"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TypesController : ODataController
    {
        private ParcHelperEntities db = new ParcHelperEntities();

        // GET: odata/Types
        [EnableQuery]
        public IQueryable<Data.Type> GetTypes()
        {
            return db.Types;
        }

        // GET: odata/Types(5)
        [EnableQuery]
        public SingleResult<Data.Type> GetType([FromODataUri] int key)
        {
            return SingleResult.Create(db.Types.Where(type => type.Id == key));
        }

        // PUT: odata/Types(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Data.Type> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Data.Type type = await db.Types.FindAsync(key);
            if (type == null)
            {
                return NotFound();
            }

            patch.Put(type);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(type);
        }

        // POST: odata/Types
        public async Task<IHttpActionResult> Post(Data.Type type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Types.Add(type);
            await db.SaveChangesAsync();

            return Created(type);
        }

        // PATCH: odata/Types(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Data.Type> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Data.Type type = await db.Types.FindAsync(key);
            if (type == null)
            {
                return NotFound();
            }

            patch.Patch(type);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(type);
        }

        // DELETE: odata/Types(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Data.Type type = await db.Types.FindAsync(key);
            if (type == null)
            {
                return NotFound();
            }

            db.Types.Remove(type);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Types(5)/Attractions
        [EnableQuery]
        public IQueryable<Attraction> GetAttractions([FromODataUri] int key)
        {
            return db.Types.Where(m => m.Id == key).SelectMany(m => m.Attractions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeExists(int key)
        {
            return db.Types.Count(e => e.Id == key) > 0;
        }
    }
}
