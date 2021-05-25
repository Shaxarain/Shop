using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBs.Production;
using DBs.Sales;
using Funcs;
using System.Data.Entity;
using System.Data;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        Sal sal = new Sal();
 
        public ActionResult Index()
        {
            return View();
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
        public RedirectToRouteResult Cart()
        {
            return RedirectToRoute(new { controller = "Cart", action = "Index" });
        }
    }
}