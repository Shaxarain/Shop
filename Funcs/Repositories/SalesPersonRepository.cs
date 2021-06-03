using DBs.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcs.Repositories
{
    public class SalesPersonRepository : IRepository<SalesPerson>
    {
        private DataBase db;

        public SalesPersonRepository(DataBase context)
        {
            this.db = context;
        }

        public IEnumerable<SalesPerson> GetAll()
        {
            return db.SalesPerson;
        }

        public SalesPerson Get(int id)
        {
            return db.SalesPerson.Find(id);
        }

        public void Create(SalesPerson sp)
        {
            db.SalesPerson.Add(sp);
        }

        public void Update(SalesPerson sp)
        {
            db.Entry(sp).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            SalesPerson sp = db.SalesPerson.Find(id);
            if (sp != null)
                db.SalesPerson.Remove(sp);
        }
    }
}
