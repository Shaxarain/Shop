using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBs.Production;

namespace Funcs
{
    public class UOW : IDisposable
    {
        private Prod db = new Prod();
        private ProductRepository productRepository;
        private PrPrPhotoRepository prprphotoRepository;
        private ProductPhotoRepository productphotoRepository;
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
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}