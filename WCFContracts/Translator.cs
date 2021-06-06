using DBs.DB;
using Funcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            return poh;
        }
        public static List<TerritoryData> TerritoriesToContracts(List<SalesTerritory> lst) 
        {
            List<TerritoryData> ltd = new List<TerritoryData>();
            foreach (var i in lst)
            {
                ltd.Add(new TerritoryData(i));
            }
            return ltd;
        }
        public static List<OrderData> HeadersToOrders(IEnumerable<PurchaseOrderHeader> poh)
        {
            List<OrderData> od = new List<OrderData>();
            foreach(var i in poh)
            {
                od.Add(new OrderData(i));
            }
            return od;
        }

       /* public static ClaimsIdentityData ClaimsIdentityToContract(ClaimsIdentity claims)
        {
            var data = new ClaimsIdentityData();
            data = claims as ClaimsIdentityData;
            return data;
        }*/
    }
}
