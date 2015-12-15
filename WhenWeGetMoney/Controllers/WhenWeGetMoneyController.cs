﻿using System;
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

        // GET: WhenWeGetMoney
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";

            return View();

        }

        public ActionResult moneyPot()
        {
            return View();
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