using Funcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        UOWCatalog uow;
        public ProductController()
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
    }
}