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
        [System.Web.Http.Route("api/Wish/")]
        [System.Web.Http.HttpPost]
        public void Post([FromBody]Wish newWish)
        {
            string user = User.Identity.GetUserId();
            ApplicationUser new_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user);
            Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user).SingleOrDefault();

           // Wish new_wish = new Wish { Author = me, Content = newWish.Content, Picture = newWish.Picture, WishUrl = newWish.WishUrl, Date = DateTime.Now, BoughtIt = false };
            if(ModelState.IsValid)
            {

            }
           
            if (me != null)
            {
                 Repo.CreateWish(me, newWish.Content, newWish.Picture, newWish.WishUrl);
            }
                //return new HttpResponseMessage(HttpStatusCode.OK);

        }

        // PUT: api/Wish/5
        public void Put(int id, [FromBody]string value)
        {
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
