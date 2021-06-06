using DBs.DB;
using Funcs.Interfaces;
using Shop.Funcs.EF;
using Shop.Funcs.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcs.Repositories
{
    public class ClientManagerRepository : IClientManager
    {
        public ApplicationContext Database = new ApplicationContext("DataBase");
        public ClientManagerRepository()
        {
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            try
            {
                Database.SaveChanges();
            }
            catch 
            {
                Database.SaveChanges();
            }
        }

        public List<ClientProfile> GetAll()
        {
            return Database.ClientProfiles.ToList();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
