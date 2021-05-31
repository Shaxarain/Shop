using DBs.DB;
using Funcs;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ProductDetailController : Controller
    {
        UOWCatalog uow;
        public ProductDetailController()
        {
            uow = new UOWCatalog();
        }
        public ActionResult Index(Product product)
        {
            var PrPhoto = from p in uow.Product.GetAll()
                          join ppp in uow.PrPrPhoto.GetAll() on p.ProductID equals ppp.ProductID
                          join pp in uow.ProductPhoto.GetAll() on ppp.ProductPhotoID equals pp.ProductPhotoID
                          where p.ProductID == product.ProductID
                          select pp.LargePhoto;

            ViewBag.pp = PrPhoto.First();
            return View(new ProductDetailViewModel
            { 
                Product = product
            });
        }
        public RedirectToRouteResult ProductPage(int ProductID)
        {
            Product product = uow.Product.Get(ProductID);
            return RedirectToAction("Index", product);
        }
    }
}