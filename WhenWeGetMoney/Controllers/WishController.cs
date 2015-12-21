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
            return  Repo.GetAllWishes();

            //string json = JsonConvert.SerializeObject(new
            //{
            //    listOfWishes = Repo.GetAllWishes()
            //}
            //);
            //return json;

            //string json = JsonConvert.SerializeObject(new
            //{
            //    results = new List<Wish>()
            //    {
            //     new Wish { Content = "Testing"  },
            //     new Wish { Content = "Help!" }
            //    }
            //});
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
