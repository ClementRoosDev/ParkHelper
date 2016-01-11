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
    builder.EntitySet<Planning>("Plannings");
    builder.EntitySet<EtatLieu>("EtatLieux"); 
    builder.EntitySet<Horaire>("Horaires"); 
    builder.EntitySet<Jour>("Jours"); 
    builder.EntitySet<Lieu>("Lieux"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PlanningsController : ODataController
    {
        private ParcHelperEntities db = new ParcHelperEntities();

        // GET: odata/Plannings
        [EnableQuery]
        public IQueryable<Planning> GetPlannings()
        {
            return db.Plannings;
        }

        // GET: odata/Plannings(5)
        [EnableQuery]
        public SingleResult<Planning> GetPlanning([FromODataUri] int key)
        {
            return SingleResult.Create(db.Plannings.Where(planning => planning.IdLieu == key));
        }

        // PUT: odata/Plannings(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Planning> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Planning planning = db.Plannings.Find(key);
            if (planning == null)
            {
                return NotFound();
            }

            patch.Put(planning);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanningExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(planning);
        }

        // POST: odata/Plannings
        public IHttpActionResult Post(Planning planning)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Plannings.Add(planning);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PlanningExists(planning.IdLieu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(planning);
        }

        // PATCH: odata/Plannings(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Planning> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Planning planning = db.Plannings.Find(key);
            if (planning == null)
            {
                return NotFound();
            }

            patch.Patch(planning);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanningExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(planning);
        }

        // DELETE: odata/Plannings(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Planning planning = db.Plannings.Find(key);
            if (planning == null)
            {
                return NotFound();
            }

            db.Plannings.Remove(planning);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Plannings(5)/EtatLieu
        [EnableQuery]
        public SingleResult<EtatLieu> GetEtatLieu([FromODataUri] int key)
        {
            return SingleResult.Create(db.Plannings.Where(m => m.IdLieu == key).Select(m => m.EtatLieu));
        }

        // GET: odata/Plannings(5)/Horaire
        [EnableQuery]
        public SingleResult<Horaire> GetHoraire([FromODataUri] int key)
        {
            return SingleResult.Create(db.Plannings.Where(m => m.IdLieu == key).Select(m => m.Horaire));
        }

        // GET: odata/Plannings(5)/Jour
        [EnableQuery]
        public SingleResult<Jour> GetJour([FromODataUri] int key)
        {
            return SingleResult.Create(db.Plannings.Where(m => m.IdLieu == key).Select(m => m.Jour));
        }

        // GET: odata/Plannings(5)/Lieu
        [EnableQuery]
        public SingleResult<Lieu> GetLieu([FromODataUri] int key)
        {
            return SingleResult.Create(db.Plannings.Where(m => m.IdLieu == key).Select(m => m.Lieu));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlanningExists(int key)
        {
            return db.Plannings.Count(e => e.IdLieu == key) > 0;
        }
    }
}
