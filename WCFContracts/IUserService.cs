using DBs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFContracts.DataContracts;

namespace WCFContracts
{
    [ServiceContract]
    public interface IUserService : IDisposable
    {
        [OperationContract]
        OperationDetails Create(UserData userDto);
        [OperationContract]
        ClaimsIdentityData Authenticate(UserData userDto);
        [OperationContract]
        void SetInitialData(UserData adminDto, List<string> roles);
    }
}
