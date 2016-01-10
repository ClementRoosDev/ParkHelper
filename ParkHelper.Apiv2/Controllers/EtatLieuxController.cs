using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
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

        // PUT: odata/EtatLieux(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<EtatLieu> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EtatLieu etatLieu = db.EtatLieux.Find(key);
            if (etatLieu == null)
            {
                return NotFound();
            }

            patch.Put(etatLieu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtatLieuExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(etatLieu);
        }

        // POST: odata/EtatLieux
        public IHttpActionResult Post(EtatLieu etatLieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EtatLieux.Add(etatLieu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EtatLieuExists(etatLieu.IdEtat))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(etatLieu);
        }

        // PATCH: odata/EtatLieux(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<EtatLieu> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EtatLieu etatLieu = db.EtatLieux.Find(key);
            if (etatLieu == null)
            {
                return NotFound();
            }

            patch.Patch(etatLieu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtatLieuExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(etatLieu);
        }

        // DELETE: odata/EtatLieux(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            EtatLieu etatLieu = db.EtatLieux.Find(key);
            if (etatLieu == null)
            {
                return NotFound();
            }

            db.EtatLieux.Remove(etatLieu);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
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
