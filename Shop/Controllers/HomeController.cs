using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBs.Production;
using Funcs;
using System.Data.Entity;
using System.Data;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        UOW uow;
        /*BasicRepository<Product> prodRepo = new BasicRepository<Product>(new Prod());
        BasicRepository<ProductProductPhoto> prodprodphotoRepo = new BasicRepository<ProductProductPhoto>(new Prod());*/
        public HomeController()
        {
            uow = new UOW();
        }
        public ActionResult Index()
        {
            var catalog1 = uow.Product.GetAll();
            ViewBag.Productions = catalog1;
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
    }
}