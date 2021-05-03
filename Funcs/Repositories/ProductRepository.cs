using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBs.Production;
using System.Data.Entity;

namespace Funcs
{
    public class ProductRepository : IRepository<Product>
    {
        private Prod db;

        public ProductRepository(Prod context)
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
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Product product = db.Product.Find(id);
            if (product != null)
                db.Product.Remove(product);
        }
    }
}
