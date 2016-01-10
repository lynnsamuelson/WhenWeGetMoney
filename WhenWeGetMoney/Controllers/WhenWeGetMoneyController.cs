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

        [Authorize]
        public ActionResult Index()
        {

            string user_id = User.Identity.GetUserId();
        
            if (user_id == null)
            {
                return RedirectToAction("family");
            } else
            {
                Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user_id).SingleOrDefault();

                if (me == null)
                {
                    return RedirectToAction("family");
                }

                ViewBag.Amount = me.DollarAmount;

                List<Wish> boughtWishes = Repo.GetFamilyBoughtWishes(me);
                ViewBag.Bought = boughtWishes;

                List<Wish> my_wishes = Repo.GetFamilyWishes(me);
                return View(my_wishes);

            }




        }

        [Authorize]
        public ActionResult WishFeed()
        {
           string user_id = User.Identity.GetUserId();
            
           Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user_id).SingleOrDefault();

           List<Wish> list_of_wishes = Repo.GetFamilyWishes(me);
           return View(list_of_wishes);
        }

        [Authorize]
        public ActionResult moneyPot()
        {
            string user_id = User.Identity.GetUserId();

            Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user_id).SingleOrDefault();

            ViewBag.Amount = me.DollarAmount;
            ViewBag.Name = me.FamilyName;
            return View();
        }

        [Authorize]
        public ActionResult family()
        {
            string user_id = User.Identity.GetUserId();
            Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user_id).SingleOrDefault();

            
            if (me != null)
            {
                ViewBag.Name = me.FamilyName;
                ViewBag.Type = me.TypeOfFamily;
                ViewBag.Amount = me.DollarAmount;

            }
            return View();
        }

        public ActionResult boughtIt()
        {
            string user_id = User.Identity.GetUserId();
            Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user_id).SingleOrDefault();

            ViewBag.Amount = me.DollarAmount;

            List<Wish> boughtWishes = Repo.GetFamilyBoughtWishes(me);
            ViewBag.Bought = boughtWishes;

            return View(boughtWishes);
        }

        public ActionResult _Bought()
        {
            string user_id = User.Identity.GetUserId();
            Family me = Repo.GetAllFamilies().Where(u => u.RealUser.Id == user_id).SingleOrDefault();
            List<Wish> boughtWishes = Repo.GetFamilyBoughtWishes(me);
            ViewBag.Bought = boughtWishes;

            return View(boughtWishes);
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
