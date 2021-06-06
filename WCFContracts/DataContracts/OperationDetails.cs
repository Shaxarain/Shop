using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DBs.Infrastructure
{
    [DataContract]
    public class OperationDetails
    {
        [DataMember]
        public bool Succedeed { get; private set; }
        [DataMember]
        public string Message { get; private set; }
        [DataMember]
        public string Property { get; private set; }
        public OperationDetails(bool succedeed, string message, string prop)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
        }
    }
}
