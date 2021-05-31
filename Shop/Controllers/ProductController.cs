using Funcs;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {}
        public ActionResult Index(int page = 1)
        {
            ProductServiceRef.MainContractOf_ProductDataClient client = new ProductServiceRef.MainContractOf_ProductDataClient();
            return View(client.GetPage(page));
        }
    }
}