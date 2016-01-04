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
    builder.EntitySet<TypeDeLieu>("TypeDeLieux");
    builder.EntitySet<Lieu>("Lieux"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TypeDeLieuxController : ODataController
    {
        private ParcHelperEntities db = new ParcHelperEntities();

        // GET: odata/TypeDeLieux
        [EnableQuery]
        public IQueryable<TypeDeLieu> GetTypeDeLieux()
        {
            return db.TypeDeLieux;
        }

        // GET: odata/TypeDeLieux(5)
        [EnableQuery]
        public SingleResult<TypeDeLieu> GetTypeDeLieu([FromODataUri] int key)
        {
            return SingleResult.Create(db.TypeDeLieux.Where(typeDeLieu => typeDeLieu.Id == key));
        }

        // PUT: odata/TypeDeLieux(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<TypeDeLieu> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TypeDeLieu typeDeLieu = db.TypeDeLieux.Find(key);
            if (typeDeLieu == null)
            {
                return NotFound();
            }

            patch.Put(typeDeLieu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeDeLieuExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(typeDeLieu);
        }

        // POST: odata/TypeDeLieux
        public IHttpActionResult Post(TypeDeLieu typeDeLieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeDeLieux.Add(typeDeLieu);
            db.SaveChanges();

            return Created(typeDeLieu);
        }

        // PATCH: odata/TypeDeLieux(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<TypeDeLieu> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TypeDeLieu typeDeLieu = db.TypeDeLieux.Find(key);
            if (typeDeLieu == null)
            {
                return NotFound();
            }

            patch.Patch(typeDeLieu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeDeLieuExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(typeDeLieu);
        }

        // DELETE: odata/TypeDeLieux(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            TypeDeLieu typeDeLieu = db.TypeDeLieux.Find(key);
            if (typeDeLieu == null)
            {
                return NotFound();
            }

            db.TypeDeLieux.Remove(typeDeLieu);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/TypeDeLieux(5)/Lieux
        [EnableQuery]
        public IQueryable<Lieu> GetLieux([FromODataUri] int key)
        {
            return db.TypeDeLieux.Where(m => m.Id == key).SelectMany(m => m.Lieux);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeDeLieuExists(int key)
        {
            return db.TypeDeLieux.Count(e => e.Id == key) > 0;
        }
    }
}
