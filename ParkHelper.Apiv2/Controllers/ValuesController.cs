using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ParkHelper.Apiv2.Model;
using ParkHelper.Data;
using ParkHelper.Apiv2.Models;

namespace ParkHelper.Apiv2.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private readonly object _algorithmLock = new object();
        private TravellingSalesmanAlgorithm _algorithm;
        private readonly Location _startLocation = new Location(50, 50);
        private const int _populationCount = 114;

        //[AllowAnonymous]
        /**public Parcours Get([FromUri] int[] values)
        {            
            var CP = new CalculParcours(values);
            CP.CalculeParcoursOptimal();
            return CP.Parcours;
        }*/

        [AllowAnonymous]
        public IEnumerable<Location> Get([FromUri] double[] lieux)
        {
            var locations = CityProvider.ConvertFromList(lieux);

            lock (_algorithmLock)
                _algorithm = new TravellingSalesmanAlgorithm(_startLocation, locations, _populationCount);

            return _algorithm.GetBestSolutionSoFar();
        }

        // GET api/values/5
        [AllowAnonymous]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
