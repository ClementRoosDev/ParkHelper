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
        public Location[] Get([FromUri] Location[] locations)
        {
            var _randomLocations = CityProvider.GetRandomDestinations(locations);

            lock (_algorithmLock)
                _algorithm = new TravellingSalesmanAlgorithm(_startLocation, _randomLocations, _populationCount);

            var _bestSolutionSoFar = _algorithm.GetBestSolutionSoFar().ToArray();
            return _bestSolutionSoFar;
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
