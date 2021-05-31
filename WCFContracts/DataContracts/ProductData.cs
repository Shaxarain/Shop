using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DBs.DB;

namespace WCFContracts.DataContracts
{
    [DataContract]
    public class ProductData
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public decimal StandardCost { get; set; }
        [DataMember]
        public string Size { get; set; }
        [DataMember]
        public decimal? Weight { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string Style { get; set; }
        [DataMember]
        public int? ProductSubcategoryID { get; set; }
        [DataMember]
        public Guid rowguid { get; set; }
        [DataMember]
        public byte[] LargePhoto { get; set; }
        [DataMember]
        public byte[] ThumbNailPhoto { get; set; }
        public ProductData(Product product)
        {
            this.ProductID = product.ProductID;
            this.Name = product.Name;
            this.Color = product.Color;
            this.StandardCost = product.StandardCost;
            this.Size = product.Size;
            this.Weight = product.Weight;
            this.Class = product.Class;
            this.Style = product.Style;
            this.ProductSubcategoryID = product.ProductSubcategoryID;
            this.rowguid = product.rowguid;
            this.LargePhoto = product.ProductProductPhoto.First().ProductPhoto.LargePhoto;
            this.ThumbNailPhoto = product.ProductProductPhoto.First().ProductPhoto.ThumbNailPhoto;
        }
    }
}
