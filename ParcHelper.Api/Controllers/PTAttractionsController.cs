using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using ParkHelper.Api.Models;
using ParkHelper.Data;

namespace ParkHelper.Api.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class PTAttractionsController : ApiController
    {
        private readonly IParkHelperRepository _repository;

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
            HttpResponseMessage response = new HttpResponseMessage
            {
                Content = new ObjectContent<List<Attraction>>
                    (attractions, new JsonMediaTypeFormatter(), "application/json")
            };
            return response;
        }

        // GET api/ptattractions/5
        [Route("api/ptattractions/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var attraction = _repository.GetAttraction(id);
            HttpResponseMessage response = new HttpResponseMessage
            {
                Content = new ObjectContent<Attraction>
                    (attraction, new JsonMediaTypeFormatter(), "application/json")
            };
            return response;
        }

        [Route("api/ptattractions/{name:alpha}")]
        public HttpResponseMessage Get(string name)
        {
            var attraction = _repository.SearchAttractionsByName(name);
            HttpResponseMessage response = new HttpResponseMessage
            {
                Content = new ObjectContent<List<Attraction>>
                    (attraction, new JsonMediaTypeFormatter(), "application/json")
            };
            return response;
        }
        #endregion

        #region Attractions POST
        [Route("api/ptattractions")]
        public HttpResponseMessage Post(Attraction e)
        {
            var attractions = _repository.InsertAttraction(e);
            HttpResponseMessage response = new HttpResponseMessage
            {
                Content = new ObjectContent<List<Attraction>>
                    (attractions, new JsonMediaTypeFormatter(), "application/json")
            };
            return response;
        }
        #endregion

        #region Attractions PUT
        [Route("api/ptatttractions")]
        public HttpResponseMessage Put(Attraction e)
        {
            var attractions = _repository.UpdateAttraction(e);
            HttpResponseMessage response = new HttpResponseMessage
            {
                Content = new ObjectContent<List<Attraction>>
                     (attractions, new JsonMediaTypeFormatter(), "application/json")
            };
            return response;
        }
        #endregion

        #region Attractions POST
        [Route("api/ptattractions")]
        public HttpResponseMessage Delete(Attraction e)
        {
            var attractions = _repository.DeleteAttraction(e);
            HttpResponseMessage response = new HttpResponseMessage
            {
                Content = new ObjectContent<List<Attraction>>
                    (attractions, new JsonMediaTypeFormatter(), "application/json")
            };
            return response;
        }
        #endregion
    }
}
