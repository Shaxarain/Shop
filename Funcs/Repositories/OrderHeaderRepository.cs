using DBs.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcs.Repositories
{
    public class OrderHeaderRepository : IRepository<PurchaseOrderHeader>
    {
        private DataBase db;

        public OrderHeaderRepository(DataBase context)
        {
            this.db = context;
        }

        public IEnumerable<PurchaseOrderHeader> GetAll()
        {
            return db.PurchaseOrderHeader;
        }

        public PurchaseOrderHeader Get(int id)
        {
            return db.PurchaseOrderHeader.Find(id);
        }

        public void Create(PurchaseOrderHeader poh)
        {
            db.PurchaseOrderHeader.Add(poh);
        }

        public void Update(PurchaseOrderHeader poh)
        {
            db.Entry(poh).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            PurchaseOrderHeader poh = db.PurchaseOrderHeader.Find(id);
            if (poh != null)
                db.PurchaseOrderHeader.Remove(poh);
        }
    }
}
