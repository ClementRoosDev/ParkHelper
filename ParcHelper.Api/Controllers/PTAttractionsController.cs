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
        #region Attractions GET
        // GET api/ptattractions
        [Route("api/ptattractions")]
        public HttpResponseMessage Get()
        {
            var attractions = AttractionsRepository.GetAllAttractions();
            var response = Request.CreateResponse(HttpStatusCode.OK, attractions);
            return response;
        }

        // GET api/ptattractions/5
        [Route("api/ptattractions/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var attraction = AttractionsRepository.GetAttraction(id);
            var response = Request.CreateResponse(HttpStatusCode.OK, attraction);
            return response;
        }

        [Route("api/ptattractions/{name:alpha}")]
        public HttpResponseMessage Get(string name)
        {
            var attraction = AttractionsRepository.SearchAttractionsByName(name);
            var response = Request.CreateResponse(HttpStatusCode.OK, attraction);
            return response;
        }
        #endregion

        #region Attractions POST
        [Route("api/ptattractions")]
        public HttpResponseMessage Post(Attraction e)
        {
            var attractions = AttractionsRepository.InsertAttraction(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, attractions);
            return response;
        }
        #endregion

        #region Attractions PUT
        [Route("api/ptatttractions")]
        public HttpResponseMessage Put(Attraction e)
        {
            var attractions = AttractionsRepository.UpdateAttraction(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, attractions);
            return response;
        }
        #endregion

        #region Attractions POST
        [Route("api/ptattractions")]
        public HttpResponseMessage Delete(Attraction e)
        {
            var attractions = AttractionsRepository.DeleteAttraction(e);
            var response = Request.CreateResponse(HttpStatusCode.OK, attractions);
            return response;
        }
        #endregion
    }
}
