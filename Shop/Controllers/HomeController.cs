using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBs.Production;
using System.Data.Entity;
using System.Data;


namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        Prod prod = new Prod();
        public ActionResult Index()
        {
            var prodph = prod.Product.Include(pph => pph.ProductProductPhoto);
            var prph = prod.ProductProductPhoto.Include(ph => ph.ProductPhoto);
            /*IEnumerable<Product> prods = prod.Product;
            IEnumerable<ProductPhoto> prodphotos = prod.ProductPhoto;
            ViewBag.Productions = prods;
            ViewBag.ProductPhotos = prodphotos;*/
            return View(prph.ToList());
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