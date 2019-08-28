using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Models;

namespace SnoopsAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values


        [EnableCors(origins: "http://localhost:57887", headers: "*", methods: "*")]
        public IEnumerable<string> Get()
        {
            return new List<string> { "Value1", "value2" };
        }

        // GET api/values/5
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
