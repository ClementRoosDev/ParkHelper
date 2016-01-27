using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ParkHelper.Apiv2.Model;
using ParkHelper.Data;

namespace ParkHelper.Apiv2.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {

        [AllowAnonymous]
        public Parcours Get([FromUri] int[] values)
        {
            var tspSearch = new TSPSearch();
            var valuesCorrrected = new int[values.Length];
            int size = 0;
            foreach (var idLieu in values)
            {
                if(idLieu == 63)
                {
                    valuesCorrrected[size] = 58;
                    size++;
                }
                else
                {
                    valuesCorrrected[size] = idLieu;
                    size++;
                }
            }
            tspSearch.Search(valuesCorrrected);

            size = 0;
            foreach (var idLieu in tspSearch.bestSol)
            {
                if (idLieu == 58)
                {
                    valuesCorrrected[size] = 63;
                    size++;
                }
                else
                {
                    valuesCorrrected[size] = idLieu;
                    size++;
                }
            }

            var CP = new CalculParcours(valuesCorrrected);
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
