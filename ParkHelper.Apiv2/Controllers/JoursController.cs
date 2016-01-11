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
    builder.EntitySet<Jour>("Jours");
    builder.EntitySet<Planning>("Plannings"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class JoursController : ODataController
    {
        private ParcHelperEntities db = new ParcHelperEntities();

        // GET: odata/Jours
        [EnableQuery]
        public IQueryable<Jour> GetJours()
        {
            return db.Jours;
        }

        // GET: odata/Jours(5)
        [EnableQuery]
        public SingleResult<Jour> GetJour([FromODataUri] int key)
        {
            return SingleResult.Create(db.Jours.Where(jour => jour.Id == key));
        }

        // PUT: odata/Jours(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Jour> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Jour jour = db.Jours.Find(key);
            if (jour == null)
            {
                return NotFound();
            }

            patch.Put(jour);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JourExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(jour);
        }

        // POST: odata/Jours
        public IHttpActionResult Post(Jour jour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jours.Add(jour);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (JourExists(jour.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(jour);
        }

        // PATCH: odata/Jours(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Jour> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Jour jour = db.Jours.Find(key);
            if (jour == null)
            {
                return NotFound();
            }

            patch.Patch(jour);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JourExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(jour);
        }

        // DELETE: odata/Jours(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Jour jour = db.Jours.Find(key);
            if (jour == null)
            {
                return NotFound();
            }

            db.Jours.Remove(jour);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Jours(5)/Plannings
        [EnableQuery]
        public IQueryable<Planning> GetPlannings([FromODataUri] int key)
        {
            return db.Jours.Where(m => m.Id == key).SelectMany(m => m.Plannings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JourExists(int key)
        {
            return db.Jours.Count(e => e.Id == key) > 0;
        }
    }
}
