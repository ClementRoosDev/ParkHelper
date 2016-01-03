using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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
    builder.EntitySet<Attraction>("Attractions");
    builder.EntitySet<Type>("Types"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class AttractionsController : ODataController
    {
        private ParcHelperEntities db = new ParcHelperEntities();

        // GET: odata/Attractions
        [EnableQuery]
        public IQueryable<Attraction> GetAttractions()
        {
            return db.Attractions;
        }

        // GET: odata/Attractions(5)
        [EnableQuery]
        public SingleResult<Attraction> GetAttraction([FromODataUri] int key)
        {
            return SingleResult.Create(db.Attractions.Where(attraction => attraction.Id == key));
        }

        // PUT: odata/Attractions(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Attraction> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Attraction attraction = db.Attractions.Find(key);
            if (attraction == null)
            {
                return NotFound();
            }

            patch.Put(attraction);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttractionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(attraction);
        }

        // POST: odata/Attractions
        public IHttpActionResult Post(Attraction attraction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Attractions.Add(attraction);
            db.SaveChanges();

            return Created(attraction);
        }

        // PATCH: odata/Attractions(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Attraction> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Attraction attraction = db.Attractions.Find(key);
            if (attraction == null)
            {
                return NotFound();
            }

            patch.Patch(attraction);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttractionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(attraction);
        }

        // DELETE: odata/Attractions(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Attraction attraction = db.Attractions.Find(key);
            if (attraction == null)
            {
                return NotFound();
            }

            db.Attractions.Remove(attraction);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Attractions(5)/Type
        [EnableQuery]
        public SingleResult<ParkHelper.Data.Type> GetType([FromODataUri] int key)
        {
            return SingleResult.Create(db.Attractions.Where(m => m.Id == key).Select(m => m.Type));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttractionExists(int key)
        {
            return db.Attractions.Count(e => e.Id == key) > 0;
        }
    }
}
