using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBs.DB;

namespace Funcs.Repositories
{
    public class ShoppingCartItemRepository : IRepository <ShoppingCartItem>
    {
        private DataBase db;
        public ShoppingCartItemRepository(DataBase context)
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

        public void Create(ShoppingCartItem sci)
        {
            db.ShoppingCartItem.Add(sci);
        }

        public void Update(ShoppingCartItem sci)
        {
            db.Entry(sci).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ShoppingCartItem sci = db.ShoppingCartItem.Find(id);
            if (sci != null)
                db.ShoppingCartItem.Remove(sci);
        }
    }
}
