using DBs.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcs.Repositories
{
    public class TerritoryRepository : IRepository<SalesTerritory>
    {
        private DataBase db;

        public TerritoryRepository(DataBase context)
        {
            this.db = context;
        }

        public IEnumerable<SalesTerritory> GetAll()
        {
            return db.SalesTerritory;
        }

        public SalesTerritory Get(int id)
        {
            return db.SalesTerritory.Find(id);
        }

        public void Create(SalesTerritory st)
        {
            db.SalesTerritory.Add(st);
            db.SaveChanges();
        }

        public void Update(SalesTerritory st)
        {
            db.Entry(st).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            SalesTerritory st = db.SalesTerritory.Find(id);
            if (st != null)
                db.SalesTerritory.Remove(st);
            db.SaveChanges();
        }
    }
}
