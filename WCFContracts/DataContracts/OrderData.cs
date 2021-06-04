using DBs.DB;
using Funcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFContracts.DataContracts
{
    [DataContract]
    public class OrderData
    {
        [DataMember]
        public byte Status { get; set; }
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
        [DataMember]
        public int? CustomerID { get; set; }
        [DataMember]
        public List<CartLine> OrderProducts { get; set; }
        [DataMember]
        public int? TerritoryID { get; set; }
        public OrderData(PurchaseOrderHeader poh) 
        {
            UOWCatalog uow = new UOWCatalog();
            this.Status = poh.Status;
            this.EmployeeID = poh.EmployeeID;
            this.SubTotal = poh.SubTotal;
            this.ModifiedDate = poh.ModifiedDate;
            this.CustomerID = poh.CustomerID;
            this.OrderProducts = new List<CartLine>();
            foreach (var pod in poh.PurchaseOrderDetail)
            {
                ProductData pd = new ProductData(uow.Product.Get(pod.ProductID));
                CartLine cl = new CartLine();
                cl.Product = pd;
                cl.Quantity = pod.OrderQty;
                this.OrderProducts.Add(cl);
            }
            if(poh.Customer == null)
            {
                this.TerritoryID = null;
            }
            else
            {
                this.TerritoryID = poh.Customer.TerritoryID;
            }
        }
        public OrderData() { }
    }
}
