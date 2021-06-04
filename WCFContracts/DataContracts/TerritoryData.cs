using DBs.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFContracts.DataContracts
{
    [DataContract]
    public class TerritoryData
    {
        [DataMember]
        public int TerritoryID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CountryRegionCode { get; set; }
        [DataMember]
        public string Group { get; set; }
        public TerritoryData(SalesTerritory st) 
        {
            this.TerritoryID = st.TerritoryID;
            this.Name = st.Name;
            this.CountryRegionCode = st.CountryRegionCode;
            this.Group = st.Group;
        }
        public TerritoryData() { }
    }
}
