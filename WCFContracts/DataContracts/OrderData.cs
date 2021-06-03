using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFContracts.DataContracts
{
    [DataContract]
    public class OrderData
    {
        [DataMember]
        public byte Status { get; set; }
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public virtual List<CartLine> OrderProducts { get; set; }
        [DataMember]
        public int TerritoryID { get; set; }
    }
}
