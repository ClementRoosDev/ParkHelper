using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using ParkHelper.Data;

namespace ParkHelper.Apiv2.Controllers
{
    public class LieuxController : ODataController
    {
        // GET: odata/Lieux
        [EnableQuery]
        public IQueryable<Lieu> GetLieux()
        {
            using (var db = new  ParcHelperEntities())
            {
                return db.Lieux;
            }
                
        }

        // GET: odata/Lieux(5)
        [EnableQuery]
        public SingleResult<Lieu> GetLieu([FromODataUri] int key)
        {
            using (var db = new ParcHelperEntities())
            {
                return SingleResult.Create(db.Lieux.Where(lieu => lieu.Id == key));
            }
        }

        // GET: odata/Lieux(5)/TypeDeLieu
        [EnableQuery]
        public SingleResult<TypeDeLieu> GetTypeDeLieu([FromODataUri] int key)
        {
            using (var db = new ParcHelperEntities())
            {
                return SingleResult.Create(db.Lieux.Where(m => m.Id == key).Select(m => m.TypeDeLieu));
            }
        }

        // GET: odata/Lieux(5)/Indications
        [EnableQuery]
        public IQueryable<Indication> GetIndications([FromODataUri] int key)
        {
            using (var db = new ParcHelperEntities())
            {
                return db.Lieux.Where(m => m.Id == key).SelectMany(m => m.Indications);
            }
        }        
    }
}
