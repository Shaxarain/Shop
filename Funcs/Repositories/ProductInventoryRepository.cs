using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBs.DB;
using System.Data.Entity;

namespace Funcs.Repositories
{
    public class ProductInventoryRepository : IRepository<ProductInventory>
    {
        private DataBase db;

        public ProductInventoryRepository(DataBase context)
        {
            this.db = context;
        }

        public IEnumerable<ProductInventory> GetAll()
        {
            return db.ProductInventory.Include(o => o.Product);
        }

        public ProductInventory Get(int id)
        {
            return db.ProductInventory.Find(id);
        }

        public void Create(ProductInventory pi)
        {
            db.ProductInventory.Add(pi);
            db.SaveChanges();
        }

        public void Update(ProductInventory pi)
        {
            db.Entry(pi).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            ProductInventory pi = db.ProductInventory.Find(id);
            if (pi != null)
                db.ProductInventory.Remove(pi);
            db.SaveChanges();
        }
    }
}
