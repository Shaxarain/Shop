using DBs.DB;
using Funcs;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFContracts.DataContracts;

namespace Shop.Controllers
{
    public class ProductDetailController : Controller
    {
        public ProductDetailController() { }
        public ActionResult Index(int ProductID)
        {
            ProductServiceRef.MainContractOf_ProductDataClient client = new ProductServiceRef.MainContractOf_ProductDataClient();
            ProductData product = client.Get(ProductID);
            client.Close();
            return View(new ProductDetailViewModel
            { 
                Product = product
            });
        }
    }
}