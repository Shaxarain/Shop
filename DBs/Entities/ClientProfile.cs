using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DBs.DB;

namespace Shop.Funcs.Entities
{
    [Table("ClientProfile")]
    public partial class ClientProfile
    {
        [Key] 
        public string Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Address { get; set; }

        public int CustomerID { get; set; }

    }
}