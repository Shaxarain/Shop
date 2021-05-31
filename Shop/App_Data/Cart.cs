using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBs.DB;
using Funcs;
using System.Data.Entity;
using System.Data;
using WCFContracts.DataContracts;

namespace Shop
{
    public class Cart
    {
        private List<CartLine> Carting = new List<CartLine>();
        public void Adding(ProductData product, int quantity)
        {
            CartLine cartline = Carting
                .Where(pi => pi.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (cartline == null)
            {
                Carting.Add(new CartLine() { Product = product, Quantity = quantity }) ;
            }
            else
            {
                cartline.Quantity += 1;
            }
        }
        public void Deleting(ProductData product)
        {
            Carting.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }
        public decimal ComputeTotalValue()
        {
            return Carting.Sum(e => e.Product.StandardCost * e.Quantity);
        }
        public IEnumerable<CartLine> Lines
        {
            get { return Carting; }
        }
    }
    public class CartLine
    {
        public ProductData Product { get; set; }
        public int Quantity { get; set; }
    }
}
