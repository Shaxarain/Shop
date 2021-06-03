using DBs.DB;
using Funcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFContracts.DataContracts;

namespace WCFContracts
{
    public class Translator
    {
        static UOWCatalog uow = new UOWCatalog();
        public static List<ProductData> ProductsToContracts(IEnumerable<Product> ptc)
        {
            List<ProductData> lpd = new List<ProductData>();
            foreach(Product p in ptc)
            {
                ProductData pd = new ProductData(p);
                lpd.Add(pd);
            }
            return lpd;
        }
        public static Product ContractsToProduct(ProductData pd)
        {
            Product product = new Product();
            product.ProductID = pd.ProductID;
            product.Name = pd.Name;
            product.Color = pd.Color;
            product.StandardCost = pd.StandardCost;
            product.Size = pd.Size;
            product.Weight = pd.Weight;
            product.Class = pd.Class;
            product.Style = pd.Style;
            product.ProductSubcategoryID = pd.ProductSubcategoryID;
            product.rowguid = pd.rowguid;
            return product;
        }
        public static PurchaseOrderHeader OrderToHeader(OrderData od)
        {
            PurchaseOrderHeader poh = new PurchaseOrderHeader();
            poh.RevisionNumber = 4;
            poh.Status = od.Status;
            if(uow.SalesPerson.GetAll().Where(x => x.TerritoryID == od.TerritoryID) == null)
            {
                poh.EmployeeID = uow.SalesPerson.GetAll().OrderBy(y => y.SalesLastYear).First().BusinessEntityID;
            }
            else
            {
                poh.EmployeeID = uow.SalesPerson.GetAll().Where(x => x.TerritoryID == od.TerritoryID).OrderBy(y => y.SalesLastYear).First().BusinessEntityID;
            }
            poh.VendorID = 1580;
            poh.ShipMethodID = 3;
            poh.OrderDate = DateTime.Now;
            poh.SubTotal = od.SubTotal;
            poh.TaxAmt = od.SubTotal * (8/100);
            poh.Freight = 100;
            poh.TotalDue = poh.SubTotal + poh.TaxAmt + poh.Freight;
            poh.ModifiedDate = DateTime.Now;
            poh.CustomerID = od.CustomerID;
            foreach(var pq in od.OrderProducts)
            {
                PurchaseOrderDetail pod = new PurchaseOrderDetail();
                pod.PurchaseOrderID = poh.PurchaseOrderID;
                pod.DueDate = DateTime.Now;
                pod.OrderQty = (short)pq.Quantity;
                pod.ProductID = pq.Product.ProductID;
                pod.UnitPrice = pq.Product.StandardCost;
                pod.LineTotal = pq.Quantity * pod.UnitPrice;
                pod.ReceivedQty = 999;
                pod.RejectedQty = 0;
                pod.StockedQty = pod.ReceivedQty - pod.RejectedQty;
                pod.ModifiedDate = DateTime.Now;
                uow.OrderDetail.Create(pod);
            }
            return poh;
        }
    }
}
