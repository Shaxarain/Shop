using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFContracts.DataContracts
{
    [DataContract]
    public class CartLine
    {
        [DataMember]
        public ProductData Product { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
