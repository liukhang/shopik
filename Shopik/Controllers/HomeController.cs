using Shopik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopik.Controllers
{
    public class HomeController : Controller
    {
        ShopikEntities db = new ShopikEntities();
        public ActionResult Index()
        {
            return View(db.Products.OrderByDescending(n => n.id).Take(6).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}