using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBs.Sales;

namespace Funcs.Repositories
{
    class ShoppingCartItemRepository : IRepository <ShoppingCartItem>
    {
        private Sal db;
        public ShoppingCartItemRepository(Sal context)
        {
            this.db = context;
        }

        public IEnumerable<ShoppingCartItem> GetAll()
        {
            return db.ShoppingCartItem;
        }

        public ShoppingCartItem Get(int id)
        {
            return db.ShoppingCartItem.Find(id);
        }

        public void Create(ShoppingCartItem product)
        {
            db.ShoppingCartItem.Add(product);
        }

        public void Update(ShoppingCartItem product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ShoppingCartItem product = db.ShoppingCartItem.Find(id);
            if (product != null)
                db.ShoppingCartItem.Remove(product);
        }
    }
}
