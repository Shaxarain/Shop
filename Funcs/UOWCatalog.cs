using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBs.DB;
using Funcs.Identity;
using Funcs.Interfaces;
using Funcs.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.Funcs.EF;
using Shop.Funcs.Entities;

namespace Funcs
{
    public class UOWCatalog : IDisposable
    {
        private DataBase db = new DataBase();
        private ApplicationContext bd = new ApplicationContext("Identity");

        private ProductRepository productRepository;
        private PrPrPhotoRepository prprphotoRepository;
        private ProductPhotoRepository productphotoRepository;
        private ProductInventoryRepository productinventoryRepository;
        private ShoppingCartItemRepository shoppingcartitemRepository;
        private OrderHeaderRepository orderheaderRepository;
        private SalesPersonRepository salespersonRepository;
        private OrderDetailRepository orderdetailRepository;
        private TerritoryRepository salesterritoryRepository;

        private ApplicationUserManager usermanagerRepository;
        private ApplicationRoleManager rolemanagerRepository;
        private IClientManager clientmanagerRepository;

        public ProductRepository Product
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }
        public PrPrPhotoRepository PrPrPhoto
        {
            get
            {
                if (prprphotoRepository == null)
                    prprphotoRepository = new PrPrPhotoRepository(db);
                return prprphotoRepository;
            }
        }
        public ProductPhotoRepository ProductPhoto
        {
            get
            {
                if (productphotoRepository == null)
                    productphotoRepository = new ProductPhotoRepository(db);
                return productphotoRepository;
            }
        }
        public ProductInventoryRepository ProductInventory
        {
            get
            {
                if (productinventoryRepository == null)
                    productinventoryRepository = new ProductInventoryRepository(db);
                return productinventoryRepository;
            }
        }
        public ShoppingCartItemRepository ShoppingCartItem
        {
            get
            {
                if (shoppingcartitemRepository == null)
                    shoppingcartitemRepository = new ShoppingCartItemRepository(db);
                return shoppingcartitemRepository;
            }
        }
        public OrderHeaderRepository OrderHeader
        {
            get
            {
                if (orderheaderRepository == null)
                    orderheaderRepository = new OrderHeaderRepository(db);
                return orderheaderRepository;
            }
        }
        public OrderDetailRepository OrderDetail
        {
            get
            {
                if (orderdetailRepository == null)
                    orderdetailRepository = new OrderDetailRepository(db);
                return orderdetailRepository;
            }
        }
        public SalesPersonRepository SalesPerson
        {
            get
            {
                if (salespersonRepository == null)
                    salespersonRepository = new SalesPersonRepository(db);
                return salespersonRepository;
            }
        }
        public TerritoryRepository SalesTerritory
        {
            get
            {
                if (salesterritoryRepository == null)
                    salesterritoryRepository = new TerritoryRepository(db);
                return salesterritoryRepository;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                if (usermanagerRepository == null)
                    usermanagerRepository = new ApplicationUserManager(new UserStore<ApplicationUser>(bd));
                return usermanagerRepository;
            }
        }

        public IClientManager ClientManager
        {
            get
            {
                if (clientmanagerRepository == null)
                    clientmanagerRepository = new ClientManagerRepository();
                return clientmanagerRepository;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                if (rolemanagerRepository == null)
                    rolemanagerRepository = new ApplicationRoleManager(new RoleStore<ApplicationRole>(bd));
                return rolemanagerRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
        public UOWCatalog()
        {
        }
    }
}