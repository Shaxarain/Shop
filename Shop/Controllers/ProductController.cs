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
        UOWCatalog uow;
        public int PageSize = 8;
        public ProductController()
        {
            uow = new UOWCatalog();
        }
        public ActionResult Index(int page = 1)
        {
            ProductsViewModel model = new ProductsViewModel
            {
                Products = uow.Product.GetAll()
                .Where(p => p.ProductInventory.Sum(q => q.Quantity) > 0 && p.StandardCost != 0)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = uow.Product.GetAll().Where(p => p.ProductInventory.Sum(q => q.Quantity) > 0 && p.StandardCost != 0).Count()
                }
            };
            return View(model);
        }
    }
}