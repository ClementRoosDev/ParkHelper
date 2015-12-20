using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ParkHelper.Api.Models;
using System.Web.Routing;
using Microsoft.Ajax.Utilities;

namespace ParkHelper.Api.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class PTParcoursController : ApiController
    {
        #region Parcours GET
        //api/ptparcours/1,2,3
        [Route("api/ptparcours/{listeAttractions}")]
        public HttpResponseMessage Get([FromUri]IEnumerable<string> listeAttractions)
        {
            var liste = new List<int>();
            var split = listeAttractions.ElementAt(0).Split(',');
            foreach (var element in split)
            {
                int nombre = 0;
                var conversion = element.TryParseIntInvariant(NumberStyles.Any, out nombre);
                liste.Add(nombre);
            }
            var parcours = ParcoursRepository.GetBestParcours(liste);
            var response = Request.CreateResponse(HttpStatusCode.OK, parcours);
            return response;
        }
        #endregion
    }
}
