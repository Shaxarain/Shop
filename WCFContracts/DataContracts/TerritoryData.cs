using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFContracts.DataContracts
{
    [DataContract]
    class TerritoryData
    {
        [DataMember]
        public int TerritoryID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CountryRegionCode { get; set; }
        [DataMember]
        public string Group { get; set; }
    }
}
