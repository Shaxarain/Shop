using DBs.DB;
using Funcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFContracts;
using WCFContracts.DataContracts;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "OrderService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы OrderService.svc или OrderService.svc.cs в обозревателе решений и начните отладку.
    public class OrderService : IOrderContract<OrderData>
    {
        UOWCatalog uow = new UOWCatalog();
        public List<OrderData> GetAll()
        {
            return Translator.HeadersToOrders(uow.OrderHeader.GetAll());
        }
        public OrderData Get(int id)
        {
            return new OrderData(uow.OrderHeader.Get(id));
        }
        public ProductsViewModel GetPage(int page = 1)
        {
            int PageSize = 10;
            ProductsViewModel model = new ProductsViewModel();
            return model;
        }
        public void Create(OrderData item)
        {
            uow.OrderHeader.Create(Translator.OrderToHeader(item));
            foreach (var pq in item.OrderProducts)
            {
                PurchaseOrderDetail pod = new PurchaseOrderDetail();
                pod.PurchaseOrderID = uow.OrderHeader.GetAll().OrderByDescending(x => x.PurchaseOrderID).First().PurchaseOrderID;
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
        }
        public void Update(OrderData item)
        {
            uow.OrderHeader.Update(Translator.OrderToHeader(item));
        }
        public void Delete(int id)
        {
            uow.OrderHeader.Delete(id);
        }
        public List<TerritoryData> GetTerritory()
        {
            return Translator.TerritoriesToContracts(uow.SalesTerritory.GetAll().ToList());
        }
    }
}
