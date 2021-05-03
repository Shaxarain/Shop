using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBs.Production;

namespace Funcs
{
    /*interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }*/
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

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
    public class PrPrPhotoRepository : IRepository<ProductProductPhoto>
    {
        private Prod db;

        public PrPrPhotoRepository(Prod context)
        {
            this.db = context;
        }

        public IEnumerable<ProductProductPhoto> GetAll()
        {
            return db.ProductProductPhoto.Include(o => o.Product);
        }

        public ProductProductPhoto Get(int id)
        {
            return db.ProductProductPhoto.Find(id);
        }

        public void Create(ProductProductPhoto ppp)
        {
            db.ProductProductPhoto.Add(ppp);
        }

        public void Update(ProductProductPhoto ppp)
        {
            db.Entry(ppp).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ProductProductPhoto ppp = db.ProductProductPhoto.Find(id);
            if (ppp != null)
                db.ProductProductPhoto.Remove(ppp);
        }
    }
    public class ProductPhotoRepository : IRepository<ProductPhoto>
    {
        private Prod db;

        public ProductPhotoRepository(Prod context)
        {
            this.db = context;
        }

        public IEnumerable<ProductPhoto> GetAll()
        {
            return db.ProductPhoto.Include(o => o.ProductProductPhoto);
        }

        public ProductPhoto Get(int id)
        {
            return db.ProductPhoto.Find(id);
        }

        public void Create(ProductPhoto pp)
        {
            db.ProductPhoto.Add(pp);
        }

        public void Update(ProductPhoto pp)
        {
            db.Entry(pp).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ProductPhoto pp = db.ProductPhoto.Find(id);
            if (pp != null)
                db.ProductPhoto.Remove(pp);
        }
    }

}