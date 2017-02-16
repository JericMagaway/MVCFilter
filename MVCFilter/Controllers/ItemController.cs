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
        public ActionResult Index(string searchString)
        {
            var item = from a in db.Items
                       select a;


            if (!String.IsNullOrEmpty(searchString))
            {

                item = item.Where(s => s.Name.Contains(searchString));
            }

            return View(item);
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
            Item item= db.Items.Find(id);
            return View(item);
        }

        //
        // POST: /Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Item item)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(item);

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
            Item item = db.Items.Find(id);
            return View(item);
        }

        //
        // POST: /Item/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  item = db.Items.Find(id);
                    if (item == null)
                        return HttpNotFound();

                    db.Items.Remove(item);
                    db.SaveChanges();

                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
                }
                return View(item);

            }
            catch
            {
                return View();
            }
        }
    }
}
