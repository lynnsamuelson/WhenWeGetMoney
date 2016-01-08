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
    public class FamilyController : ApiController
    {
        public WhenWeGetMoneyRepository Repo { get; set; }
        public FamilyController() : base()
        {
            Repo = new WhenWeGetMoneyRepository();
        }

        public FamilyController(WhenWeGetMoneyRepository _repo)
        {
            Repo = _repo;
        }

        // GET: api/Family
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Family/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Family
        [System.Web.Http.Route("api/Family/")]
        [System.Web.Http.HttpPost]
        public void Post([FromBody]Family familyName)
        {
            string user = User.Identity.GetUserId();
            ApplicationUser new_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user);

            Repo.CreateFamily(new_user, familyName.FamilyName, familyName.DollarAmount);
        }

        // PUT: api/Family/5
        [System.Web.Http.Route("api/Family/")]
        [System.Web.Http.HttpPut]
        public void Put([FromBody]Family newFamily)
        {
            string user = User.Identity.GetUserId();
            ApplicationUser new_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user);
            //Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user).SingleOrDefault();
            //Repo.CreateFamily(new_user, newFamily.FamilyName);

        }

        // DELETE: api/Family/5
        public void Delete(int id)
        {
        }
    }
}
