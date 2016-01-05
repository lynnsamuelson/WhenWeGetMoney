using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WhenWeGetMoney.Controllers
{
    public class MoneyPotController : ApiController
    {
        // GET: api/MoneyPot
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MoneyPot/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MoneyPot
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MoneyPot/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MoneyPot/5
        public void Delete(int id)
        {
        }
    }
}
