using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBs.DB;
using System.Data.Entity;

namespace Funcs
{
    public class ProductPhotoRepository : IRepository<ProductPhoto>
    {
        private DataBase db;

        public ProductPhotoRepository(DataBase context)
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
