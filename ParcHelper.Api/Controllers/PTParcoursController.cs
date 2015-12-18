using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ParkHelper.Api.Models;

namespace ParkHelper.Api.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class PTParcoursController : ApiController
    {
        #region Parcours GET
        // GET api/ptattractions
        [Route("api/ptparcours")]
        public HttpResponseMessage Get([FromBody] List<int> listeAttractions)
        {
            var parcours = ParcoursRepository.GetBestParcours(listeAttractions);
            var response = Request.CreateResponse(HttpStatusCode.OK, parcours);
            return response;
        }
        #endregion
    }
}
