using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBs.DB;
using System.Data.Entity;

namespace Funcs
{
    public class ProductRepository : IRepository<Product>
    {
        private DataBase db;

        public ProductRepository(DataBase context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Product;
        }

        public Product Get(int id)
        {
            return db.Product.Find(id);
        }

        public void Create(Product product)
        {
            db.Product.Add(product);
            db.SaveChanges();
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = db.Product.Find(id);
            if (product != null)
                db.Product.Remove(product);
            db.SaveChanges();
        }
    }
}
