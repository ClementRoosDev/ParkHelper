using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ParkHelper.Api.Models;
using ParkHelper.Data;

namespace ParkHelper.Api.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class PTAttractionsController : ApiController
    {
        private IParkHelperRepository _repository;

        public PTAttractionsController(IParkHelperRepository repository)
        {
            _repository = repository;
        }

        #region Attractions GET
        // GET api/ptattractions
        [Route("api/ptattractions")]
        public HttpResponseMessage Get()
        {
            var attractions = _repository.GetAllAttractions();
            var response = Request.CreateResponse(HttpStatusCode.OK, attractions);
            return response;
        }

        // GET api/ptattractions/5
        [Route("api/ptattractions/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var attraction = _repository.GetAttraction(id);
            var response = Request.CreateResponse(HttpStatusCode.OK, attraction);
            return response;
        }

        [Route("api/ptattractions/{name:alpha}")]
        public HttpResponseMessage Get(string name)
        {
            var attraction = _repository.SearchAttractionsByName(name);
            var response = Request.CreateResponse(HttpStatusCode.OK, attraction);
            return response;
        }
        #endregion

        #region Attractions POST
        [Route("api/ptattractions")]
        public HttpResponseMessage Post(Attraction e)
        {
            var attractions = _repository.InsertAttraction(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, attractions);
            return response;
        }
        #endregion

        #region Attractions PUT
        [Route("api/ptatttractions")]
        public HttpResponseMessage Put(Attraction e)
        {
            var attractions = _repository.UpdateAttraction(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, attractions);
            return response;
        }
        #endregion

        #region Attractions POST
        [Route("api/ptattractions")]
        public HttpResponseMessage Delete(Attraction e)
        {
            var attractions = _repository.DeleteAttraction(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, attractions);
            return response;
        }
        #endregion
    }
}
