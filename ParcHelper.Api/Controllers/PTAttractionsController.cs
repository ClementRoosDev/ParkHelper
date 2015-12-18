using ProjectTrackingServices.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ParkHelper.Data;

namespace ProjectTrackingServices.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class PTAttractionsController : ApiController
    {
        // GET api/ptattractions
        [Route("api/ptattractions")]
        public HttpResponseMessage Get()
        {
            var employees= AttractionsRepository.GetAllAttractions();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }
        // GET api/ptattractions/5
        [Route("api/ptattractions/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var employees = AttractionsRepository.GetAttraction(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        [Route("api/ptattractions/{name:alpha}")]
        public HttpResponseMessage Get(string name)
        {
            var employees = AttractionsRepository.SearchAttractionsByName(name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        [Route("api/ptattractions")]
        public HttpResponseMessage Post(Attraction e)
        {
            var employees = AttractionsRepository.InsertAttraction(e);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        [Route("api/ptatttractions")]
        public HttpResponseMessage Put(Attraction e)
        {
            var employees = AttractionsRepository.UpdateAttraction(e);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        [Route("api/ptattractions")]
        public HttpResponseMessage Delete(Attraction e)
        {
            var employees = AttractionsRepository.DeleteAttraction(e);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }
    }
}
