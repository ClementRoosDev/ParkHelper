using System.Web.Http;
using ParkHelper.Data;
using ParkHelper.Apiv2.Models;

namespace ParkHelper.Apiv2.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        /**[AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        [AllowAnonymous]
        public Parcours Get([FromUri] int[] values)
        {            
            CalculParcours CP = new CalculParcours(values);
            CP.CalculeParcoursOptimal();
            return CP.Parcours;
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
