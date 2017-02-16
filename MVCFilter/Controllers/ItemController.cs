using MVCFilter.Context;
using MVCFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilter.Controllers
{
    public class ItemController : Controller
    {
        private ItemContext db = new ItemContext();
        //
        // GET: /Item/
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        //
        // GET: /Item/Details/5
        public ActionResult Details(int id)
        {
            Item item = db.Items.Find(id);
            if(item == null)
               return HttpNotFound();
            return View(item);
        }

        //
        // GET: /Item/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Item/Create
        [HttpPost]
        public ActionResult Create(Item item)
        {
            try
            {
                // TODO: Add insert logic here
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        //
        // GET: /Item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Item/Edit/5
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

        //
        // GET: /Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Item/Delete/5
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
