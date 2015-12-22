using System.Linq;
using System.Web.Http;
using System.Web.OData;
using ParkHelper.OData.Repository;

namespace ParkHelper.OData.Controllers
{
    [EnableQuery]
    public class AttractionsController : ODataController
    {
        readonly AttractionRepository _repository;

        public AttractionsController()
        {
            _repository = new AttractionRepository();
        }

        public IHttpActionResult Get()
        {
            return Ok(_repository.List.AsQueryable());
        }
    }
}