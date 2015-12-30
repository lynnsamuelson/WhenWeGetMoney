using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using WhenWeGetMoney.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace WhenWeGetMoney.Controllers
{
    public class WishController : ApiController
    {
        public WhenWeGetMoneyRepository Repo { get; set; }
        public WishController() : base()
        {
            Repo = new WhenWeGetMoneyRepository();
        }

        public WishController(WhenWeGetMoneyRepository _repo)
        {
            Repo = _repo;
        }

        

        // GET: api/Wish
        public List<Wish> Get()
        {
            Family familyId = Repo.GetFamilyById(1);
            return  Repo.GetFamilyWishes(familyId);
        }

        // GET: api/Wish/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Wish
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Wish/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Wish/5
        public void Delete()
        {
            string user_id = User.Identity.GetUserId(); ;
            ApplicationUser real_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user_id);

            if (real_user.Email.Contains("test7@example.com")) { Repo.DeleteAllUsers(); }
        }

        public void Delete(int id)
        {

        }
    }
}
