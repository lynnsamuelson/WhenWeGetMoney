using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhenWeGetMoney.Models;

namespace WhenWeGetMoney.Controllers
{
    public class TestController : ApiController
    {
        

        public WhenWeGetMoneyRepository Repo { get; set; }
        public TestController() : base()
        {
            Repo = new WhenWeGetMoneyRepository();
        }

        // GET: api/Test
        public string Get()
        {
            return "Monkey Rock!";
        }

     
        //public IEnumerable<Wish> Get()
        //{
        //    List<Wish> listOfWishes = Repo.GetAllWishes();
        //    return Repo.GetAllWishes();
        //}

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}*/

        //public string Get()
        //{
            
        //    //return "Monkey Rock!";
        //}

        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
