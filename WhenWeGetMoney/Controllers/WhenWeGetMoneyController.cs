using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhenWeGetMoney;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WhenWeGetMoney.Models;

namespace WhenWeGetMoney.Controllers
{
    public class WhenWeGetMoneyController : Controller
    {
        public WhenWeGetMoneyRepository Repo { get; set; }
        public WhenWeGetMoneyController() : base()
        {
            Repo = new WhenWeGetMoneyRepository();
        }

        public ActionResult Admin()
        {
            List<Family> all_families = Repo.GetAllFamilies();
            return View(all_families);
        }

        public ActionResult Index()
        {

           
            //string user_id = User.Identity.GetUserId();

            //Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user_id).SingleOrDefault();
           
            //List<Wish> my_wishes = Repo.GetFamilyWishes(me);
            //return View(my_wishes);

            string user_id = User.Identity.GetUserId(); //is in the e-mail account

            Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user_id).SingleOrDefault();
            List<Wish> my_wishes = Repo.GetFamilyWishes(me);
            return View(my_wishes);

            }


        public ActionResult WishFeed()
        {
           string user_id = User.Identity.GetUserId();
            
           Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user_id).SingleOrDefault();

           List<Wish> list_of_wishes = Repo.GetFamilyWishes(me);
           return View(list_of_wishes);
        }


        public ActionResult moneyPot()
        {
            string user_id = User.Identity.GetUserId();

            Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user_id).SingleOrDefault();

            List<MoneyPot> amount = Repo.GetAllMoneyPots();
            return View(amount);
        }

        public ActionResult boughtIt()
        {
            return View();
        }

        public ActionResult wishList()
        {
            return View();
        }

        // GET: WhenWeGetMoney/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WhenWeGetMoney/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WhenWeGetMoney/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WhenWeGetMoney/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WhenWeGetMoney/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WhenWeGetMoney/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WhenWeGetMoney/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
