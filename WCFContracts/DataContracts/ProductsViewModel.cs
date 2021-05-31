using DBs.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFContracts.DataContracts
{
    [DataContract]
    public class ProductsViewModel
    {
        [DataMember]
        public IEnumerable<ProductData> Products { get; set; }
        [DataMember]
        public PageInfo PageInfo { get; set; }
    }
}