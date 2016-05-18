using FlowersShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowersShop.Controllers
{
    public class AdminController : Controller
    {
        private FlowersShopDBEntities db = new FlowersShopDBEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            IEnumerable<Flower> flowers = db.Flowers.ToList();
            return View(flowers);
        }

        public ActionResult Details(int id)
        {
            var flowerDetails = db.Flowers.Where(f => f.FlowerId == id).FirstOrDefault();
            return View(flowerDetails);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            Flower flower = new Flower();
            return View(flower);
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(Flower flower)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Flowers.Add(flower);
                    db.SaveChanges();
                    return RedirectToAction("Index");   
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }
            return View(flower);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id)
        {
            var flowerEdit = db.Flowers.Where(f => f.FlowerId == id).FirstOrDefault();
            return View(flowerEdit);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var flowerEdit = db.Flowers.Where(f => f.FlowerId == id).FirstOrDefault();

            try
            {
                UpdateModel(flowerEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(flowerEdit);
            }
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id)
        {
            var flowerDelete = db.Flowers.Where(f => f.FlowerId == id).FirstOrDefault();
            return View(flowerDelete);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var flowerDelete = db.Flowers.Where(f => f.FlowerId == id).FirstOrDefault();
            try
            {
                db.Flowers.Remove(flowerDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(flowerDelete);
            }
        }
    }
}
