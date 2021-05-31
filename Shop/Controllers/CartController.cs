﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBs.DB;
using Funcs;
using Shop.Models;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private UOWCatalog uow;
        public CartController()
        {
            uow = new UOWCatalog();
        }
        public ViewResult Index ()
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart()
            });
        }

        public RedirectToRouteResult AddToCart(int ProductID)
        {
            Product product = uow.Product.Get(ProductID);
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
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult RemoveFromCart(Product product)
        {
            Product Productincart = uow.Product.Get(product.ProductID);

            if (Productincart != null)
            {
                GetCart().Deleting(product);
            }
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