using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBs.DB;
using Funcs;
using Shop.Models;
using WCFContracts.DataContracts;
using Shop.OrderServiceRef;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        public CartController() { }
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
        public RedirectToRouteResult RemoveFromCart(int ProductID)
        {
            ProductServiceRef.MainContractOf_ProductDataClient client = new ProductServiceRef.MainContractOf_ProductDataClient();
            ProductData Productincart = client.Get(ProductID);

            if (Productincart != null)
            {
                GetCart().Deleting(Productincart);
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
        [HttpPost]
        public ViewResult Checkout(Cart cart, OrderData orderdata)
        {
            cart = GetCart();
           
            if (cart.Lines.Count == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                OrderServiceRef.OrderContractOf_OrderDataClient client = new OrderContractOf_OrderDataClient();
                orderdata.OrderProducts = cart.Lines;
                orderdata.SubTotal = cart.ComputeTotalValue();
                client.Create(orderdata);
                cart.Clear();
                client.Close();
                return View("Completed");
            }
            else
            {
                return View(orderdata);
            }
        }
        public ViewResult Checkout()
        {
            var cart = GetCart();
            ViewBag.value = cart.ComputeTotalValue();
            OrderServiceRef.OrderContractOf_OrderDataClient client = new OrderContractOf_OrderDataClient();
            var terra = client.GetTerritory();
            SelectList territories = new SelectList(terra, "TerritoryID", "Name");
            ViewBag.terra = territories;
            ViewBag.cl = cart.Lines;
            client.Close();
            return View(new OrderData());
        }
    }
}