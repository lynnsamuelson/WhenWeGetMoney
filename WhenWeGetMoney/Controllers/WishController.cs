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
            return Repo.GetAllWishes();
        }

        // GET: api/Wish/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Wish
        [System.Web.Http.Route("api/Wish/")]
        [System.Web.Http.HttpPost]
        public void Post([FromBody]Wish newWish)
        {
            string user = User.Identity.GetUserId();
            ApplicationUser new_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user);
            Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user).SingleOrDefault();

            if(ModelState.IsValid)
            {

            }
           
            if (me != null)
            {
                string itemCost = newWish.Cost.ToString();
                 Repo.CreateWish(me, newWish.Content, itemCost);
            }

        }

        // PUT: api/Wish/5
        //[System.Web.Http.Route("api/Wish/")]
        //[System.Web.Http.HttpPut]
        public void Put(int id)
        {
            string user = User.Identity.GetUserId();
            ApplicationUser real_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user);
            Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user).SingleOrDefault();

            Wish theWishToUpdate = Repo.Context.Wishes.SingleOrDefault(u => u.WishId == id);
            decimal dollarAmount = me.DollarAmount - theWishToUpdate.Cost;

            Repo.UpdateFamily(real_user, me, me.FamilyName, dollarAmount);

            Wish toBuy = Repo.Context.Wishes.FirstOrDefault(u => u.WishId == id);
            Repo.BoughtWish(toBuy);
        }

        // DELETE: api/Wish/5
        public void Delete()
        {
            string user = User.Identity.GetUserId(); ;
            ApplicationUser real_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user);
            Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user).SingleOrDefault();


        }

        public void Delete(int id)
        {
            Wish toDelete = Repo.Context.Wishes.FirstOrDefault(u => u.WishId == id);
            Repo.DeleteWish(toDelete);
        }
    }
}
