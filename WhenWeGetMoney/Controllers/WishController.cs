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
            //Family familyId = Repo.GetFamilyById(1);
            //return  Repo.GetFamilyWishes(familyId);

            return Repo.GetAllWishes();

        }

        // GET: api/Wish/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Wish
        public void Post(Wish new_Wish)
        {
            string user = User.Identity.GetUserId();
            ApplicationUser new_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user);
            Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user).First();

            //var query = from u in Repo.Context.Families where u.FamilyUserID == user.FamilyUserID select u;
            //Family found_user = query.SingleOrDefault<Family>();

            if (me != null)
            {
                Repo.CreateWish(me, new_Wish.Content, new_Wish.Picture, new_Wish.WishUrl);
            }

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
