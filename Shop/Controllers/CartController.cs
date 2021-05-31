using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBs.DB;
using Funcs;
using Shop.Models;
using WCFContracts.DataContracts;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        public CartController(){ }
        public ViewResult Index ()
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart()
            });
        }

        public RedirectToRouteResult AddToCart(int ProductID)
        {
            ProductServiceRef.MainContractOf_ProductDataClient client = new ProductServiceRef.MainContractOf_ProductDataClient();
            ProductData product = client.Get(ProductID);
            if (product != null)
            {
                try
                {
                    GetCart().Adding(product, 1);
                }
                catch
                {
                    return RedirectToAction("Index");
                }
                
            }
            client.Close();
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult RemoveFromCart(ProductData product)
        {
            ProductServiceRef.MainContractOf_ProductDataClient client = new ProductServiceRef.MainContractOf_ProductDataClient();
            ProductData Productincart = client.Get(product.ProductID);

            if (Productincart != null)
            {
                GetCart().Deleting(product);
            }
            client.Close();
            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}