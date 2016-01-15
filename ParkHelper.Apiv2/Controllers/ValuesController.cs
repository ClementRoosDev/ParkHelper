﻿using System.Linq;
using System.Runtime.Serialization;
using System.Web.Http;
using ParkHelper.Data;
using ParkHelper.Apiv2.Models;

namespace ParkHelper.Apiv2.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        [AllowAnonymous]
        public Parcours Get([FromUri] int[] values)
        {            
            var CP = new CalculParcours(values);
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
