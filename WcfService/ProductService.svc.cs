using DBs.DB;
using Funcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFContracts;
using WCFContracts.DataContracts;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class ProductService : IMainContract<ProductData>
    {
        UOWCatalog uow = new UOWCatalog();
        public List<ProductData> GetAll() 
        {
            return Translator.ProductsToContracts(uow.Product.GetAll());
        }
        public ProductData Get(int id)
        {
            return new ProductData(uow.Product.Get(id));
        }
        public ProductsViewModel GetPage(int page = 1)
        {
            int PageSize = 10;
            ProductsViewModel model = new ProductsViewModel
            {
                Products = Translator.ProductsToContracts(uow.Product.GetAll()
                .Where(p => p.ProductInventory.Sum(q => q.Quantity) > 0 && p.StandardCost != 0)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = uow.Product.GetAll().Where(p => p.ProductInventory.Sum(q => q.Quantity) > 0 && p.StandardCost != 0).Count()
                }
            };
            return model;
        }
        public void Create(ProductData item)
        {
            uow.Product.Create(Translator.ContractsToProduct(item));
        }
        public void Update(ProductData item)
        {
            uow.Product.Update(Translator.ContractsToProduct(item));
        }
        public void Delete(int id)
        {
            uow.Product.Delete(id);
        }
    }
}
