using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBs.Production;
using System.Data.Entity;

namespace Funcs
{
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
}
