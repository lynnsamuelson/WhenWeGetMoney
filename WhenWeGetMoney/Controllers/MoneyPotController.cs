using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhenWeGetMoney.Models;

namespace WhenWeGetMoney.Controllers
{
    public class MoneyPotController : ApiController
    {
        public WhenWeGetMoneyRepository Repo { get; set; }
        public MoneyPotController() : base()
        {
            Repo = new WhenWeGetMoneyRepository();
        }

        public MoneyPotController(WhenWeGetMoneyRepository _repo)
        {
            Repo = _repo;
        }
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
        [System.Web.Http.Route("api/MoneyPot/")]
        [System.Web.Http.HttpPost]
        public void Post([FromBody]string amount)
        {
            string user = User.Identity.GetUserId();
            ApplicationUser new_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user);
            Repo.CreateMoneyPot(amount);
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
