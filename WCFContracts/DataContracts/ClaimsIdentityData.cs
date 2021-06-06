using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WCFContracts.DataContracts
{
    [DataContract]
    public class ClaimsIdentityData : ClaimsIdentity
    {
        [DataMember]
        public ClaimsIdentity test;
        public ClaimsIdentityData(ClaimsIdentity check)
        {
            test = check;
        }
    }
}
