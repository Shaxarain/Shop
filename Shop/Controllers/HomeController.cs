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
        UOWCatalog uow;
        /*BasicRepository<Product> prodRepo = new BasicRepository<Product>(new Prod());
        BasicRepository<ProductProductPhoto> prodprodphotoRepo = new BasicRepository<ProductProductPhoto>(new Prod());*/
        public HomeController()
        {
            uow = new UOWCatalog();
        }
        public ActionResult Index()
        {
            var catalog = uow.Product.GetAll().Where(p => p.ProductInventory.Sum(q => q.Quantity) > 0 && p.StandardCost != 0);
            ViewBag.Catalog = catalog;
            /*IEnumerable<Product> prods = prodRepo.GetWithInclude(pp => pp.ProductProductPhoto.ProductPhoto));
            ViewBag.Productions = prods;*/
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