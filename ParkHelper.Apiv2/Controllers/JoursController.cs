﻿using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using ParkHelper.Data;

namespace ParkHelper.Apiv2.Controllers
{
    public class JoursController : ODataController
    {
        private readonly ParcHelperEntities _db = new ParcHelperEntities();

        // GET: odata/Jours
        [EnableQuery]
        public IQueryable<Jour> GetJours()
        {
            return _db.Jours;
        }

        // GET: odata/Jours(5)
        [EnableQuery]
        public SingleResult<Jour> GetJour([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Jours.Where(jour => jour.Id == key));
        }
 
        // GET: odata/Jours(5)/Plannings
        [EnableQuery]
        public IQueryable<Planning> GetPlannings([FromODataUri] int key)
        {
            return _db.Jours.Where(m => m.Id == key).SelectMany(m => m.Plannings);
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
