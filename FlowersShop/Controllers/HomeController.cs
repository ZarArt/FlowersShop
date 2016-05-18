using FlowersShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowersShop.Controllers
{
    public class HomeController : Controller
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
    }
}
