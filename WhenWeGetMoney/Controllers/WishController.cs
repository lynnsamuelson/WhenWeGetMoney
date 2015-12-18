using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using WhenWeGetMoney.Models;
using System.Web.Mvc;

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
            //List<Wish> listOfWishes = Repo.GetAllWishes();
            //var json = JsonConvert.SerializeObject(listOfWishes);
            //return json;

            //List<Wish> listOfWishes = Repo.GetAllWishes();
            //return listOfWishes[1].Content;
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
        public void Delete(int id)
        {
        }
    }
}
