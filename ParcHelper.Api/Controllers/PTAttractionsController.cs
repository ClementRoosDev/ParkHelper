using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ParkHelper.Api.Repository;
using ParkHelper.Data;

namespace ParkHelper.Api.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class PTAttractionsController : ApiController
    {
        private readonly AttractionRepository _repository;

        public PTAttractionsController()
        {
            _repository = new AttractionRepository();
        }

        #region Attractions GET
        // GET api/ptattractions
        [Route("api/ptattractions")]
        public HttpResponseMessage Get()
        {
            var attractions = _repository.List;
            var response = Request.CreateResponse(HttpStatusCode.OK, attractions);
            return response;
        }

        // GET api/ptattractions/5
        [Route("api/ptattractions/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var attraction = _repository.FindById(id);
            var response = Request.CreateResponse(HttpStatusCode.OK, attraction);
            return response;
        }

        [Route("api/ptattractions/{name:alpha}")]
        public HttpResponseMessage Get(string name)
        {
            var attraction = _repository.FindByName(name);
            var response = Request.CreateResponse(HttpStatusCode.OK, attraction);
            return response;
        }
        #endregion

        #region Attractions POST
        [Route("api/ptattractions")]
        public HttpResponseMessage Post(Attraction e)
        {
//            var attractions = _repository.InsertAttraction(e);
            _repository.Add(e);
            _repository.Save();
            var response = Request.CreateResponse(HttpStatusCode.OK, _repository.List);
            return response;
        }
        #endregion

        #region Attractions PUT
        [Route("api/ptatttractions")]
        public HttpResponseMessage Put(Attraction e)
        {
//            var attractions = _repository.UpdateAttraction(e);
            _repository.Update(e);
            _repository.Save();
            var response = Request.CreateResponse(HttpStatusCode.OK, _repository.List);
            return response;
        }
        #endregion

        #region Attractions POST
        [Route("api/ptattractions")]
        public HttpResponseMessage Delete(Attraction e)
        {
//            var attractions = _repository.DeleteAttraction(e);
            _repository.Delete(e);
            _repository.Save();
            var response = Request.CreateResponse(HttpStatusCode.OK, _repository.List);
            return response;
        }
        #endregion
    }
}
