using DBs.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcs.Repositories
{
    public class OrderDetailRepository : IRepository<PurchaseOrderDetail>
    {
        private DataBase db;

        public OrderDetailRepository(DataBase context)
        {
            this.db = context;
        }

        public IEnumerable<PurchaseOrderDetail> GetAll()
        {
            return db.PurchaseOrderDetail;
        }

        public PurchaseOrderDetail Get(int id)
        {
            return db.PurchaseOrderDetail.Find(id);
        }

        public void Create (PurchaseOrderDetail sod)
        {
            db.PurchaseOrderDetail.Add(sod);
        }

        public void Update(PurchaseOrderDetail sod)
        {
            db.Entry(sod).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            PurchaseOrderDetail sod = db.PurchaseOrderDetail.Find(id);
            if (sod != null)
                db.PurchaseOrderDetail.Remove(sod);
        }
    }
}
