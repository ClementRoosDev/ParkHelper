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
    builder.EntitySet<Horaire>("Horaires");
    builder.EntitySet<Planning>("Plannings"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class HorairesController : ODataController
    {
        private ParcHelperEntities db = new ParcHelperEntities();

        // GET: odata/Horaires
        [EnableQuery]
        public IQueryable<Horaire> GetHoraires()
        {
            return db.Horaires;
        }

        // GET: odata/Horaires(5)
        [EnableQuery]
        public SingleResult<Horaire> GetHoraire([FromODataUri] int key)
        {
            return SingleResult.Create(db.Horaires.Where(horaire => horaire.Id == key));
        }

        // PUT: odata/Horaires(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Horaire> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Horaire horaire = db.Horaires.Find(key);
            if (horaire == null)
            {
                return NotFound();
            }

            patch.Put(horaire);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoraireExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(horaire);
        }

        // POST: odata/Horaires
        public IHttpActionResult Post(Horaire horaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Horaires.Add(horaire);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HoraireExists(horaire.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(horaire);
        }

        // PATCH: odata/Horaires(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Horaire> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Horaire horaire = db.Horaires.Find(key);
            if (horaire == null)
            {
                return NotFound();
            }

            patch.Patch(horaire);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoraireExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(horaire);
        }

        // DELETE: odata/Horaires(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Horaire horaire = db.Horaires.Find(key);
            if (horaire == null)
            {
                return NotFound();
            }

            db.Horaires.Remove(horaire);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Horaires(5)/Plannings
        [EnableQuery]
        public IQueryable<Planning> GetPlannings([FromODataUri] int key)
        {
            return db.Horaires.Where(m => m.Id == key).SelectMany(m => m.Plannings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HoraireExists(int key)
        {
            return db.Horaires.Count(e => e.Id == key) > 0;
        }
    }
}
