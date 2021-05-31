using DBs.DB;
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
    }
}
