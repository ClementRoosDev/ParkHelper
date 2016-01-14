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
    builder.EntitySet<Planning>("Plannings1");
    builder.EntitySet<EtatLieu>("EtatLieux"); 
    builder.EntitySet<Horaire>("Horaires"); 
    builder.EntitySet<Jour>("Jours"); 
    builder.EntitySet<Lieu>("Lieux"); 
    builder.EntitySet<Mois>("Mois"); 
    builder.EntitySet<NumeroJour>("NumeroJours"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PlanningsController : ODataController
    {
        private readonly ParcHelperEntities _db = new ParcHelperEntities();

        // GET: odata/Plannings1
        [EnableQuery]
        public IQueryable<Planning> GetPlannings1()
        {
            return _db.Plannings;
        }

        // GET: odata/Plannings1(5)
        [EnableQuery]
        public SingleResult<Planning> GetPlanning([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Plannings.Where(planning => planning.id == key));
        }

        // GET: odata/Plannings1(5)/EtatLieu
        [EnableQuery]
        public SingleResult<EtatLieu> GetEtatLieu([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Plannings.Where(m => m.id == key).Select(m => m.EtatLieu));
        }

        // GET: odata/Plannings1(5)/Horaire
        [EnableQuery]
        public SingleResult<Horaire> GetHoraire([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Plannings.Where(m => m.id == key).Select(m => m.Horaire));
        }

        // GET: odata/Plannings1(5)/Jour
        [EnableQuery]
        public SingleResult<Jour> GetJour([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Plannings.Where(m => m.id == key).Select(m => m.Jour));
        }

        // GET: odata/Plannings1(5)/Lieu
        [EnableQuery]
        public SingleResult<Lieu> GetLieu([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Plannings.Where(m => m.id == key).Select(m => m.Lieu));
        }

        // GET: odata/Plannings1(5)/Mois
        [EnableQuery]
        public SingleResult<Mois> GetMois([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Plannings.Where(m => m.id == key).Select(m => m.Mois));
        }

        // GET: odata/Plannings1(5)/NumeroJour
        [EnableQuery]
        public SingleResult<NumeroJour> GetNumeroJour([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Plannings.Where(m => m.id == key).Select(m => m.NumeroJour));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
