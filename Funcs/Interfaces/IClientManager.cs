using DBs.DB;
using Shop.Funcs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcs.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
        List<ClientProfile> GetAll();
    }
}
