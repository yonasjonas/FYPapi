using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ProviderModel
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        public string phone { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string weekvalue { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public int businessId { get; set; }

    }

}
